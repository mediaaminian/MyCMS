using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.EFServices.Enums;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using AutoMapper;
using MyCMS.Model;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
//using JqGridHelper.Models;
//using JqGridHelper.DynamicSearch;
using System.Collections.Specialized;
using MyCMS.Utilities.DynamicLinq;
using EFSecondLevelCache;

namespace MyCMS.Servicelayer.EFServices
{
    public class ProductService : IProductService
    {

        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Product> _Product;

        public ProductService(IUnitOfWork uow,IMappingEngine mappingEngine)
        {
            _unitOfWork = uow;
            _Product = uow.Set<Product>();
            _mappingEngine = mappingEngine;
        }

        //public async Task<DataGridViewModel<ProductDataGridViewModel>> GetDataGridSource(string orderBy, JqGridRequest request, NameValueCollection form, DateTimeType dateTimeType, int page, int pageSize)
        //{
        //    var usersQuery = _Product.AsQueryable();

        //    var query = new JqGridSearch(request, form, dateTimeType).ApplyFilter(usersQuery);

        //    var dataGridModel = new DataGridViewModel<ProductDataGridViewModel>
        //    {
        //        Records = await query.AsQueryable().OrderBy(orderBy)
        //            .Skip(page * pageSize)
        //            .Take(pageSize).ProjectTo<ProductDataGridViewModel>(null, _mappingEngine).ToListAsync(),

        //        TotalCount = await query.AsQueryable().OrderBy(orderBy).CountAsync()
        //    };
        //    return dataGridModel;
        //}

        public IList<T> UpdateOneToManyRelation<T>(List<T> updatedList, List<T> existingList) where T : BaseEntity
        {
            var addedEntities = updatedList.Where(x => existingList.All(item => item.Id != x.Id)).ToList();

            var deletedEntities = existingList.Where(x => updatedList.All(item => item.Id != x.Id)).ToList();

            var modifiedEntities = updatedList.Where(x => addedEntities.All(item => item.Id != x.Id)).ToList();

            addedEntities.ForEach(entity => _unitOfWork.MarkAsAdded(entity));

            deletedEntities.ForEach(entity => _unitOfWork.MarkAsDeleted(entity));

            foreach (var entity in modifiedEntities)
            {
                var existingEntity = _unitOfWork.Set<T>().Find(entity.Id);

                if (existingEntity != null)
                {
                    var entityEntry = _unitOfWork.Entry(existingEntity);
                    entityEntry.CurrentValues.SetValues(entity);
                }

            }
            return deletedEntities;
        }
        public async Task<ProductViewModel> GetProductForEdit(int productId)
        {
            return await _Product.Where(p => p.Id == productId)
                .ProjectTo<ProductViewModel>(parameters: null, mappingEngine: _mappingEngine).SingleOrDefaultAsync();
        }

        public void DeleteProductWithState(int productId)
        {
            var entity = new Product() { Id = productId };
            _unitOfWork.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<IList<ProductViewModel>> GetNewestProducts(int count)
        {
            return await _Product.AsNoTracking().OrderBy(product => product.Status).ThenByDescending(product => product.CreatedDate)
                .Take(count)
                             .ProjectTo<ProductViewModel>(parameters: null, mappingEngine: _mappingEngine)
                                .Cacheable().ToListAsync();
        }

        public void AddProduct(ProductModel ProductModel)
        {
            var ProductItem = _mappingEngine.Map<Product>(ProductModel);
            _Product.Add(ProductItem);
        }
        [CacheMethod]

        public IList<ProductModel> GetAllProducts()
        {
            var List = _Product.AsNoTracking().OrderByDescending(c => c.Id).ToList();
            var ModelList = _mappingEngine.Map<IEnumerable<ProductModel>>(List);
            return ModelList.ToList();

        }


        public IList<ProductModel> GetProduct(int page, int count, Order order = Order.Asscending)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int ProductID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductModel ProductModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductModel, Product>());

            var ProductItem = Mapper.Map<Product>(ProductModel);


            _Product.Attach(ProductItem);

        }

        public void DeleteProduct(int ProductID)
        {
            _Product.Remove(_Product.Find(ProductID));
        }
    }
}