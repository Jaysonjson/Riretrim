using System;
using System.Collections;
using System.Collections.Generic;
using Discord;
using UnityEngine;

public class RichPresenceTitlescreen : MonoBehaviour
{
    void Start () {
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
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord Loaded");
            }
        });
    }
    private void Update () {
        DiscordRPC.discord.RunCallbacks();
    }

    private void OnApplicationQuit()
    {
        DiscordRPC.discord.Dispose();
    }
}
