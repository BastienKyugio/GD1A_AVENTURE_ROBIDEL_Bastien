using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(2);
            CurrentSceneManager.instance.coinsPickUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
