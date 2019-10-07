using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] GameObject losePanel = null;

    private Image[] lifes;
    Player player;
    Canvas canvas;

    private int lifeCount = 0;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        canvas = GetComponentInParent<Canvas>();

        lifes = GetComponentsInChildren<Image>();
        lifeCount = lifes.Length;
    }

    private void OnEnable()
    {
        player.OnTouchBomb += LoseLife;
    }

    private void OnDisable()
    {
        player.OnTouchBomb -= LoseLife;
    }

    private void LoseLife()
    {
        lifeCount--;

        if (lifeCount > 0)
        {
            lifes[lifeCount].enabled = false;
        }
        else
        {
            ShowLosePanel();
        }
    }

    private void ShowLosePanel()
    {
        Time.timeScale = 0f;
        Instantiate(losePanel, canvas.transform);
    }
}
