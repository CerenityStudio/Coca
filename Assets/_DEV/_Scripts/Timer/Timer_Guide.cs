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

    public PlayerController pc;

    public void setText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = menit.ToString("00") + ":" + detik.ToString("00");
    }

    float s;

    private void Start()
    {
        GameOn.SetActive(false);
        pc.rb.isKinematic = true;
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
            pc.rb.isKinematic = false;
            Guide.SetActive(false);
            GameOn.SetActive(true);
        }

        setText();
    }
}
