using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Camera mainCamera; // �������� �� ������� ������
    private float cameraDistance = 7f; // ������ ������
    private float cameraDistanceMod; // ���������� ������
    public float multiplier = 0.02f; // �������

    public float maxSpeed = 10f; // ����������� �������� ������
    public float forceMultiplier = 100f; // ������� ����
    public float forceMod = 15f;

    public float animTime = 20f; // ��� 䳿 ��������

    private Rigidbody rb; // ��������� �� �������� ���������

    public float divider = 2f; // ������� �� ��� �� ����� ��� ������� ���������

    private Vector3 scaleMod; // ���������� ������
    private Vector3 currentScale; // �������� �����
    public float forwardMod = 1.3f; // ����������� � �������
    public float sideMod = 0.8f; // ����������� � ������

    private Projectile projectileScript; // ������

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        projectileScript = GetComponent<Projectile>();

        rb = GetComponent<Rigidbody>();
        currentScale = transform.localScale; // ����'����� �������� ����� �� "currentScale"

        scaleMod = transform.localScale / divider; // �������� �� ��� ���� ������������ �����

        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;

        cameraDistanceMod = multiplier;
    }
    // ���� ����� ������, ���� ����������� �� ������ ����������� ��� ��������
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

        // �������� ������� ���� � ������� �����������
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // ��������� �������� �� ������� �� ����� �������
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0;

            // ��������� ������� � �������� �� �������
            if (direction.magnitude > 0.1f) // ��� �������� ������� ���������
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 5f);
            }

            // ������ ��������� ��� ������� ��� (˳�� ������ ����)
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(direction * forceMultiplier
                    * Time.deltaTime, ForceMode.Acceleration);
                // �������� ����������� ��������
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
        // ������ ������� �����
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
        // ������ ������� �����
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
