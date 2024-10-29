using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOrg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player.AddScale();
        Destroy(gameObject);
    }
}
