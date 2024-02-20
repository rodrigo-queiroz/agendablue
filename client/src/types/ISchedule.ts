import { IUser } from '@/types/IUser';
export interface ISchedule {
   GetAsync(): Promise<IUser[]>;
   PostAsync(user: IUser): Promise<IUser[]>;
   PutAsync(user: IUser): Promise<IUser[]>;
   DeleteAsync(id: string): Promise<IUser[]>;
}
