using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject screamer_1_obj; // Об'єкт скрімера

    public void ActivateScreamer_1()
    {
        // Активація і деактивація скрімера в залежності від поточного стану
        screamer_1_obj.SetActive(!screamer_1_obj.activeSelf);
    }
}
