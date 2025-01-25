using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Затримка до наступної дії
    public float objectSpeed = 5f; // Швидкість об'єкту

    private Rigidbody rb; // Змінна для компоненту Rigidbody

    public float anglePerIteration = 90f; // Те наскільки міняється кут за раз(кут за ітерацію)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Привязка фізичного компонента rb
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        Vector3 forward = transform.up;
        rb.velocity = forward * objectSpeed * Time.deltaTime;
    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo);

            // Зміна поточного кута
            Vector3 currentEulerAngle =
                transform.rotation.eulerAngles;
            // Додавання змін до координат y
            currentEulerAngle.y += anglePerIteration;
            // Встановлення нових координат обертання
            transform.rotation = Quaternion.Euler(currentEulerAngle);
        }
    }
}
