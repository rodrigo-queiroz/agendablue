using MediatR;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System.Collections.Generic;

namespace ScheduleBlue.Application.Queries.GetAllSchedule
{
    public class GetAllScheduleHandler : IRequestHandler<GetAllScheduleQuery, List<Schedule>>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public GetAllScheduleHandler(IScheduleRepository scheduleRepository) => _scheduleRepository = scheduleRepository;
        public async Task<List<Schedule>> Handle(GetAllScheduleQuery request, CancellationToken cancellationToken)
        {
            List<Schedule> schedule = await _scheduleRepository.GetAllAsync();
            return schedule.Select(p => p).ToList(); ;
        }
    }
}
