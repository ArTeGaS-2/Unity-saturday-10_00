using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOrg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
        if (other.gameObject.CompareTag("Slime"))
        {
            Player.Instance.AddScale();
            Player.Instance.AddCameraDistance();
        }
        Score.Instance.AddScore();
        Destroy(gameObject);
    }
}
