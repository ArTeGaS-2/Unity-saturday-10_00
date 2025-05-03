using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // �������� �� �������� 䳿
    public float objectSpeed = 5f; // �������� ��'����

    private Rigidbody rb; // ����� ��� ���������� Rigidbody

    public float anglePerIteration = 90f; // �� �������� �������� ��� �� ���(��� �� ��������)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")||
            other.gameObject.CompareTag("Slime"))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������� ��������� ���������� rb
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

            // ���� ��������� ����
            Vector3 currentEulerAngle =
                transform.rotation.eulerAngles;
            // ��������� ��� �� ��������� y
            currentEulerAngle.y += anglePerIteration;
            // ������������ ����� ��������� ���������
            transform.rotation = Quaternion.Euler(currentEulerAngle);
        }
    }
}
