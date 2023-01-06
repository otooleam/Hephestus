using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Hephaestus.Jobs
{
    public class MondayTaphouse : IJob
    {
        public static IJobDetail CreateJob() => JobBuilder.Create<MondayTaphouse>()
            .WithIdentity("monday-taphouse")
            .Build();

        public static ITrigger CreateTrigger() => TriggerBuilder.Create()
            .WithIdentity("monday-taphouse")
            .StartNow()
            .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(DayOfWeek.Thursday, 11, 45))
            .Build();

        public async Task Execute(IJobExecutionContext context)
        {
            await DiscordHelper.SendMessage(DiscordHelper.Channels.MondayTaphouse, "Who all is coming to Monday Taphouse Thursday? 🍔 for you 🍺 for a +1");
        }
    }
}
