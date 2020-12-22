using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006231947, TransactionBehavior.None)]
	public class M202006231947_AlterTemplateInstanceCreateTemplateUseReason : Migration
	{
		public override void Up()
		{
			Alter.Table("TemplateInstance").AddColumn("UnsuggestedTemplateUseReason").AsString(512).Nullable();
		}

		public override void Down()
		{
			Delete.Column("UnsuggestedTemplateUseReason").FromTable("TemplateInstance");
		}
	}
}
