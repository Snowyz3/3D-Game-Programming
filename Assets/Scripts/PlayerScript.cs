using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int startHealth;
    [SerializeField] HeartUIScript heartUIScript;
    [SerializeField] TextMeshProUGUI customerServedText;
    [SerializeField] TextMeshProUGUI scoreText;

    PauseMenu pauseMenu;    
    int consecutiveCustomersServed;
    int score;
    int health;

    void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        heartUIScript.UpdateUI();
        customerServedText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            CustomerLeft();
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            consecutiveCustomersServed = 9;
            CustomerServed();
        }
    }

    public void CustomerServed()
    {
        consecutiveCustomersServed++;
        score++;
        customerServedText.text = score.ToString();
        if (consecutiveCustomersServed < 10)
            return;

        consecutiveCustomersServed = 0;

        if (health >= maxHealth)
            return;
            
        health++;
        heartUIScript.UpdateUI();
    }

    public void CustomerLeft()
    {
        consecutiveCustomersServed = 0;
        health--;
        heartUIScript.UpdateUI();
        if (health == 0)
        {
            scoreText.text = score.ToString();
            pauseMenu.EndGame();
        }
    }
    
    public int GetMaxHealth()
    {
        return (maxHealth);
    }

    public int GetHealth()
    {
        return (health);
    }


}
