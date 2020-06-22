public interface IQuest
{
    bool done
    {
        get;
        set;
    }
    bool unlocked
    {
        get;
        set;
    }
    bool inProgress
    {
        get;
        set;
    }
    JsonDateTime timeFinished
    {
        get;
        set;
    }

    void StartQuest();
    void EndQuest();
}