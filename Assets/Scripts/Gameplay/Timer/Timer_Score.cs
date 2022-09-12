using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer_Score : MonoBehaviour
{
    public Text textTimer;
    public float waktu;
    public bool gameON = true;

    public GameObject leaderboardsPanel;
    public GameObject flagHandler;

    public Timer_Guide tg;

    private void Start()
    {
        Time.timeScale = 1f;
        flagHandler.SetActive(false);
        leaderboardsPanel.SetActive(false);
    }


    float s;

    void Update()
    {
        if (tg.gameRunning == true)
        {
            flagHandler.SetActive(true);
        }

        if (gameON)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                waktu--;
                s = 0;
            }
        }

        if (gameON && waktu <= 0)
        {
            Debug.Log("Game Over");
            gameON = false;

            Time.timeScale = 0f;
            ShowLeaderboards();
            flagHandler.SetActive(false);

        }

        setText();
    }

    public void setText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = menit.ToString("00") + ":" + detik.ToString("00");
    }

    public void DisableLeaderboards()
    {
        leaderboardsPanel.SetActive(false);
    }

    public void ShowLeaderboards()
    {
        leaderboardsPanel.SetActive(true);
    }
}