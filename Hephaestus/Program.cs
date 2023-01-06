using Discord;
using Discord.WebSocket;
using Quartz;
using Quartz.Impl;
using Hephaestus;
using Hephaestus.Jobs;

public class Program
{
    public static Task Main(string[] args) => new Program().MainAsync();

    public async Task MainAsync()
    {
        DiscordSocketClient Discord = new DiscordSocketClient();

        await Discord.LoginAsync(TokenType.Bot, "<TOKEN>");
        await Discord.StartAsync();

        Discord.Log += (LogMessage msg) =>
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        };

        Discord.Connected += async () =>
        {
            DiscordHelper.Client = Discord;
            await StartScheduler();
        };
         
        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private async Task<Task> StartScheduler()
    {
        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler scheduler = await factory.GetScheduler();

        await scheduler.Start();

        await scheduler.ScheduleJob(MondayTaphouse.CreateJob(), MondayTaphouse.CreateTrigger());

        return Task.CompletedTask; 
    }
}