using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202008311355, TransactionBehavior.None)]
	public class M202008311355_Add448thOrgsAndUsersData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
if exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician') 
  begin
	update AppRole set AppRoleName = 'Logistician Management Specialist' where AppRoleName = 'Logistician'
  end

  if not exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist') 
  begin
	insert into AppRole select 'Logistician Management Specialist'
  end
  
  if not exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Engineer') 
  begin
	insert into AppRole select 'Engineer'
  end

  if not exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Item Manager') 
  begin
	insert into AppRole select 'Item Manager'
  end

  if not exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Material Manager') 
  begin
	insert into AppRole select 'Material Manager'
  end

  if not exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Equipment Specialist') 
  begin
	insert into AppRole select 'Equipment Specialist'
  end

  if not exists (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist') 
  begin
	insert into AppRole select 'Production Management Specialist'
  end

  update BidType set Name = 'Sole Sourced' where Name = 'Closed Bid'
  update BidType set Name = 'Competitive' where Name = 'Open Bid'

  update Org set Description = '421st SCMS' where Name = '421st'
  update Org set Description = '422nd SCMS' where Name = '422nd'

  insert into Org 
  select '423rd', '423rd SCMS'
  union all select '424th', '424th SMCS'  
  union all select '848th', '848th SCMG'
  union all select '448th', '448th SCMW'

  insert into RoleClaim
  select (select top 1 AppRoleId from AppRole where AppRoleName = 'Item Manager'), 5
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Item Manager'), 6
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Item Manager'), 7
  
  insert into RoleClaim
  select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), 5
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), 6
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), 7

  insert into RoleClaim
  select (select top 1 AppRoleId from AppRole where AppRoleName = 'Equipment Specialist'), 5
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Equipment Specialist'), 6
	
  insert into RoleClaim
  select (select top 1 AppRoleId from AppRole where AppRoleName = 'Material Manager'), 5
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Material Manager'), 6
  union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Material Manager'), 7

  --add users with pwd hash, add to roles
  declare @orgId int
  select @orgId = Id from Org where Name = '421st'
  declare @userId int
  insert into UserAccount 
  select null, 'carly.hobbs.1@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'carly.hobbs.1@us.af.mil', 
  'L9ZUpdu3vmsziAqNzLVK33QlGIm83wyPArzyxKIZ3AQKAT7/2S8xvycZQafblU5Dx1p6OB+ZP3em2tawZnA9jGMAYQByAGwAeQAuAGgAbwBiAGIAcwAuADEAQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Carly', 'Hobbs', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Item Manager'), @userId
  
  insert into UserAccount 
  select null, 'lauren.griffin.2@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'lauren.griffin.2@us.af.mil', 
  '/ZFfiaTnFxzZMDWj6MpSt7xSHFkeQkXZmaHb0i1YleCvb8VRPuTCvB4CzjnCHhVdYCHL1hRsApYvwnXUVmlKiWwAYQB1AHIAZQBuAC4AZwByAGkAZgBmAGkAbgAuADIAQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Lauren', 'Griffin', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'angela.anson@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'angela.anson@us.af.mil', 
  'RIeaTM+AY5dU2jjgdf/z435UlZRkQm0gh4pVgk/7BAR/i1zuNKNodxGwAYVFeiCgjnU+aqhCPhjb5BbEhFejV2EAbgBnAGUAbABhAC4AYQBuAHMAbwBuAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Angela', 'Anson', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'paul.koon@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'paul.koon@us.af.mil', 
  'SLibPq75+q9T+vkzeWIizF+PP5axwMWQEhZX/MuYiVBxjRCwKVENW40guNybCQivwS32mZ6eOTadNixQ5MfVa3AAYQB1AGwALgBrAG8AbwBuAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Paul', 'Koon', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId

  --------------------------------------------------------------------

  select @orgId = Id from Org where Name = '422nd'
  insert into UserAccount 
  select null, 'robin.nash@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'robin.nash@us.af.mil', 
  'XqMvnP5u21evGYh167kgd29rVTRwtheccK74+sBn4m4viLcqQ8FKEZzWYRKkscTMaHuWGiyre/cjXuYuKMVLgHIAbwBiAGkAbgAuAG4AYQBzAGgAQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Robin', 'Nash', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'mark.elden@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'mark.elden@us.af.mil', 
  'KA6yVbmdn1cIti1hENAS2YeAfPu3uAlkaoqN9wo3SVYPT7Eb/F9TRZxD7sryFDoxOALZ9CFjvAaziKVHa2RXeG0AYQByAGsALgBlAGwAZABlAG4AQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Mark', 'Elden', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Engineer'), @userId
  
  insert into UserAccount 
  select null, 'lloyd.cohen@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'lloyd.cohen@us.af.mil', 
  'iLBZ3mEWTlJcI+5IvLYSwArD33xREMQrPF+NmhVnDYhU6fD8+UW0YTh8+gdvFWfa39g/rqK8IiLw6146tklcsWwAbABvAHkAZAAuAGMAbwBoAGUAbgBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Lloyd', 'Cohen', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'kenneth.bettis@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'kenneth.bettis@us.af.mil', 
  'h+J0o8pv5LuDurb5GjJUhOAuAOGkuIslJhGD9Bg0Uv1pLz/NRWyOeJndJew1DU0PtJuruMGi8+W6kd0gZVcXJGsAZQBuAG4AZQB0AGgALgBiAGUAdAB0AGkAcwBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Kenneth', 'Bettis', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Material Manager'), @userId

  insert into UserAccount 
  select null, 'mariah.schon.1@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'mariah.schon.1@us.af.mil', 
  '98KojWBFxsTIBAjCXVKhOEwfRthfIEPmFWS5fL2SkEuQIBxNXGfPOoSWXHgutBuSFCaDzFXcbAbG7K+XsJCjJW0AYQByAGkAYQBoAC4AcwBjAGgAbwBuAC4AMQBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Mariah', 'Schon', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'renata.coble@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'renata.coble@us.af.mil', 
  'drK3NtTVQiQoAK6UfwqIq3gDHxj/dFdImsiYz510Uj66nL8RcZdDdNJ7i2tGfRdWtXH6VPkVR3hTXZiPFzrruXIAZQBuAGEAdABhAC4AYwBvAGIAbABlAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Renata', 'Coble', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'frank.deitchman.3@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'frank.deitchman.3@us.af.mil', 
  'H0B3WRSX8SZlw79gpRJrnoEJbPhjEttAYrYt65DaA9yFAkfo/s+3kR73n9aG3j1W3+jMUozcljsbPthFmMEf4GYAcgBhAG4AawAuAGQAZQBpAHQAYwBoAG0AYQBuAC4AMwBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Frank', 'Deitchman', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Equipment Specialist'), @userId
  
  insert into UserAccount 
  select null, 'keshawn.richardson.2@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'keshawn.richardson.2@us.af.mil', 
  'gy7nb1HWx82IGzqqGEOIMPr3j9dJK/0FfF45rUJXI96N+b5lxpW3zfDi6s4YgUmIbmae4eG8FHachl9Uvf20a2sAZQBzAGgAYQB3AG4ALgByAGkAYwBoAGEAcgBkAHMAbwBuAC4AMgBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Keshawn', 'Richardson', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Material Manager'), @userId

  ----------------------------------------

  select @orgId = Id from Org where Name = '423rd'
  insert into UserAccount 
  select null, 'marcus.balano-taylor@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'marcus.balano-taylor@us.af.mil', 
  '1r4VVbi0dEQQm7B4/7ILO7kda7lkU1KJg1Q3mqYVYtz/NZrqn05bxzUqUlATWnJ7lBrGbKFA6oBgQ4av67t45m0AYQByAGMAdQBzAC4AYgBhAGwAYQBuAG8ALQB0AGEAeQBsAG8AcgBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Marcus', 'Balano-Taylor', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'karla.desalle@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'karla.desalle@us.af.mil', 
  'jvYJx5aZ82iXAGTVYbTsFd9NzAH3+rB+9VehBk5JxehB99WHg/XC78OFsXE1QlLDOyQHfkyX6bKbqEDU6lowCmsAYQByAGwAYQAuAGQAZQBzAGEAbABsAGUAQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Karla', 'DeSalle', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'sureewan.changfang@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'sureewan.changfang@us.af.mil', 
  '6LhEN3l6uAhPfnRykCJXDC434M/9dZ+cEHhpKKv6pHrc3Ifolw1KhAEPYJnXmlvFj1WP1i2YmgvtBROoM++uRnMAdQByAGUAZQB3AGEAbgAuAGMAaABhAG4AZwBmAGEAbgBnAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Sue', 'Changfang', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'mychael.holford@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'mmychael.holford@us.af.mil', 
  'PuPtUo4vznFkyBmMbG5ZiPsdwG4JKX3vn+Ya62i9RNVDag5rzd/gP5LYqzdiZhr60z7Mg+9+CsFTfc7D7y0Y0G0AeQBjAGgAYQBlAGwALgBoAG8AbABmAG8AcgBkAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Mychael', 'Holford', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId

