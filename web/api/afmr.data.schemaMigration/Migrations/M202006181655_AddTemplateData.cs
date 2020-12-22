using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Tags(Tags.DevTag)]
	[Migration(202006181655, TransactionBehavior.None)]
	public class M202006181655_AddTemplateData : Migration
	{
		public override void Up()
		{
			Execute.Sql(builderSql);
		}

		public override void Down()
		{
			Execute.Sql(@"
delete from CustomSelectAnswer
delete from SectionQuestion
delete from Question
delete from QuestionType
delete from TemplateSection
delete from Section
delete from TemplateBidType
delete from TemplateSourceType
delete from TemplateServiceType
delete from TemplateOrg
delete from TemplateInstance
delete from Template");
		}

		private string builderSql = @"
declare @tempId int
insert into Template
select 'Template 1 Name', 'Template 1 Description',0,999999999, 1
set @tempId = @@IDENTITY

insert into TemplateOrg
select @tempId, (select top 1 Id from Org where Name = '421st')
union all select @tempId, (select top 1 Id from Org where Name = '422nd')

insert into TemplateSourceType
select @tempId, 1

insert into TemplateServiceType
select @tempId, 1

insert into TemplateBidType
select @tempId, 2

declare @sectionOneId int
insert into Section
select 'I.', 'Section A I description'
set @sectionOneId = @@IDENTITY

declare @sectionTwoId int
insert into Section
select 'II.', 'Section A II description'
set @sectionTwoId = @@IDENTITY

declare @sectionThreeId int
insert into Section
select 'Section B', 'Section B description'
set @sectionThreeId = @@IDENTITY

declare @sectionGroupId int
insert into TemplateSectionGroup
select 'Section A', 'Section A description'
set @sectionGroupId = @@IDENTITY

insert into TemplateSection
select @tempId, @sectionOneId, @sectionGroupId, 1
union all select @tempId, @sectionTwoId, @sectionGroupId, 2
union all select @tempId, @sectionThreeId, null, 3

insert into QuestionType
select 1, 'Small Text', 'One line text input', 0
union all select 2, 'Large Text', 'Multiple lines of text input', 0

declare @questionId int
insert into Question
select 'Question 1 Name','Question 1 Description', 1, 25
set @questionId = @@IDENTITY

insert into SectionQuestion
select @sectionOneId, @questionId, 1

insert into Question
select 'Question 2 Name', 'Question 2 Description', 2, 500
set @questionId = @@IDENTITY

insert into SectionQuestion
select @sectionTwoId, @questionId, 2
union all select @sectionThreeId, @questionId, 3

insert into TemplateInstance
select 'Template 1 Name', 1, @tempId, 'Template 1 Name', (select top 1 Id from Org where Name = '421st'), 2, 1, 1, '1234PRPS', '1234567890123', 1, 1000, GETUTCDATE(), null";

	}
}
