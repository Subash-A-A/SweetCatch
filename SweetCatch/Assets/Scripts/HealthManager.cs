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
        if (currentHealth <= 0)
        {
            Invoke("GameOver", 0.5f);
        }
    }

    public void TakeDamage()
    {
        currentHealth--;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

}
