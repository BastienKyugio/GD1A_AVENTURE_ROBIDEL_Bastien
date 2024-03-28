using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public int playerId = 0;
    private Player player;
    public bool useController;

    public Animator animator;
    public GameObject crossHair;
    public GameObject fireballPrefab;


    Vector3 movement;
    Vector3 aim;
    bool isAiming;
    bool endOfAiming;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }


    void Update()
    {

        ProcessInput();
        AimAndShoot();
        Animate();
        Move();

    }

    private void ProcessInput()
    {
        if (useController)
        {
            movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);
            aim = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"), 0.0f);
            aim.Normalize();
            isAiming = player.GetButton("Fire");
            endOfAiming = player.GetButtonUp("Fire");
        }
        else
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            aim = aim + mouseMovement;
            if (aim.magnitude > 1.0f)
            {
                aim.Normalize();
            }
            isAiming = Input.GetButton("FireKey");
            endOfAiming = Input.GetButtonUp("FireKey");
        }
    }

    private void Move()
    {
        transform.position = transform.position + movement * Time.deltaTime;
    }
    private void Animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
    }

    private void AimAndShoot()
    {
        Vector2 shootingDirection = new Vector2(aim.x, aim.y);

        if (aim.magnitude > 0.0f)
        {
            crossHair.transform.localPosition = aim * 0.4f;
            crossHair.SetActive(true);

            shootingDirection.Normalize();
            if (endOfAiming)
            {
                GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
                fireball.GetComponent<Rigidbody2D>().velocity = shootingDirection * 3f ;
                fireball.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(fireball, 2.0f);

            }
        }
        else
        {
            crossHair.SetActive(false);
        }
    }

}