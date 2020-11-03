using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NamingPlayersManager : MonoBehaviour
{
    public Text[] playerTexts;
    public InputField[] playerInputs;

    void Awake()
    {
        for (int i = 0; i < DataManager.Instance.numPlayers; i++)
        {
            playerTexts[i].gameObject.SetActive(true);
            playerInputs[i].gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        DataManager.Instance.playerNames = new string[DataManager.Instance.numPlayers];
        for (int i = 0; i < DataManager.Instance.numPlayers; i++)
        {
            DataManager.Instance.playerNames[i] = playerInputs[i].text;
        }
        SceneManager.LoadScene(2);
    }

}
