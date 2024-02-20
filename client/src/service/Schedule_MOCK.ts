import { IUser } from '@/types/IUser';

export default class Schedule_MOCK {

   private users:IUser[] = [];
   constructor() {}

   public GetAll() { return this.users; }
   public Insert(user:IUser) { 
      user.id = this.users.length;
      this.users.push(user); 
   }
   public Update(user:IUser) { 
      const newUser:IUser[] = this.users.map(u => { 
         if (u.id === user.id)
         {
            u = {
               id: user.id,
               name: user.name,
               email: user.email,
               telephone: user.telephone
            };
         }
         return u;
      });
      this.users = [...newUser];
   }
   public Delete(user:IUser) { 
      const newIuser:IUser[] = this.users.filter((u) => u.id !== user.id);
      this.users =[ ...newIuser];
   }

};
