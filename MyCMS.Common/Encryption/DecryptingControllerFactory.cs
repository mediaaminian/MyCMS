using System;
using System.Linq;
using System.Web.Mvc;

namespace MyCMS.Utilities.Encryption
{
    public class DecryptingControllerFactory : DefaultControllerFactory
    {
        private readonly IEncryptSettingsProvider _settings;

        public DecryptingControllerFactory()
        {
            _settings = new EncryptSettingsProvider();
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            try
            {
                if ((controllerName=="TemplateStatic") || (controllerName=="Template"))
                    return base.CreateController(requestContext, controllerName);

                var parameters = requestContext.HttpContext.Request.Params;
                var encryptedParamKeys = parameters.AllKeys.Where(x => x.StartsWith(_settings.EncryptionPrefix)).ToList();

                IRijndaelStringEncrypter decrypter = null;
                foreach (var key in encryptedParamKeys)
                {
                    if (decrypter == null)
                    {
                        decrypter = GetDecrypter(requestContext);
                    }

                    var oldKey = key.Replace(_settings.EncryptionPrefix, string.Empty);
                    var oldValue = decrypter.Decrypt(parameters[key]);
                    if (requestContext.RouteData.Values[oldKey] != null)
                    {
                        if (requestContext.RouteData.Values[oldKey].ToString() != oldValue)
                            throw new ApplicationException("Form values is modified!");
                    }
                    requestContext.RouteData.Values[oldKey] = oldValue;
                }

                if (decrypter != null)
                {
                    decrypter.Dispose();
                }

            }
            catch 
            {
                
                
            }
            return base.CreateController(requestContext, controllerName);
        }

        private IRijndaelStringEncrypter GetDecrypter(System.Web.Routing.RequestContext requestContext)
        {
            var decrypter = new RijndaelStringEncrypter(_settings, requestContext.GetActionKey());
            return decrypter;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return base.GetControllerInstance(requestContext, controllerType);
        }

        protected override System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var t = base.GetControllerSessionBehavior(requestContext, controllerType);
            return t ;
        }

        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return base.GetControllerType(requestContext, controllerName);
        }

        public override void ReleaseController(IController controller)
        {
            base.ReleaseController(controller);
        }
    }
}