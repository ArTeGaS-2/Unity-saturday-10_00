using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Camera mainCamera; // Посиланя на головну камеру
    private float cameraDistance = 7f; // Висота камери
    private float cameraDistanceMod; // Модіфікатор висоти
    public float multiplier = 0.02f; // Множник

    public float maxSpeed = 10f; // Максимальна швидкість гравця
    public float forceMultiplier = 100f; // Множник сили
    public float forceMod = 15f;

    public float animTime = 20f; // Час дії анімації

    private Rigidbody rb; // Посилання на фізичний компонент

    public float divider = 2f; // Значеня на яке ми ділимо або множимо кординати

    private Vector3 scaleMod; // Модіфікатор розміру
    private Vector3 currentScale; // Поточний розмір
    public float forwardMod = 1.3f; // Розтягувати в довжину
    public float sideMod = 0.8f; // Розтягувати в ширину

    private Projectile projectileScript; // Скрипт

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        projectileScript = GetComponent<Projectile>();

        rb = GetComponent<Rigidbody>();
        currentScale = transform.localScale; // Прив'язуємо поточний розмір до "currentScale"

        scaleMod = transform.localScale / divider; // Значення на яке буде збільшуватися розмір

        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;

        cameraDistanceMod = multiplier;
    }
    // Додає розмір слайму, коли викликається та коригує модіфікатори для анімації
    public void AddScale()
    {
        currentScale = currentScale + scaleMod;

        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;

        forceMultiplier += forceMod;

    }
    public void AddCameraDistance()
    {
        cameraDistance = cameraDistance + cameraDistanceMod;
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

        if (Input.GetMouseButtonDown(1) ||
            Input.GetKeyDown(KeyCode.Space))
        {
            projectileScript.ShootProjectileForward();
        }

        mainCamera.transform.position = new Vector3(
            transform.position.x,
            cameraDistance,
            transform.position.z + -cameraDistance / 7);
            
    }
    private void SlimeMoveAnim()
    {
        // Плавно змінюємо розмір
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            forwardMod,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            sideMod,
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
            currentScale.z,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            currentScale.x,
            Time.deltaTime / animTime);


        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
}
