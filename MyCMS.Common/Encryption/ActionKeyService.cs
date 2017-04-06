using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Utilities.Encryption
{
    public class ActionKeyService
    {

        #region [ Field ]

        private static readonly IList<ActionKey> ActionKeys; 
        
        #endregion

        #region [ Method ]

        static ActionKeyService()
        {
            ActionKeys = new List<ActionKey>();
        }
        public string GetActionKey(string action, string controller, string area = "")
        {
            area = area ?? "";
            var actionKey = ActionKeys.FirstOrDefault(a =>
                a.Action.ToLower() == action.ToLower() &&
                a.Controller.ToLower() == controller.ToLower() &&
                a.Area.ToLower() == area.ToLower());
            return actionKey != null ? actionKey.ActionKeyValue : AddActionKey(action, controller, area);
        }
        private string AddActionKey(string action, string controller, string area = "")
        {
            var actionKey = new ActionKey
            {
                Action = action,
                Controller = controller,
                Area = area,
                ActionKeyValue = Guid.NewGuid().ToString()
            };
            ActionKeys.Add(actionKey);
            return actionKey.ActionKeyValue;
        }
        
        #endregion

    }
}
