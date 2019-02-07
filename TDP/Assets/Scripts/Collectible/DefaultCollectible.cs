using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Values>().KeyCount++;
            if (GetComponentInParent<Values>().KeyCount == 2)
                Destroy(GameObject.Find("Door"));
            Destroy(this.gameObject);
        }
    }
}

