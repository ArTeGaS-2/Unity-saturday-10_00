using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Player : MonoBehaviour
{
    public static WASD_Player Instance; // Паттерн Сінглтон

    public Camera mainCamera; // Посилання на головну Камеру
    private static float cameraDistance = 7f; // Відстань від персонажа

    public float maxSpeed = 10f; // Максимальна швидкість
    public float rotationSpeed = 10f; // Швидкість обертання

    private Rigidbody rb; // Посилання на фізичний компонент
    public Animator animator; // Посилання на компонент Аніматору

    private Projectile projectile; // Посилання на скрипт
    private void Start()
    {
        Instance = this; // Бере з пам'яті екземпляр скрипта
        rb = GetComponent<Rigidbody>(); // Призначення компонента в змінну
        projectile = GetComponent<Projectile>(); // Отримуємо доступ
    }
    private void Update()
    {
        // Отримуємо значення вводу з клавіатури
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0,
            Input.GetAxis("Vertical"));
        // Пряме присвоєння швидкості (замість AddForce)
        if(moveInput.magnitude > 0.1f)
        {
            Vector3 desiredVelocity = moveInput.normalized * maxSpeed;
            rb.velocity = new Vector3(desiredVelocity.x,
                rb.velocity.y, desiredVelocity.z);
        }
        else
        {
            rb.velocity = new Vector3 (0, rb.velocity.y, 0);
        }
        // Обчислюємо локальний вектор руху відносно поточного повороту
        // моделі
        Vector3 localMovement = transform.InverseTransformDirection(
           moveInput);
        // Передаємо локальні координати в аніматор
        animator.SetFloat("VelocityX", localMovement.x);
        animator.SetFloat("VelocityZ", localMovement.z);

        // Обертання моделі у напрямку миші
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        if (plane.Raycast(ray, out float rayDistance))
        {
            Vector3 worldMousePosition = ray.GetPoint(rayDistance);
            Vector3 directionToMouse = worldMousePosition -
                transform.position;
            directionToMouse.y = 0;

            if (directionToMouse.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(
                    directionToMouse);
                transform.rotation = Quaternion.Lerp(
                    transform.rotation, targetRotation,
                    Time.deltaTime * rotationSpeed);
            }
        }
        // Оновлення позиції камери
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            cameraDistance,
            transform.position.z - cameraDistance / 7f);
    }
}
