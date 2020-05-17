using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSEnemy : MonoBehaviour
{
    public GameScreen gameScreen;
    public int percentageAddition;
    public void onDestroy()
    {
        gameScreen.percentage += percentageAddition;
    }
}

