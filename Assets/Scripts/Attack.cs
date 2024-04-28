using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D atk;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        atk.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attaque();
        }
    }
    private void Attaque()
    {
        atk.enabled = true;
        animator.SetTrigger("Hit");
    }
    public void AttaqueEnd()
    {
        atk.enabled = false;
    }
}
