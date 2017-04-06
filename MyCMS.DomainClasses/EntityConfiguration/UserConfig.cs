﻿using System.Data.Entity.ModelConfiguration;
using MyCMS.DomainClasses.Entities;

namespace MyCMS.DomainClasses.EntityConfiguration
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasOptional(x => x.UserMetaData).WithRequired(x => x.User).WillCascadeOnDelete(false);
            HasMany(user => user.Posts).WithRequired(post => post.User).WillCascadeOnDelete(false);


            //this.HasMany(user => user.Pages).WithRequired(page => page.User);
            Property(x => x.UserName).HasMaxLength(20).IsRequired();
            Property(x => x.Password).HasMaxLength(200).IsRequired();
            Property(x => x.Email).HasMaxLength(100).IsRequired();
            Property(x => x.IP).HasMaxLength(20).IsOptional();
        }
    }
}