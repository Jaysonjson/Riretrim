public class Quests
{
    public Quest placeHolder = new Quest(true, 5);


    public void Load(IQuest guest)
    {
        guest.unlocked = true;
    }

    public void Save()
    {

    }
}