using MediatR;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System.Collections.Generic;

namespace ScheduleBlue.Application.Queries.GetScheduleById
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, Schedule>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public GetScheduleByIdQueryHandler(IScheduleRepository scheduleRepository) => _scheduleRepository = scheduleRepository;
        public async Task<Schedule> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            Schedule schedule = await _scheduleRepository.GetByIdAsync(request.Id);
            return schedule;
        }
    }
}
