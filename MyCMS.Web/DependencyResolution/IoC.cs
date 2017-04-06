// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Web;
using Castle.DynamicProxy;
using MyCMS.Datalayer.Context;
using MyCMS.Servicelayer.EFServices;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using MyCMS.Web.Caching;
using MyCMS.Web.Email;
using MyCMS.Web.Infrastructure;
using MyCMS.Web.MyCMSMembership;
using StructureMap;

namespace MyCMS.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));

                x.For<IPrincipalService>().Use<MyCMSSupportPrincipalService>();
                x.For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();

                var dynamicProxy = new ProxyGenerator();

                x.For<IUnitOfWork>().HttpContextScoped().Use<MyCMSDbContext>();
                x.For<IUserService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<UserService>();

                x.For<IRoleService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<RoleService>();

                x.For<ICurrencyService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<CurrencyService>();
                x.For<ISliderService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<SliderService>();

                x.For<IPostService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PostService>();

                x.For<IBookService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<BookService>();

                x.For<ILabelService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<LabelService>();

                x.For<IDownloadLinkService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<DownloadLinkService>();

                x.For<ICommentService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<CommentService>();

                x.For<IAnonymousUser>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<AnounymousUserService>();

                x.For<IPageService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PageService>();

                x.For<IOptionService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<OptionService>();

                x.For<IPageService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PageService>();

                x.For<ICategoryService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<CategoryService>();

                x.For<IArticleService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ArticleService>();

                x.For<IForgottenPasswordService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ForgottenPasswordService>();

                x.For<IMessageService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<MessageService>();

                x.For<ICacheService>().EnrichAllWith(myTypeInterface =>
                        dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<CacheService>();
                x.For<IEmailService>().EnrichAllWith(myTypeInterface =>
                      dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<EmailService>();
                x.For<IViewConvertor>().EnrichAllWith(myTypeInterface =>
                     dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ViewConvertor>();

                x.For<IPropertyGroupService>().EnrichAllWith(myTypeInterface =>
     dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PropertyGroupService>();
                                x.For<IPropertyGroupService>().EnrichAllWith(myTypeInterface =>
     dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PropertyGroupService>();

                x.For<IPropertyService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PropertyService>();
                x.For<IPropertyService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<PropertyService>();

                x.For<ITimeFrameService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<TimeFrameService>();
                x.For<ITimeFrameService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<TimeFrameService>();

                x.For<IProductPropertyService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductPropertyService>();
                x.For<IProductPropertyService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductPropertyService>();

                x.For<IProductService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductService>();
                x.For<IProductService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductService>();

                x.For<IProductTypeGroupService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductTypeGroupService>();
                x.For<IProductTypeGroupService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductTypeGroupService>();

                x.For<IProductTypeGroupTimeFrameService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductTypeGroupTimeFrameService>();
                x.For<IProductTypeGroupTimeFrameService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductTypeGroupTimeFrameService>();

                x.For<IProductTypeService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductTypeService>();
                x.For<IProductTypeService>().EnrichAllWith(myTypeInterface =>
dynamicProxy.CreateInterfaceProxyWithTarget(myTypeInterface, new CacheInterceptor())).Use<ProductTypeService>();


            });
            return ObjectFactory.Container;
        }
    }
}