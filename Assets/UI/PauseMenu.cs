using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance; // ���� ��������� ���� �� ���
    public GameObject pauseMenuObject; // �������� ��'��� ���� �����

    void Awake()
    {
        Instance = this; // ����'����� ��������� ���� �� �����
        pauseMenuObject.SetActive(false); // �������� ���� ����� �� �������
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
        pauseMenuObject.SetActive(true); // ������ ���� �������� �� ������ Esc
        Time.timeScale = 0; //��������� ���
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); //�������� ���� ����� �� �������
        Time.timeScale = 1; //³��������� ���
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1; // ��������� ���
        SceneManager.LoadScene(0); // ����������� ������� ����
    }
}