using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202010212136, TransactionBehavior.None)]
	public class M202010212136_AddQuestionTypeData : Migration
	{
		public override void Up()
		{			
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
declare @QId int, @SQId int, @SectionId int
declare @SQGlobalId varchar(50) = 'F37DC819-6B30-4834-86B0-BBE2967F2509'

select top 1 @SectionId = Id from Section where Name ='III. Vendor Information'

insert into QuestionType select 9, 'Identifier', 'Id of an entity', 0

insert into Question select 'Vendor ID', 'Identifier for vendor entity', 9, 0
set @QId = @@IDENTITY

insert into SectionQuestion select @SectionId, @QId, 9, @SQGlobalId
set @SQId = @@IDENTITY

insert into TemplateInstanceAnswer
select tia.TemplateInstanceId, tia.TemplateSectionId, @SQId, tia.AnswerGroupIndex, v.Id as VendorId
FROM TemplateInstanceAnswer tia
join SectionQuestion sq on tia.SectionQuestionId = sq.Id
join Vendor v on tia.AnswerValue = v.DUNSId
where tia.AnswerGroupIndex is not null and sq.GlobalId = 'FA41B94F-07F5-4557-988C-EFE582276040'";
	}
}
