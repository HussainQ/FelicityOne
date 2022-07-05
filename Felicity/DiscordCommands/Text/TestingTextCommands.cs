﻿using Discord.Commands;
using Felicity.Models.Caches;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Felicity.DiscordCommands.Text;

public class BasicTextCommands : ModuleBase<ShardedCommandContext>
{
    [Command("ping")]
    public async Task Pong()
    {
        // ReSharper disable once StringLiteralTypo
        await ReplyAsync("<:NOOOOOOOOOOOOOT:855149582177533983>");
    }

    [Command("fillCPs")]
    public async Task FillCPs(ulong messageId)
    {
        var msg = await Context.Channel.GetMessageAsync(messageId);
        ProcessCpData.Populate(msg);
    }
}