using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Spawner : MonoBehaviour
{
    // Список з gameObject(ігрові об'єкти) для спавну
    public List<GameObject> organisms;

    // Радіус, в якому будуть спавнитись об'єкти
    public float radius = 5f;

    // Затримка після спавну об'єкту
    public float delay = 0.3f;

    // Координати в яких викликається об'єкт
    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        StartCoroutine(spawnCreature());
    }
    private IEnumerator spawnCreature()
    {
        while (true)
        {
            // Визначаємо випадкові координати по "x" та "z" в діапазоні
            x_Pos = Random.Range(-radius, radius);
            z_Pos = Random.Range(-radius, radius);

            // Обираємо випадковий мікроорганізм, з обраних
            GameObject objectToSpawn = organisms[
                Random.Range(0, organisms.Count - 1)];

            // Визначаємо точку розміщення на ігровому полі
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);

            // Створюємо обраний об'єкт, в обраному місці, без зміни обертання
            Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);

            yield return new WaitForSeconds(delay);
        }
    }
}
