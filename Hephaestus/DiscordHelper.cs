using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Hephaestus
{
    public static class DiscordHelper
    {
        public static DiscordSocketClient Client;
        public const ulong GuidID = 991131334112182282;

        public const ulong MondayTaphouseChannelID = 1012045560208957470;
        public const ulong GeneralChannelID = 991131334846197853;
        public const ulong TestChannelID = 1051569424433426472;

        public static async Task SendMessage(ulong channelID, string message)
        {
            await Client.GetGuild(GuidID).GetTextChannel(channelID).SendMessageAsync(message);
        }

        public static class Channels
        {
            public const ulong General = 991131334846197853;
            public const ulong Test = 1051569424433426472;
            public const ulong MondayTaphouse = 1012045560208957470;
        }

        public static Dictionary<string, long> Snowflakes = new Dictionary<string, long>
        {
            public const ulong Amanda = 324750323543441408;
            public const ulong Tate = 192401370660339712;
            public const ulong Eric = 200243201146224641;
            public const ulong Casey = 339867506346950667;
            public const ulong Matt = 700510948691017798;
            public const ulong Brendan = 293049758824660992;
            public const ulong Bryant = 138321980104507393;
            public const ulong Shane = 675093012904411161;
            public const ulong Eli = 152180130867838987;
            public const ulong Ben = 646471871964905491;
            public const ulong Mike = 425452693356806184;
        }
    }
}
