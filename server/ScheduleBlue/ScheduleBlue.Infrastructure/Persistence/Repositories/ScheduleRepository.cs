using Microsoft.EntityFrameworkCore;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBlue.Infrastructure.Persistence.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleBlueDbContext _scheduleBlueDbContext;
        public ScheduleRepository() => _scheduleBlueDbContext = new();
        public async Task<List<Schedule>> GetAllAsync() => await _scheduleBlueDbContext.Schedules.ToListAsync();
        public async Task<Schedule> GetByIdAsync(int id) => await _scheduleBlueDbContext.Schedules.SingleOrDefaultAsync(u => u.Id == id);
        public async Task SaveChangesAsync() => await _scheduleBlueDbContext.SaveChangesAsync();
        public async Task AddAsync(Schedule schedule) => await _scheduleBlueDbContext.Schedules.AddAsync(schedule);
        public void DeleteById(Schedule schedule) { _scheduleBlueDbContext.Schedules.Remove(schedule); }
    }
}
