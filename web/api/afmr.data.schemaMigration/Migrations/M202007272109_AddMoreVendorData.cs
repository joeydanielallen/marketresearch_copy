using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007272109, TransactionBehavior.None)]
	public class M202007272109_AddMoreVendorData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
insert into Vendor
select 'ACCURUS AEROSPACE TULSA, LLC','65462','64544224',null,'12716 E PINE ST','','TULSA','OK','74116', null, null
union all select 'ACME ENVIRONMENTAL, INC','54400','58080110',null,'2666 N DARLINGTON AVE 66','','TULSA','OK','74115', null, null
union all select 'ADVANCED MACHINING SOLUTIONS, LLC','5QTA6','832217777',null,'4703 ENTERPRISE DRIVE, SUITE A','','OKLAHOMA CITY','OK','73128', null, null
union all select 'AERO COMPONENTS, INC.','5U204','52853876',null,'535 SE 82ND ST','','OKLAHOMA CITY','OK','73149', null, null
union all select 'AERO-TEC INDUSTRIES INC','65392','119060887',null,'11990 N HIGHWAY 99','','SEMINOLE','OK','74868', null, null
union all select 'ALKO ENTERPRISES, INC.','0DJS1','181118738',null,'7416 N BROADWAY EXT STE H','','OKLAHOMA CITY','OK','73116', null, null
union all select 'ALL AMERICAN EAR MOLD LABORATORIES INC','65733','156239550',null,'625 ENTERPRISE DR STE 160','','EDMOND','OK','73013', null, null
union all select 'APPLETON GRP LLC','58YU7','1063390',null,'9810 E 42ND ST, STE 102','','TULSA','OK','74146', null, null
union all select 'APPLIED INDUSTRIAL TECHNOLOGIES, INC.','6L483','47994686',null,'1623 SE 23RD ST','','OKLAHOMA CITY','OK','73129', null, null
union all select 'ARCHER TECHNOLOGIES INTERNATIONAL, INCORPORATED','1U5F4','38552647',null,'45308 HARDESTY RD','','SHAWNEE','OK','74801', null, null
union all select 'ASES, LLC','6KCS9','969826267',null,'6015 S PORTLAND AVE','','OKLAHOMA CITY','OK','73159', null, null
union all select 'AUTOQUIP CORPORATION','12458','51922888',null,'1058 W INDUSTRIAL AVE','','GUTHRIE','OK','73044', null, null
union all select 'B & B MEDICAL SERVICES INC.','4S156','70839501',null,'4045 NW 64TH ST STE 250','','OKLAHOMA CITY','OK','73116', null, null
union all select 'B & C MACHINE COMPANY, INC.','22383','8244139',null,'8301 SW 3RD ST','','OKLAHOMA CITY','OK','73128', null, null
union all select 'BARON MANUFACTURING CO INC','010M0','877973933',null,'3100 W I 44 SERVICE RD','','OKLAHOMA CITY','OK','73112', null, null
union all select 'BATTERIES SOONER, LLC','3DZC5','31344984',null,'4100 WILL ROGERS PKWY STE 300','','OKLAHOMA CITY','OK','73108', null, null
union all select 'BENNETT, TOM MANUFACTURING','30763','7188212',null,'18 NE 48TH ST','','OKLAHOMA CITY','OK','73105', null, null
union all select 'BERENDSEN, INC.','3B169','33121641',null,'401 S BOSTON AVE STE 1200','','TULSA','OK','74103', null, null
union all select 'BOEING COMPANY, THE','43999','76200344',null,'6001 S AIR DEPOT BLVD','','OKLAHOMA CITY','OK','73135', null, null
union all select 'BOEING COMPANY, THE','82918','7237241',null,'6001 S AIR DEPOT BLVD','','OKLAHOMA CITY','OK','73135', null, null
union all select 'BRADFORD INDUSTRIAL SUPPLY CORP','3F064','33012709',null,'120 E HILL ST','','OKLAHOMA CITY','OK','73105', null, null
union all select 'BS&B SAFETY SYSTEMS, L.L.C.','32874','161521612',null,'7455 E 46TH','','TULSA','OK','74145', null, null
union all select 'C M P CORPORATION','31042','44371474',null,'4101 SE 85TH ST','','OKLAHOMA CITY','OK','73135', null, null
union all select 'CANNON & REFERMAT, L.L.C.','6WE76','65447252',null,'4601 N WALNUT AVE','','OKLAHOMA CITY','OK','73105', null, null
union all select 'CARTER AEROSPACE MANUFACTURING COMPANY LLC','3E2D6','126790828',null,'901 S JOHN ZINK AVE','','SKIATOOK','OK','74070', null, null
union all select 'CARTER CHEVROLET AGENCY, L.L.C.','61930','62273610',null,'214 W OKLAHOMA','','OKARCHE','OK','73762', null, null
union all select 'CENTRIFUGAL CASTING MACHINE CO., INC.','11325','7221773',null,'7744 NORTH OWASSO EXPY STE A','','OWASSO','OK','74055', null, null
union all select 'CFS BRANDS, LLC','1M2P6','5086491',null,'4711 E HEFNER RD','','OKLAHOMA CITY','OK','73131', null, null
union all select 'CHANDLER INSTRUMENTS COMPANY L.L.C.','5EAU5','13719166',null,'2001 N INDIANWOOD AVE','','BROKEN ARROW','OK','74012', null, null
union all select 'CHEROKEE NATION AEROSPACE AND DEFENSE, L.L.C.','57WW1','828449160',null,'470739 HIGHWAY 51','','STILWELL','OK','74960', null, null
union all select 'CHEROKEE NATION INDUSTRIES, LLC','2R431','61630554',null,'ROUTE 3 BOX 498','','STILWELL','OK','74960', null, null
union all select 'CHEROKEE NATION RED WING LLC','6VB43','78752449',null,'2777 HWY 69-A','','PRYOR','OK','74361', null, null
union all select 'CHEROKEE NATION RED WING, L.L.C.','5D1N1','829776975',null,'10838 E MARSHALL ST STE 200','','TULSA','OK','74116', null, null
union all select 'CHICKASHA MANUFACTURING CO., INC.','8U293','7188857',null,'5501 HIGHWAY 81 S','','CHICKASHA','OK','73018', null, null
union all select 'CITY CARBONIC LLC','4UZ16','33016536',null,'406 SW 4TH ST','','OKLAHOMA CITY','OK','73109', null, null
union all select 'CND, L.L.C.','0HLG5','361560576',null,'470739 HIGHWAY 51','','STILWELL','OK','74960', null, null
union all select 'COPE PLASTICS, INC.','1V201','65445355',null,'310 NE 31ST ST','','OKLAHOMA CITY','OK','73105', null, null
union all select 'CROWL MACHINE & HEAT TREATING CO.','4TXT2','7188352',null,'1632 NW 5TH ST','','OKLAHOMA CITY','OK','73106', null, null
union all select 'DELCO DIESEL SERVICES, INC.','0H1R1','82558107',null,'1100 S AGNEW AVE','','OKLAHOMA CITY','OK','73108', null, null
union all select 'DISAN ENGINEERING CORPORATION','31281','7166812',null,'101 MOHAWK DR','','NOWATA','OK','74048', null, null
union all select 'DRISCOLL AUTOMATIC CONTROL COMPANY INC','0TW10','72422496',null,'3220 S PEORIA AVE STE 101','','TULSA','OK','74105', null, null
union all select 'DUCOMMUN LABARGE TECHNOLOGIES, INC.','07618','617360219',null,'11616 E 51ST ST','','TULSA','OK','74146', null, null
union all select 'EBSCO SPRING CO. INC.','2K242','7221377',null,'4949 S 83RD E AVE','','TULSA','OK','74145', null, null
union all select 'ECRC INC','1GPL6','18499934',null,'4153 MERIDIAN RD','','ARDMORE','OK','73401', null, null
union all select 'ELECTRO ENTERPRISES, INC.','4H538','51645935',null,'3601 N I 35 SERVICE RD','','OKLAHOMA CITY','OK','73111', null, null
union all select 'ENVIRO SYSTEMS, INC.','0B9E8','50909480',null,'12037 N HWY 99','','SEMINOLE','OK','74868', null, null
union all select 'ERON CORP, THE','55853','610608739',null,'28701 S HWY 125','','AFTON','OK','74331', null, null
union all select 'EVANS ENTERPRISES, INC.','9F958','7207517',null,'6707 N INTERSTATE DR','','NORMAN','OK','73069', null, null
union all select 'FABCO WELDING & MACHINE, INC.','6TD95','60019043',null,'7512 E HWY 37','','TUTTLE','OK','73089', null, null
union all select 'FACET (OKLAHOMA) LLC','87405','21661699',null,'11607 E 43RD ST NORTH','','TULSA','OK','74116', null, null
union all select 'FEDERAL CORPORATION','4H549','7204738',null,'120 E MAIN','','OKLAHOMA CITY','OK','73104', null, null
union all select 'FLIGHTSAFETY INTERNATIONAL INC','31866','178233086',null,'700 N 9TH ST','','BROKEN ARROW','OK','74012', null, null
union all select 'FRONTIER ELECTRONIC SYSTEMS CORP.','63812','91590703',null,'4500 W 6TH AVE','','STILLWATER','OK','74074', null, null
union all select 'GENISCO FILTER CORP.','07294','74182366',null,'3100 S NORGE RD','','CHICKASHA','OK','73018', null, null
union all select 'GOVCON INC','1RFN7','843957650',null,'4801 N CLASSEN BLVD STE 126','','OKLAHOMA CITY','OK','73118', null, null
union all select 'GRAYBAR ELECTRIC COMPANY, INC.','3B196','33026204',null,'103 NE 44TH ST','','OKLAHOMA CITY','OK','73105', null, null
union all select 'GREEN COUNTRY AIRCRAFT EXHAUST INC','1GZY9','948829692',null,'1876 N 106 E AVE','','TULSA','OK','74116', null, null
union all select 'GUNNEBO JOHNSON CORPORATION','99557','194399259',null,'1240 N HARVARD AVE','','TULSA','OK','74115', null, null
union all select 'HELICOMB INTERNATIONAL, INC.','6W159','38322814',null,'1402 S 69TH EAST AVE','','TULSA','OK','74112', null, null
union all select 'HIGH PRESSURE EQUIPMENT INC.','17338','7191653',null,'7130 MELROSE LN','','OKLAHOMA CITY','OK','73127', null, null
union all select 'HOLLAND SIGNAL, INC.','0LAG2','624532826',null,'8325 NW 143RD TER','','OKLAHOMA CITY','OK','73142', null, null
union all select 'HONEYWELL AEROSPACE TULSA/LORI','63389','80578982',null,'6930 N LAKEWOOD AVE','','TULSA','OK','74117', null, null
union all select 'HUNZICKER BROTHERS, INC.','3B242','7205065',null,'501 N VIRGINIA AVE','','OKLAHOMA CITY','OK','73106', null, null
union all select 'HYDRA SERVICE INC','1HPV1','33107640',null,'12332 E 1ST ST','','TULSA','OK','74128', null, null
union all select 'IAQS INC','4E4X4','2226780',null,'3709 S MISSOURI AVE','','OKLAHOMA CITY','OK','73129', null, null
union all select 'IMAGENET CONSULTING, LLC','0LVY4','98459357',null,'913 N BROADWAY AVE','','OKLAHOMA CITY','OK','73102', null, null
union all select 'INDUSTRIAL GASKET, INC.','14890','7195035',null,'720 S SARA RD','','MUSTANG','OK','73064', null, null
union all select 'JD SUPPLY & MFG','61YT1','830926312',null,'5974 TRACY LN','','PIEDMONT','OK','73078', null, null
union all select 'JGB TECHNOLOGY INCORPORATED','061X6','932795586',null,'15208 GATEWAY GARDEN DR','','OKLAHOMA CITY','OK','73165', null, null
union all select 'KIRBY - SMITH MACHINERY, INC.','0BAH3','105889752',null,'6715 W RENO AVE','','OKLAHOMA CITY','OK','73127', null, null
union all select 'L-3 COMMUNICATIONS WESTWOOD CORPORATION','0FNW8','116211835',null,'12402 E 60TH ST','','TULSA','OK','74146', null, null
union all select 'L-3 COMMUNICATIONS WESTWOOD CORPORATION','3FEQ2','360674337',null,'12402 E 60TH ST','','TULSA','OK','74146', null, null
union all select 'L-3 COMMUNICATIONS WESTWOOD CORPORATION','58475','116337846',null,'12402 E 60TH ST','','TULSA','OK','74146', null, null
union all select 'L3 TECHNOLOGIES, INC.','63100','795771307',null,'3724 W VANCOUVER ST','','BROKEN ARROW','OK','74012', null, null
union all select 'LAMAR ENTERPRISES, INC.','0BK61','59634709',null,'4300 W RIVER PARK DR','','OKLAHOMA CITY','OK','73108', null, null
union all select 'LIMCO AIREPAIR INC.','16630','13807144',null,'5304 S LAWTON AVE','','TULSA','OK','74107', null, null
union all select 'M&M PRECISION COMPONENTS, LLC','0DZM8','80252469',null,'13914 E ADMIRAL PL STE A','','TULSA','OK','74116', null, null
union all select 'MACHINE TOOL MARKETING, INC.','0KZ21','98467715',null,'21083 S. 103RD EAST AVE','','BIXBY','OK','74008', null, null
union all select 'MALONE''S CNC MACHINING, INC.','2V045','54989991',null,'2015 E INDUSTRIAL 5 RD','','GROVE','OK','74344', null, null
union all select 'MAVERICK TECHNOLOGIES, LLC','3GA37','128817546',null,'2800 S PURDUE DR','','OKLAHOMA CITY','OK','73128', null, null
union all select 'MOTION INDUSTRIES, INC.','0JP77','122592835',null,'4116 WILL ROGERS PKWY STE 800','','OKLAHOMA CITY','OK','73108', null, null
union all select 'NAVICO, INC.','66210','7139199',null,'4500S 129TH E AVE STE200','','TULSA','OK','74134', null, null
union all select 'NECO INDUSTRIES, INC.','9S163','54586854',null,'3345 S ANN ARBOR AVE','','OKLAHOMA CITY','OK','73179', null, null
union all select 'NEWVIEW OKLAHOMA, INC.','7E931','74280983',null,'501 N DOUGLAS AVE','','OKLAHOMA CITY','OK','73106', null, null
union all select 'NORDAM GROUP LLC, THE','0J2J9','929236834',null,'7018 N LAKEWOOD AVE','','TULSA','OK','74117', null, null
union all select 'NORDAM GROUP LLC, THE','29957','148317472',null,'11200 E PINE ST','','TULSA','OK','74116', null, null
union all select 'NORTHROP GRUMMAN SYSTEMS CORPORATION','78JW8','79610750',null,'6401 S AIR DEPOT BLVD','','OKLAHOMA CITY','OK','73135', null, null
union all select 'O & L RESOURCES, INC.','1C7R0','9531497',null,'400 E 1ST ST','','CHELSEA','OK','74016', null, null
union all select 'OAI ELECTRONICS, LLC','22887','556962611',null,'6960 E 12TH ST','','TULSA','OK','74112', null, null
union all select 'OIL CAPITAL VALVE COMPANY','00515','7221146',null,'7400 E 42ND PL','','TULSA','OK','74145', null, null
union all select 'OIL FILTER CO INC','0E5Z6','62264585',null,'1410 SW 3RD ST','','OKLAHOMA CITY','OK','73108', null, null
union all select 'OKLAHOMA SAFETY EQUIPMENT COMPANY, INC.','64055','38322483',null,'1701 W TACOMA ST','','BROKEN ARROW','OK','74012', null, null
union all select 'ORIZON AEROSTRUCTURES - GROVE, INC.','4Y930','7228562',null,'500 INDUSTRIAL RD','','GROVE','OK','74344', null, null
union all select 'P-T COUPLING COMPANY','33813','7245087',null,'1414 E WILLOW RD','','ENID','OK','73701', null, null
union all select 'PADGETT MACHINE SHOP, INC.','6W037','61635082',null,'1226 N 143RD E AVE','','TULSA','OK','74116', null, null
union all select 'PD-RX PHARMACEUTICALS, INC.','0PTU3','156893695',null,'727 N ANN ARBOR','','OKLAHOMA CITY','OK','73127', null, null
union all select 'PETROLAB, L.L.C.','0DRR8','154120570',null,'2001 N INDIANWOOD AVE','','BROKEN ARROW','OK','74012', null, null
union all select 'POWER CABLE SOLUTIONS LLC','80AH3','80749370',null,'832 COUNTY STREET 2920','','TUTTLE','OK','73089', null, null
union all select 'PRECISION FLUID POWER, INC','033M9','793042003',null,'1567 EXCHANGE AVE','','OKLAHOMA CITY','OK','73108', null, null
union all select 'PRO-FAB, LLC','0BT76','27662626',null,'910 N MORGAN RD','','OKLAHOMA CITY','OK','73127', null, null

declare @vendorId int
select top 1 @vendorId = Id from Vendor where CAGECode='00515'
insert into VendorContact
select @vendorId, 'Jane Doe', null, 'jane@oilcap.com',null, null, null, null, null
union all select @vendorId, 'John Dozier', null, 'john@oilcap.com',null, null, null, null, null
union all select @vendorId, 'Barry Allen', null, 'flash@oilcap.com',null, null, null, null, null

insert into VendorPart
select @vendorId,'200718', '2040016625779', 'DRAIN,AUTOMATIC,BOAT'


select top 1 @vendorId = Id from Vendor where CAGECode='43999'
insert into VendorContact
select @vendorId, 'Karen Doe', null, 'karen@boeing.com',null, null, null, null, null
union all select @vendorId, 'Barry White', null, 'barryw@boeing.com',null, null, null, null, null
union all select @vendorId, 'Barry Allen', null, 'flash@boeing.com',null, null, null, null, null

insert into VendorPart
select @vendorId,'200718', '1005006989618', 'ACTUATOR ASSY,SWITCH'

";
	}
}
