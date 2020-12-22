using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006161646, TransactionBehavior.None)]
	public class M202006161646_CreateTemplateBidType : Migration
	{
		private string _tableName = "TemplateBidType";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("TemplateId").AsInt32().NotNullable().ForeignKey("Template", "Id")
				.WithColumn("BidTypeId").AsInt32().NotNullable().ForeignKey("BidType", "Id");

			Create.UniqueConstraint("UC_Template_BidType").OnTable(_tableName).Columns("TemplateId", "BidTypeId");
		}

		public override void Down()
		{
			Delete.UniqueConstraint("UC_Template_BidType").FromTable(_tableName);
			Delete.Table(_tableName);
		}
	}
}
