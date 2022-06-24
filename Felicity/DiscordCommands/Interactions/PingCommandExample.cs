﻿using System.Text.Json;
using Discord;
using Discord.Interactions;
using Felicity.DbObjects;

// ReSharper disable EmptyConstructor
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Felicity.DiscordCommands.Interactions;

public class PingCommandExample : InteractionModuleBase<ShardedInteractionContext>
{
    private readonly UserDb _userDb;

    public PingCommandExample(UserDb userContext)
    {
        _userDb = userContext;
    }

    [SlashCommand("ping", "Pongs back")]
    public async Task PongAsync(
        [Summary("text", "text to pong back")] string text = "")
    {
        var eb = new EmbedBuilder()
            .WithTitle("Glorious embed title")
            .WithDescription("Description? Idk what you expected in ping command")
            .AddField("PONG", "PONG");
        
        if (string.IsNullOrEmpty(text))
        {
            eb.AddField("Some custom text", text);
        }

        await RespondAsync(embed: eb.Build(), ephemeral: true);
    }

    [SlashCommand("whoami", "test db")]
    public async Task WhoAmI()
    {
        await DeferAsync();

        var user = _userDb.Users.FirstOrDefault(x => x.DiscordId == Context.User.Id);
        if (user == null)
            await FollowupAsync("User not found in db.");
    
        await FollowupAsync(JsonSerializer.Serialize(user));
    }
}