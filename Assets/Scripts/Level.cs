using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class Level : MonoBehaviour
{
    [SerializeField] public int totalCoinsAmount;
    [SerializeField] public int coinsFound { get; set; }
    [SerializeField] public int showelsAmount = 20;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI showelsLeftText;

    // cached reference
    SceneLoader sceneloader;
    System.Random random;
    public int coinsPicked { get; set; }

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();

        //totalCoinsAmount = random.Next(3, 10);
        coinsFound = 0;
        coinsPicked = 0;
        random = new System.Random();
    }

    private void Update()
    {
        scoreText.SetText(coinsPicked.ToString());
        showelsLeftText.SetText(showelsAmount.ToString());
    }

    public void BlockShoweled()
    {
        showelsAmount--;
        if (coinsPicked == totalCoinsAmount)
        {
            sceneloader.LoadNextScene();
        }
        if (showelsAmount <= 0)
        {
            FindObjectOfType<SceneLoader>().RestartGame();
        }
    }

    public void RestartOnClick()
    {
        FindObjectOfType<SceneLoader>().RestartLevel();
    }
}
