using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    #region Fields
    [SerializeField]
    TextMeshProUGUI scoreText;
    int score;
    const string ScorePrefix = "Score: ";

    #endregion
    private void Start()
    {
        scoreText.text = ScorePrefix + score.ToString();
    }
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }
    public void ReducePoints(int points)
    {
        score = points;
        scoreText.text = ScorePrefix + (score - 1).ToString();
    }
    public int GetPoints()
    {
        return score;
    }
}
