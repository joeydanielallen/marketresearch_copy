using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202010251932, TransactionBehavior.None)]
	public class M202010251932_AlterTemplateInitiateVendor : Migration
	{
		private string tableName = "TemplateInitiateVendor";

		public override void Up()
		{
			Delete.FromTable(tableName).AllRows();

            Delete.Column("PartNumber").FromTable(tableName);
			Alter.Table(tableName).AddColumn("VendorId").AsInt32().Nullable();
			Alter.Table(tableName).AddColumn("SustainmentId").AsString(32).Nullable();
			Alter.Table(tableName).AddColumn("DUNSId").AsString(32).Nullable();
			Alter.Table(tableName).AddColumn("Ranking").AsDecimal(6, 6).Nullable();
		}

		public override void Down()
		{
			Delete.Column("VendorId").FromTable(tableName);
			Delete.Column("SustainmentId").FromTable(tableName);
			Delete.Column("DUNSId").FromTable(tableName);
			Delete.Column("Ranking").FromTable(tableName);
		}
	}
}
