using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI score;

    private void OnEnable()
    {
        CollectableObject.OnObjectCollected += AddScore;
    }
    private void OnDisable()
    {
        CollectableObject.OnObjectCollected -= AddScore;
    }
    private void Start()
    {
        UpdateScore();
    }
    public void AddScore()
    {
        playerScore += 10;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if(score == null) { return; }
        score.text = "Points: " + playerScore;
        //Debug.Log("Score updated: " + playerScore);
    }

    private void FinishGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
