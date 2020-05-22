using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichPresenceSpacemap : MonoBehaviour
{
    void Start () {
        var activity = new Discord.Activity
        {
            Details = Registry.Language.drpc_inside_solarsystem.Replace("%S", Registry.profile.Data.current_solarsystem),
            Assets =
            {
                SmallImage = "riretrim",
                SmallText = Application.unityVersion + " || " + Application.version,
                LargeImage = "sun",
                LargeText = Registry.profile.Data.current_solarsystem
            },
            State = "Cruisin'"
        };
        DiscordRPC.activityManager.UpdateActivity(activity, (res) =>
        {
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
