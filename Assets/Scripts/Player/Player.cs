using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int currentHealth;
    private Animator animator;
    [SerializeField] private TextMeshProUGUI vidasText;
    public UnityEvent OnPlayerDeath;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        currentHealth = 1;
        UpdateHealthText();
    }

    public void AddPoint()
    {
        AudioManager.Instance.PlayWih();
        animator.Play("Pompi vida");
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        //AudioManager.Instance.PlayWih();
        //animator.Play("Pompi vida");
        AudioManager.Instance.PlayPop();
        if (currentHealth > Utils.Variables.MaxHealth)
        {
            currentHealth = Utils.Variables.MaxHealth;
        }
        UpdateHealthText();
    }

    public void SubtractHealth(int amount)
    {
        currentHealth -= amount;
        AudioManager.Instance.PlayAuch();
        if (currentHealth <= 0)
        {
            animator.Play("Pompi muerte total");
            currentHealth = 0;
            GameOver();
        }
        else 
            animator.Play("Pompi muerte");
        UpdateHealthText();
    }

    private void GameOver()
    {
        OnPlayerDeath.Invoke();
    }

    private void UpdateHealthText()
    {
        vidasText.text = "Vidas: " + currentHealth;
    }
}