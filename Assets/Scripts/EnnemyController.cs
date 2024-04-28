using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    public Animator animator;
    public GameObject objectToDestroy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetBool("Attack", true);
            PlayerHealth playerhealth = collision.transform.GetComponent<PlayerHealth>();
            playerhealth.TakeDamage(15);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Destroy(objectToDestroy);
        }
    }

}
