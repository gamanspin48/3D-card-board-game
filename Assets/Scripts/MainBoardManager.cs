using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoardManager : MonoBehaviour
{
    public GameObject[] players;

    public Transform[] playerPositions;


    void Awake()
    {
        for (int i = 0; i < DataManager.Instance.numPlayers; i++)
        {
            Instantiate(players[i], playerPositions[i].position, Quaternion.identity);
        }
    }

}
