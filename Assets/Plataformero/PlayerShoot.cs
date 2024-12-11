using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float shootCooldown = 0.5f; // Tiempo de enfriamiento entre disparos
    private float lastShootTime;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.L) && Time.time > lastShootTime + shootCooldown)
        {
            lastShootTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            float direction = transform.localScale.x > 0 ? 1f : -1f; // Determinar la dirección basado en la escala del jugador
            bullet.GetComponent<FireBullet>().SetDirection(direction);

            Destroy(bullet, 3f);
        }
    }
}
