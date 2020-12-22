using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006020402, TransactionBehavior.None)]
	public class M202006020402_CreateMMAC : Migration
	{
		public override void Up()
		{
			Create.Table("MaterialMgmtAggregateCode")
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("Code").AsString(2).NotNullable().Indexed("IX_MaterialMgmtAggregateCode_Code")
				.WithColumn("IsInventoryControlPoint").AsBoolean().NotNullable().WithDefaultValue(false)
				.WithColumn("ActivityCode").AsString(2)
				.WithColumn("Description").AsString(1024);
		}

		public override void Down()
		{
			Delete.Table("MaterialMgmtAggregateCode");
		}
	}
}
