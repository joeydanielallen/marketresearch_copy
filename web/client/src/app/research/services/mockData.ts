import { InitiateResponse } from 'src/app/research/models/initiate-response';
import { TemplateInstance } from 'src/app/research/models/template-instance';
import { TemplateInstanceSummary } from 'src/app/research/models/my-research';


const hardcodedTemplateId = 1;

const hardcodedInitiateResponse: InitiateResponse = {
    modelHash: 'GXzxHcN4jwRsh3g1HBSo4JZZBapFl9yoSZzAktHjj58K+DqLDeft9K/ptXSZ/qrKwj0Cbl75mlE+ChlNZLWm9DEA',
      initiateSummary: {
        estimatedValue: 1,
        itemEstimatedValue: 1,
        itemQuantity: 1,
        nsn: '2935013249087',
        purchaseRequestProcessingSystemId: '1234',
        serviceTypeName: 'Buy',
        sourceTypeName: 'Domestic',
      },
      initiateNsn: {
        fscName: 'Engine System Cooling Components, Aircraft Prime Moving',
        fsgName: 'Engine Accessories',
        mmac: '',
        name: 'COOLER,LUBRICATING ',
        nsn: '2935013249087',
      },

      proposedBidType: 3,

      awards: [
        {
          partNumber: 'UA539800-2',
          vendor: {
            cageCode: '78943',
            // dunsId: null,
            name: 'TRIUMPH THERMAL SYSTEMS, INC.',
          }
        },
        {
          partNumber: '4069429',
          vendor: {
            cageCode: '77445',
            // dunsId: null,
            name: 'UNITED TECHNOLOGIES CORPORATION'
          }
        },
        {
          partNumber: '4076474',
          vendor: {
            cageCode: '77445',
            // dunsId: null,
            name: 'UNITED TECHNOLOGIES CORPORATION'
          }
        }
      ],
      suggestedVendors: [],
      priorResearchSummaries: [],
      proposedTemplates: [
        {
          bidTypeId: 3,
          bidTypeName: 'ClosedBid',
          description: '',
          id: 1,
          name: 'AFMC MP5327.9001',
          orgId: 1,
          orgName: '421st',
          serviceTypeId: 1,
          serviceTypeName: 'Buy',
          sourceTypeId: 1,
          sourceTypeName: 'Domestic',
        }
      ],
      remainingTemplates: [
        {
          bidTypeId: 2,
          bidTypeName: 'OpenBid',
          description: '',
          id: 2,
          name: 'AFMC MP5327.9002',
          orgId: 1,
          orgName: '421st',
          serviceTypeId: 1,
          serviceTypeName: 'Buy',
          sourceTypeId: 1,
          sourceTypeName: 'Domestic'
        }
      ],
      // searchQueueResponse: null
    };

