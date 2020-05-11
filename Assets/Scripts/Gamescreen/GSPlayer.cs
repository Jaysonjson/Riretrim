using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class GSPlayer : MonoBehaviour
{
    public int gun_temperature;
    public int max_gun_temperature = 150;

    private Random Random = new Random();
    public GameObject bullet;
    public GameObject bulletGroup;
    public GunTemperatureProgressbar GunTemperatureProgressbar;
    private bool ableToShoot = true;
    private bool isShooting = false;
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

                if (!isShooting)
                {
                    StartCoroutine(coolGun());
                }
        }

    }
    public IEnumerator shootBullet ()
    {
        isShooting = true;
        GameObject spawned_bullet = Instantiate(bullet, bulletGroup.transform);
        spawned_bullet.SetActive(true);
        spawned_bullet.transform.position = new Vector3(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        GameObject spawned_bullet1 = Instantiate(bullet, bulletGroup.transform);
        spawned_bullet1.SetActive(true);
        spawned_bullet1.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        ableToShoot = false;
        gun_temperature += Random.Next(15);
        GunTemperatureProgressbar.UpdateBar();
        yield return new WaitForSeconds(0.55f);
        ableToShoot = true;
        isShooting = false;
        StartCoroutine(coolGun());
    }

    public IEnumerator coolGun()
    {
        if(Shoot.ReadValue<float>() > 0)
        {
            yield break;
        }
        if (gun_temperature > 0)
        {
            yield return new WaitForSeconds(0.7f);
            gun_temperature--;
            GunTemperatureProgressbar.UpdateBar();
            yield return new WaitForSeconds(0.2f);
            if (!isShooting)
            {
                StartCoroutine(coolGun());
            }
        }
    }
}