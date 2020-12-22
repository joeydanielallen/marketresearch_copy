import { AppUser } from './template-user';

export interface TemplateInstanceSummary {
    createdByAppUser: AppUser;
    id: number;
    title: string;
    createdOnUtc: string;
    completedOnUtc: string;
    progressComplete: number;
    assignedUsers: AppUser[];
    createdByAppUserInitials?: string;
}
