
import { QuestionAnswer } from '../components/start-research/models/question-answer';

export interface TemplateQuestion {
    id: number;
    name: string;
    description: string;
    orderIndex: number;
    answerType: number;
    allowMultipleSelectAnswers: boolean;
    maxLength: number;
    questionAnswers: QuestionAnswer[];
    groupIndex: number;
}
