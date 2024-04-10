using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isInvincible = false;
    public int currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer graphics;
    public float invicibilityFlashDelay = 0.15f;
    public float invincibilityTimeAfterHit = 2f;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //test de la barre de vie
        {
            TakeDamage(20);
        }
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }

    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 0f, 0f, 0.5f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
