using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
    [Migration(202009231738, TransactionBehavior.None)]
    public class M202009231738_AlterQuestionSectionGlobalId : Migration
    {
        private string Section = "TemplateSection";
        private string Question = "SectionQuestion";
        private string GlobalId = "GlobalId";

        public override void Up()
        {
            Alter.Column(GlobalId).OnTable(Section).AsString(36).NotNullable().Unique("UX_" + Section + "_" + GlobalId);
            Alter.Column(GlobalId).OnTable(Question).AsString(36).NotNullable().Unique("UX_" + Question + "_" + GlobalId);
        }

        public override void Down()
        {
            Delete.Index("UX_" + Question + "_" + GlobalId).OnTable(Question);
            Delete.Index("UX_" + Section + "_" + GlobalId).OnTable(Section);
        }
    }
}
