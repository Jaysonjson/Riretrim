using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSEnemy : MonoBehaviour
{
    public GameScreen gameScreen;
    public int percentageAddition;
    private void OnDestroy()
    {
        gameScreen.percentage += percentageAddition;
    }
}

