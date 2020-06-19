using Newtonsoft.Json;
public class Quest
{
    public bool done = false;
    public bool unlocked = false;
    public bool inProgress = false;
    public JsonDateTime timeFinished = new JsonDateTime();

    [JsonIgnore]
    public float currency_reward = 0;

    public Quest(bool unlocked, float currency_reward)
    {
        this.unlocked = unlocked;
        this.currency_reward = currency_reward;
    }
}