// var hardcodedTemplateInstance: TemplateInstance = {
//     "id": 1,
//     "answers": [],
//     "name": "Template 1 Name",
//     "templateId": 7,
//     "originalTemplateName": "Template 1 Name",
//     "purchaseRequestProcessingSystemId": "1234PRPS",
//     "nsn": "1234567890123",
//     "itemQuantity": 1,
//     "itemEstimatedValue": 1000,
//     "createdOn": "2020-06-21T15:35:10.01Z",
//     "completedOn": null,
//     "createdByAppUser": {
//       "id": 1,
//       "firstName": "Tester",
//       "lastName": "Test"
//     },
//     "appUsers": [],
//     "org": {
//       "id": 1,
//       "name": "421st",
//       "description": "421 SCMG"
//     },
//     "serviceType": 1,
//     "sourceType": 1,
//     "bidType": 2,
//     "template": {
//       "id": 7,
//       "name": "Template 1 Name",
//       "description": "Template 1 Description",
//       "minEstimatedValue": 0,
//       "maxEstimatedValue": 999999999,
//       "isActive": true,
//       "bidTypes": [
//         2
//       ],
//       "orgs": [
//         {
//           "id": 1,
//           "name": "421st",
//           "description": "421 SCMG"
//         },
//         {
//           "id": 2,
//           "name": "422nd",
//           "description": "422 SCMG"
//         }
//       ],
//       "serviceTypes": [
//         1
//       ],
//       "sourceTypes": [
//         1
//       ],
//       "sections": [
//         {
//           "id": 1,
//           "templateId": 7,
//           "sectionId": 1,
//           "name": "I.",
//           "description": "Section A I description",
//           "orderIndex": 1,
//           "templateSectionGroupId": 1,
//           "templateSectionGroup": {
//             "id": 1,
//             "name": "Section A",
//             "description": "Section A description"
//           },
//           "questions": [
//             {
//               "id": 1,
//               "name": "Question 1 Name",
//               "description": "Question 1 Description",
//               "orderIndex": 1,
//               "answerType": 1,
//               "allowMultipleSelectAnswers": false,
//               "maxLength": 25,
//               "questionAnswers": []
//             }
//           ]
//         },
//         {
//           "id": 2,
//           "templateId": 7,
//           "sectionId": 2,
//           "name": "II.",
//           "description": "Section A II description",
//           "orderIndex": 2,
//           "templateSectionGroupId": 1,
//           "templateSectionGroup": {
//             "id": 1,
//             "name": "Section A",
//             "description": "Section A description"
//           },
//           "questions": [
//             {
//               "id": 2,
//               "name": "Question 2 Name",
//               "description": "Question 2 Description",
//               "orderIndex": 2,
//               "answerType": 2,
//               "allowMultipleSelectAnswers": false,
//               "maxLength": 500,
//               "questionAnswers": []
//             }
//           ]
//         },
//         {
//           "id": 3,
//           "templateId": 7,
//           "sectionId": 3,
//           "name": "Section B",
//           "description": "Section B description",
//           "orderIndex": 3,
//           "templateSectionGroupId": null,
//           "templateSectionGroup": null,
//           "questions": [
//             {
//               "id": 3,
//               "name": "Question 2 Name",
//               "description": "Question 2 Description",
//               "orderIndex": 3,
//               "answerType": 2,
//               "allowMultipleSelectAnswers": false,
//               "maxLength": 500,
//               "questionAnswers": []
//             }
//           ]
//         }
//       ]
//     }
//   }

// var hardcodedTemplateInstanceSummaries: TemplateInstanceSummary[] = [
//     {
//         title: 'AFMC MP5327.9001',
//         id: 1,
//         createdOnUtc: new Date().toString(),
//         progressComplete: 60,
//         createdByAppUser: {
//             profilePicLink: 'profilePicSustain.png',
//             initials: 'ZP',
//             color: '#73969A'
//         },
//         lastViewed: new Date().toString(),
//     },
//     {
//         title: 'AFMC QR5327.9002',
//         id: 2,
//         createdOnUtc: new Date().toString(),
//         progressComplete: 100,
//         createdByAppUser: {
//             profilePicLink: 'profilePicSustain.png',
//             initials: 'ZP',
//             color: '#73969A'
//         },
//         lastViewed: new Date().toString(),
//     },
//     {
//         title: 'AFMC UI5327.9003',
//         id: 3,
//         createdOnUtc: new Date().toString(),
//         progressComplete: 20,
//         createdByAppUser: {
//             profilePicLink: 'profilePicSustain.png',
//             initials: 'ZP',
//             color: '#66798E'
//         },
//         lastViewed: new Date().toString(),
//     }
// ]

const hardcodedVendorAnswers = [
  {
    id: 15,
    name: 'Vendor 3',
    pocs: ['Jack', 'Jill'],
    selectedPoc: 'Jill',
    partNumbers: ['88888', '11111'],
    selectedPartNumber: '11111',
    capabilities: '1 machines, slow',
    pastPerformance: 'Completed 1 contracts'
  },
  {
    id: 16,
    name: 'Vendor 4',
    pocs: ['Mary', 'Maria'],
    selectedPoc: 'Maria',
    partNumbers: ['11225', '33664'],
    selectedPartNumber: '11225',
    capabilities: '20 machines, medium speed',
    pastPerformance: 'Completed 10 contracts'
  }
];


export let mockData = {
    hardcodedTemplateId,
    hardcodedInitiateResponse,
    // hardcodedTemplateInstance,
    // hardcodedTemplateInstanceSummaries,
    hardcodedVendorAnswers
};
