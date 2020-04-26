using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichPresenceSpacemap : MonoBehaviour
{
    void Start () {
        var activity = new Discord.Activity
        {
            Details = "Inside Solar System: " + Profile.current_solarsystem,
            Assets =
            {
                SmallImage = "riretrim",
                SmallText = Application.unityVersion + " || " + Application.version,
                LargeImage = "sun",
                LargeText = Profile.current_solarsystem
            },
            State = "Cruisin'"
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
