using UnityEngine;
using TMPro; // Make sure you have TextMeshPro package installed

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 30f; // Duration in seconds
    public TextMeshProUGUI countdownText; // Assign in Inspector

    private float currentTime;
    private bool gameEnded = false;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        if (gameEnded)
            return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0); // Clamp to 0

        countdownText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0f)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0f; // Pause the game
        countdownText.text = "Time's Up!";
    }
}
