using System.Web.Mvc;

namespace MyCMS.Model.AdminModel
{
    public class UpdateOptionModel
    {
        public string SiteUrl { get; set; }
        public string BlogName { get; set; }
        public string BlogKeywords { get; set; }
        public string BlogDescription { get; set; }
        public decimal CustomSourcePercent { get; set; }
        public decimal VATPercent { get; set; }
        [AllowHtml]
        public string AboutDescription { get; set; }
        [AllowHtml]
        public string CompanyAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string eMail { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string GooglePlus { get; set; }
        public string Telegram { get; set; }
        public bool UsersCanRegister { get; set; }
        public string AdminEmail { get; set; }
        public bool CommentsNotify { get; set; }
        public string MailServerUrl { get; set; }
        public string MailServerLogin { get; set; }
        public string MailServerPass { get; set; }
        public int? MailServerPort { get; set; }
        public bool CommentModeratingStatus { get; set; }
        public int PostPerPage { get; set; }
    }
}