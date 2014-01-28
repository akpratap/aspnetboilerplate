﻿using FluentMigrator;

namespace Abp.Modules.Core.Data.Migrations.V20130824
{
    [Migration(2013082402)]
    public class _02_CreateAbpUsersTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("AbpUsers")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("AbpTenants", "Id")
                .WithColumn("UserName").AsString(32).NotNullable()
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("Surname").AsString(30).NotNullable()
                .WithColumn("EmailAddress").AsString(100).NotNullable()
                .WithColumn("Password").AsString(80).NotNullable()
                .WithColumn("ProfileImage").AsString(100).Nullable()
                .WithColumn("IsTenantOwner").AsBoolean().NotNullable().WithDefaultValue(false);

            Insert.IntoTable("AbpUsers").Row(
                new
                    {
                        TenantId = 1,
                        Name = "Halil İbrahim",
                        Surname = "Kalkan",
                        EmailAddress = "hi_kalkan@yahoo.com",
                        Password = "123"
                    }
                );

            Create.Index("AbpUsers_UserName")
                .OnTable("AbpUsers")
                .OnColumn("UserName")
                .Ascending()
                .WithOptions().Unique()
                .WithOptions().NonClustered();

            Create.Index("AbpUsers_EmailAddress")
                .OnTable("AbpUsers")
                .OnColumn("EmailAddress")
                .Ascending()
                .WithOptions().Unique()
                .WithOptions().NonClustered();
        }
    }
}
