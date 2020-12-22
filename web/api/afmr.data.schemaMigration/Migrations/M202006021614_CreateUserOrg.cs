using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006021614, TransactionBehavior.None)]
	public class M202006021614_CreateUserOrg : Migration
	{
		public override void Up()
		{
			Create.Table("UserOrg")
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("UserAccountId").AsInt32().NotNullable().ForeignKey("UserAccount", "UserAccountId")
				.WithColumn("OrgId").AsInt32().NotNullable().ForeignKey("Org", "Id");
		}

		public override void Down()
		{
			Delete.Table("UserOrg");
		}
	}
}
