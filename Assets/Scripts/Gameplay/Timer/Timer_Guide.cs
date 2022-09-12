using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer_Guide : MonoBehaviour
{
    public Text textTimer;

    public GameObject Guide;
    public GameObject GameOn;

    public float waktu;

    float s;

    public bool gameRunning = false;

    private void Start()
    {
        GameOn.SetActive(false);
    }

    void Update()
    {
        s += Time.deltaTime;
        if (s >= 1)
        {
             waktu--;
             s = 0;
        }

        if (waktu <= 0)
        {
            Guide.SetActive(false);
            GameOn.SetActive(true);
            gameRunning = true;
        }
        setText();
    }
    public void setText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = menit.ToString("00") + ":" + detik.ToString("00");
    }
}
