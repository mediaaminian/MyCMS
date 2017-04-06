using System.Data.Entity.Migrations;
using MyCMS.Datalayer.Context;
using MyCMS.DomainClasses;
using MyCMS.DomainClasses.Entities;
using MyCMS.Utilities.DateAndTime;
using MyCMS.Utilities.Security;

namespace MyCMS.Datalayer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MyCMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyCMSDbContext context)
        {
            context.Roles.AddOrUpdate(x => new { x.Name, x.Description },
                new Role { Name = "admin", Description = "مدیرکل" },
                new Role { Name = "moderator", Description = "مدیر" },
                new Role { Name = "writer", Description = "نویسنده" },
                new Role { Name = "editor", Description = "ویرایشگر" },
                new Role { Name = "user", Description = "کاربر" });

            context.Options.AddOrUpdate(op => new { op.Name, op.Value }, new Option { Name = "SiteUrl", Value = "" },
                new Option { Name = "BlogName", Value = "" }, new Option { Name = "BlogKeywords", Value = "" },
                new Option { Name = "BlogDescription", Value = "" },
                new Option { Name = "UsersCanRegister", Value = "true" }, new Option { Name = "AdminEmail", Value = "" },
                new Option { Name = "CommentsNotify", Value = "true" },
                new Option { Name = "MailServerUrl", Value = "" }, new Option { Name = "MailServerLogin", Value = "" },
                new Option { Name = "MailServerPass", Value = "" },
                new Option { Name = "MailServerPort", Value = "25" },
                new Option { Name = "CustomSourcePercent", Value = "" },
                new Option { Name = "VATPercent", Value = "" },
                new Option { Name = "AboutDescription", Value = "" },
                new Option { Name = "CompanyAddress", Value = "" },
                new Option { Name = "Phone", Value = "" },
                new Option { Name = "Fax", Value = "" },
                new Option { Name = "eMail", Value = "" },
                new Option { Name = "Facebook", Value = "" },
                new Option { Name = "Linkedin", Value = "" },
                new Option { Name = "GooglePlus", Value = "" },
                new Option { Name = "Telegram", Value = "" },
                new Option { Name = "CommentModeratingStatus", Value = "true" },
                new Option { Name = "PostPerPage", Value = "10" });

            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.UserName, new User
            {
                CreatedDate = DateAndTime.GetDateTime(),
                Email = "admin@gmail.com",
                IsBaned = false,
                Password = Encryption.EncryptingPassword("123456"),
                Role = context.Roles.Find(1),
                UserName = "admin",
                UserMetaData = new UserMetaData()
            });
        }
    }
}