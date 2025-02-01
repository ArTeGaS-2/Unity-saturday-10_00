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
        // Знаходить об'єкт з ім'ям "Player" та отримує його компонент Transform
        target = GameObject.Find("Player").GetComponent<Transform>();
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
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
