using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    //public InputField playerName;
    public TMP_InputField playerName;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // load previous high score with player name
        getHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // start the game if player name entered
    public void StartGame()
    {
        if (playerName.text != null && playerName.text != "Enter name")
        {
            DataManager.Instance.playerName = playerName.text;
            SceneManager.LoadScene(1);
        }

    }

    // exit the game
    public void ExitGame()
    {
        DataManager.Instance.SaveScore();
# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# else
        Application.Quit();
# endif
    }

    void getHighScore()
    {
        // load previous high score with player name if exists
        if (DataManager.Instance.highScore != 0)
        {
            highScoreText.SetText($"High Score: {DataManager.Instance.highScorePlayerName} : {DataManager.Instance.highScore}");
        }
        else
        {
            highScoreText.SetText("High Score: 0");
        }
    }
}
