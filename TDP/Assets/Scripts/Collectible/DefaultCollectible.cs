﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultCollectible : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
