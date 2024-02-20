using MediatR;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBlue.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public UpdateUserCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await _scheduleRepository.GetByIdAsync(request.Id);
            schedule.Update(request.Name, request.Email, request.Telephone);
            await _scheduleRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}