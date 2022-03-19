using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text score;
    private int scoreInt;

    private void Start()
    {
        score.text = "0";
        scoreInt = 0;
    }
    public void IncrementScore()
    {
        scoreInt++;
        score.text = scoreInt.ToString();
    }
}
