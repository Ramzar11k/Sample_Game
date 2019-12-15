using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestory : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
