using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006161751, TransactionBehavior.None)]
	public class M202006161751_CreateTemplateServiceType : Migration
	{
		private string _tableName = "TemplateServiceType";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("TemplateId").AsInt32().NotNullable().ForeignKey("Template", "Id")
				.WithColumn("ServiceTypeId").AsInt32().NotNullable().ForeignKey("ServiceType", "Id");

			Create.UniqueConstraint("UC_Template_ServiceType").OnTable(_tableName).Columns("TemplateId", "ServiceTypeId");
		}

		public override void Down()
		{
			Delete.UniqueConstraint("UC_Template_ServiceType").FromTable(_tableName);
			Delete.Table(_tableName);
		}
	}
}
