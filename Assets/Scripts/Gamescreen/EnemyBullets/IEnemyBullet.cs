using UnityEngine;

interface IEnemyBullet
{
    float damage { get; set; }
    void Shoot(GameObject bullet, GSEnemy ship);
}

