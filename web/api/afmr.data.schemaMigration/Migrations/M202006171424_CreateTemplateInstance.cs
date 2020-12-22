using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006171424, TransactionBehavior.None)]
	public class M202006171424_CreateTemplateInstance : Migration
	{
		private string _tableName = "TemplateInstance";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(128).NotNullable()
				.WithColumn("CreatedByUserAccountId").AsInt32().NotNullable().ForeignKey("UserAccount", "UserAccountId")
				.WithColumn("TemplateId").AsInt32().NotNullable().ForeignKey("Template", "Id")
				.WithColumn("OriginalTemplateName").AsString(128).NotNullable()
				.WithColumn("OrgId").AsInt32().NotNullable().ForeignKey("Org", "Id")
				.WithColumn("BidTypeId").AsInt32().NotNullable().ForeignKey("BidType", "Id")
				.WithColumn("SourceTypeId").AsInt32().NotNullable().ForeignKey("SourceType", "Id")
				.WithColumn("ServiceTypeId").AsInt32().NotNullable().ForeignKey("ServiceType", "Id")
				.WithColumn("PurchaseRequestProcessingSystemId").AsString(64)
				.WithColumn("Nsn").AsString(16).NotNullable()
				.WithColumn("ItemQuantity").AsInt32().NotNullable().WithDefaultValue(0)
				.WithColumn("ItemEstimatedValue").AsDecimal(11, 2).NotNullable().WithDefaultValue(0M)
				.WithColumn("CreatedOnUtc").AsDateTime().NotNullable()
				.WithColumn("CompletedOnUtc").AsDateTime().Nullable();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
