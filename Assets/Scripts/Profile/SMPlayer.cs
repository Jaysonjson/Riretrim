using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SMPlayer : MonoBehaviour
{
    public bool blackhole = false;
    public GameObject blackholeObject;
    private float speed = 0.005f;
    private void Update()
    {
        if(blackhole)
        {
            Vector3 otherDirection = blackholeObject.transform.position - transform.position;
            float angle = Mathf.Atan2(otherDirection.y, otherDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            speed += 0.0001f;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, blackholeObject.transform.position, speed);
            float distance = 1 - (Vector2.Distance(gameObject.transform.position, blackholeObject.transform.position) / 25);
            GetComponent<Orbit>().speed += 5.2f;
            blackholeObject.GetComponent<Volume>().weight = distance;
        }
    }
}

