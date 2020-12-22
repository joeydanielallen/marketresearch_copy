using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006302302, TransactionBehavior.None)]
	public class M202006302302_AddRealTemplateData : Migration
	{
        public override void Up()
        {
            Execute.Sql(sql);
        }

        public override void Down()
        {
            Execute.Sql(sqlDown);
        }

        private string sqlDown = @"
delete from TemplateSection
delete from TemplateSectionGroup
delete from SectionQuestion
delete from Section
delete from CustomSelectAnswer
delete from Question";

        private string sql = @"
declare @tempId int
select @tempId = Id from Template where Name = 'AFMC MP5327.9001'

declare @sectionId int
insert into Section select 'Section A: General Contract Information', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

declare @questionId int
insert into Question select 'Contracting Activity/Organization:', '', 1, 200
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

insert into Question select 'Project/Program Name:', '', 1, 200
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 2

insert into Question select 'Report Date:', '', 3, 0
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 3

insert into Question select 'Market Research Start Date:', '', 3, 0
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 4

insert into Question select 'Market Research End Date:', '', 3, 0
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 5

insert into Question select 'Purchase Request/Identification Number:', '', 1, 32
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 6

insert into Question select 'Estimated Contract Cost (Include Options):', '', 8, 999999999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 7

insert into Question select 'Projected Period of Performance:', '', 1, 128
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 8

insert into Question select 'NAICS:', '', 1, 16
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 9

insert into Question select 'PSC/FSC:', '', 1, 128
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 10

insert into Section select 'Section B: Product or Service Description', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Include a description of the product or service to be addressed by this market research report. Information shall be provided to state current and projected quantities or service requirements to be addressed by this acquisition as well as an assessment as to the potential sustainment life cycle for any follow on requirements.', 2, 1024
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

insert into Section select 'Section C: Background', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Provide a short narrative on the various weapon systems and/or platforms for which this product or service shall be used to support.  For follow-on contracts, include information relative to the previous awards such as: <br>
- past acquisition strategies supported (including specific historical data from the last contract award) <br>
    -- e.g. NAICS, large or small business awardee, contract dollar amount, period of performance, etc.<br>
- past MR summary and results<br>
- activities taken to remove competitive barriers <br>
- actions taken to resolve deficient data issues <br>
- changes in the market place (suppliers, trends, technologies)', 2, 1024
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

insert into Section select 'Section D: Performance Requirements', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'State the critical performance requirements which the product or service must meet.  Provide an assessment as to whether the requirements are military unique or can be acquired to some degree in the commercial market sector.  Identify as appropriate any critical and long lead schedule items which will impact contract performance and delivery requirements.', 2, 1024
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

declare @groupId int
insert into TemplateSectionGroup select 'Section E: Vendor Survey', ''
set @groupId = @@IDENTITY

insert into Section select 'I. General Discussion', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, @groupId, 1

insert into Question select '', 'Provide an overview of the vendor survey that was performed.  If sole source, describe efforts to locate additional sources.  Explain the rationale used to exclude sources (remember you are looking for a CAPABILITY - not doing a SOURCE SELECTION).  Identify the number of sources contacted and why they were considered a potential company able to perform this acquisition. If small businesses were contacted please click on the small business button and provide the number of each socioeconomic category. Summarize the information obtained from each source contacted and provide a list of potential vendors and known sources of supply that could be solicited to provide the product or service required in the table below.<br>
Market research assessment should identify if there is a reasonable expectation that two or more responsible offerors, competing independently, would submit priced offers in response to the solicitation expressed requirement.<br>
Determine if the services may be provided by the AbilityOne program.  ( www.abilityone.gov )', 2, 1024
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'II. Process Information: (Identify the number of sources contacted in each category.)', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, @groupId, 2

insert into Question select 'Large Business', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

insert into Question select 'Educational Institution', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 2

insert into Question select 'Non-Profit', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 3

insert into Question select 'Government Entity', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 4

insert into Question select 'Small Business - SDB', 'Small Disadvantaged Business', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 5

insert into Question select 'Small Business - EDWOSB', 'Economically Disadvantaged Women-Owned Small Businesses', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 6

insert into Question select 'Small Business - WOSB', 'Women-Owned Small Businesses', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 7

insert into Question select 'Small Business - 8(a)', 'Owned and controlled at least 51% by socially and economically disadvantaged individuals', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 8

insert into Question select 'Small Business - HUBZone', 'Historically Underutilized Business Zone', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 9

insert into Question select 'Small Business - Veteran', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 10

insert into Question select 'Small Business - SDVOSB', 'Service Disabled Veteran Owned Small Business', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 11

insert into Question select 'Small Business - Native', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 12

insert into Question select 'Other', '', 4, 999
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 13

insert into Section select 'III. Vendor Information', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, @groupId, 3


insert into Section select 'Section F: Product Data', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'List any available commercial product sheets, test data, qualification data, support manuals, or related data that defines the performance and manufacturing characteristics of the product required. If the product is under the configuration control of the government provide an assessment as to the quality and thoroughness of the available data to sustain an acquisition for this product.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1

insert into Section select 'Section G: Environmental Impact Considerations and Certification Requirements', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Identify any known environmental regulations or product certification requirements which must be obtained in order to manufacture, produce, store, or distribute the product or provide the service.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section H: Commercial Opportunities', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Provide pertinent information that a contracting officer can use to conduct an assessment as to whether the product or service meets the definitions of FAR Part 2 in terms of commercial items or non-developmental items which can be acquired using the streamlined acquisition procedures under FAR Part 12.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section I: Industry Standards, Commercial Business Practices', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'List any applicable industry standards, regulations, trade journals, or process guides germane to the product or service to be acquired.  Identify any professional societies or organizations that represent the market sector or advance the science and technology of the products or services comprising the marketplace.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section J: Technology Trends & Technology Insertion Opportunities', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Provide a technology assessment of the market sector as applicable to the product or service to be acquired as to:<br>
  - current state of the art employed by the government as compared to what is available in the commercial marketplace.<br>
  - known parts obsolescence and diminishing vendor impacts that could affect the current acquisition requirements and any projected life cycle sustainment efforts.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section K: Small Business Opportunities', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Provide an assessment of the potential opportunities for small business set aside and direct award opportunities as well as potential subcontracting opportunities.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section L: Terms and Conditions', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Provide an assessment of any differences between the terms and conditions offered to the government versus commercial customers.  Identify standard industry terms and conditions offered to commercial customers in the market place to include: <br>
  - warranty options<br>
  - maintenance support<br>
  - financing and discounts<br>
  - marking and packaging<br>
  - inspection and acceptance processes<br>
  - a fair/reasonable market price for the industry, which may include an assessment of available price data, price ranges, known pricing issues, or an explanation of price variations<br>
  - insured/bonded/licensed<br>
  - payment plans', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section M: Government''s Presence/Leverage In the Market', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Provide your assessment of the government’s leverage in the marketplace, such as being the only buyer, making a minority of buys in the market, making the majority of buys, or being one buyer among many. Describe the nature of other market participants, such as other governments (foreign, state/local), and commercial firms.', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'Section N: Conclusions and Recommendations', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, null, 1

insert into Question select '', 'Summarize your data analysis with recommendations for: <br>
  - acquisition strategies to pursue (i.e., 8(a), HUBZone, or Service-Disabled Veteran set-aside or sole source, small business set-aside, full and open competition, sole source award, commercial or non-commercial)<br>
  - list of potential contract vehicles that already exist which may be employed to satisfy your requirement<br>
  - quality and thoroughness of the government’s technical performance documents and configuration control data to include suggestions for improvement before contract solicitation<br>
  - relevant risks to be considered as part of any source selection activities<br>
  - for specific contract terms and conditions', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into TemplateSectionGroup select 'Section O: Market Research Techniques Used', ''
set @groupId = @@IDENTITY

insert into Section select 'I. Methods', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, @groupId, 1

insert into Question select 'Select All That Apply', '', 7, 0
set @questionId = @@IDENTITY

insert into CustomSelectAnswer
		select @questionId, 'Internet Searches', '', 1
union all select @questionId, 'Sources Sought', '', 2
union all select @questionId, 'Industry Days', '', 3
union all select @questionId, 'Request for Information (RFI)', '', 4
union all select @questionId, 'FedBizOpps', '', 5
union all select @questionId, 'One-on-One Industry Sessions', '', 6
union all select @questionId, 'Trade Journals/Shows', '', 7
union all select @questionId, 'Government Contacts (SME in specific Markets, Other People with experience with this product/service)', '', 8
union all select @questionId, 'Conducting Site Visits', '', 9
union all select @questionId, 'Contacting known source of products or services', '', 10
union all select @questionId, 'Government Databases (FPDS-NG, FAPISS, PPIRS, CPS, GSA, SBA Databases etc...)', '', 11
union all select @questionId, 'Reviewed results of recent market research on similar or identical requirements', '', 12
union all select @questionId, 'Draft Solicitation or Statement of Work', '', 13
union all select @questionId, 'Obtaining Source Lists', '', 14
union all select @questionId, 'Contacted Small Business Office', '', 15

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Question select 'Other (Please Identify):', '', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1


insert into Section select 'II. Describe the details regarding the various methods indicated above that were used to arrive at the market research findings.', ''
set @sectionId = @@IDENTITY

insert into TemplateSection select @tempId, @sectionId, @groupId, 2

insert into Question select '', '', 2, 4096
set @questionId = @@IDENTITY

insert into SectionQuestion select @sectionId, @questionId, 1";
    }
}
