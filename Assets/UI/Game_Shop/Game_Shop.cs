using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Shop : MonoBehaviour
{
    Renderer slimeRenderer;
    private void Start()
    {
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
        gameObject.SetActive(false);
    }
}
