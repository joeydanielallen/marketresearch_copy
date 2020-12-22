using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202009101010, TransactionBehavior.None)]
	public class M202009101010_UpdateSectionQuestionData : Migration
	{
		public override void Up()
		{			
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
  update SectionQuestion set OrderIndex=2 
  where SectionId=(select top 1 id from Section where name='I. Methods')
  and QuestionId= (select top 1 id from Question where name='Other (Please Identify):')
  and OrderIndex=1";
	}
}
