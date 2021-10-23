using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Button startButton;
    public static int score = 0;
    public static bool isStarted = false;

    private void Start()
    {
        startButton.onClick.AddListener(delegate { menu.SetActive(false); isStarted = true; });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
    }
}
