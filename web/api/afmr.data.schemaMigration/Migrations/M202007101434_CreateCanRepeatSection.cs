using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007101434, TransactionBehavior.None)]
	public class M202007101434_CreateCanRepeatSection : Migration
	{
		public override void Up()
		{
			Alter.Table("Section").AddColumn("CanRepeat").AsBoolean().NotNullable().WithDefaultValue(0);
		}

		public override void Down()
		{
			Delete.Column("CanRepeat").FromTable("Section");
		}
	}
}
