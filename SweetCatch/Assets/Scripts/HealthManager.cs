using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] float maxHealth = 3f;
    private float currentHealth;

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    private void Update()
    {
        healthBar.value = Mathf.Lerp(healthBar.value, currentHealth, 10 * Time.deltaTime);
    }

    public void TakeDamage()
    {
        currentHealth--;
    }

}
