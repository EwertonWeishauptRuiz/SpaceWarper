using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int pointCounter;
    float points;
    float multiplier = 1;

    public Text pointsDisplay;


	// Update is called once per frame
	void Update () {

        DisplayPoints();

        if (pointCounter > 10) {
           multiplier = 1.1f;

        }
        if (pointCounter > 20){
            multiplier = 1.2f;

        }
        if (pointCounter > 30) {
            multiplier = 1.4f;

        }
        if (pointCounter > 50) {            
            multiplier = 1.6f;

        }
        if (pointCounter > 50) {
            multiplier = 1.7f;

        }
        if (pointCounter > 60) {
            multiplier = 2f;

        }
        if (pointCounter > 65) {
            multiplier = 2.2f;

        }
        if (pointCounter > 70) {
            multiplier = 2.5f;

        }
        if (pointCounter > 80) {
            multiplier = 2.7f;

        }
        if (pointCounter > 90) {
            multiplier = 3f;

        }
    }
    void DisplayPoints() {
        int roundPoints = Mathf.RoundToInt(points);
        pointsDisplay.text = roundPoints.ToString ();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            pointCounter++;            
            points = pointCounter * multiplier * 10;
        }
    }


}
