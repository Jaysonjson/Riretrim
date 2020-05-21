using System;
using UnityEngine;

public class EnemyBulletZenin : MonoBehaviour, IEnemyBullet
{
    float IEnemyBullet.damage { get; set; }

    public void Shoot(GameObject bullet, GSEnemy ship)
    {
       GameObject firstBullet =  Instantiate(bullet, ship.transform);
       firstBullet.transform.position = new Vector2(ship.transform.position.x + 0.2f, ship.transform.position.y - 0.45f);
       GameObject secondBullet = Instantiate(bullet, ship.transform);
       secondBullet.transform.position = new Vector2(ship.transform.position.x - 0.2f, ship.transform.position.y - 0.45f);

        firstBullet.SetActive(true);
        secondBullet.SetActive(true);
    }
}
