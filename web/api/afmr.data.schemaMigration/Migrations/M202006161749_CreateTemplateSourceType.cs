using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006161749, TransactionBehavior.None)]
	public class M202006161749_CreateTemplateSourceType : Migration
	{
		private string _tableName = "TemplateSourceType";


		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("TemplateId").AsInt32().NotNullable().ForeignKey("Template", "Id")
				.WithColumn("SourceTypeId").AsInt32().NotNullable().ForeignKey("SourceType", "Id");

			Create.UniqueConstraint("UC_Template_SourceType").OnTable(_tableName).Columns("TemplateId", "SourceTypeId");
		}

		public override void Down()
		{
			Delete.UniqueConstraint("UC_Template_SourceType").FromTable(_tableName);
			Delete.Table(_tableName);
		}
	}
}
