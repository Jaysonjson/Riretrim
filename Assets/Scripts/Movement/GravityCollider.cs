using UnityEngine;

public class GravityCollider : MonoBehaviour
{
    public float mass = 1f;
    public GameObject body;
    public GameObject sun;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GravityCollider") && other.gameObject.GetComponent<GravityCollider>() != null)
        {
            GravityCollider otherGravity = other.gameObject.GetComponent<GravityCollider>();
            GameObject strongerOject;
            GameObject weakerObject;
            if (otherGravity.mass > mass)
            {
                strongerOject = otherGravity.body;
                weakerObject = body;
            }
            else
            {
                strongerOject = body;
                weakerObject = otherGravity.body;
            }
            if (weakerObject.gameObject.GetComponent<Orbit>() != null)
            {
                weakerObject.GetComponent<Orbit>().target = strongerOject;
                Debug.Log("Changed " + weakerObject.name + " target to " + strongerOject.name);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GravityCollider"))
        {
            body.GetComponent<Orbit>().target = sun;
        }
    }
}
