using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuState : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GamePlayState gamePlayState;
    public TextMeshProUGUI scoreText;
    
    private void OnEnable()
    {

    }
    public void Play()
    {
        this.gameObject.SetActive(false);
        gamePlayState.Play();

    }
}
