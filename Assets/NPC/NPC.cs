using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject gameShop;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gameShop.SetActive(true); // ¬микаЇмо в≥кно магазину по кл≥ку
            Time.timeScale = 0f; // «упин€Ї час у гр≥
        }
    }
}
