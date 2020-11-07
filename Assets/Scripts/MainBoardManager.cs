using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBoardManager : MonoBehaviour
{
    public GameObject[] playersPrefab;

    public Player[] players;

    public Transform[] playerPositions;

    public int curIndexPlayer;

    public Board[] boards;
    public Board destinationBoard;
    public Board curDestinationBoard;
    int step;

    public string state = "idle";

//UI
    public Text diceText;
    public Text playerText;

    bool isPlay = true;

    public static MainBoardManager Instance { get; private set; } // static singleton

    public Vector3[] vectorPosition;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        for (int i = 0; i < DataManager.Instance.numPlayers; i++)
        {
            players[i] = Instantiate(playersPrefab[i], playerPositions[i].position, Quaternion.identity).GetComponent<Player>();
        }
        playerText.text = DataManager.Instance.playerNames[0];
        BoardsPosition();
    }

    void Update()
    {   
        if (isPlay)
        {
            switch (state)
            {
                case "idle":
                    break;
                case "roll":
                    if (!players[curIndexPlayer].Move(curDestinationBoard))
                    {
                        if (curDestinationBoard == destinationBoard)
                        {
                            if (curDestinationBoard == boards[boards.Length - 1])
                                state = "finish";
                            else
                            {
                                state = "idle";
                                playerText.text = DataManager.Instance.playerNames[curIndexPlayer];
                                players[curIndexPlayer].transform.position = boards[players[curIndexPlayer].curIndex].playerPositions[curIndexPlayer].transform.position;
                            }
                            
                        }
                        else
                        {
                            TakeStep();
                        }
                    }
                    break;
                case "finish":
                    playerText.text = DataManager.Instance.playerNames[curIndexPlayer] + " win";
                    isPlay = false;
                    break;
                default:
                    break;
            }
        
        }
    }

    public void RollDice()
    {
        int diceCount = Random.Range(1, 6);
        diceText.text = diceCount.ToString();
        NextPlayerIndex();
        int des = players[curIndexPlayer].curIndex + diceCount;
        if ( des < boards.Length)
        {
            state = "roll";
            step = diceCount;
            TakeStep();
            destinationBoard = boards[players[curIndexPlayer].curIndex + step];
        }
        
    }

    public void NextPlayerIndex()
    {
        if (curIndexPlayer == DataManager.Instance.numPlayers - 1)
            curIndexPlayer = 0;
        else
            curIndexPlayer++;

    }

    public void TakeStep()
    {
        players[curIndexPlayer].curIndex ++;
        curDestinationBoard = boards[players[curIndexPlayer].curIndex];
        step--;
    }

    public void BoardsPosition() {
        for (int i = 0; i < boards.Length; i++) {
            for (int j = 0; j < boards[i].playerPositions.Length; j++) {
                boards[i].playerPositions[j] = Instantiate(playersPrefab[j], playerPositions[j].transform.localPosition, Quaternion.identity, boards[i].transform).transform;
                boards[i].playerPositions[j].transform.localPosition = vectorPosition[j];
          
            }
        }
    }

}
