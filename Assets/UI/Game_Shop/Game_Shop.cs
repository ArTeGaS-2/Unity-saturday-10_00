using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Shop : MonoBehaviour
{
    Renderer slimeRenderer;

    public GameObject gameShop; // Посиланян на ігровий магзин
    private void Start()
    {
        gameShop.SetActive(false); // Вимикаємо вікно магазину на початку
        slimeRenderer = Player.Instance.gameObject.GetComponent<Renderer>();
    }
    public void SetColorRed()
    {
        slimeRenderer.material.color = Color.red;
    }
    public void SetColorGreen()
    {
        slimeRenderer.material.color = Color.green;
    }
    public void SetColorBlue()
    {
        slimeRenderer.material.color = Color.blue;
    }
    public void CloseShop()
    {
        gameShop.SetActive(false); // Вимикаємо вікно магазину по кліку
        Time.timeScale = 1.0f;
    }
}
