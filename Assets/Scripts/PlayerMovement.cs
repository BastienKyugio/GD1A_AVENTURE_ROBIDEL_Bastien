using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using 

public class PlayerMovement : MonoBehaviour
{
    public int playerId = 0;
    public Animator animator;
    public GameObject crossHair;
    public GameObject fireballPrefab;



    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);

        

        AimAndShoot();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;
    }

    private void AimAndShoot()
    {
        Vector3 aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);
        Vector2 shootingDirection = new Vector2(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"));

        if (aim.magnitude > 0.0f)
        {
            aim.Normalize();
            aim *= 0.4f;
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true);

            shootingDirection.Normalized()
            if (Input.GetButtonDown("Fire"))
            {
                GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
                fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(4.0f, 0.0f);

            }
        }
        else crossHair.SetActive(false);
    }

}