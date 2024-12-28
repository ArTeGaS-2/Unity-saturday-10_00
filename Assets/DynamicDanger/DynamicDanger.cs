using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затримка до наступної дії
    public float objectSpeed = 5f; // Швидкість об'єкту

    private Rigidbody rb; // Змінна для компоненту Rigidbody
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // 
    }
    private void Update()
    {
        rb.velocity = Vector3.forward * objectSpeed * Time.deltaTime;
    }
}
