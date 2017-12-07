using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    public Text[] highscores;
    string[] highscoreNames;
    int[] highscorePoints;
    
    void Start(){
        highscoreNames = new string[highscores.Length];
        highscorePoints = new int[highscores.Length];    

        //Initialize a Leaderboard
        //for (int i = 0; i < highscores.Length; i++) {            
        //    PlayerPrefs.SetString("HighscoreNames" + i, "a" + i.ToString());
        //    PlayerPrefs.SetInt("HighscorePoints" + i, i * 10);
        //}

        //Print HighScores in the beginning
        //for (int i = 0; i < highscores.Length; i++) {
        //    highscoreNames[i] = PlayerPrefs.GetString("HighscoreNames" + i);
        //    highscorePoints[i] = PlayerPrefs.GetInt("HighscorePoints" + i);
        //    print("Highscore " + i + " is : " + PlayerPrefs.GetInt("HighscorePoints" + i) + " from player : " + PlayerPrefs.GetString("HighscoreNames" + i));
        //}        
    }

    void SaveScores(){
        for (int i = 0; i < highscores.Length; i++) {
            PlayerPrefs.SetString("HighscoreNames" + i, highscoreNames[i]);
            PlayerPrefs.SetInt("HighscorePoints" + i, highscorePoints[i]);
            PlayerPrefs.Save();
        }       
    }
    
    public void CheckHighScores(string name, int points){
        for (int x = 0; x < highscores.Length; x++) {
            //Find out if it is higher than any other score.
            if (points > highscorePoints[x]) {
                print("New highscore");
                //Rearange all the highscores
                //Start at the bottom of the list.
                for (int y = highscores.Length - 1; y > x; y--) {
                    highscoreNames[y] = highscoreNames[y - 1];
                    highscorePoints[y] = highscorePoints[y - 1];
                }            
                //Put the new HighScore in place
                highscoreNames[x] = name;
                highscorePoints[x] = points;
                //Display and save new HighScores
                DrawScore();
                SaveScores();                
                break;                
            }          
        } 
        DrawScore();               
    }
    
    void DrawScore(){
        for (int i = 0; i < highscores.Length; i++){
            highscores[i].text = highscoreNames[i] + "  -  " + highscorePoints[i].ToString();
        }
    }
}
