using MediatR;
using ScheduleBlue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBlue.Application.Queries.GetAllSchedule
{
    public class GetAllScheduleQuery : IRequest<List<Schedule>> { }
}
