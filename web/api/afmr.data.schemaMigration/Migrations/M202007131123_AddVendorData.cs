using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007131123, TransactionBehavior.None)]
	public class M202007131123_AddVendorData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private readonly string sql = @"
  declare @VId int
  insert into Vendor select 'VertiPrime Government Services, LLC', '7VUK2', '080660867', 7, '7576 N Highway 81', 'Ste 25', 'Duncan', 'OK', '73533-3400', 'Capabilities are endless', 'Past performances are stellar'
  set @VId = @@IDENTITY

  insert into VendorContact select @VId, 'Michael Morford', '1234567890', 'michael.morford@vertiprime.com', null, null, null, null, null
  insert into VendorPart select @VId, '', '8505684769', null";
	}
}
