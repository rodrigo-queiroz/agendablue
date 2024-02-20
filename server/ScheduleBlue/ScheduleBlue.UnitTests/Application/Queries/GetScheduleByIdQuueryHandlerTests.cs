using Moq;
using ScheduleBlue.Application.Queries.GetAllSchedule;
using ScheduleBlue.Application.Queries.GetScheduleById;
using ScheduleBlue.Core.Entities;
using ScheduleBlue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleBlue.UnitTests.Application.Queries
{
    public class GetScheduleByIdQuueryHandlerTests
    {
        // PATTERN AAA AND GIVEN-WHEN-THEN

        [Fact]
        public async Task GetOneUsersSchedule_Executed_ReturnOneUserViewModel()
        {
            // Arange
            List<Schedule> schedules = new List<Schedule> {
                    new("Rodrigo", "Rodrigo@gmail.com", "(81) 99725-7349"),
                    new("Aline", "Aline@gmail.com", "(81) 99725-7349"),
                    new("Sarah", "Sarah@gmail.com", "(81) 99725-7349")
            };
            int UserSeleted = 1;

            int countSc = 0;

            var newSchedule = schedules.Select(sc => 
            {
                countSc++;
                return new { countSc, sc.Name, sc.Email, sc.Telephone };
            });

            Mock<IScheduleRepository> scheduleRepositoryMock = new Mock<IScheduleRepository>();
            scheduleRepositoryMock.Setup(sc => sc.GetByIdAsync(schedules[UserSeleted].Id).Result).Returns(schedules[UserSeleted]);

            GetScheduleByIdQuery getSchedulesByIdQuery = new GetScheduleByIdQuery(schedules[UserSeleted].Id);
            GetScheduleByIdQueryHandler getSchedulesByIdQueryHandler = new GetScheduleByIdQueryHandler(scheduleRepositoryMock.Object);

            // Act
            var scheduleViewModelList = await getSchedulesByIdQueryHandler.Handle(getSchedulesByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(scheduleViewModelList);
            Assert.Equal(schedules[0], scheduleViewModelList);

            scheduleRepositoryMock.Verify(pr => pr.GetByIdAsync(scheduleViewModelList.Id).Result, Times.Once);
        }
    }
}
