using ScheduleBlue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleBlue.UnitTests.Core.Entities
{
    public class ScheduleTests
    {
        [Fact]
        public void TestIfScheduleUpdateWorks()
        {
            Schedule schedule = new("Rodrigo", "baruksoftware@gmail.com", "(81) 99725-7349");

            Assert.NotNull(schedule.Name);
            Assert.NotEmpty(schedule.Name);

            Assert.NotNull(schedule.Email);
            Assert.NotEmpty(schedule.Email);

            Assert.NotNull(schedule.Telephone);
            Assert.NotEmpty(schedule.Telephone);
            Assert.True(Convert.ToInt32(schedule.Telephone.Count()) > 14);

            Schedule oldSchedule = new(schedule.Name, schedule.Email, schedule.Telephone);
            schedule.Update("Aline", "aline@gmail.com", "(81) 99725-7349");
            Assert.NotEqual(oldSchedule, schedule);


        }
    }
}
