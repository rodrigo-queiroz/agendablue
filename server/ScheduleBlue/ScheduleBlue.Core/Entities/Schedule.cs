using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScheduleBlue.Core.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule(string name, string email, string telephone)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
        }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Telephone { get; private set; } = string.Empty;

        public void Update(string name, string email, string telephone)
        {
            Name = name;
            Email= email;
            Telephone = telephone;
        }
    }
}
