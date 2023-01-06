using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Hephaestus.Jobs
{
    public class FunFoodFwednesday : IJob
    {
        //needs a persistent way to store whos next


        public static IJobDetail CreateJob() => JobBuilder.Create<FunFoodFwednesday>()
                .WithIdentity("FFF")
                .Build();

        public static ITrigger CreateTrigger() => TriggerBuilder.Create()
                .WithIdentity("FFF")
                .StartNow()
                .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(DayOfWeek.Tuesday, 4, 0))
                .Build();

        public async Task Execute(IJobExecutionContext context)
        {
            await DiscordHelper.SendMessage(DiscordHelper.GeneralChannelID, "Fun Food Fwednesday Reminder: ");
        }
    }
}
