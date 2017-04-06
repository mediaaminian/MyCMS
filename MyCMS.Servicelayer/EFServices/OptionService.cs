using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses.Entities;
using MyCMS.Model;
using MyCMS.Model.AdminModel;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;

namespace MyCMS.Servicelayer.EFServices
{
    public class OptionService : IOptionService
    {
        private readonly IDbSet<Option> _options;

        public OptionService(IUnitOfWork uow)
        {
            _options = uow.Set<Option>();
        }

        public void Update(UpdateOptionModel model)
        {
            List<Option> options = _options.ToList();
            options.Where(op => op.Name.Equals("SiteUrl")).FirstOrDefault().Value = model.SiteUrl;
            options.Where(op => op.Name.Equals("BlogName")).FirstOrDefault().Value = model.BlogName;
            options.Where(op => op.Name.Equals("BlogKeywords")).FirstOrDefault().Value = model.BlogKeywords;
            options.Where(op => op.Name.Equals("BlogDescription")).FirstOrDefault().Value = model.BlogDescription;
            options.Where(op => op.Name.Equals("UsersCanRegister")).FirstOrDefault().Value = model.UsersCanRegister.ToString();
            options.Where(op => op.Name.Equals("AdminEmail")).FirstOrDefault().Value = model.AdminEmail;
            options.Where(op => op.Name.Equals("CommentsNotify")).FirstOrDefault().Value = Convert.ToString(model.CommentsNotify);
            options.Where(op => op.Name.Equals("MailServerUrl")).FirstOrDefault().Value = model.MailServerUrl;
            options.Where(op => op.Name.Equals("MailServerLogin")).FirstOrDefault().Value = model.MailServerLogin;
            options.Where(op => op.Name.Equals("MailServerPass")).FirstOrDefault().Value = model.MailServerPass;
            options.Where(op => op.Name.Equals("MailServerPort")).FirstOrDefault().Value = model.MailServerPort.ToString();
            options.Where(op => op.Name.Equals("CommentModeratingStatus")).FirstOrDefault().Value = model.CommentModeratingStatus.ToString();
            options.Where(op => op.Name.Equals("PostPerPage")).FirstOrDefault().Value = model.PostPerPage.ToString();
            options.Where(op => op.Name.Equals("CustomSourcePercent")).FirstOrDefault().Value = model.CustomSourcePercent.ToString();
            options.Where(op => op.Name.Equals("VATPercent")).FirstOrDefault().Value = model.VATPercent.ToString();
            options.Where(op => op.Name.Equals("AboutDescription")).FirstOrDefault().Value = model.AboutDescription;
            options.Where(op => op.Name.Equals("CompanyAddress")).FirstOrDefault().Value = model.CompanyAddress;
            options.Where(op => op.Name.Equals("Phone")).FirstOrDefault().Value = model.Phone;
            options.Where(op => op.Name.Equals("Fax")).FirstOrDefault().Value = model.Fax;
            options.Where(op => op.Name.Equals("eMail")).FirstOrDefault().Value = model.eMail;
            options.Where(op => op.Name.Equals("Facebook")).FirstOrDefault().Value = model.Facebook;
            options.Where(op => op.Name.Equals("Linkedin")).FirstOrDefault().Value = model.Linkedin;
            options.Where(op => op.Name.Equals("GooglePlus")).FirstOrDefault().Value = model.GooglePlus;
            options.Where(op => op.Name.Equals("Telegram")).FirstOrDefault().Value = model.Telegram;
        }

        [CacheMethod(SecondsToCache = 20)]
        public SiteConfig GetAll()
        {
            List<Option> options = _options.ToList();
            var model = new SiteConfig
            {
                AdminEmail = options.Where(op => op.Name.Equals("AdminEmail")).FirstOrDefault().Value,
                BlogDescription = options.Where(op => op.Name.Equals("BlogDescription")).FirstOrDefault().Value,
                BlogKeywords = options.Where(op => op.Name.Equals("BlogKeywords")).FirstOrDefault().Value,
                BlogName = options.Where(op => op.Name.Equals("BlogName")).FirstOrDefault().Value,
                CommentsNotify =
                    Convert.ToBoolean(options.Where(op => op.Name.Equals("CommentsNotify")).FirstOrDefault().Value),
                CommentModeratingStatus =
                    Convert.ToBoolean(options.Where(op => op.Name.Equals("CommentModeratingStatus"))
                        .FirstOrDefault().Value),
                MailServerLogin = options.Where(op => op.Name.Equals("MailServerLogin")).FirstOrDefault().Value,
                MailServerPass = options.Where(op => op.Name.Equals("MailServerPass")).FirstOrDefault().Value,
                MailServerPort =
                    Convert.ToInt32(options.Where(op => op.Name.Equals("MailServerPort")).FirstOrDefault().Value),
                MailServerUrl = options.Where(op => op.Name.Equals("MailServerUrl")).FirstOrDefault().Value,
                PostPerPage =
                    Convert.ToInt32(options.Where(op => op.Name.Equals("PostPerPage")).FirstOrDefault().Value),
                SiteUrl = options.Where(op => op.Name.Equals("SiteUrl")).FirstOrDefault().Value,
                UsersCanRegister = Convert.ToBoolean(options.Where(op => op.Name.Equals("UsersCanRegister"))
                    .FirstOrDefault().Value),
                CustomSourcePercent =
                    Convert.ToDecimal(!string.IsNullOrEmpty(options.Where(op => op.Name.Equals("CustomSourcePercent")).FirstOrDefault()?.Value) ? options.Where(op => op.Name.Equals("CustomSourcePercent")).FirstOrDefault()?.Value:"9"),
                VATPercent =
                    Convert.ToDecimal(!string.IsNullOrEmpty(options.Where(op => op.Name.Equals("VATPercent")).FirstOrDefault()?.Value) ? options.Where(op => op.Name.Equals("VATPercent")).FirstOrDefault()?.Value:"5"),
                AboutDescription = options.Where(op => op.Name.Equals("AboutDescription")).FirstOrDefault()?.Value,
                CompanyAddress = options.Where(op => op.Name.Equals("CompanyAddress")).FirstOrDefault()?.Value,
                Phone = options.Where(op => op.Name.Equals("Phone")).FirstOrDefault()?.Value,
                Fax = options.Where(op => op.Name.Equals("Fax")).FirstOrDefault()?.Value,
                eMail = options.Where(op => op.Name.Equals("eMail")).FirstOrDefault()?.Value,
                Facebook = options.Where(op => op.Name.Equals("Facebook")).FirstOrDefault()?.Value,
                Linkedin = options.Where(op => op.Name.Equals("Linkedin")).FirstOrDefault()?.Value,
                GooglePlus = options.Where(op => op.Name.Equals("GooglePlus")).FirstOrDefault()?.Value,
                Telegram = options.Where(op => op.Name.Equals("Telegram")).FirstOrDefault()?.Value
                
            };
            return model;
        }


        public bool ModeratingComment
        {
            get
            {
                return Convert.ToBoolean(_options.Where(option => option.Name == "CommentModeratingStatus")
                    .FirstOrDefault().Value);
            }
        }
    }
}