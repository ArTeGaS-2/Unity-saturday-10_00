using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject screamer_1_obj; // ��'��� �������

    public void ActivateScreamer_1()
    {
        // ��������� � ����������� ������� � ��������� �� ��������� �����
        screamer_1_obj.SetActive(!screamer_1_obj.activeSelf);
    }
}
