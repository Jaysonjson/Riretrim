using UnityEngine;

public class RichPresenceGamescreen : MonoBehaviour
{
    Discord.Activity activity;
    void Start()
    {
        activity = new Discord.Activity
        {
            Details = Registry.Language.drpc_inside_solarsystem.Replace("%S", Registry.profile.Data.current_solarsystem),
            Assets =
            {
                SmallImage = "riretrim",
                SmallText = Application.unityVersion + " || " + Application.version,
                LargeImage = "zenin",
                LargeText = "Health: " + Registry.profile.Data.health
            },
            State = "Fightin'"
        };
    }
    private void Update()
    {
        DiscordRPC.activityManager.UpdateActivity(activity, (res) =>
        {
        });
        DiscordRPC.discord.RunCallbacks();
    }

    private void OnApplicationQuit()
    {
        DiscordRPC.discord.Dispose();
    }
}
