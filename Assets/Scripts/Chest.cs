using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;
    public int chestValue;

    private void Awake()
    {
        if (PlayerController.instance.useController)
        {
            interactUI = GameObject.FindGameObjectWithTag("InteractUIController").GetComponent<Text>();
        }
        else
        {
            interactUI = GameObject.FindGameObjectWithTag("InteractUIKeyboard").GetComponent<Text>();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }
    void OpenChest()
    {
        Destroy(gameObject);
        Inventory.instance.AddCoins(chestValue);
        CurrentSceneManager.instance.coinsPickUpInThisSceneCount += chestValue;
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
