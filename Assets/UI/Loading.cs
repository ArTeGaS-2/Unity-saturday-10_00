using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // Контейнер для всього екрану завантаження
    public GameObject loadingScreen;

    // Посилання на крапки
    public GameObject dot_1, dot_2, dot_3;

    private void Start()
    {
        StartCoroutine(AnimateDots());
    }

    private IEnumerator AnimateDots()
    {
        Time.timeScale = 0f; // Зупиняємо час у грі

        for (int i = 0; i < 3; i++)
        {
            // Збільшуємо крапку в 2 рази
            dot_1.transform.localScale = new Vector2(2f, 2f);
            // Зупиняємо виконання програми на час (у секундах)
            yield return new WaitForSecondsRealtime(0.1f);
            // Повертаємо початковий розмір
            dot_1.transform.localScale = new Vector2(1f, 1f);

            // Збільшуємо крапку в 2 рази
            dot_2.transform.localScale = new Vector2(2f, 2f);
            // Зупиняємо виконання програми на час (у секундах)
            yield return new WaitForSecondsRealtime(0.1f);
            // Повертаємо початковий розмір
            dot_2.transform.localScale = new Vector2(1f, 1f);

            // Збільшуємо крапку в 2 рази
            dot_3.transform.localScale = new Vector2(2f, 2f);
            // Зупиняємо виконання програми на час (у секундах)
            yield return new WaitForSecondsRealtime(0.1f);
            // Повертаємо початковий розмір
            dot_3.transform.localScale = new Vector2(1f, 1f);
        }
        loadingScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
