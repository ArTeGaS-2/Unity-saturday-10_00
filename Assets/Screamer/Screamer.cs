using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public static Screamer Instance; // Сінглтон
    public List<GameObject> screamersList; // Список скримерів
    private void Start()
    {
        Instance = this; 
    }
    public void ActivateScreamer(int index)
    {
        // Активація скрімера
        screamersList[index].gameObject.SetActive(true);
    }
    IEnumerator DeactivateAllScreamers()
    {
        yield return new WaitForSeconds(5f);
    }
    public void DeactivateScreamer(int index)
    {
        // Деактивація скрімера
        screamersList[index].gameObject.SetActive(false);
    }
}
