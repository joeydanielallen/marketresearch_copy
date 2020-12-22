using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202004090709, TransactionBehavior.None)]
	public class M202004090709_CreateUserAccount : Migration
	{
		public override void Up()
		{
			Create.Table("UserAccount")
				.WithColumn("UserAccountId").AsInt32().PrimaryKey().Identity()
				.WithColumn("AppKey").AsString(128).Nullable().Unique()
				.WithColumn("Email").AsString(128)
				.WithColumn("ExpiresOnUtc").AsDateTime().NotNullable()
				.WithColumn("IsLockedOut").AsBoolean().WithDefaultValue(false).NotNullable()
				.WithColumn("UserName").AsString(64).Nullable().Unique()
				.WithColumn("PasswordHash").AsString(256).Nullable()
				.WithColumn("FirstName").AsString(128)
				.WithColumn("LastName").AsString(128)
				.WithColumn("ModifiedOnUtc").AsDateTime().NotNullable().WithDefaultValue("getutcdate()");
		}

		public override void Down()
		{
			Delete.Table("UserAccount");
		}
	}
}
