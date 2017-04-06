﻿using System.Web.Mvc;

namespace MyCMS.Model.AdminModel
{
    public class SendingMailModel
    {
        public string Subject { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public int[] UsersId { get; set; }
        public string[] SendTo { get; set; }
    }
}