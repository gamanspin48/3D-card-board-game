using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBoardManager : MonoBehaviour
{
    public GameObject[] players;

    public Transform[] playerPositions;

    public int curIndexPlayer;

    public string state = "idle";

//UI
    public Text diceText;
    public Text playerText;

    void Awake()
    {
        for (int i = 0; i < DataManager.Instance.numPlayers; i++)
        {
            Instantiate(players[i], playerPositions[i].position, Quaternion.identity);
        }
        playerText.text = DataManager.Instance.playerNames[0];
    }

    public void RollDice()
    {
        diceText.text = Random.Range(1, 6).ToString();
        nextPlayerIndex();
        playerText.text = DataManager.Instance.playerNames[curIndexPlayer];

    }

    public void nextPlayerIndex()
    {
        if (curIndexPlayer == DataManager.Instance.numPlayers - 1)
            curIndexPlayer = 0;
        else
            curIndexPlayer++;
    }

}
