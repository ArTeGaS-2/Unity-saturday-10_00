using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TextMeshProUGUI text; // Посилання на об'єкт тексту
    public int scoreCounter = 0; // Змінна лічильника

    private void Start()
    {
        Instance = this;
        text.text = "Зібрано: 0"; // Встанвлюєм базове значення тексту
    }
    public void AddScore()
    {
        scoreCounter++; // Додаємо 1 до лічильника
        text.text = $"Зібрано: {scoreCounter}"; // Оновлюємо текст елементу
    }

}
