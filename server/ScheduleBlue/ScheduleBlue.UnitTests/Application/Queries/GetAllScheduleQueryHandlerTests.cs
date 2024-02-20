using Moq;
using ScheduleBlue.Application.Queries.GetAllSchedule;
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
    public class GetAllScheduleQueryHandlerTests
    {
        // PATTERN AAA AND GIVEN-WHEN-THEN

        [Fact]
        public async Task ThreeUsersExist_Executed_ReturnThreeUsersViewModels()
        {
            // Arange
            List<Schedule> schedules = new List<Schedule> { 
                new("Rodrigo", "Rodrigo@gmail.com", "(81) 99725-7349"),
                new("Aline", "Aline@gmail.com", "(81) 99725-7349"),
                new("Sarah", "Sarah@gmail.com", "(81) 99725-7349")
            };

            Mock<IScheduleRepository> scheduleRepositoryMock = new Mock<IScheduleRepository>();
            scheduleRepositoryMock.Setup(sc => sc.GetAllAsync().Result).Returns(schedules);

            GetAllScheduleQuery getAllSchedulesQuery = new GetAllScheduleQuery();
            GetAllScheduleHandler getAllSchedulesQueryHandler = new GetAllScheduleHandler(scheduleRepositoryMock.Object);

            // Act
            var scheduleViewModelList = await getAllSchedulesQueryHandler.Handle(getAllSchedulesQuery, new CancellationToken());

            // Assert
            Assert.NotNull(scheduleViewModelList);
            Assert.NotEmpty(scheduleViewModelList);
            Assert.Equal(schedules.Count, scheduleViewModelList.Count);

            scheduleRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
