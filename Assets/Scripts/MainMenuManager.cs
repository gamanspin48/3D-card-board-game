using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject nextBtn;
    public GameObject prevBtn;
    public int numPlayers = 2;
    const int MIN_PLAYER = 2;
    const int MAX_PLAYER = 4;
    public Text numPlayersText;
    
    public void NextButton()
    {
        numPlayers++;
        numPlayersText.text = numPlayers.ToString();
        nextBtn.SetActive(numPlayers < MAX_PLAYER);
        prevBtn.SetActive(numPlayers > MIN_PLAYER);
        DataManager.Instance.numPlayers = numPlayers;
    }

    public void PrevButton()
    {
        numPlayers--;
        numPlayersText.text = numPlayers.ToString();
        nextBtn.SetActive(numPlayers < MAX_PLAYER);
        prevBtn.SetActive(numPlayers > MIN_PLAYER);
        DataManager.Instance.numPlayers = numPlayers;

    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
