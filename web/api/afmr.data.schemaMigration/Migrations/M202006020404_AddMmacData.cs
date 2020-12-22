using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006020404, TransactionBehavior.None)]
	public class M202006020404_AddMmacData : Migration
	{
		public override void Up()
		{
			Execute.Sql(insertSql);
		}

		public override void Down()
		{
			Delete.FromTable("MaterialMgmtAggregateCode").AllRows();
		}

		private string insertSql = @"
INSERT INTO MaterialMgmtAggregateCode
	select 'AA', 0 ,'TG','AIM-4 MISSILE'
union all select 'AB', 0 ,'TG','AIM-9 (SIDE WINDER)'
union all select 'AD', 0 ,'SU','SPACE SUPPORT PROGRAM (SSP)'
union all select 'AE', 0 ,'SU','LGM-25C/LV-4 (TITAN II)'
union all select 'AH', 0 ,'SU','LGM-30 MINUTEMAN'
union all select 'AI', 0 ,'SU','ADVANCED INTERCONTINENTAL BALLISTIC (MX)'
union all select 'AJ', 0 ,'SU','AEROJET ENGINES & COMPONENTS LR-87, LR-91'
union all select 'AK', 0 ,'TG','AGM-12/ATM-12 (BULLPUP)'
union all select 'AL', 0 ,'TG','ADVANCE MEDIUM RANGE AIR-TO-AIR MISSILE'
union all select 'AM', 0 ,'SU','LGM-30G'
union all select 'AN', 0 ,'SX','CONTAINERS FOR OCALC-MANAGED JET ENGINE (FSC 8145)'
union all select 'AO', 0 ,'TG','AGM-88 HIGHSPEED ANTI-RADIATION MISSILE (HARM)'
union all select 'AQ', 0 ,'SU','AMMUNITION AND EXPLOSIVES'
union all select 'AS', 0 ,'SU','LGM-30G TRAINER'
union all select 'AT', 0 ,'SX','ADVANCED CRUISE MISSILE INTEGRATION (ACMI)'
union all select 'AU', 0 ,'SX','WHOLE UP AIRCRAFT'
union all select 'AV', 0 ,'SU','SMALL ICBM SYSTEM'
union all select 'AW', 0 ,'SX','AIRBORNE WARNING AND CONTROL SYSTEM (AWACS) 411L'
union all select 'AY', 0 ,'TG','FIRE CONTROL AND BOMBING SYSTEMS'
union all select 'BA', 1 ,'TB','C-17 PROGRAM'
union all select 'BC', 0 ,'SU','C-131/T-29 SAMARITAN/FLYING CLASSROOM'
union all select 'BD', 0 ,'SU','U-10 COURIER'
union all select 'BE', 1 ,'TB','C-17 ENGINE'
union all select 'BF', 0 ,'SU','F-4 (PHANTOM II)'
union all select 'BG', 0 ,'SU','PARTS COMMON, MCDONNEL (FSC 1560)'
union all select 'BH', 0 ,'SU','F-102 DELTA DAGGER'
union all select 'BJ', 0 ,'SU','F-111'
union all select 'BK', 0 ,'SU','F-106 DELTA DART'
union all select 'BL', 0 ,'TG','AIM-7 (SPARROW)'
union all select 'BM', 0 ,'SU','DEFENSE METEOROLOGICAL SATELLITE PROGRAM'
union all select 'BN', 0 ,'SU','A-1 SKYRAIDER'
union all select 'BO', 0 ,'SX','BREATHING OXYGEN SYSTEMS AND COMPONENT'
union all select 'BP', 0 ,'SU','U-17 INCLUDES MAP CESSNA 150/180'
union all select 'BQ', 1 ,'TN','B-2 TSSP, NORTHROP GRUMMAN'
union all select 'BR', 0 ,'SU','FB-111'
union all select 'BS', 0 ,'SU','GLOBAL BROADCAST SERVICE'
union all select 'BT', 0 ,'TG','FIRE FIGHTING EQUIPMENT'
union all select 'BU', 0 ,'TG','PERSONAL SAFETY EQUIPMENT'
union all select 'BV', 0 ,'TB','OSPREY CV-22 TILT-ROTOR AIRCRAFT'
union all select 'BW', 0 ,'SU','JOINT STANDOFF WEAPON (JSOW) SYSTEM'
union all select 'BX', 0 ,'SU','C-7A (CV-2) CARIBOU'
union all select 'BY', 0 ,'TG','AIRBORNE COMMUNICATION EQUIPMENT'
union all select 'BZ', 0 ,'TG','H-53 SEASTALLION'
union all select 'CA', 0 ,'SJ','COMMUNICATIONS SECURITY (COMSEC) SERIALIZED CONTROL ITEM'
union all select 'CB', 0 ,'SU','F-104G STARFIGHTER'
union all select 'CC', 0 ,'TG','ELECTRONIC SUPPORT SYSTEM FOR E-3 AIRCRAFT'
union all select 'CD', 0 ,'SU','WS314A MK1 MOD O GUIDED WEAPON (WALLEYE)'
union all select 'CE', 0 ,'SJ','INTEL PRODUCTS'
union all select 'CG', 0 ,'SU','O-2A CESSNA SUPER SKYMASTER'
union all select 'CH', 0 ,'TG','AGM-78A, ATM-78A'
union all select 'CI', 0 ,'SJ','CRYPTOLOGIC ITEM OTHER THAN COMMUNICATIONS SECURITY (COMSEC) ITEMS'
union all select 'CJ', 0 ,'SX','AGM-69 SRAM'
union all select 'CM', 0 ,'SC','NUCLEAR ORDNANCE MATERIEL'
union all select 'CN', 0 ,'SX','TF-41 ENGINE'
union all select 'CP', 0 ,'SU','MICROWAVE COMMAND GUIDANCE PROGRAM (AN/UPQ-3)'
union all select 'CQ', 0 ,'TV','BALLISTIC MISSILE EARLY WARNING SYSTEM'
union all select 'CS', 0 ,'SJ','COMMUNICATIONS SECURITY (COMSEC) OTHER THAN SERIALIZED CONTROL ITEM'
union all select 'CT', 0 ,'TG','463L MATERIELS HANDLING SYSTEM'
union all select 'CU', 0 ,'TG','MISCELLANEOUS CLASSES (POTENTIAL CUSTODIAN)'
union all select 'CW', 0 ,'TG','AIRBORNE RADAR AND MISCELLANEOUS ELECTRONIC EQUIPMENT'
union all select 'CX', 0 ,'TG','AIRBORNE COMMUNICATIONS AND NAVIGATION EQUIPMENT'
union all select 'CY', 0 ,'TG','UR-ALC SERIAL CONTROL FOR CCI'
union all select 'CZ', 0 ,'SU','440L HF FORWARD SCATTER RADAR'
union all select 'DC', 0 ,'SU','C-47/C-117 SKYTRAIN'
union all select 'DE', 0 ,'SU','C-54 SKYMASTER'
union all select 'DF', 0 ,'TG','H-34 CHOCTAW'
union all select 'DG', 0 ,'TV','PRECISION ACQUISITION VEHICLE ENTRY PHASED ARRAY WARNING SYSTEM'
union all select 'DH', 0 ,'SU','C-118/DC-6B LIFTMASTER'
union all select 'DI', 0 ,'TO','DIRECTIONAL INFRARED COUNTERMEASURE SYSTEM'
union all select 'DM', 0 ,'SU','AGM. 15&A, JOINT AIR TO SURFACE STAND OFF MISSILE'
union all select 'DN', 1 ,'TM','RQ-4A'
union all select 'DO', 0 ,'SU','QF-4 DRONE PROGRAM'
union all select 'DU', 0 ,'SU','BDU 36/38/46 ITEMS'
union all select 'DZ', 0 ,'SU','QU-22'
union all select 'EA', 0 ,'TG','E-8/B JOINT STARS AIRCRAFT'
union all select 'EE', 0 ,'TG','AIR TRANSPORTABLE AIRLIFT CONTROL ELEMENT (PROJECT SEEK LIFT/SEEK CARGO/SEEK ALICE)'
union all select 'EF', 0 ,'SX','ENHANCED FLIGHT SCREENER AIRCRAFT'
union all select 'EH', 0 ,'SX','ELECTRONIC COMPONENTS'
union all select 'EI', 0 ,'SU','PHOTONIC/ELECTRONIC IMAGE'
union all select 'EJ', 0 ,'TG','BARE BASE MOBILE SHELTERS/EQUIPMENT'
union all select 'EK', 0 ,'SX','B-1'
union all select 'EN', 0 ,'TV','BMEWS AND PAVE-PAWS COMBINATION'
union all select 'ES', 0 ,'SU','CARTRIDGE AND PROPELLANT ACTUATED DEVICES'
union all select 'EV', 0 ,'SU','OV-10A BRONCO'
union all select 'EW', 0 ,'TG','AIRBORNE ELECTRONIC WARFARE EQUIPMENT'
union all select 'EX', 0 ,'TG','PECULIAR NONSTANDARD ELECTRONIC WARFARE ITEMS'
union all select 'FB', 0 ,'SU','CIM-10 BOMARC'
union all select 'FC', 0 ,'SX','C-22 AIRCRAFT'
union all select 'FD', 0 ,'SU','ELECTRONIC WARFARE EQUIPMENT, NON-AIRBORNE'
union all select 'FE', 0 ,'TG','AIRCRAFT BATTLE DAMAGE REPAIR PROGRAM'
union all select 'FF', 0 ,'SX','KC-10 EXTENDER'
union all select 'FG', 0 ,'SX','B-52 STRATO FORTRESS'
union all select 'FH', 0 ,'SX','C-97 STRATO FREIGHTER'
union all select 'FJ', 0 ,'SU','A-10 SPECIALIZED CLOSE SUPPORT AIRCRAFT'
union all select 'FK', 0 ,'SX','MISCELLANEOUS AIRCRAFT COMPONENTS'
union all select 'FL', 0 ,'SX','C-135 STRATOLIFTER'
union all select 'FM', 0 ,'SX','B-747 AF1'
union all select 'FN', 0 ,'TG','COMMUNICATIONS EQUIPMENT /NON-AIRBORNE (FROZEN)'
union all select 'FO', 0 ,'SU','FIBER OPTICS COMPONENTS'
union all select 'FP', 0 ,'TG','DEFENSE COMMUNUCATION SYSTEM'
union all select 'FR', 1 ,'TL','F-22 AIRCRAFT'
union all select 'FT', 0 ,'SU','CENTRAL TANK MANAGEMENT'
union all select 'FW', 0 ,'SX','B-2 AIRCRAFT'
union all select 'FX', 0 ,'TG','F-15 EAGLE'
union all select 'FZ', 0 ,'SU','F22 WEAPON SYSTEM'
union all select 'GA', 0 ,'TG','H-1 IROQUOIS'
union all select 'GB', 0 ,'SU','HU-16 ALBATROSS'
union all select 'GC', 0 ,'TG','UH/60A BLACKHAWK'
union all select 'GD', 0 ,'SU','GROUND DETECTION SENSORS'
union all select 'GF', 0 ,'SX','AGM-86 AIR LAUNCHED CRUISE MISSILE (ALCM)'
union all select 'GG', 0 ,'TG','GUNNERY EQUIPMENT'
union all select 'GI', 0 ,'TG','TACTICAL SATELLITE COMMUNICATION PROGRAM'
union all select 'GK', 0 ,'SX','FSC 1560 ITEMS NOT ELSEWHERE MMAC CODED'
union all select 'GL', 0 ,'SX','GROUND LAUNCHED CRUISE MISSILE (GLCM)'
union all select 'GM', 0 ,'TV','PERIMETER ACQUISITION RADAR ATTACK CHARACTERIZATION SYSTEM'
union all select 'GN', 0 ,'SX','CONVENTIONAL AIR LAUNCHED CRUISE MISSLE (CALCM)'
union all select 'GO', 0 ,'SU','GPS OCS'
union all select 'GP', 0 ,'SU','A-37 A/B'
union all select 'GR', 0 ,'TG','GLOBAL POSITIONING SYSTEM-RANGE APPLICATIONS PROGRAM/TEST INSTRUMENTATIONS DEVELOPMENT SYSTEM'
union all select 'GU', 0 ,'SU','F-101 VOODOO'
union all select 'GW', 0 ,'SU','C-121 CONSTELLATION'
union all select 'GX', 0 ,'TG','MQM/107B TARGET SYSTEM'
union all select 'GY', 0 ,'TG','BQM-34 FIREBEE'
union all select 'HB', 0 ,'SX','ADM-20 QUAIL'
union all select 'HC', 0 ,'SX','AGM-28 HOUND DOG'
union all select 'HD', 0 ,'SX','MISCELLANEOUS MISSILE COMPONENTS'
union all select 'HF', 0 ,'SU','A-7 CORSAIR II'
union all select 'HH', 0 ,'TG','CH-47 CHINOOK'
union all select 'HJ', 0 ,'SU','MILSTAR'
union all select 'HK', 0 ,'SX','NATIONAL AIRSPACE SYSTEM PLAN'
union all select 'HL', 0 ,'TG','TH-1H SUPT HELICOPTER'
union all select 'HM', 0 ,'SU','NON-MEDICAL BASE 86 ITEMS'
union all select 'HN', 0 ,'SU','HAVE NAPAGM/142A'
union all select 'HQ', 0 ,'TG','AIR TO AIR RECOVERY SYSTEMS'
union all select 'HR', 0 ,'SX','AGM-84 HARPOON MISSILE'
union all select 'HS', 0 ,'SX','AIRCRAFT HYDRAULIC SYSTEMS AND COMPONENTS'
union all select 'HX', 0 ,'SX','ELECTRICAL AND ELECTRONICS COMPONENTS'
union all select 'HY', 0 ,'SX','ELECTRICAL CONTROL & DISTRIBUTION EQUIPMENT AIRBORNE, ELECTRICAL GENERATORS'
union all select 'HZ', 0 ,'SU','POWER CONDITIONING PCCIE PROGRAM'
union all select 'IC', 1 ,'TL','LARGE AIRCRAFT INFRARED COUNTERMEASURES'
union all select 'ID', 0 ,'TG','GENERATORS AND GENERATOR SETS, GROUND'
union all select 'IF', 0 ,'TG','GROUND ELECTRONICS CONTROL SYSTEMS 412L USAF AIR CONTROL, SYSTEMS GROUND CONTROL PROJECTS'
union all select 'IM', 0 ,'SX','GROUND NAVIGATION AIDS NAVAIDS PROJECTS, 404L TRAFFIC CONTROL, APPROACH AND LANDING SYSTEM (TRACLS)'
union all select 'IN', 0 ,'SX','ENGINES, COMPLETE'
union all select 'IQ', 0 ,'TG','USREDCOM COMMAND AND CONTROL SYSTEM'
union all select 'IV', 0 ,'TG','GROUND ELECTRONIC MISCELLANEOUS C-E PROJECTS'
union all select 'IY', 0 ,'TG','GROUND RADIO COMMUNICATIONS, GROUND COMMUNICATIONS PROJECTS, COMPASS LINK DEFENSE SATELLITE COMMUNICATIONS SYSTEM (DSCS) 439L, COMMUNICATION SYSTEM. 469L, CONVERSION OF RANGE TELEMETRY SYSTEM (CORTS) 484L, MOBILE SECURE VOICE SYSTEM, 484N, PACIFIC AREA COMMUNICATION SYSTEM 486L, EUROPEAN WIDEBAND RADIO RELAY SYSTEM, 487L, SURVIVAL LOW FREQUENCY SYSTEM, 487M, VLF/LF SPECIAL PURPOSE COMMUNICATIONS SYSTEM, 488L, GREEN PINE SYSTEM, 489L, FOX-THULE TROPO SYSTEM, 490L DCS AUTOVON (OVERSEAS) SYSTEM, 439L, SECURE V'
union all select 'IZ', 0 ,'SX','SATELLITE DATA RELAY SYSTEM'
union all select 'JA', 0 ,'TV','GROUND-BASED ELECTRO-OPTICAL DEEP-SPACE SURVEILLANCE SYSTEM'
union all select 'JB', 0 ,'SU','AGM-65A MAVERICK'
union all select 'JC', 0 ,'SU','H-43 HUSKIE'
union all select 'JD', 0 ,'SU','BOMB DIRECTING SYSTEMS AN/MSQ-77 BOMB DIRECTING CENTRAL, RADAR AN/TSQ-81 BOMB DIRECTING CENTRAL, RADAR AN/TSQ-96 BOMB DIRECTING CENTRAL, RADAR'
union all select 'JE', 0 ,'SU','MAVERICK MISSILE UPROUNDS'
union all select 'JF', 0 ,'SX','F-101 ENGINE'
union all select 'JG', 0 ,'SU','AGM-130'
union all select 'JH', 0 ,'TG','C-141 STARLIFTER'
union all select 'JJ', 0 ,'SU','FSG 14, FSC 4935 ITEMS NOT ELSEWHERE MMAC CODED'
union all select 'JL', 0 ,'SU','SWITCHBLADE'
union all select 'JM', 0 ,'SU','GRIFFIN - CAPTIVE AIR TRAINING MISSILE'
union all select 'JP', 0 ,'SU','FSC 2810 ITEMS NOT ELSEWHERE MMAC CODE'
union all select 'JQ', 0 ,'TG','FSC 1520 AND 1615 ITEMS NOT ELSEWHERE'
union all select 'JS', 0 ,'SU','SPECIALIZED PRINTED CIRCUIT BOARD AND MICROCIRCUIT MANUFACTURING MACHINERY'
union all select 'JT', 0 ,'SU','RIGID WALL SHELTERS'
union all select 'JU', 0 ,'SX','F118-GE-100 ENGINE'
union all select 'JV', 0 ,'SX','CONTAINERS FOR SAALC-MANAGED JET ENGINES -8145'
union all select 'JW', 0 ,'TG','CHEMICAL WARFARE DEFENSE'
union all select 'JX', 0 ,'TG','AIRCRAFT MAINTENANCE EQUIPMENT'
union all select 'JY', 0 ,'SX','MISCELLANEOUS AIRCRAFT ACCESSORIES AND SYSTEMS'
union all select 'JZ', 0 ,'TG','GENERAL PURPOSE AUTOMATIC DATA PROCESSING EQUIPMENT, SOFTWARE, SUPPLIES AND SUPPORT EQUIPMENT'
union all select 'KA', 0 ,'SJ','RB-57F CANBERRA'
union all select 'KC', 0 ,'SJ','B-57 CANBERRA'
union all select 'KD', 0 ,'SU','SPACE SUPPORT PROGRAM'
union all select 'KH', 0 ,'TG','AQM-34'
union all select 'KO', 0 ,'SX','PARTS COMMON, DOUGLAS, (FSC 1560)'
union all select 'KQ', 0 ,'TV','UPGRADE EARLY WARNING SYSTEM (UEWS)'
union all select 'KR', 0 ,'SX','MISCELLANEOUS AIRCRAFT SUPPORT COMPONETS'
union all select 'KU', 0 ,'TG','NON-AUTOMATIC AVIONICS TEST EQUIPMENT'
union all select 'KV', 0 ,'TG','AUTOMATIC TEST EQUIPMENT (ATE)'
union all select 'KW', 0 ,'TG','DEFENSE SPECIAL SECURITY COMMUNICATIONS SYSTEM (DSSCS) PROJECT STRAWHAT'
union all select 'LA', 0 ,'SX','AIRCRAFT ENGINE FUEL AND ELECTRICAL'
union all select 'LC', 0 ,'SU','T-33 SHOOTING STAR'
union all select 'LE', 0 ,'SU','LANDING GEAR SYSTEMS AND COMPONENTS'
union all select 'LF', 0 ,'SU','C-121 CONSTELLATION'
union all select 'LG', 0 ,'TG','C-130 HERCULES'
union all select 'LK', 0 ,'SU','F-104 STARFIGHTER'
union all select 'LN', 0 ,'SX','FLIGHT LOAD DATA RECORDING SYSTEM EQUIPMENT'
union all select 'LP', 0 ,'SX','FSC 2840 ITEMS NOT ELSEWHERE MMAC CODED'
union all select 'LR', 0 ,'SX','MISCELLANEOUS JET ENGINES AND COMPONENTS'
union all select 'LT', 0 ,'TG','C-5 AMP'
union all select 'LZ', 0 ,'TG','C-17 AIRCRAFT'
union all select 'MA', 0 ,'SU','A-7 CORSAIR II'
union all select 'MB', 0 ,'SU','MK12A POST SERV'
union all select 'MD', 0 ,'SU','MK12 POST SERV'
union all select 'MF', 0 ,'SU','T-28 TROJAN'
union all select 'MG', 0 ,'SX','AIRSEARCH ENGINES, COMPONENTS T-75, TPE 331 SERIES'
union all select 'MH', 0 ,'TG','LIFE SUPPORT SYSTEM 412A'
union all select 'MI', 0 ,'SA','CHAPEL ORGANS'
union all select 'MJ', 0 ,'SU','F-86 SABRE'
union all select 'ML', 0 ,'SU','F-100 SUPER SABRE'
union all select 'MM', 0 ,'SU','F-86 SABRE'
union all select 'MN', 0 ,'SU','COMPLETE ROUND COMPONENTS (NON-PRIME)'
union all select 'MP', 0 ,'SU','MISSION SUPPORT SYSTEM'
union all select 'MQ', 0 ,'TF','PREDATOR/MQ1 AND REAPER/MQ9 COMMON'
union all select 'MU', 0 ,'SX','PRATT & WHITNEY JET ENGINES & COMPONENTS BASE PT6T400-CP-400'
union all select 'MV', 0 ,'TG','NUCLEAR, BIOLOGICAL AND CHEMICAL WARFARE DEFENSE'
union all select 'MW', 0 ,'SX','CMPG BOMBER'
union all select 'MZ', 0 ,'SU','MILSTAR'
union all select 'NA', 0 ,'SU','LGM-30G PACER BLUE'
union all select 'NB', 0 ,'SU','MINUTEMAN III ITEMS'
union all select 'NC', 0 ,'SU','COMBAT AMMUNITIONS SYSTEMS (CAS) MUNITIONS'
union all select 'ND', 0 ,'SU','F-84 THUNDER STREAK'
union all select 'NE', 0 ,'SU','F-105 THUNDER CHIEF'
union all select 'NH', 0 ,'SU','F/117A'
union all select 'NI', 0 ,'SX','CONTINENTAL JET ENGINES & COMPONENTS, J-69, J-100'
union all select 'NJ', 0 ,'SX','WRIGHT JET ENGINES & COMPONENTS J-65'
union all select 'NK', 0 ,'SX','F-112 ENGINE'
union all select 'NL', 0 ,'SX','LYCOMING JET ENGINES & COMPONENTS T-53'
union all select 'NM', 0 ,'SU','NONEXPLOSIVE MANAGED ASSETS'
union all select 'NN', 0 ,'SX','PRATT & WHITNEY JET ENGINES & COMPONENTS, J-52, J-60, JT8D9'
union all select 'NP', 0 ,'SU','PEACEKEEPER ITEMS'
union all select 'NR', 0 ,'SX','MISCELLANEOUS AIRCRAFT INSTRUMENTS & ELECTRONICS'
union all select 'NS', 0 ,'TG','NAVSTAR GLOBAL POSITIONING SYSTEM EQUIPMENT ITEMS'
union all select 'NT', 0 ,'SX','AIRCRAFT INSTRUMENTS'
union all select 'NV', 0 ,'TG','JOINT VERTICAL LIFT AIRCRAFT CV-22 (OSPREY)'
union all select 'NY', 0 ,'SX','GENERAL ELECTRIC ENGINES & COMPONENTS, TF-39'
union all select 'NZ', 0 ,'SX','PRATT & WHITNEY JET ENGINES & COMPONENTS, F-100-P-100'
union all select 'OA', 0 ,'SX','LYCOMING JET ENGINES AND COMPONENTS T-55'
union all select 'OC', 0 ,'SX','GENERAL ELECTRIC JET ENGINE COMPONENTS (TURBO SHAFT (T700))'
union all select 'OD', 0 ,'SX','PARTS COMMON, FAIRCHILD, FSC 1560'
union all select 'OG', 0 ,'SX','119-PW-100 ENGINE FOR ATF(F-22)'
union all select 'OH', 0 ,'SX','F-109 ENGINE'
union all select 'OJ', 0 ,'SX','ALLISON JET ENGINES & COMPONENTS, T-56'
union all select 'OK', 0 ,'SX','GENERAL ELECTRIC JET ENGINES & COMPONENTS, J-85'
union all select 'OM', 0 ,'SX','NON-MEDICAL BASE 86 ITEMS'
union all select 'ON', 0 ,'SU','T-37 Aircraft'
union all select 'OP', 0 ,'SX','TF-34'
union all select 'OU', 0 ,'SX','LIGHTING FIXTURES AND LAMPS'
union all select 'PA', 0 ,'SU','CONTINENTAL RECIPROCATING ENGINES AND COMPONENTS 0-470 I0-360C/D I0-520'
union all select 'PB', 0 ,'SU','WRIGHT RECIPROCATING ENGINES & COMPONENTS, R-1300, R-3350'
union all select 'PC', 0 ,'SU','LYCOMING RECIPROCATING ENGINES & COMPONENTS, 0-435, 0-480'
union all select 'PD', 0 ,'SU','PRATT & WHITNEY RECIPROCATING ENGINES & COMPONENTS, R-1340, R1830, R-2000, R-2800, R-4360, R-985'
union all select 'PJ', 0 ,'SX','ALLISON JET ENGINES & COMPONENTS J-33, J-35, J-71'
union all select 'PK', 0 ,'SU','PHOTOGRAPHIC SYSTEMS COMPONENTS, AND SUPPLIES 428A, 430A, TACTICAL INFORMATION PROCESSING AND INTERPRETATION SYSTEM'
union all select 'PL', 0 ,'SX','GENERAL ELECTRIC JET ENGINES & COMPONENTS, J-47, J-73, J-79, J-93, T-58, T-64, CFM56'
union all select 'PM', 0 ,'SU','MARQUARDT ENGINES & COMPONENTS J-43'
union all select 'PN', 0 ,'SX','F-108 ENGINE'
union all select 'PP', 0 ,'TG','PROPELLER SYSTEMS'
union all select 'PQ', 0 ,'SX','PRATT & WHITNEY ENGINES AND COMPONENTS, TF-30'
union all select 'PR', 0 ,'SX','F11O GE 100 ENGINE'
union all select 'PU', 0 ,'SU','F-4 PHANTOM II NON-AF & DOD'
union all select 'PV', 0 ,'SX','F107-WR-100 ENGINES'
union all select 'PW', 0 ,'TG','SHIPS, SMALL CRAFT, AND MARINE EQUIPMENT'
union all select 'QC', 0 ,'TG','ELECTRICAL AND ELECTRONIC PROPERTIES MEASURING AND TESTING'
union all select 'QD', 0 ,'SX','MISCELLANEOUS INSTRUMENTS'
union all select 'QE', 0 ,'SX','AERIAL CARGO EQUIPMENT AND SPECIALIZED FLIGHT CLOTHING'
union all select 'QF', 0 ,'TG','CHEMICAL AND GAS CYLINDERS'
union all select 'QJ', 0 ,'TG','NON-AIRCRAFT ENGINES AND COMPONENTS'
union all select 'QK', 0 ,'SX','ROPE, HARDWARE, SPRINGS, SPACERS, AND ABRASIVES'
union all select 'QL', 0 ,'TG','WR-ALC RETAINED ITEMS (FROZEN)'
union all select 'QM', 0 ,'SX','PIPE, TUBING, HOSE & VALVES'
union all select 'QP', 0 ,'TG','MISCELLANEOUS GROUND SUPPORT AND SHOP EQUIPMENT'
union all select 'QQ', 0 ,'SX','HAZARD DETECTION EQUIPMENT 6665 NOT OTHERWISE CODED'
union all select 'QR', 0 ,'SX','ALARM AND SIGNAL SYSTEMS'
union all select 'QS', 0 ,'TG','AIRCRAFT GROUND SERVICES EQUIPMENT'
union all select 'QU', 0 ,'SU','MATURE & PROVEN AIRCRAFT (FSC RESIDUAL MMAC)'
union all select 'QX', 0 ,'SU','ATMOSPHERIC EARLY WARNING SYSTEM (AEWS) (FSC RESIDUAL MMAC)'
union all select 'RA', 0 ,'SX','C-18A AIRCRAFT'
union all select 'RC', 0 ,'SI','AE100D3/C-130J ENGINE'
union all select 'RD', 0 ,'SU','C-119 PACKET'
union all select 'RE', 0 ,'SU','C-123 PROVIDER'
union all select 'RF', 1 ,'TP','F-119-PW-100 FOR ATF-ENGINE'
union all select 'RG', 0 ,'TC','AIR FORCE SUB-SCALE AERIAL TARGET (AFSAT)'
union all select 'RH', 0 ,'TG','AUTO TEST EQUIPMENT/AUTO TEST SYSTEMS (ATE/ATS) (FSC RESIDUAL MMAC)'
union all select 'RI', 0 ,'SU','GROUND BASED SENSORS/GROUND RADAR (GBS/GR) (FSC RESIDUAL MMAC)'
union all select 'RJ', 0 ,'SX','JET AIRCRAFT ENGINES (FSC RESIDUAL MMAC)'
union all select 'RK', 0 ,'SX','AEROSPACE SUPPORT ACCESSORIES'
union all select 'RL', 0 ,'SU','RSLP-ROCKET SYSTEMS LAUNCH PROGRAM'
union all select 'RM', 0 ,'TG','NON-MEDICAL BASE 86 ITEMS'
union all select 'RN', 0 ,'TG','GROUND SUPPORT EQUIPMENT (FSC RESIDUAL MMAC)'
union all select 'RP', 0 ,'SU','GAS TURBINE ENGINES (FSC RESIDUAL MMAC)'
union all select 'RQ', 0 ,'SX','JET ENGINE COMPONENTS (FSC RESIDENT MMAC)'
union all select 'RR', 0 ,'TG','DIESEL-GAS ENGINES (FSC RESIDUAL MMAC)'
union all select 'RT', 0 ,'SX','PRATT & WHITNEY JET ENGINES & COMPONENTS, J-75'
union all select 'RU', 0 ,'SX','PRATT & WHITNEY JET ENGINES & COMPONENTS, J-57'
union all select 'RV', 0 ,'SX','PRATT & WHITNEY JET ENGINES & COMPONENTS TF-33'
union all select 'RY', 0 ,'TG','RADIO/TV (FSC RESIDUAL MMAC)'
union all select 'SA', 0 ,'SU','TELECOMMUNICATIONS (FSC RESIDUAL MMAC)'
union all select 'SD', 0 ,'SU','SPACE LIFT RANGES'
union all select 'SE', 0 ,'SU','T-37'
union all select 'SG', 1 ,'TV','SATELLITE CONTROL NETWORK (SCNC) HONEYWELL TECHNICAL SERVICES'
union all select 'SH', 1 ,'TQ','SNSC SATELLITE CONTROL NETWORK - HONEYWELL TECHNICAL SERVICES'
union all select 'SJ', 0 ,'TG','COMMUNICATIONS'
union all select 'SK', 0 ,'TG','AGM-45 SHRIKE'
union all select 'SM', 0 ,'SJ','MISSION AND SECURITY PRODUCTS'
union all select 'SN', 0 ,'SU','AF SATELLITE CONTROL NETWORK COMMON USER SUPPORT'
union all select 'SO', 0 ,'TG','SPECIAL OPERATIONAL FORCES (SOF) PECULIAR'
union all select 'SQ', 0 ,'SX','FUELS-OC-ALC (FSC RESIDUAL MMAC)'
union all select 'SR', 0 ,'TG','FUELS-WR-ALC (FSC RESIDUAL MMAC)'
union all select 'SS', 0 ,'SU','AIR FORCE SATELLITE COMMUNICATIONS SYSTEM (AFSCS) GROUND EQUIPMENT'
union all select 'SU', 0 ,'SU','AF SICA RESIDUAL MMAC-OO-ALC'
union all select 'SV', 0 ,'TG','LIVE ANIMALS (FSC RESIDUAL MMAC)'
union all select 'SW', 0 ,'TG','FIM/92A STINGER WEAPON SYSTEM'
union all select 'SX', 0 ,'SX','AF SICA RESIDUAL MMAC-OC-ALC'
union all select 'SY', 1 ,'TL','C-5 RELIABILITY ENHANCEMENT REENGINEERING PROGRAM'
union all select 'SZ', 1 ,'TV','SPACELIFT RANGE SYSTEMS (SLRS)'
union all select 'TA', 0 ,'SU','TRAINING AIDS AND DEVICES'
union all select 'TE', 0 ,'SU','CONTAINERS FOR GAS TURBINE UNITS (FSC 8145)'
union all select 'TF', 0 ,'SU','CONSTANT SOURCE TRE SYSTEMS'
union all select 'TG', 0 ,'TG','AF SICA RESIDUAL MMAC-WR-ALC'
union all select 'TH', 0 ,'TG','H-3 SEA KING'
union all select 'TI', 0 ,'SU','NONEXPLOSIVE TEST & SUPPORT EQUIPMENT'
union all select 'TJ', 0 ,'TB','AC-130U GUNSHIP'
union all select 'TL', 1 ,'TL','C-5 AMP'
union all select 'TM', 0 ,'TG','GLOBAL HAWK, OTHER SERVICE/AGENCY MANAGED ITEMS'
union all select 'TP', 0 ,'SX','TEMPERATURE AND PRESSURE CONTROLS, AIRCRAFT'
union all select 'TQ', 0 ,'TF','REAPER/MQ9'
union all select 'TS', 0 ,'SU','TACTICAL AIR DEFENSE SYSTEM (TADS) (GERMAN)'
union all select 'TT', 0 ,'SX','T-41 (CESSNA 172)'
union all select 'UB', 0 ,'TG','U-2'
union all select 'UC', 0 ,'TG','C-5A GALAXY'
union all select 'UD', 0 ,'TG','U-2 COMMON GROUND STATIONS'
union all select 'UE', 0 ,'SU','GBU-31 SERIES OF JOINT DIRECT ATTACK MUNITIONS'
union all select 'UF', 0 ,'TO','L3 COMMUNICATIONS'
union all select 'UG', 0 ,'SU','ELECTRICAL AND ELECTRONIC COMPONENTS'
union all select 'UI', 0 ,'TG','WHOLE AIRCRAFT'
union all select 'UK', 0 ,'TB','COMBAT TALON II'
union all select 'UM', 0 ,'TG','ADM-160A, MINIATURE AIR LAUNCHED DECOY'
union all select 'UN', 0 ,'SU','WHOLE AIRCRAFT'
union all select 'UO', 0 ,'SU','NON AF MANAGED ITEMS'
union all select 'UR', 1 ,'TL','RSA IIA'
union all select 'US', 0 ,'SX','F404-GE-F1D2'
union all select 'UV', 1 ,'TF','PREDATOR UNMANNED ARERIAL VEHICLE (UAV)'
union all select 'UY', 0 ,'TG','F-15 SPECIAL WEAPONS ITEMS'
union all select 'VB', 0 ,'SX','C-12 ATTACHE AIRCRAFT'
union all select 'VB', 0 ,'TA','C-12 ATTACHE AIRCRAFT'
union all select 'VC', 0 ,'TB','C-130 AMP'
union all select 'VG', 0 ,'SU','PECULIAR ITEMS FOR DOD I&S ONLY'
union all select 'VH', 0 ,'SX','PECULIAR ITEMS FOR DOD I&S ONLY'
union all select 'VL', 0 ,'TG','PECULIAR ITEMS FOR DOD I&S ONLY'
union all select 'VM', 1 ,'TL','C-130J AIRCRAFT'
union all select 'VR', 0 ,'SU','TORPEDO, DEPTH CHARGE, UNDERWATER MINE, AND ROCKET MAINTENANCE, REPAIR AND CHECKOUT SPECIALIZED EQUIPMENT'
union all select 'VX', 0 ,'TG','SPECIAL SUPPORT EQUIPMENT & WEAPONS TRAILERS'
union all select 'WB', 0 ,'SX','C/KC-135 ELECTRICAL WIRING REPLACEMENT PROGRAM'
union all select 'WD', 0 ,'TG','H-19 CHICKASAW'
union all select 'WF', 0 ,'SU','F-16 AIR COMBAT FIGHTER'
union all select 'WH', 1 ,'TN','E-8C JOINT STARS AIRCRAFT (NGC) WI TV BMEWS AND/OR PAVE-PAWS AND/OR PARACS AND/OR GEODSS COMBINATION'
union all select 'WK', 0 ,'SU','DOE MILSPARES'
union all select 'WN', 0 ,'SU','SAC AUTOMATED TOTAL INFORMATION NETWORK (SATIN IV)'
union all select 'WO', 0 ,'TG','NON AF MANAGED ITEMS'
union all select 'WR', 0 ,'TG','SPECIAL TACTICAL MISSILE COMPONENTS'
union all select 'WS', 0 ,'SX','AGM-86D CONV AIR LAUNCHED MISSLE PENETRATOR'
union all select 'WZ', 0 ,'SU','F-16 SPECIAL WEAPONS ITEMS'
union all select 'XC', 0 ,'SX','C-137 STRATOLINER'
union all select 'XD', 0 ,'SU','C-140 JET STAR'
union all select 'XE', 0 ,'SU','T-38 TALON'
union all select 'XF', 0 ,'SU','T-39 SABRELINER'
union all select 'XG', 0 ,'TG','FMS NONSTANDARD PECULIAR ITEMS & WRALC'
union all select 'XI', 0 ,'SX','NON AF MANAGED ENGINES'
union all select 'XJ', 0 ,'SU','F-5 FREEDOM FIGHTER'
union all select 'XM', 0 ,'SU','COMPOSITE MATERIAL CLEARINGHOUSE (CMC)'
union all select 'XN', 0 ,'TD','NONSTANDARD ITEM PARTS ACQUISITION REPAIR'
union all select 'XO', 0 ,'SX','NON AF MANAGED ITEMS'
union all select 'XR', 0 ,'SX','AE3 FMS PECULIAR'
union all select 'XS', 0 ,'TD','AC-13H AI/M2MSA'
union all select 'XT', 0 ,'SU','PECULIAR FMS NONSTANDARD ENGINE ITEMS ONLY SA-ALCF-404'
union all select 'XV', 0 ,'SX','FMS UNIQUE/OC-ALC'
union all select 'XW', 0 ,'SU','FMS UNIQUE/SA-ALC'
union all select 'XZ', 0 ,'TG','FMS UNIQUE/WR-ALC'
union all select 'YE', 0 ,'TG','MEASURING TOOLS'
union all select 'YH', 0 ,'TG','MISCELLANEOUS INDUSTRIAL EQUIPMENT'
union all select 'YK', 0 ,'TG','PUMPS & COMPRESSORS'
union all select 'YM', 0 ,'TG','HAND TOOLS'
union all select 'YN', 0 ,'TG','NONMETALLIC FABRICATED MATERIELS'
union all select 'YP', 0 ,'SU','GAS TURBINES AND JET ENGINES NON-AIRCRAFT'
union all select 'YQ', 0 ,'SX','ENGINE ACCESSORIES, AIRCRAFT'
union all select 'YU', 0 ,'TG','AUTOMATIC DATA PROCESSING SYSTEMS'
union all select 'YW', 0 ,'TG','VEHICLES AND COMPONENTS ELECTRICAL VEHICULAR LIGHTS AND FIXTURES (FSC 6220) NONAIRBORNE'
union all select 'YX', 0 ,'TG','BEARINGS'
union all select 'YY', 0 ,'TG','INDUSTRIAL MACHINERY AND EQUIPMENT'
union all select 'ZA', 0 ,'SU','496L SPACETRACT NETTED SYSTEM OF SPACE SENSORS'
union all select 'ZC', 0 ,'SU','416L CONTINENTAL AIR DEFENSE CONTROL AIR DEFENSE CONTROL AND WARNING SYSTEM (INCLUDES CADIN/PINE TREE) 416M, BACKUP INTERCEPTOR CONTROL SYSTEM 416Q, COMMON DIGITIZER SYSTEM (AN/FYQ-47) 474N, SEA LAUNCH BALLISTIC MISSLE DETECTION AND WARNING SYSTEM'
union all select 'ZD', 0 ,'SU','CHEYENNE MOUNTAIN COMPLEX (CMC) AND ASSOCIATED SUPPORT COMPLEXES'
union all select 'ZE', 0 ,'SU','METEOROLOGICAL EQUIPMENT 433L, WEATHER OBSERVATION AND FORECASTING SYSTEMS, METEROLOGICAL/WEATHER PROJECTS'
union all select 'ZF', 0 ,'SU','465L SAC COMMAND AND CONTROL SYSTEM'
union all select 'ZG', 0 ,'SJ','COMMUNICATIONS - ELECTRONICS SECURE 466L ELECTRO-MAGNETIC INTELLIGENCE SYSTEM'
union all select 'ZH', 0 ,'SU','AIR FORCE INTEGRATED COMMAND AND CONTROL SYSTEM'
union all select 'ZJ', 0 ,'SU','474L BALLISTIC MISSILE EARLY WARNING SYSTEM'
union all select 'ZL', 0 ,'SU','AUTODIN'
union all select 'ZM', 0 ,'SU','494L UHF EMERGENCY ROCKET COMMUNICATION SYSTEM, 494L PROJECTS'
union all select 'ZO', 0 ,'SU','P5CTS'
union all select 'ZQ', 0 ,'SU','OTH/B RADAR SYSTEM'
union all select 'ZR', 0 ,'SU','407L TACTICAL AIR CONTROL SYSTEM 485L TACTICAL AIR CONTROL SYSTEM IMPROVEMENTS (TACSI)'
union all select 'ZS', 0 ,'SU','GROUND WIRE EQUIPMENT WIRE PROJECTS'
union all select 'ZV', 0 ,'SU','ELECTRONIC COUNTER-COUNTER MEASURE AND AIRBORNE RADOME TEST EQUIPMENT, ECCM PROJECTS'
union all select 'ZW', 0 ,'SU','SURVEILLANCE AND WARNING SYSTEMS SURVEILLANCE AND WARNING PROJECTS GROUND IDENTIFICATION AND RECOGNITION EQUIPMENT (COMMOM) 441A RADAR SYSTEM (AN/FPS/95), WESTPACNORTH (WPN) COMPATABILITY SYSTEM'
";
	}
}
