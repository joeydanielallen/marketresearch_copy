using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006161759, TransactionBehavior.None)]
	public class M202006161759_CreateTemplateOrg : Migration
	{
		private string _tableName = "TemplateOrg";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("TemplateId").AsInt32().NotNullable().ForeignKey("Template", "Id")
				.WithColumn("OrgId").AsInt32().NotNullable().ForeignKey("Org", "Id");

			Create.UniqueConstraint("UC_Template_Org").OnTable(_tableName).Columns("TemplateId", "OrgId");
		}

		public override void Down()
		{
			Delete.UniqueConstraint("UC_Template_Org").FromTable(_tableName);
			Delete.Table(_tableName);
		}
	}
}
