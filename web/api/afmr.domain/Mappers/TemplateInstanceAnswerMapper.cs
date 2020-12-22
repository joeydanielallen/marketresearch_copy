using afmr.data.Models.Template;
using afmr.domain.Internal.Models.Sustainment.PdfService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static IEnumerable<data.Models.Template.TemplateInstanceAnswer> Map (this IEnumerable<model.Research.TemplateInstanceAnswer> model)
        {
            if (model == null) return null;

            var data = new List<data.Models.Template.TemplateInstanceAnswer>();

            foreach (var item in model)
            {
                var dataModel = new data.Models.Template.TemplateInstanceAnswer();
                dataModel.AnswerGroupIndex = item.AnswerGroupIndex;
                dataModel.AnswerValue = item.AnswerValue;
                dataModel.Id = item.Id;
                dataModel.SectionQuestionId = item.SectionQuestionId;
                dataModel.TemplateInstanceId = item.TemplateInstanceId;
                dataModel.TemplateSectionId = item.TemplateSectionId;

                data.Add(dataModel);
            }

            return data;
        }

//TODO Replace with dynamic,data driven mapping
        public static Root MapToRoot(this IEnumerable<data.Models.Template.TemplateInstanceAnswer> data)
        {
            if (data == null)
                return null;

            var answers = data.ToList();

            var pdf = new Root();

            pdf.a = new A();
            pdf.a.cage = GetFormValue(FormIds.SectionA, FormIds.QuestionContractActivityOrg, answers);
            pdf.a.id = GetFormValue(FormIds.SectionA, FormIds.QuestionPRNumber, answers);
            pdf.a.name = GetFormValue(FormIds.SectionA, FormIds.QuestionProjectName, answers);
            pdf.a.cost = GetFormValue(FormIds.SectionA, FormIds.QuestionEstimatedCost, answers);
            if(!string.IsNullOrWhiteSpace(pdf.a.cost))
            {
                pdf.a.cost = "$" + pdf.a.cost;
            }
            pdf.a.report_dt = GetFormValue(FormIds.SectionA, FormIds.QuestionReportDate, answers);
            pdf.a.end = GetFormValue(FormIds.SectionA, FormIds.QuestionMREndDate, answers);
            pdf.a.naics = GetFormValue(FormIds.SectionA, FormIds.QuestionNAICS, answers);
            pdf.a.period = GetFormValue(FormIds.SectionA, FormIds.QuestionProjectPerformancePeriod, answers);
            pdf.a.psc = GetFormValue(FormIds.SectionA, FormIds.QuestionPscFsc, answers);
            pdf.a.start = GetFormValue(FormIds.SectionA, FormIds.QuestionMRStartDate, answers);
            
            pdf.b = GetFormValue(FormIds.SectionB, FormIds.QuestionProductOrServiceDescription, answers);
            pdf.c = GetFormValue(FormIds.SectionC, FormIds.QuestionShortNarrative, answers);
            pdf.d = GetFormValue(FormIds.SectionD, FormIds.QuestionPerformanceRequirements, answers);

            pdf.e = new E();
            pdf.e.edu = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionEducationalInstituteCount, answers);
            pdf.e.edwosb = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizEDWOSBCount, answers);
            pdf.e.Eighta = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBiz8aCount, answers);
            pdf.e.general = GetFormValue(FormIds.SectionIGeneral, FormIds.QuestionSoleSourceVendorSurvey, answers);
            pdf.e.govt = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionGovtEntityCount, answers);
            pdf.e.hub = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizHUBCount, answers);
            pdf.e.large = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionLargeBizCount, answers);
            pdf.e.native = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizNativeCount, answers);
            pdf.e.nonprofit = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionNonProfitCount, answers);
            pdf.e.other = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionOtherCount, answers);
            pdf.e.sdb = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizSDBCount, answers);
            pdf.e.sdvosb = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizSDVOSBCount, answers);
            pdf.e.vet = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizVeteranCount, answers);
            pdf.e.wosb = GetFormValue(FormIds.SectionIIProcessInfo, FormIds.QuestionSmallBizWOSBCount, answers);
            pdf.e.vendors = new List<Vendor>();            
            pdf.e.small = SumValues(pdf.e.edwosb, pdf.e.Eighta, pdf.e.hub, pdf.e.native, pdf.e.sdb, pdf.e.sdvosb, pdf.e.vet, pdf.e.wosb);

            var allVendorDataAnswers = data
                .Where(e => e.TemplateSection.GlobalId == FormIds.SectionIIIVendorInfo)
                .OrderBy(e => e.AnswerGroupIndex)
                .GroupBy(e => e.AnswerGroupIndex);

            foreach (var items in allVendorDataAnswers)
            {
                var vendorAnswers = items.Select(e => e).ToList();
                var vendor = new Vendor();
                vendor.CAGE = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorCageDuns, vendorAnswers);
                vendor.caps = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorCapabilites, vendorAnswers);
                vendor.group = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorSocioeconomicStatus, vendorAnswers);
                vendor.loc = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorLocation, vendorAnswers);
                vendor.name = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorName, vendorAnswers);
                vendor.past = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorPerformance, vendorAnswers);
                vendor.poc = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorContact, vendorAnswers);

                pdf.e.vendors.Add(vendor);
            }

            pdf.f = GetFormValue(FormIds.SectionF, FormIds.QuestionListAvailableInfo, answers);
            pdf.g = GetFormValue(FormIds.SectionG, FormIds.QuestionRegulationsOrCertification, answers);
            pdf.h = GetFormValue(FormIds.SectionH, FormIds.QuestionStreamlineAcquisitionPotential, answers);
            pdf.i = GetFormValue(FormIds.SectionI, FormIds.QuestionIndustryInfo, answers);
            pdf.j = GetFormValue(FormIds.SectionJ, FormIds.QuestionTechAssessment, answers);
            pdf.k = GetFormValue(FormIds.SectionK, FormIds.QuestionSmallBizAssessment, answers);
            pdf.l = GetFormValue(FormIds.SectionL, FormIds.QuestionTermsConditionDifferences, answers);
            pdf.m = GetFormValue(FormIds.SectionM, FormIds.QuestionGovtMarketLeverage, answers);
            pdf.n = GetFormValue(FormIds.SectionN, FormIds.QuestionRACQAnalysis, answers);

            pdf.o = new O();
            pdf.o.describe = GetFormValue(FormIds.SectionDescribeMethods, FormIds.QuestionStrategyDetails, answers);
            pdf.o.extra = GetFormValue(FormIds.SectionIMethods, FormIds.QuestionOtherMethods, answers);
            
            pdf.o.checks = new List<int>();

            var customSelectAnswers = answers.Where(e => e.TemplateSection.GlobalId == FormIds.SectionIMethods && e.SectionQuestion.GlobalId == FormIds.QuestionSelectAllApply).ToList();

            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionInternet)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionSourcesSought)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionIndustryDays)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionRFI)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionFedBizOps)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionIndustrySessions)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionTradeJournalsShows)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionGovtContacts)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionSiteVisit)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionContactKnownSource)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionGovtDBs)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionPriorResearch)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionSoW)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionSourceLists)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(customSelectAnswers.Any(e => e.AnswerValue == e.SectionQuestion.Question.CustomSelectAnswers.FirstOrDefault(a => a.GlobalId == FormIds.QuestionSBAOffice)?.Id.ToString()) ? 1 : 0);
            pdf.o.checks.Add(string.IsNullOrWhiteSpace(pdf.o.extra) ? 0 : 1);

            pdf.p = new P()
            {
                co = new Co() { date = "2020-09-30", name = "co name", rank = "co rank", title = "co title" },
                pm = new Pm() { date = "2020-09-30", name = "pm name", rank = "pm rank", title = "pm title" }
            };

            return pdf;
        }

        private static string SumValues(params string[] integerValues)
        {
            if(integerValues == null || integerValues.Length < 1)
            {
                return string.Empty;
            }

            int sum = 0;
            int value;
            foreach (var item in integerValues)
            {
                if(int.TryParse(item, out value))
                {
                    sum += value;
                }
            }

            return sum.ToString();
        }

        internal static string GetFormValue(
            string sectionGlobalId,
            string questionGlobalId,
            List<data.Models.Template.TemplateInstanceAnswer> answers)
        {
            var value = answers.FirstOrDefault(e => 
                e.TemplateSection.GlobalId == sectionGlobalId && 
                e.SectionQuestion.GlobalId == questionGlobalId);

            if (value == null)
            {
                return string.Empty;
            }

            if (value.SectionQuestion.Question.QuestionTypeId == QuestionTypes.Date)
            {
                if (DateTime.TryParse(value.AnswerValue, out var date))
                {
                    //shud b n UTC, use CST for now
                    date.AddHours(-5);
                    return date.ToString("yyyy-MM-dd");
                }
            }

            return value.AnswerValue ?? string.Empty;
        }

        internal struct FormIds
        {
            public const string SectionA = "CF6B2E05-BDAB-464D-8025-677D6B8A1662";
            public const string QuestionContractActivityOrg = "82C82765-233F-4D96-8C60-E733360F19B9";
            public const string QuestionProjectName = "674D0E30-C94A-4C46-9B6B-1479029AA855";
            public const string QuestionReportDate = "7E896EFC-1BA2-4B04-9617-B1303951BF22";
            public const string QuestionMRStartDate = "254386ED-C553-48E3-A9F6-F1ADCBCBB29E";
            public const string QuestionMREndDate = "AECA3AD0-1F8E-41FA-9DFC-B6C689018431";
            public const string QuestionPRNumber = "E8D121E6-4CDB-446E-85FD-05F18EDA1C81";
            public const string QuestionEstimatedCost = "0D699D81-8FE5-49B9-A3E3-F24D4914916C";
            public const string QuestionProjectPerformancePeriod = "193D16AF-3BA9-4FD7-9B8E-8B64138D13C7";
            public const string QuestionNAICS = "B8B56909-0543-41FD-AD96-56F9F363EB38";
            public const string QuestionPscFsc = "67270B26-1195-41C1-A434-9C902BADCF34";

            public const string SectionB = "D13ED3C9-87A4-46D7-86BD-AC57A2DA4E97";
            public const string QuestionProductOrServiceDescription = "30988158-4F5D-4CD2-B943-F87A52A920E3";

            public const string SectionC = "B4917E20-4C13-484C-95C6-0C28780236A5";
            public const string QuestionShortNarrative = "1205FD8E-B9EE-4E16-9C8C-CC3843FBE359";

            public const string SectionD = "43644DDB-611D-45E1-9BBF-C3BB94AB5AB3";
            public const string QuestionPerformanceRequirements = "222714F4-8028-4946-A538-2669392C3792";

            public const string SectionIGeneral = "510889C4-F15D-4EDF-86AD-609A99D71139";
            public const string QuestionSoleSourceVendorSurvey = "E29BD5B5-FD45-4AF0-91E0-784E28E40938";

            public const string SectionIIProcessInfo = "10A61014-2457-42E7-8F52-A58B3488B28F";
            public const string QuestionLargeBizCount = "1AF3F881-54BE-4EB0-908E-5F22F449A7BE";
            public const string QuestionEducationalInstituteCount = "AF6A11BA-FF43-4100-9427-F03C972D6F0E";
            public const string QuestionNonProfitCount = "A36DE3E4-1702-42B8-A551-DB34A0EC2942";
            public const string QuestionGovtEntityCount = "04A17ED9-E575-4494-BEB5-00D9804D7790";
            public const string QuestionSmallBizSDBCount = "9D0A73ED-92E5-4A0B-85D4-361DAEF9F56D";
            public const string QuestionSmallBizEDWOSBCount = "20868339-0A53-4294-B01D-55D6DE76BD3C";
            public const string QuestionSmallBizWOSBCount = "3370C3B7-3DFC-411D-BA9A-0E1F2D8AF248";
            public const string QuestionSmallBiz8aCount = "26E7017A-94F1-4394-8572-E08C9B334501";
            public const string QuestionSmallBizHUBCount = "1456A762-D283-4095-BE48-A8AE58637327";
            public const string QuestionSmallBizVeteranCount = "47B07279-232F-457F-846F-D5AD7C4CCE98";
            public const string QuestionSmallBizSDVOSBCount = "39BA33EE-2D53-4607-8EC2-E1D387628B37";
            public const string QuestionSmallBizNativeCount = "0E9B66DB-BE16-4C31-A319-25139610A8AF";
            public const string QuestionOtherCount = "E625EB59-F5F6-4FA6-8C08-8160D06F3223";

            public const string SectionIIIVendorInfo = "579F17D5-E11C-4914-B9D6-FEFF5D76790C";
            public const string QuestionVendorName = "9577B06A-100F-4E4D-926A-868BDA9EBD74";
            public const string QuestionVendorCageDuns = "FA41B94F-07F5-4557-988C-EFE582276040";
            public const string QuestionVendorSocioeconomicStatus = "D56F6C9C-0095-477C-AB7E-07D3606EE374";
            public const string QuestionVendorLocation = "F6A5908D-F064-4830-BBED-17EF48E563D3";
            public const string QuestionVendorContact = "1148C6C4-4D99-4A78-BAA0-3DB9D41725C2";
            public const string QuestionVendorPartNumber = "39BFD151-12EE-4F19-AEAC-5B1068630276";
            public const string QuestionVendorCapabilites = "C44B183D-F0D5-4DBB-BE94-9BC230BAE145";
            public const string QuestionVendorPerformance = "950F8B2A-661E-4914-A144-48C6A78533D4";
            public const string QuestionVendorId = "F37DC819-6B30-4834-86B0-BBE2967F2509";


            public const string SectionF = "62A8D336-812F-4432-94FD-D9ED1CC1D4BF";
            public const string QuestionListAvailableInfo = "D2841F81-6BDF-4644-88EB-C919A1E12B83";

            public const string SectionG = "4D084A15-3916-45A4-8F68-A8C9ECEDDB50";
            public const string QuestionRegulationsOrCertification = "0B6E52F8-E677-4579-AB52-93BEDD0059E9";

            public const string SectionH = "2C6912EF-EE9A-4774-A1F5-0F5AF4215102";
            public const string QuestionStreamlineAcquisitionPotential = "7DA58437-28CE-4BE0-8E4A-F8A630AED4FC";

            public const string SectionI = "434E0C06-E241-4FBA-83D2-44EBA54A208A";
            public const string QuestionIndustryInfo = "37F1DE90-6301-458F-B0CA-8B539681FFBA";

            public const string SectionJ = "893057F4-2248-4856-85F4-E6D67194383E";
            public const string QuestionTechAssessment = "860D50A7-B31A-462C-AFAD-87E49855E211";

            public const string SectionK = "F646C2B8-A33C-490D-9616-01CBF21204DB";
            public const string QuestionSmallBizAssessment = "AF9F127D-EA3A-491B-AA05-8F080BF92E0F";

            public const string SectionL = "34A7FB50-EB44-429B-B836-D370FC2EF4E2";
            public const string QuestionTermsConditionDifferences = "3A6F6B3D-E809-4BDC-A034-5F3D195E969C";

            public const string SectionM = "475B234B-3FC8-4AC5-AA48-C5F9E245203F";
            public const string QuestionGovtMarketLeverage = "67B5C082-2DDD-40E6-8370-C08B6E0A8A00";

            public const string SectionN = "141E415A-114C-4912-96CF-5E200AD9B9FD";
            public const string QuestionRACQAnalysis = "43F2FCB1-C6EE-425E-8DC8-D90BEF151B5A";

            public const string SectionIMethods = "A9C123E4-889A-4CDE-9259-5EA09D20EB76";
            public const string QuestionSelectAllApply = "CC15EAB1-BC99-4726-95A3-761B5FB3B382";

            public const string QuestionInternet = "4AFE5295-D4B5-4C2B-A824-35FFEF2E57AB";
			public const string QuestionSourcesSought = "391DB4F9-4721-416C-8DC8-9C2F6027D619";
            public const string QuestionIndustryDays = "76C873F1-AB1E-4F1E-A591-1AEADE971753";
            public const string QuestionRFI = "935CBEE6-A89D-4713-818C-36CB226ADFF1";
            public const string QuestionFedBizOps = "6B51B0F1-6829-4DDD-996B-1E63198C0CFA";
            public const string QuestionIndustrySessions = "3C493053-B3B5-4B76-8533-94725C11C921";
            public const string QuestionTradeJournalsShows = "CFCE8697-0102-4B9F-8A3D-91BA5512072C";
            public const string QuestionGovtContacts = "D4F441BD-3F42-4FDD-906B-2DB6C91B18A2";
            public const string QuestionSiteVisit = "3CB299D8-8BA4-4547-9B2A-DC14A98EA750";
            public const string QuestionContactKnownSource = "A2CE1BE3-37B5-4750-A04D-535F2E9F7AA0";
            public const string QuestionGovtDBs = "13BC599B-4848-4F0A-952F-B93E5805DC02";
            public const string QuestionPriorResearch = "C1318CD1-78B6-476E-8305-5A3DCCBF1C74";
            public const string QuestionSoW = "2DCE105C-30AE-43CE-BA6A-23073AA325CD";
            public const string QuestionSourceLists = "660B3A86-CAA8-40FE-A80E-B06B8FFCB895";
            public const string QuestionSBAOffice = "172F38D2-07A9-472D-B7EF-6BFDCF88DE39";

            public const string QuestionOtherMethods = "1644F465-9DC1-4E37-B3C3-7E676376F155";

            public const string SectionDescribeMethods = "8AE477D8-FF02-473D-9298-D56E3E65FD91";
            public const string QuestionStrategyDetails = "92DA8715-17F5-4F3F-9961-3C1AC2829F0E";
        }
    }
}
