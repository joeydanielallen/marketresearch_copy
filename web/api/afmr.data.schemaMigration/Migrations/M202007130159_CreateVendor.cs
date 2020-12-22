using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007130159, TransactionBehavior.None)]
	public class M202007130159_CreateVendor : Migration
	{
		private string _tableName = "Vendor";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(1024).NotNullable()
				.WithColumn("CAGECode").AsString(5).Nullable()
				.WithColumn("DUNSId").AsString(32).Nullable()
				.WithColumn("SetAsideId").AsInt32().Nullable().ForeignKey("SetAside", "Id")
				.WithColumn("AddressLine1").AsString(128).Nullable()
				.WithColumn("AddressLine2").AsString(128).Nullable()
				.WithColumn("City").AsString(128).Nullable()
				.WithColumn("StateAbbreviation").AsString(2).Nullable()
				.WithColumn("PostalCode").AsString(10).Nullable()
				.WithColumn("Capability").AsString(int.MaxValue).Nullable()
				.WithColumn("PastPerformance").AsString(int.MaxValue).Nullable();

			Create.Table("VendorContact")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("VendorId").AsInt32().NotNullable().ForeignKey("Vendor", "Id")
				.WithColumn("Name").AsString(128).NotNullable()
				.WithColumn("Phone").AsString(10).Nullable()
				.WithColumn("Email").AsString(128).Nullable()
				.WithColumn("AddressLine1").AsString(128).Nullable()
				.WithColumn("AddressLine2").AsString(128).Nullable()
				.WithColumn("City").AsString(128).Nullable()
				.WithColumn("StateAbbreviation").AsString(2).Nullable()
				.WithColumn("PostalCode").AsString(10).Nullable();

			Create.Table("VendorPart")
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("VendorId").AsInt32().NotNullable().ForeignKey("Vendor", "Id")
				.WithColumn("PartNumber").AsString(128).NotNullable()
				.WithColumn("Nsn").AsString(15).Nullable()
				.WithColumn("Description").AsString(int.MaxValue).Nullable();
		}

		public override void Down()
		{
			Delete.Table("VendorPart");
			Delete.Table("VendorContact");
			Delete.Table(_tableName);
		}
	}
}
