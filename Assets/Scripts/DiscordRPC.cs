using Discord;
using UnityEngine;

public class DiscordRPC : MonoBehaviour
{
    public static Discord.Discord discord;
    public static ActivityManager activityManager;
    public static ImageManager imageManager;
    public static ActivityAssets riretrimDefault = new ActivityAssets();
    void Start()
    {
        discord = new Discord.Discord(703992524406259742, (System.UInt64) Discord.CreateFlags.Default);
        activityManager = discord.GetActivityManager();
        imageManager = discord.GetImageManager();
        riretrimDefault.LargeImage = "riretrim";
        riretrimDefault.LargeText = Application.unityVersion + " || " + Application.version;
    }
}
