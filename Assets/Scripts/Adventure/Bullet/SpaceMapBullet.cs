using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceMapBullet : MonoBehaviour
{

    public GameObject bulletDummy;
    private bool ableToShoot = true;
    public float bulletSpeed = 0.05f;
    private InputActionMap playerActionMap;
    private InputAction Shoot;
    private void Start()
    {
        playerActionMap = GetComponent<PlayerInput>().actions.FindActionMap("GSPlayer");
        Shoot = playerActionMap.FindAction("Shoot");
    }

    void Update()
    {
        if (Shoot.ReadValue<float>() > 0)
        {
            if (ableToShoot)
            {
                StartCoroutine(shootBullet());
            }
        }

    }
    public IEnumerator shootBullet ()
    {
        GameObject spawned_bullet = Instantiate(bulletDummy, transform.position, transform.rotation);
        GameObject spawned_bullet1 = Instantiate(bulletDummy, transform.position, transform.rotation);
        spawned_bullet.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
        spawned_bullet1.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
        spawned_bullet1.SetActive(true);
        spawned_bullet.SetActive(true);
        ableToShoot = false;
        yield return new WaitForSeconds(0.55f);
        ableToShoot = true;
    }
}
