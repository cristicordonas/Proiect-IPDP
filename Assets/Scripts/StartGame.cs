using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Text playerName;
    private DataBase dataBase_obj;
    private void Start()
    {
        dataBase_obj = new DataBase();
    }
    public void StartGameButton()
    {
        if (playerName.text != "")
        {
            PlayerPrefs.SetString("playerName", playerName.text);
            dataBase_obj.CreateDatabase();
            //dataBase_obj.DeleteFromLeaderboard();
            dataBase_obj.InsertIntoLeaderboard(playerName.text);
            FileUtil.ReplaceFile(Application.dataPath + "/Leaderboard.db", "../sqlite-leaderboard/Leaderboard.db");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
