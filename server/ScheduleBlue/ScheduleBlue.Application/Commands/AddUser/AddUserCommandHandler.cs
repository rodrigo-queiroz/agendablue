using MediatR;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBlue.Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public AddUserCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = new(request.Name, request.Email, request.Telephone);
            await _scheduleRepository.AddAsync(schedule);
            await _scheduleRepository.SaveChangesAsync();

            return schedule.Id;
        }
    }
}