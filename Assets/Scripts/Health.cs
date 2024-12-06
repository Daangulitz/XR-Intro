using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private static readonly int Hit = Animator.StringToHash("Hit");
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarFill;
    public Animator animator;
    
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        animator.SetBool(IsDead, false);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        animator.SetTrigger(Hit);
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    
    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    
    void UpdateHealthBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }

    private void Death()
    {
        animator.SetBool(IsDead, true);
    }

}