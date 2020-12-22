using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007232116, TransactionBehavior.None)]
	public class M202007232116_CreateSystemControlType : Migration
	{
		private string _tableName = "SystemControlType";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
				.WithColumn("Name").AsString(64).NotNullable()
				.WithColumn("Description").AsString(128).Nullable();

			Alter.Table("Section").AddColumn("CanDelete").AsBoolean().NotNullable().WithDefaultValue(true);

			Alter.Table("Section").AddColumn("SystemControlTypeId").AsInt32().Nullable().ForeignKey(_tableName, "Id");
		}

		public override void Down()
		{
			Delete.Column("SystemControlTypeId").FromTable("Section");
			Delete.Column("CanDelete").FromTable("Section");
			Delete.Table(_tableName);
		}
	}
}
