using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOrg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Score.Instance.AddScore();
        Player.Instance.AddCameraDistance();
        Player.Instance.AddScale();
        Destroy(gameObject);
    }
}
