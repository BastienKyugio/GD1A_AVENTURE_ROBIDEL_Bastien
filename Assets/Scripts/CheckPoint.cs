using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Transform spawn;
    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spawn.position = transform.position;
        }
    }
}
