using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Video reference: https://www.youtube.com/watch?v=rEGPve_8kW4

public class HighScoreManager : MonoBehaviour {

    public Text[] highscores;
    string[] highscoreNames;
    int[] highscorePoints;
    
    void Start(){
        highscoreNames = new string[highscores.Length];
        highscorePoints = new int[highscores.Length];

        for (int i = 0; i < highscores.Length; i++){
            highscoreNames[i] = PlayerPrefs.GetString("HighscoreNames" + i);
            highscorePoints[i] = PlayerPrefs.GetInt("HighscorePoints" + i);
        }
    }
    //Is called, is not saving
    void SaveScores(){
        for (int i = 0; i < highscores.Length;i++){
            PlayerPrefs.SetString("HighscoreNames", highscoreNames[i]);
            PlayerPrefs.SetInt("HighscorePoints", highscorePoints[i]);
        }
        print("Saving scores");
    }
    //Is called, is not saving
    public void CheckHighScores(string name, int points){
        for (int i = 0; i < highscores.Length;i++){
            if(points > highscorePoints[i]){
                for (int x = highscores.Length - 1; x > i; x--){
                    highscoreNames[x] = highscoreNames[x - 1];
                    highscorePoints[x] = highscorePoints[x - 1];
                }
                highscorePoints[i] = points;
                highscoreNames[i] = name;
            }
            SaveScores();
			DrawScore();
        }
        print("Display HighScores");
    }
    
    void DrawScore(){
        for (int i = 0; i < highscores.Length; i++){
            highscores[i].text = highscoreNames[i] + ":" + highscorePoints[i];
        }
    }

}
