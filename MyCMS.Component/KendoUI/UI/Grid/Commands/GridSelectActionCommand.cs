namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;

    using Kendo.Mvc.UI.Html;
    using MyCMS.Component.KendoUI.Resources;

    public class GridSelectActionCommand : GridActionCommandBase
    {
        public GridSelectActionCommand()
        {
            Text = Messages.Grid_Select;
        }

        public override string Name
        {
            get { return "select"; }
        }

        public override IEnumerable<IGridButtonBuilder> CreateDisplayButtons(IGridUrlBuilder urlBuilder, IGridHtmlHelper htmlHelper)
        {
            var button = CreateButton<GridLinkButtonBuilder>(Text, UIPrimitives.Grid.Select);
            
            button.SpriteCssClass = "k-select";
            button.Url = urlBuilder.SelectUrl;

            return new[] { button };
        }
    }
}
