
using UnityEngine;
using UnityEngine.SceneManagement;

public class GSEndBorder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            SceneManager.LoadScene("Spacemap");
        }
    }
}

