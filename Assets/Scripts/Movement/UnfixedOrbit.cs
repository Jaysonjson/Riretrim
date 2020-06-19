using UnityEngine;
public class UnfixedOrbit : MonoBehaviour
{
    public GameObject target;
    public float speed;
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
