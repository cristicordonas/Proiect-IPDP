using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor;

public class TimeCount : MonoBehaviour
{
    public static float secondsCount = 0;
    public static int minutesPassed = 0;
    [SerializeField] private Text timeCountText;
    private DataBase dataBase_obj;
    private bool dbUpdated;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("minutesPassed", 0);
            PlayerPrefs.SetFloat("secondsCount", 0);
        }
        minutesPassed = PlayerPrefs.GetInt("minutesPassed");
        secondsCount = PlayerPrefs.GetFloat("secondsCount");
        dataBase_obj = new DataBase();
        dbUpdated = false;
    }
    void Update()
    {   
        timeCountText.text = "Time: " + minutesPassed + " min " + (int)secondsCount + " s";
        if(PlayerLife.isDead)
        {
            return;
        }
        else
        {
            secondsCount += Time.deltaTime;
        }
        if(secondsCount >= 60)
        {
            secondsCount = 0;
            minutesPassed++;
        }
        if(Finish.isLevelCompleted)
        {
            Finish.isLevelCompleted = false;
            PlayerPrefs.SetInt("minutesPassed", minutesPassed);
            PlayerPrefs.SetFloat("secondsCount", secondsCount);
            if (SceneManager.GetActiveScene().buildIndex == 3 && !dbUpdated)
            {
                dbUpdated = true;
                dataBase_obj.UpdateLeaderboard(PlayerPrefs.GetString("playerName"), minutesPassed, (int)secondsCount);
                FileUtil.ReplaceFile(Application.dataPath + "/Leaderboard.db", "../sqlite-leaderboard/Leaderboard.db");
            }
        } 
    }
}
