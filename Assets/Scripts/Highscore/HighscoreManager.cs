using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private string KeyToSave = "KeyHighscore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighscore;


    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
    uiTextHighscore.text = PlayerPrefs.GetString(KeyToSave,"Sem Highscore");

    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(KeyToSave, p.playerName);
        UpdateText();
    }
}
    
