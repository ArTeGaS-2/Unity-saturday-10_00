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
        index = Random.Range(0, screamersList.Count - 1);
        screamersList[index].gameObject.SetActive(true);
        StartCoroutine(DeactivateCurrentScreamer(index));
    }
    IEnumerator DeactivateCurrentScreamer(int index)
    {
        yield return new WaitForSeconds(2f);
        DeactivateScreamer(index);
    }
    public void DeactivateScreamer(int index)
    {
        // ����������� �������
        foreach (GameObject screamer in screamersList)
        {
            screamer.SetActive(false);
        }
    }
}
