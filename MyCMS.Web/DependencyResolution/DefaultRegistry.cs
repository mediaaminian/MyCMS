

using System.Data.Entity;
using System.Security.Principal;
using System.Web;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web;
using MyCMS.Datalayer.Context;
using MyCMS.Web.MyCMSMembership;
using Castle.DynamicProxy;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Servicelayer.EFServices;
using MyCMS.Web.Caching;
using MyCMS.Web.Email;
using MyCMS.Web.Infrastructure;

namespace MyCMS.Web.DependencyResolution
{

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {

            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            For<HttpContextBase>()
                .HybridHttpOrThreadLocalScoped()
                .Use(() => new HttpContextWrapper(HttpContext.Current));

            For<IIdentity>().Use(() => (HttpContext.Current != null && HttpContext.Current.User != null) ? HttpContext.Current.User.Identity : null);

            For<IUnitOfWork>()
                .HybridHttpOrThreadLocalScoped()
                .Use<MyCMSDbContext>();
            // Remove these 2 lines if you want to use a connection string named connectionString1, defined in the web.config file.
            //.Ctor<string>("connectionString")
            //.Is("Data Source=(local);Initial Catalog=TestDbIdentity;Integrated Security = true");

            For<MyCMSDbContext>().HybridHttpOrThreadLocalScoped()
               .Use(context => (MyCMSDbContext)context.GetInstance<IUnitOfWork>());
            For<DbContext>().HybridHttpOrThreadLocalScoped()
               .Use(context => (MyCMSDbContext)context.GetInstance<IUnitOfWork>());

            #region RegisterDynamicProxy

            For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));

            For<IPrincipalService>().Use<MyCMSSupportPrincipalService>();
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();

            var dynamicProxy = new ProxyGenerator();

            For<IUnitOfWork>().HttpContextScoped().Use<MyCMSDbContext>();
            For<IUserService>().Use<UserService>();

            For<IRoleService>().Use<RoleService>();

            For<ICurrencyService>().Use<CurrencyService>();
            For<ISliderService>().Use<SliderService>();

            For<IPostService>().Use<PostService>();

            For<IBookService>().Use<BookService>();

            For<ILabelService>().Use<LabelService>();

            For<IDownloadLinkService>().Use<DownloadLinkService>();

            For<ICommentService>().Use<CommentService>();

            For<IAnonymousUser>().Use<AnounymousUserService>();

            For<IPageService>().Use<PageService>();

            For<IOptionService>().Use<OptionService>();

            For<IPageService>().Use<PageService>();

            For<ICategoryService>().Use<CategoryService>();

            For<IArticleService>().Use<ArticleService>();

            For<IForgottenPasswordService>().Use<ForgottenPasswordService>();

            For<IMessageService>().Use<MessageService>();

            For<ICacheService>().Use<CacheService>();
            For<IEmailService>().Use<EmailService>();
            For<IViewConvertor>().Use<ViewConvertor>();

            For<IPropertyGroupService>().Use<PropertyGroupService>();

            For<IPropertyService>().Use<PropertyService>();

            For<ITimeFrameService>().Use<TimeFrameService>();

            For<IProductPropertyService>().Use<ProductPropertyService>();

            For<IProductService>().Use<ProductService>();

            For<IProductTypeGroupService>().Use<ProductTypeGroupService>();

            For<IProductTypeGroupTimeFrameService>().Use<ProductTypeGroupTimeFrameService>();

            For<IProductTypeService>().Use<ProductTypeService>();
            #endregion RegisterDynamicProxy
        }

        #endregion
    }
}