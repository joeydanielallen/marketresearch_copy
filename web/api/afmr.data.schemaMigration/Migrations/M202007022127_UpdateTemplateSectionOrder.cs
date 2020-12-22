using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007022127, TransactionBehavior.None)]
	public class M202007022127_UpdateTemplateSectionOrder : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
declare @secId int
select @secId = Id from Section where Name like 'Section B:%'
update TemplateSection set OrderIndex = 2 where SectionId = @secId

select @secId = Id from Section where Name like 'Section C%'
update TemplateSection set OrderIndex = 3 where SectionId = @secId

select @secId = Id from Section where Name like 'Section D:%'
update TemplateSection set OrderIndex = 4 where SectionId = @secId

select @secId = Id from Section where Name like 'I. General Discussion'
update TemplateSection set OrderIndex = 5 where SectionId = @secId

select @secId = Id from Section where Name like 'II. Process Information: %'
update TemplateSection set OrderIndex = 6 where SectionId = @secId

select @secId = Id from Section where Name like 'III. Vendor Information'
update TemplateSection set OrderIndex = 7 where SectionId = @secId

select @secId = Id from Section where Name like 'Section F:%'
update TemplateSection set OrderIndex = 8 where SectionId = @secId

select @secId = Id from Section where Name like 'Section G:%'
update TemplateSection set OrderIndex = 9 where SectionId = @secId

select @secId = Id from Section where Name like 'Section H:%'
update TemplateSection set OrderIndex = 10 where SectionId = @secId

select @secId = Id from Section where Name like 'Section I:%'
update TemplateSection set OrderIndex = 11 where SectionId = @secId

select @secId = Id from Section where Name like 'Section J:%'
update TemplateSection set OrderIndex = 12 where SectionId = @secId

select @secId = Id from Section where Name like 'Section K:%'
update TemplateSection set OrderIndex = 13 where SectionId = @secId

select @secId = Id from Section where Name like 'Section L:%'
update TemplateSection set OrderIndex = 14 where SectionId = @secId

select @secId = Id from Section where Name like 'Section M:%'
update TemplateSection set OrderIndex = 15 where SectionId = @secId

select @secId = Id from Section where Name like 'Section N:%'
update TemplateSection set OrderIndex = 16 where SectionId = @secId

select @secId = Id from Section where Name like 'I. Methods'
update TemplateSection set OrderIndex = 17 where SectionId = @secId

select @secId = Id from Section where Name like 'II. Describe the details regarding the%'
update TemplateSection set OrderIndex = 18 where SectionId = @secId";
	}
}
