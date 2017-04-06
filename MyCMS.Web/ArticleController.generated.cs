// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace MyCMS.Web.Controllers
{
    public partial class ArticleController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ArticleController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Index()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Like()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Like);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DisLike()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DisLike);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UserArticles()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserArticles);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UserArticlesList()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserArticlesList);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ArticleController Actions { get { return MVC.Article; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Article";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Article";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Like = "Like";
            public readonly string DisLike = "DisLike";
            public readonly string UserArticles = "UserArticles";
            public readonly string UserArticlesList = "UserArticlesList";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Like = "Like";
            public const string DisLike = "DisLike";
            public const string UserArticles = "UserArticles";
            public const string UserArticlesList = "UserArticlesList";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Like s_params_Like = new ActionParamsClass_Like();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Like LikeParams { get { return s_params_Like; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Like
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DisLike s_params_DisLike = new ActionParamsClass_DisLike();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DisLike DisLikeParams { get { return s_params_DisLike; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DisLike
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_UserArticles s_params_UserArticles = new ActionParamsClass_UserArticles();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UserArticles UserArticlesParams { get { return s_params_UserArticles; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UserArticles
        {
            public readonly string userName = "userName";
            public readonly string page = "page";
            public readonly string count = "count";
        }
        static readonly ActionParamsClass_UserArticlesList s_params_UserArticlesList = new ActionParamsClass_UserArticlesList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UserArticlesList UserArticlesListParams { get { return s_params_UserArticlesList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UserArticlesList
        {
            public readonly string userName = "userName";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _UserArticles = "_UserArticles";
                public readonly string Index = "Index";
                public readonly string UserArticlesList = "UserArticlesList";
            }
            public readonly string _UserArticles = "~/Views/Article/_UserArticles.cshtml";
            public readonly string Index = "~/Views/Article/Index.cshtml";
            public readonly string UserArticlesList = "~/Views/Article/UserArticlesList.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ArticleController : MyCMS.Web.Controllers.ArticleController
    {
        public T4MVC_ArticleController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            IndexOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void LikeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Like(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Like);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            LikeOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DisLikeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult DisLike(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DisLike);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DisLikeOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void UserArticlesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string userName, int page, int count);

        [NonAction]
        public override System.Web.Mvc.ActionResult UserArticles(string userName, int page, int count)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserArticles);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userName", userName);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "page", page);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "count", count);
            UserArticlesOverride(callInfo, userName, page, count);
            return callInfo;
        }

        [NonAction]
        partial void UserArticlesListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string userName);

        [NonAction]
        public override System.Web.Mvc.ActionResult UserArticlesList(string userName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserArticlesList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userName", userName);
            UserArticlesListOverride(callInfo, userName);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
