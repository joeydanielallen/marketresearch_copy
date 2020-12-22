using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007121548, TransactionBehavior.None)]
	public class M202007121548_AddVendorQuestionData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
declare @qId int, @sectionId int

select top 1 @sectionId=Id from Section where Name='III. Vendor Information'

insert into Question select 'Name', '', 1, 2048
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 1

insert into Question select 'CAGE/DUNS', '', 1, 2048
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 2

insert into Question select 'Socioeconomic Status', '', 1, 2048
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 3

insert into Question select 'Location', '', 1, 2048
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 4

insert into Question select 'Point of Contact', '', 1, 2048
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 5

insert into Question select 'Part Number', '', 1, 2048
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 6

insert into Question select 'Capabilites', '', 1, 8192
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 7

insert into Question select 'Past Performance', '', 1, 8192
set @qId = @@IDENTITY
insert into SectionQuestion select @sectionId, @qId, 8";
	}
}
