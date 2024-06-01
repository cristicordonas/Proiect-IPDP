using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    private DataBase dataBase_obj;
    private Text textBox;
    void Start()
    {
        dataBase_obj = new DataBase();
        textBox = GetComponent<Text>();
    }

    void Update()
    {
        textBox.text = dataBase_obj.ReadFromLeaderboard();
    }
}
