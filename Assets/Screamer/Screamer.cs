using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public static Screamer Instance; // ѳ������
    public List<GameObject> screamersList; // ������ ��������
    private void Start()
    {
        Instance = this; 
    }
    public void ActivateScreamer(int index)
    {
        // ��������� �������
        screamersList[index].gameObject.SetActive(true);
    }
    IEnumerator DeactivateAllScreamers()
    {
        yield return new WaitForSeconds(5f);
    }
    public void DeactivateScreamer(int index)
    {
        // ����������� �������
        screamersList[index].gameObject.SetActive(false);
    }
}
