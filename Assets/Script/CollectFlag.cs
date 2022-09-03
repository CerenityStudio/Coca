using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectFlag : MonoBehaviour
{
    private int flag = 0;

    [SerializeField] private TextMeshProUGUI flagScore;
    [SerializeField] private GameObject collectedPanel;

    void Awake()
    {
        collectedPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flag A"))
        {
            Destroy(collision.gameObject);
            flag += 10;
            flagScore.text = "" + flag;
        }

        if (collision.gameObject.CompareTag("Flag B"))
        {
            Destroy(collision.gameObject);
            flag += 20;
            flagScore.text = "" + flag;
        }

        if (collision.gameObject.CompareTag("Flag C"))
        {
            Destroy(collision.gameObject);
            flag += 50;
            flagScore.text = "" + flag;
        }

        /*
        if (flag >= 3)
        {
            collectedPanel.SetActive(true);
        }
        */
    }
}
