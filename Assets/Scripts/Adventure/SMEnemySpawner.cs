using UnityEngine;

public class SMEnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private System.Random random = new System.Random();
    public SpaceMap spaceMap;
    private void Start()
    {
        for (int i = 0; i < spaceMap.star.Data.enemy_count; i++)
        {
            GameObject enemy = Instantiate(enemies[random.Next(enemies.Length)]);
            enemy.transform.position = new Vector2(Random.Range(-175, 175) + 5, Random.Range(-75, 75) + 5);
            enemy.SetActive(true);
        }
    }
}
