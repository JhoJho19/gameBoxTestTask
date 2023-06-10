using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    int score = 0;
    int mergescore;
    [SerializeField] private Text scoreCounterText;

    private void Update()
    {
        score += mergescore;
        scoreCounterText.text = score.ToString();
    }
}
