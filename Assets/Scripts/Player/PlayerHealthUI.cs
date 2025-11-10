using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealth;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealth;
    }

    void UpdateHealth(int current, int max)
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {current}/{max}";
        }
    }
}
