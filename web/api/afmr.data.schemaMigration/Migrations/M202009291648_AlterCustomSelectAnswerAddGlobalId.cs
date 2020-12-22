using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202009291648, TransactionBehavior.None)]
	public class M202009291648_AlterCustomSelectAnswerAddGlobalId : Migration
	{
		private string tableName = "CustomSelectAnswer";
		private string globalId = "GlobalId";

		public override void Up()
		{
			Alter.Table(tableName).AddColumn(globalId).AsString(36).Nullable();

			Update.Table(tableName).Set(new { GlobalId = "4AFE5295-D4B5-4C2B-A824-35FFEF2E57AB" }).Where(new { Name = "Internet Searches" });
			Update.Table(tableName).Set(new { GlobalId = "391DB4F9-4721-416C-8DC8-9C2F6027D619" }).Where(new { Name = "Sources Sought" });
			Update.Table(tableName).Set(new { GlobalId = "76C873F1-AB1E-4F1E-A591-1AEADE971753" }).Where(new { Name = "Industry Days" });
			Update.Table(tableName).Set(new { GlobalId = "935CBEE6-A89D-4713-818C-36CB226ADFF1" }).Where(new { Name = "Request for Information (RFI)" });
			Update.Table(tableName).Set(new { GlobalId = "6B51B0F1-6829-4DDD-996B-1E63198C0CFA" }).Where(new { Name = "FedBizOpps" });
			Update.Table(tableName).Set(new { GlobalId = "3C493053-B3B5-4B76-8533-94725C11C921" }).Where(new { Name = "One-on-One Industry Sessions" });
			Update.Table(tableName).Set(new { GlobalId = "CFCE8697-0102-4B9F-8A3D-91BA5512072C" }).Where(new { Name = "Trade Journals/Shows" });
			Update.Table(tableName).Set(new { GlobalId = "D4F441BD-3F42-4FDD-906B-2DB6C91B18A2" }).Where(new { Name = "Government Contacts (SME in specific Markets, Other People with experience with this product/service)" });
			Update.Table(tableName).Set(new { GlobalId = "3CB299D8-8BA4-4547-9B2A-DC14A98EA750" }).Where(new { Name = "Conducting Site Visits" });
			Update.Table(tableName).Set(new { GlobalId = "A2CE1BE3-37B5-4750-A04D-535F2E9F7AA0" }).Where(new { Name = "Contacting known source of products or services" });
			Update.Table(tableName).Set(new { GlobalId = "13BC599B-4848-4F0A-952F-B93E5805DC02" }).Where(new { Name = "Government Databases (FPDS-NG, FAPISS, PPIRS, CPS, GSA, SBA Databases etc...)" });
			Update.Table(tableName).Set(new { GlobalId = "C1318CD1-78B6-476E-8305-5A3DCCBF1C74" }).Where(new { Name = "Reviewed results of recent market research on similar or identical requirements" });
			Update.Table(tableName).Set(new { GlobalId = "2DCE105C-30AE-43CE-BA6A-23073AA325CD" }).Where(new { Name = "Draft Solicitation or Statement of Work" });
			Update.Table(tableName).Set(new { GlobalId = "660B3A86-CAA8-40FE-A80E-B06B8FFCB895" }).Where(new { Name = "Obtaining Source Lists" });
			Update.Table(tableName).Set(new { GlobalId = "172F38D2-07A9-472D-B7EF-6BFDCF88DE39" }).Where(new { Name = "Contacted Small Business Office" });

			Alter.Column(globalId).OnTable(tableName).AsString(36).NotNullable().Unique("UX_" + tableName + "_" + globalId);

		}

		public override void Down()
		{
			Delete.Index("UX_" + tableName + "_" + globalId).OnTable(tableName);
			Delete.Column(globalId).FromTable(tableName);
		}
	}
}
