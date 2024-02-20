using MediatR;
using ScheduleBlue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBlue.Application.Queries.GetScheduleById
{
    public class GetScheduleByIdQuery : IRequest<Schedule> 
    {
        public int Id { get; private set; }

        public GetScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
