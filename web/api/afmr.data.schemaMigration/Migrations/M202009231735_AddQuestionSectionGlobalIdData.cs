using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202009231735, TransactionBehavior.None)]
	public class M202009231735_AddQuestionSectionGlobalIdData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
  declare @tempId int, @secId int
  set @tempId = (select top 1 Id from Template where Name='AFMC MP5327.9001')
  
  set @secId = (select top 1 Id from Section where Name='Section A: General Contract Information')
  update TemplateSection set GlobalId='CF6B2E05-BDAB-464D-8025-677D6B8A1662' where TemplateId = @tempId and SectionId = @secId and OrderIndex=1
  update SectionQuestion set GlobalId='82C82765-233F-4D96-8C60-E733360F19B9' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='Contracting Activity/Organization:')
  update SectionQuestion set GlobalId='674D0E30-C94A-4C46-9B6B-1479029AA855' where SectionId=@secId and OrderIndex=2 and QuestionId=(select top 1 Id from Question where Name='Project/Program Name:')
  update SectionQuestion set GlobalId='7E896EFC-1BA2-4B04-9617-B1303951BF22' where SectionId=@secId and OrderIndex=3 and QuestionId=(select top 1 Id from Question where Name='Report Date:')
  update SectionQuestion set GlobalId='254386ED-C553-48E3-A9F6-F1ADCBCBB29E' where SectionId=@secId and OrderIndex=4 and QuestionId=(select top 1 Id from Question where Name='Market Research Start Date:')
  update SectionQuestion set GlobalId='AECA3AD0-1F8E-41FA-9DFC-B6C689018431' where SectionId=@secId and OrderIndex=5 and QuestionId=(select top 1 Id from Question where Name='Market Research End Date:')
  update SectionQuestion set GlobalId='E8D121E6-4CDB-446E-85FD-05F18EDA1C81' where SectionId=@secId and OrderIndex=6 and QuestionId=(select top 1 Id from Question where Name='Purchase Request/Identification Number:')
  update SectionQuestion set GlobalId='0D699D81-8FE5-49B9-A3E3-F24D4914916C' where SectionId=@secId and OrderIndex=7 and QuestionId=(select top 1 Id from Question where Name='Estimated Contract Cost (Include Options):')
  update SectionQuestion set GlobalId='193D16AF-3BA9-4FD7-9B8E-8B64138D13C7' where SectionId=@secId and OrderIndex=8 and QuestionId=(select top 1 Id from Question where Name='Projected Period of Performance:')
  update SectionQuestion set GlobalId='B8B56909-0543-41FD-AD96-56F9F363EB38' where SectionId=@secId and OrderIndex=9 and QuestionId=(select top 1 Id from Question where Name='NAICS:')
  update SectionQuestion set GlobalId='67270B26-1195-41C1-A434-9C902BADCF34' where SectionId=@secId and OrderIndex=10 and QuestionId=(select top 1 Id from Question where Name='PSC/FSC:')
  
  set @secId = (select top 1 Id from Section where Name='Section B: Product or Service Description')
  update TemplateSection set GlobalId='D13ED3C9-87A4-46D7-86BD-AC57A2DA4E97' where TemplateId = @tempId and SectionId = @secId and OrderIndex=2
  update SectionQuestion set GlobalId='30988158-4F5D-4CD2-B943-F87A52A920E3' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Include a description of the product or service to be addressed by this market research report. %')
  
  set @secId = (select top 1 Id from Section where Name='Section C: Background')
  update TemplateSection set GlobalId='B4917E20-4C13-484C-95C6-0C28780236A5' where TemplateId = @tempId and SectionId = @secId and OrderIndex=3
  update SectionQuestion set GlobalId='1205FD8E-B9EE-4E16-9C8C-CC3843FBE359' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide a short narrative on the various weapon systems and/or platforms %')
  
  set @secId = (select top 1 Id from Section where Name='Section D: Performance Requirements')
  update TemplateSection set GlobalId='43644DDB-611D-45E1-9BBF-C3BB94AB5AB3' where TemplateId = @tempId and SectionId = @secId and OrderIndex=4
  update SectionQuestion set GlobalId='222714F4-8028-4946-A538-2669392C3792' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'State the critical performance requirements which the product or service must meet. %')
  
  set @secId = (select top 1 Id from Section where Name='I. General Discussion')
  update TemplateSection set GlobalId='510889C4-F15D-4EDF-86AD-609A99D71139' where TemplateId = @tempId and SectionId = @secId and OrderIndex=5
  update SectionQuestion set GlobalId='E29BD5B5-FD45-4AF0-91E0-784E28E40938' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide an overview of the vendor survey that was performed.  If sole source, %')
 
  set @secId = (select top 1 Id from Section where Name='II. Process Information: (Identify the number of sources contacted in each category.)')
  update TemplateSection set GlobalId='10A61014-2457-42E7-8F52-A58B3488B28F' where TemplateId = @tempId and SectionId = @secId and OrderIndex=6
  update SectionQuestion set GlobalId='1AF3F881-54BE-4EB0-908E-5F22F449A7BE' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='Large Business')
  update SectionQuestion set GlobalId='AF6A11BA-FF43-4100-9427-F03C972D6F0E' where SectionId=@secId and OrderIndex=2 and QuestionId=(select top 1 Id from Question where Name='Educational Institution')
  update SectionQuestion set GlobalId='A36DE3E4-1702-42B8-A551-DB34A0EC2942' where SectionId=@secId and OrderIndex=3 and QuestionId=(select top 1 Id from Question where Name='Non-Profit')
  update SectionQuestion set GlobalId='04A17ED9-E575-4494-BEB5-00D9804D7790' where SectionId=@secId and OrderIndex=4 and QuestionId=(select top 1 Id from Question where Name='Government Entity')
  update SectionQuestion set GlobalId='9D0A73ED-92E5-4A0B-85D4-361DAEF9F56D' where SectionId=@secId and OrderIndex=5 and QuestionId=(select top 1 Id from Question where Name='Small Business - SDB')
  update SectionQuestion set GlobalId='20868339-0A53-4294-B01D-55D6DE76BD3C' where SectionId=@secId and OrderIndex=6 and QuestionId=(select top 1 Id from Question where Name='Small Business - EDWOSB')
  update SectionQuestion set GlobalId='3370C3B7-3DFC-411D-BA9A-0E1F2D8AF248' where SectionId=@secId and OrderIndex=7 and QuestionId=(select top 1 Id from Question where Name='Small Business - WOSB')
  update SectionQuestion set GlobalId='26E7017A-94F1-4394-8572-E08C9B334501' where SectionId=@secId and OrderIndex=8 and QuestionId=(select top 1 Id from Question where Name='Small Business - 8(a)')
  update SectionQuestion set GlobalId='1456A762-D283-4095-BE48-A8AE58637327' where SectionId=@secId and OrderIndex=9 and QuestionId=(select top 1 Id from Question where Name='Small Business - HUBZone')
  update SectionQuestion set GlobalId='47B07279-232F-457F-846F-D5AD7C4CCE98' where SectionId=@secId and OrderIndex=10 and QuestionId=(select top 1 Id from Question where Name='Small Business - Veteran')
  update SectionQuestion set GlobalId='39BA33EE-2D53-4607-8EC2-E1D387628B37' where SectionId=@secId and OrderIndex=11 and QuestionId=(select top 1 Id from Question where Name='Small Business - SDVOSB')
  update SectionQuestion set GlobalId='0E9B66DB-BE16-4C31-A319-25139610A8AF' where SectionId=@secId and OrderIndex=12 and QuestionId=(select top 1 Id from Question where Name='Small Business - Native')
  update SectionQuestion set GlobalId='E625EB59-F5F6-4FA6-8C08-8160D06F3223' where SectionId=@secId and OrderIndex=13 and QuestionId=(select top 1 Id from Question where Name='Other')
  

  set @secId = (select top 1 Id from Section where Name='III. Vendor Information')
  update TemplateSection set GlobalId='579F17D5-E11C-4914-B9D6-FEFF5D76790C' where TemplateId = @tempId and SectionId = @secId and OrderIndex=7
  update SectionQuestion set GlobalId='9577B06A-100F-4E4D-926A-868BDA9EBD74' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='Name')
  update SectionQuestion set GlobalId='FA41B94F-07F5-4557-988C-EFE582276040' where SectionId=@secId and OrderIndex=2 and QuestionId=(select top 1 Id from Question where Name='CAGE/DUNS')
  update SectionQuestion set GlobalId='D56F6C9C-0095-477C-AB7E-07D3606EE374' where SectionId=@secId and OrderIndex=3 and QuestionId=(select top 1 Id from Question where Name='Socioeconomic Status')
  update SectionQuestion set GlobalId='F6A5908D-F064-4830-BBED-17EF48E563D3' where SectionId=@secId and OrderIndex=4 and QuestionId=(select top 1 Id from Question where Name='Location')
  update SectionQuestion set GlobalId='1148C6C4-4D99-4A78-BAA0-3DB9D41725C2' where SectionId=@secId and OrderIndex=5 and QuestionId=(select top 1 Id from Question where Name='Point of Contact')
  update SectionQuestion set GlobalId='39BFD151-12EE-4F19-AEAC-5B1068630276' where SectionId=@secId and OrderIndex=6 and QuestionId=(select top 1 Id from Question where Name='Part Number')
  update SectionQuestion set GlobalId='C44B183D-F0D5-4DBB-BE94-9BC230BAE145' where SectionId=@secId and OrderIndex=7 and QuestionId=(select top 1 Id from Question where Name='Capabilites')
  update SectionQuestion set GlobalId='950F8B2A-661E-4914-A144-48C6A78533D4' where SectionId=@secId and OrderIndex=8 and QuestionId=(select top 1 Id from Question where Name='Past Performance')
  

  set @secId = (select top 1 Id from Section where Name='Section F: Product Data')
  update TemplateSection set GlobalId='62A8D336-812F-4432-94FD-D9ED1CC1D4BF' where TemplateId = @tempId and SectionId = @secId and OrderIndex=8
  update SectionQuestion set GlobalId='D2841F81-6BDF-4644-88EB-C919A1E12B83' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'List any available commercial product sheets, test data, qualification data, support manuals, or related data %')
  
  set @secId = (select top 1 Id from Section where Name='Section G: Environmental Impact Considerations and Certification Requirements')
  update TemplateSection set GlobalId='4D084A15-3916-45A4-8F68-A8C9ECEDDB50' where TemplateId = @tempId and SectionId = @secId and OrderIndex=9
  update SectionQuestion set GlobalId='0B6E52F8-E677-4579-AB52-93BEDD0059E9' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Identify any known environmental regulations or product certification %' )  

  set @secId = (select top 1 Id from Section where Name='Section H: Commercial Opportunities')
  update TemplateSection set GlobalId='2C6912EF-EE9A-4774-A1F5-0F5AF4215102' where TemplateId = @tempId and SectionId = @secId and OrderIndex=10
  update SectionQuestion set GlobalId='7DA58437-28CE-4BE0-8E4A-F8A630AED4FC' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide pertinent information that a contracting officer can use to conduct an %')
  
  set @secId = (select top 1 Id from Section where Name='Section I: Industry Standards, Commercial Business Practices')
  update TemplateSection set GlobalId='434E0C06-E241-4FBA-83D2-44EBA54A208A' where TemplateId = @tempId and SectionId = @secId and OrderIndex=11
  update SectionQuestion set GlobalId='37F1DE90-6301-458F-B0CA-8B539681FFBA' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'List any applicable industry standards, regulations, trade journals, %')
  
  set @secId = (select top 1 Id from Section where Name='Section J: Technology Trends & Technology Insertion Opportunities')
  update TemplateSection set GlobalId='893057F4-2248-4856-85F4-E6D67194383E' where TemplateId = @tempId and SectionId = @secId and OrderIndex=12
  update SectionQuestion set GlobalId='860D50A7-B31A-462C-AFAD-87E49855E211' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide a technology assessment of the market sector as applicable %')
  
  set @secId = (select top 1 Id from Section where Name='Section K: Small Business Opportunities')
  update TemplateSection set GlobalId='F646C2B8-A33C-490D-9616-01CBF21204DB' where TemplateId = @tempId and SectionId = @secId and OrderIndex=13
  update SectionQuestion set GlobalId='AF9F127D-EA3A-491B-AA05-8F080BF92E0F' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide an assessment of the potential opportunities for small business %')  

  set @secId = (select top 1 Id from Section where Name='Section L: Terms and Conditions')
  update TemplateSection set GlobalId='34A7FB50-EB44-429B-B836-D370FC2EF4E2' where TemplateId = @tempId and SectionId = @secId and OrderIndex=14
  update SectionQuestion set GlobalId='3A6F6B3D-E809-4BDC-A034-5F3D195E969C' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide an assessment of any differences between the terms and conditions offered %')
  
  set @secId = (select top 1 Id from Section where Name='Section M: Government''s Presence/Leverage In the Market')
  update TemplateSection set GlobalId='475B234B-3FC8-4AC5-AA48-C5F9E245203F' where TemplateId = @tempId and SectionId = @secId and OrderIndex=15
  update SectionQuestion set GlobalId='67B5C082-2DDD-40E6-8370-C08B6E0A8A00' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Provide your assessment of the government’s leverage in the marketplace, %')
  
  set @secId = (select top 1 Id from Section where Name='Section N: Conclusions and Recommendations')
  update TemplateSection set GlobalId='141E415A-114C-4912-96CF-5E200AD9B9FD' where TemplateId = @tempId and SectionId = @secId and OrderIndex=16
  update SectionQuestion set GlobalId='43F2FCB1-C6EE-425E-8DC8-D90BEF151B5A' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description like 'Summarize your data analysis with recommendations for:%')
  
  set @secId = (select top 1 Id from Section where Name='I. Methods')
  update TemplateSection set GlobalId='A9C123E4-889A-4CDE-9259-5EA09D20EB76' where TemplateId = @tempId and SectionId = @secId and OrderIndex=17
  update SectionQuestion set GlobalId='CC15EAB1-BC99-4726-95A3-761B5FB3B382' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='Select All That Apply')
  update SectionQuestion set GlobalId='1644F465-9DC1-4E37-B3C3-7E676376F155' where SectionId=@secId and OrderIndex=2 and QuestionId=(select top 1 Id from Question where Name='Other (Please Identify):')
  
  set @secId = (select top 1 Id from Section where Name='II. Describe the details regarding the various methods indicated above that were used to arrive at the market research findings.')
  update TemplateSection set GlobalId='8AE477D8-FF02-473D-9298-D56E3E65FD91' where TemplateId = @tempId and SectionId = @secId and OrderIndex=18
  update SectionQuestion set GlobalId='92DA8715-17F5-4F3F-9961-3C1AC2829F0E' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='' and Description='' and QuestionTypeId=2)
    
  set @tempId = (select top 1 Id from Template where Name='MARKET RESEARCH FOR ROUTINE NON-COMPLEX PURCHASES')
  set @secId = (select top 1 Id from Section where Name='' and CanRepeat=0 and CanDelete=1)
  update TemplateSection set GlobalId='C58F3A13-F4B1-4AB0-872A-69CFA70A8A41' where TemplateId = @tempId and SectionId = @secId and OrderIndex=1
  update SectionQuestion set GlobalId='921FAE68-6867-44CB-BE37-72421DD17344' where SectionId=@secId and OrderIndex=1 and QuestionId=(select top 1 Id from Question where Name='TECHNIQUES USED:')
  update SectionQuestion set GlobalId='F570ED77-AEAA-4C36-8519-6CCA5C542DA9' where SectionId=@secId and OrderIndex=2 and QuestionId=(select top 1 Id from Question where Name='1. MARKET RESEARCH RESULTS / TECHNIQUE REMARKS:')
  update SectionQuestion set GlobalId='65C760EE-9853-4888-A2E7-6B594D8E3243' where SectionId=@secId and OrderIndex=3 and QuestionId=(select top 1 Id from Question where Name='2. BID TYPE REASON:')
  update SectionQuestion set GlobalId='0D1760EB-3E12-40A0-B2FE-18AF8A4E7C37' where SectionId=@secId and OrderIndex=4 and QuestionId=(select top 1 Id from Question where Name='3. VENDOR INFORMATION:')
  update SectionQuestion set GlobalId='F7660508-A4DF-4276-BE11-31FD1C6AC91B' where SectionId=@secId and OrderIndex=5 and QuestionId=(select top 1 Id from Question where Name='4. DESCRIPTION OF AGENCY NEED:')
  update SectionQuestion set GlobalId='DD18BFC9-94B4-46BE-92C1-0E0DDDA5B337' where SectionId=@secId and OrderIndex=6 and QuestionId=(select top 1 Id from Question where Name='5. BUNDLING ANTICIPATION')
";
	}
}

