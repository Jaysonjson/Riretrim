using System;
using System.Collections;
using System.Collections.Generic;
using Discord;
using UnityEngine;

public class RichPresenceTitlescreen : MonoBehaviour
{
    void Start()
    {
        if (DiscordRPC.discord != null)
        {
            var activity = new Discord.Activity
            {
                Details = "Inside Titlescreen",
                Assets = DiscordRPC.riretrimDefault,
                Timestamps =
            {
                Start = 5
            },
            };
            DiscordRPC.activityManager.UpdateActivity(activity, (res) =>
            {
            });
        }
    }
    private void Update()
    {
        if (DiscordRPC.discord != null)
        {
            DiscordRPC.discord.RunCallbacks();
        }
    }

    private void OnApplicationQuit()
    {
        DiscordRPC.discord.Dispose();
    }
}
