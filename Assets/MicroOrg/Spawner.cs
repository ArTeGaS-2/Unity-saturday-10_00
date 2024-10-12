using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Список з gameObject(ігрові об'єкти) для спавну
    public List<GameObject> organisms;

    public int spawnNumber = 10;

    public float diameter = 5f;

    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        // Виконує блок коду до тих пір, поки змінна "i"
        // меньше за змінну "SpawnNumber"
        // "i" збільшується на 1 кожну ітерацію циклу
        for (int i = 0; i < spawnNumber; i++)
        {
            x_Pos = Random.Range(0f, diameter);
            z_Pos = Random.Range(0f, diameter);
        }
    }
}
