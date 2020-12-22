using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007310435, TransactionBehavior.None)]
	public class M202007310435_AlterUserAccountIsActive : Migration
	{
		public override void Up()
		{
			Alter.Table("UserAccount").AddColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
		}

		public override void Down()
		{
			Delete.Column("IsActive").FromTable("UserAccount");
		}
	}
}
