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

    public PlayerController pc;

    public void setText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = menit.ToString("00") + ":" + detik.ToString("00");
    }

    float s;

    void Update()
    {
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
            pc.rb.isKinematic = true;
            gameON = false;
            UIController.instance.LeaderboardOn();
        }

        setText();
    }
}