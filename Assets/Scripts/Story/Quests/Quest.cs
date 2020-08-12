using Newtonsoft.Json;
public class Quest : IQuest
{
    public bool done { get; set; }
    public bool unlocked { get; set; }
    public bool inProgress { get; set; }
    public JsonDateTime timeFinished { get; set; }

    public void EndQuest()
    {

    }

    public void StartQuest()
    {

    }

    [JsonIgnore]
    public float currency_reward = 0;

    public Quest(bool unlocked, float currency_reward)
    {
        this.unlocked = unlocked;
        this.currency_reward = currency_reward;
        this.inProgress = false;
        this.done = false;
    }
}