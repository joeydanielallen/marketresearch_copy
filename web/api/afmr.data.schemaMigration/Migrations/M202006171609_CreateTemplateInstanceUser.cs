using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006171609, TransactionBehavior.None)]
	public class M202006171609_CreateTemplateInstanceUser : Migration
	{
		private string _tableName = "TemplateInstanceUser";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("TemplateInstanceId").AsInt32().NotNullable().ForeignKey("TemplateInstance", "Id")
				.WithColumn("UserAccountId").AsInt32().NotNullable().ForeignKey("UserAccount", "UserAccountId");

			Create.UniqueConstraint("UC_TemplateInstance_UserAccount").OnTable(_tableName).Columns("TemplateInstanceId", "UserAccountId");
		}

		public override void Down()
		{
			Delete.UniqueConstraint("UC_TemplateInstance_UserAccount").FromTable(_tableName);
			Delete.Table(_tableName);
		}
	}
}
