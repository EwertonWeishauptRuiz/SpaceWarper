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

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        scoreManager = GetComponent<HighScoreManager>();
        speedCanvas = GameObject.Find("SpeedIndicator");
        highscoreHolder.SetActive(false);    
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
        
    void PlayerDead(int points){
        speedCanvas.SetActive(false);
        pointsDisplay.GetComponent<Text>().enabled = false;        
		highscoreHolder.SetActive(true);
        scoreManager.CheckHighScores(PlayerPrefs.GetString("PlayerName"), points);
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            pointCounter++;            
            points = pointCounter * multiplier * 10;
        }
    }
}
