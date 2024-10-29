using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Список з gameObject(ігрові об'єкти) для спавну
    public List<GameObject> organisms;

    // Максимальне число сворених об'єктів
    public int spawnNumber = 10;

    // Діаметр, в якому відбудется спавн
    public float diameter = 5f;

    // Кординати, що змінюються після кожного спавну
    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        // Виконує блок коду до тих пір, поки змінна "i"
        // меньше за змінну "SpawnNumber"
        // "i" збільшується на 1 кожну ітерацію циклу
        for (int i = 0; i < spawnNumber; i++)
        {
            // Даємо випадкові кординати
            x_Pos = Random.Range(-diameter, diameter);
            z_Pos = Random.Range(-diameter,diameter);
            // Обираємо конкретний організм зі списку
            GameObject organism = organisms[Random.Range(0, organisms.Count)];
            // Визначаємо точку спавну
            Vector3 spawnPos = new Vector3(
                x_Pos,
                organism.transform.position.y,
                z_Pos);
            // Строємо об'єкт на сцені
            Instantiate(organism, spawnPos, organism.transform.rotation);
        }
        
    }
}
