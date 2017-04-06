using System.Web.Mvc;

namespace MyCMS.Model.AdminModel
{
    public class EditCommentModel
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Body { get; set; }
    }
}