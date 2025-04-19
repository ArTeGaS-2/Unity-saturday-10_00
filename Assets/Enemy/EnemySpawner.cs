using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ���������� �� ����������
    private float xSpawnDistance;
    private float zSpawnDistance;
    // �������� �� ��������
    [SerializeField] private float spawnInterval = 1f;
    // ������� ������
    private Transform playerTransform;
    // ������ ��'����
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        playerTransform = GameObject.Find("Player_2").transform;
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // �������� ������� - �������
        Vector3 spawnPosition = playerTransform.position;
        // ���������� ���� �� ��� ��������� (X �� Z)
        int axisChoice = Random.Range(0, 2);
        switch (axisChoice)
        {
            case 0:
                zSpawnDistance = Random.Range(0f, 14.1f);
                xSpawnDistance = 20f;
                break;
            case 1:
                zSpawnDistance = 14f;
                xSpawnDistance = Random.Range(0f, 20.1f);
                break;
        }
        int signChoice = Random.Range(0, 2);
        if (signChoice == 0)
        {
            spawnPosition.x += xSpawnDistance;
            spawnPosition.z += zSpawnDistance;
        }
        else
        {
            spawnPosition.x -= xSpawnDistance;
            spawnPosition.z -= zSpawnDistance;
        }
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
