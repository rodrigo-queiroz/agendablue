using MediatR;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBlue.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public DeleteUserCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await _scheduleRepository.GetByIdAsync(request.Id);
            _scheduleRepository.DeleteById(schedule);
            await _scheduleRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}