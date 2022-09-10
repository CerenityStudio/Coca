using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject leaderboardPanel;

    // Start is called before the first frame update
    void Start()
    {
        //leaderboardPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaderboardOn()
    {
        leaderboardPanel.SetActive(true);
    }
}
