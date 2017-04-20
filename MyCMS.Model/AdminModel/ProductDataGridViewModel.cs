using AutoMapper;
using MyCMS.Abstraction;
using MyCMS.DomainClasses.Entities;
using MyCMS.Utilities;
//using MyCMS.Model.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
    public class ProductDataGridViewModel : IHaveCustomMappings
    {
        [Localized("Product.Id")]
        public int Id { get; set; }

        [Localized("Product.Name")]
        public string Name { get; set; }

        [Localized("Product.Status")]
        public System.Byte Status { get; set; }

        [Localized("Product.Status")]
        public String StatusTitle
        {
            get
            {
                try
                {
                    return DataDictionary.ProductStatusItems[Status].Item2;
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        [Localized("Product.TypeName")]
        public string ProductTypeName { get; set; }

        //public int ViewNumber { get; set; }

        public void CreateMappings()
        {
            //ProductMapper.Config();
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDataGridViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<ProductDataGridViewModel, Product>());
        }

        public Product GetDomain(ProductDataGridViewModel viewmodel)
        {
            var result = Mapper.Map<ProductDataGridViewModel, Product>(viewmodel);
            return result;
        }

        public ProductDataGridViewModel GetViewModel(Product domain)
        {
            var result = Mapper.Map<Product, ProductDataGridViewModel>(domain);
            return result;
        }
    }
}
