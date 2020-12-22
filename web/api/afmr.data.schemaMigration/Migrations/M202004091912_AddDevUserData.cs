using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Tags(Tags.DevTag)]
	[Migration(202004091912, TransactionBehavior.None)]
	public class M202004091912_AddDevUserData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("UserAccount").Row(
				new { Email = "support@email.com", 
					ExpiresOnUtc = System.DateTime.UtcNow.AddDays(180),
					UserName = "support@email.com", 
					PasswordHash = "sCFcxqLjmWcOYdwpdCNCfUBJ/dCTHMav+paXVT6r24MYcAiP+ct+T3vVBb7fHrgAhSR1xbpS4hWL00YkD9xgYXMAdQBwAHAAbwByAHQAQABlAG0AYQBpAGwALgBjAG8AbQA=", 
					FirstName = "Tester", 
					LastName = "Test" });
		}

		public override void Down()
		{

		}
	}
}
