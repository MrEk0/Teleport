using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    Player player;

    private float startScore = 0f;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        player.OnGetBanana += ChangeScore;
    }

    private void OnDisable()
    {
        player.OnGetBanana -= ChangeScore;
    }

    private void Start()
    {
        scoreText.text = startScore.ToString();
    }

    private void ChangeScore(float additionalScore)
    {
        startScore += additionalScore;
        scoreText.text = startScore.ToString();
    }
}
