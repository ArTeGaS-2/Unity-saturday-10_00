using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Шаблон проджектайлу
    public float projectileSpeed = 10f; // Швидкість проджектайлу

    public Transform spawnPoint; // Точка спавну
    public void ShootProjectileForward()
    {
        // Напрямок обираємо за орієнтацією персонажа
        Vector3 direction = transform.forward;
        // Обертаємо у напрямку руху персонажа
        Quaternion projectileRotation = Quaternion.LookRotation(direction);
        GameObject projectile = Instantiate( // Створення проджектайлу
            projectilePrefab,    // Шаблон об'єкту
            spawnPoint.position, // Позиція
            projectileRotation); // Обертання 

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if( rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
        Destroy(projectile, 10f);

    }
}
