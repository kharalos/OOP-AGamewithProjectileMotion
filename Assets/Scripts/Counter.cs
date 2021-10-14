using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Counter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().Score();
    }
}
