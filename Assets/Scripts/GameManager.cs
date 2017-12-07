using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int pointCounter;
    float points;
    float multiplier = 1;
    [HideInInspector]
    public int roundPoints;
    int targetScore = 10;
    public Text pointsDisplay;
    PlayerMovement player;
    HighScoreManager scoreManager;
    GameObject speedCanvas;
    public GameObject highscoreHolder;
    bool highscoreChecked;

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        scoreManager = GetComponent<HighScoreManager>();
        speedCanvas = GameObject.Find("SpeedIndicator");
        highscoreHolder.SetActive(false);
        highscoreChecked = false; 
    }
    
    void Update() {
        if(!player.dead){
			DisplayPoints();
			Multipliers();         
        } else {
            PlayerDead(roundPoints);
        }
    }     

    void DisplayPoints() {
        roundPoints = Mathf.RoundToInt(points);
        pointsDisplay.text = roundPoints.ToString();
    }

    void Multipliers(){
        if (pointCounter > targetScore){
            targetScore += 10;
            multiplier += 0.1f;
        }
    }
        
    void PlayerDead(int playerPoints){
        speedCanvas.SetActive(false);
        pointsDisplay.GetComponent<Text>().enabled = false;        
		highscoreHolder.SetActive(true);
        if (!highscoreChecked) {
            scoreManager.CheckHighScores(PlayerPrefs.GetString("PlayerName"), playerPoints);
            highscoreChecked = true;
        }
    }
    
    public void AsteroidDestroyed(int addPoints){
        points += addPoints;
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            pointCounter++;            
            points = pointCounter * multiplier * 10;
        }
    }
}
