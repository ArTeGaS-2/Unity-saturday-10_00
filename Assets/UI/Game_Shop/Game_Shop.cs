using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Shop : MonoBehaviour
{
    Renderer slimeRenderer;

    public GameObject gameShop; // ��������� �� ������� ������
    private void Start()
    {
        gameShop.SetActive(false); // �������� ���� �������� �� �������
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
        gameShop.SetActive(false); // �������� ���� �������� �� ����
        Time.timeScale = 1.0f;
    }
}
