using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007011936, TransactionBehavior.None)]
	public class M202007011936_AddNewTemplateData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"declare @tempId int
insert into Template select 'MARKET RESEARCH FOR ROUTINE NON-COMPLEX PURCHASES', '', 0, 999999999, 1
set @tempId = @@IDENTITY

insert into TemplateBidType select @tempId, 3
insert into TemplateServiceType select @tempId, 1
insert into TemplateSourceType select @tempId, 1
insert into TemplateOrg select @tempId, (select top 1 Id from Org where name ='421st') union all select @tempId, (select top 1 Id from Org where name ='422nd') 

declare @sectionId int
insert into Section select '', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

declare @questionId int
insert into Question select 'TECHNIQUES USED:', 'Techniques used to conduct market research', 2, 10240
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

insert into Question select '1. MARKET RESEARCH RESULTS / TECHNIQUE REMARKS:', '', 2, 10240
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 2

insert into Question select '2. BID TYPE REASON:', '', 2, 10240
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 3

insert into Question select '3. VENDOR INFORMATION:', '', 2, 10240
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 4

insert into Question select '4. DESCRIPTION OF AGENCY NEED:', '', 2, 10240
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 5

insert into Question select '5. BUNDLING ANTICIPATION', '', 2, 10240
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 6";
	}
}
