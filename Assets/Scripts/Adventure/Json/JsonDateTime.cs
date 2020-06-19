using System;
using UnityEngine;

[System.Serializable]
public class JsonDateTime
{
    public long time = 0L;

    public DateTime convertToDateTime()
    {
        return DateTime.FromFileTimeUtc(time);
    }

    public JsonDateTime convertToJsonDateTime(DateTime dateTime)
    {
        JsonDateTime jsonDateTime = new JsonDateTime();
        jsonDateTime.time = dateTime.ToFileTimeUtc();
        return jsonDateTime;
    }
}
