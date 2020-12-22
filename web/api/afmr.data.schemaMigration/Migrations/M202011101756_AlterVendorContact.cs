using FluentMigrator;
using Microsoft.VisualBasic;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202011101756, TransactionBehavior.None)]
	public class M202011101756_AlterVendorContact : Migration
	{
		private string tableName = "VendorContact";

		public override void Up()
		{
			Alter.Table(tableName).AddColumn("SavedByUserAccountId").AsInt32().Nullable().ForeignKey("UserAccount", "UserAccountId");
			Alter.Table(tableName).AddColumn("SavedOnUtc").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);
		}

		public override void Down()
		{
			Delete.Column("SavedByUserAccountId").FromTable(tableName);
			Delete.Column("SavedOnUtc").FromTable(tableName);
		}
	}
}