----------------------------------------

  select @orgId = Id from Org where Name = '424th'
  insert into UserAccount 
  select null, 'tori.matthews@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'tori.matthews@us.af.mil', 
  'jJ0mTthFx76vtgH39WFyK4RzHRCGshRs0tzVWxLM3YwoR+msNb36RqxK+BvMt2WLSXFA90ixVk27XqFV2EH8MHQAbwByAGkALgBtAGEAdAB0AGgAZQB3AHMAQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Tori', 'Matthews', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId

  insert into UserAccount 
  select null, 'brandy.frasco.3@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'brandy.frasco.3@us.af.mil', 
  'Z+mU7hgtsBAT/1I6QX7NhK7xHrFQPVii00DZCy42wTgcI6Pi+CF+V1qAy5BveDPZlR0FbYgxZ0PHy4JZBDooR2IAcgBhAG4AZAB5AC4AZgByAGEAcwBjAG8ALgAzAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Brandy', 'Frasco', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId

  insert into UserAccount 
  select null, 'jeremy.nicholson@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'jeremy.nicholson@us.af.mil', 
  'x+/b6pZ+Pm2SRdBLLvucZkZOjAV2IhbeAFJ2A759KLZwdWlRTH8K5DvJTSZPFbRj8b13Hb5P15kghC868ULdnmoAZQByAGUAbQB5AC4AbgBpAGMAaABvAGwAcwBvAG4AQAB1AHMALgBhAGYALgBtAGkAbAA=',
  'Jeremy', 'Nicholson', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'rebecca.edwardstrader@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'rebecca.edwardstrader@us.af.mil', 
  '/HhTYHq4u3Oeq36ws6EQ4ODIhV4JzoV0FpMasy9ZXaZeyLqBpU64I414nn4+ryRC4ixbOJOaT6Pk5KDq3PuEBnIAZQBiAGUAYwBjAGEALgBlAGQAdwBhAHIAZABzAHQAcgBhAGQAZQByAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Rebecca', 'Edwards-Trader', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'cameron.maxifield@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'cameron.maxifield@us.af.mil', 
  'qiXz0SyM5GTvMW6cBOm9g8tucgYlHsct8+bVkpEGRTB8zINZwB/eq47/FX55yxXTdp5Jz67Xt8g+XNRNHwPVHWMAYQBtAGUAcgBvAG4ALgBtAGEAeABpAGYAaQBlAGwAZABAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Cameron', 'Maxifield', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'jeannie.mann@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'jeannie.mann@us.af.mil', 
  '6abL+aVjOu0kE+/V6Qc8SJF3Q3GwKvbt59v/p48qWh4gidju0RIP2uf9WrK8m+sN2r1PpaeSlnRDuS1OS7LAgGoAZQBhAG4AbgBpAGUALgBtAGEAbgBuAEAAdQBzAC4AYQBmAC4AbQBpAGwA',
  'Jeannie', 'Mann', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Production Management Specialist'), @userId
  
  insert into UserAccount 
  select null, 'jeremiah.tottress@us.af.mil', DATEADD(year, 10, GETDATE()), 0,'jeremiah.tottress@us.af.mil', 
  'Rvdhxon2CY2R54s7htCmI6zUSHn6w12XinHErYp+t7IYvz2qtLNM2fDRUEy5O25QvDRaxZmGlChTuWLjeyl1w2oAZQByAGUAbQBpAGEAaAAuAHQAbwB0AHQAcgBlAHMAcwBAAHUAcwAuAGEAZgAuAG0AaQBsAA==',
  'Jeremiah', 'Tottress', GETDATE(), 1
  set @userId = @@IDENTITY
  insert into UserOrg select @userId, @orgId
  insert into UserRole select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician Management Specialist'), @userId";
	}
}
