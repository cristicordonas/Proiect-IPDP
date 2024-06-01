using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SceneManagement;

public class DataBase
{
    private string dbName = "URI=file:../sqlite-leaderboard/Leaderboard.db";
    public void CreateDatabase() 
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Leaderboard (name VARCHAR2 PRIMARY KEY, minutes INTEGER, seconds INTEGER )";
                command.ExecuteNonQuery();
            }
            Debug.Log("Database created");
            connection.Close();
        }
    }
    public void InsertIntoLeaderboard(string name)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Leaderboard (name, minutes, seconds) VALUES ('" + name + "', 0, 0)";
                command.ExecuteNonQuery();
            }
            Debug.Log("Name: " + name + " inserted in database");
            connection.Close();
        }
    }
    public string ReadFromLeaderboard()
    {
        string text = "";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Leaderboard ORDER BY minutes, seconds";
                using (IDataReader reader = command.ExecuteReader())
                {
                    int top = 10;
                    while (reader.Read() && top > 0)
                    {
                        string name = reader.GetString(0);
                        int minutes = reader.GetInt32(1);
                        int seconds = reader.GetInt32(2);
                        Debug.Log("Name: " + name + " Minutes: " + minutes + " Seconds: " + seconds);
                        text += name + " " + minutes + " min " + seconds + " s\n";
                        top--;
                    }
                }
            }
            connection.Close();
        }
        return text;
    }
    public void UpdateLeaderboard(string name, int minutes, int seconds)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Leaderboard SET minutes = " + minutes + ", seconds = " + seconds + " WHERE name = '" + name + "'";
                command.ExecuteNonQuery();
            }
            Debug.Log("Name: " + name + " updated in database with minutes: " + minutes + " and seconds: " + seconds);
            connection.Close();
        }
    }

    public void DeleteFromLeaderboard()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Leaderboard";
                command.ExecuteNonQuery();
            }
            Debug.Log("Database cleared");
            connection.Close();
        }
    }
}
