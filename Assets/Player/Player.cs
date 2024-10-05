using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera; // Посиланя на головну камеру

    public float maxSpeed = 10f; // Максимальна швидкість гравця
    public float forceTime = 1f; // Час дії інерції
    public float forceMultiplier = 100f; // Множник сили

    public float animTime = 20f; // Час дії анімації

    private Rigidbody rb; // Посилання на фізичний компонент

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Отримуємо позицію миші в світових координатах
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // Визначаємо напрямок від слимака до точки курсору
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0;

            // Повертаємо слимака у напрямку до курсору
            if (direction.magnitude > 0.1f) // Щоб уникнути дрібного коливання
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 5f);
            }

            // Рухаємо персонажа при натиску ЛКМ (Ліва Кнопка Миші)
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(direction * forceMultiplier
                    * Time.deltaTime, ForceMode.Acceleration);
                // Обмежуємо максимальну швидкість
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                SlimeMoveAnim();
            }
            else
            {
                SlimeStopAnim();
            }
        }
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            7,
            transform.position.z - 1);
    }
    private void SlimeMoveAnim()
    {
        // Плавно змінюємо розмір
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1.3f,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            0.8f,
            Time.deltaTime / animTime);


        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
    private void SlimeStopAnim()
    {
        // Плавно змінюємо розмір
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1f,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            1f,
            Time.deltaTime / animTime);


        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
}
