using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Transform target; // Ціль (персонаж)
    private NavMeshAgent agent; // Компонент для навігації
    private void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            // Знаходить об'єкт з ім'ям "Player" та отримує його компонент Transform
            target = GameObject.Find("Player").GetComponent<Transform>();
        }
        if (GameObject.Find("Player_2") != null)
        {
            // Знаходить об'єкт з ім'ям "Player" та отримує його компонент Transform
            target = GameObject.Find("Player_2").GetComponent<Transform>();
        }
        // Отримує компонент NavMeshAgent з префабу ворога
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        // Перевіряє чи знайшло персонажа гравця
        if (target != null)
        {
            // Встановлює його як ціль слідкування
            agent.SetDestination(target.position);
        }
    }
    IEnumerator StopMoving()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        agent.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Slime"))
        {
            SceneManager.LoadScene(1);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
