using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007061619, TransactionBehavior.None)]
	public class M202007061619_CreateTemplateInitiateVendor : Migration
	{
		private string _tableName = "TemplateInitiateVendor";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("TemplateInstanceId").AsInt32().NotNullable().ForeignKey("TemplateInstance", "Id")
				.WithColumn("VendorName").AsString(2048).NotNullable()
				.WithColumn("VendorCageCode").AsString(5).NotNullable()
				.WithColumn("PartNumber").AsString(1024).Nullable();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
