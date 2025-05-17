using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance; // Один екземпляр вікна на гру
    public GameObject pauseMenuObject; // Головний об'єкт вікна паузи

    void Awake()
    {
        Instance = this; // Прив'язуємо екземпляр вікна до змінної
        pauseMenuObject.SetActive(false); // Вимикаємо вікно паузи на початку
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) 
            && pauseMenuObject.activeSelf == false)
        {
            OpenPauseMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) 
            && pauseMenuObject.activeSelf == true)
        {
            ClosePauseMenu();
        }
    }
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true); // Робимо меню активним на клавішу Esc
        Time.timeScale = 0; //Зупиняємо гру
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); //Вимикаємо вікно паузи на початку
        Time.timeScale = 1; //Відновлюємо гру
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1; // Повертаємо час
        SceneManager.LoadScene(0); // Завантажуємо головне меню
    }
}