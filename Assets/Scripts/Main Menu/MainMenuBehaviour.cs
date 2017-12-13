using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {

    RotateObjectMenu rotateObject;

    public GameObject creditsCanvas;
    public GameObject optionsCanvas;
    bool active;

    void Start(){
        creditsCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        rotateObject = GameObject.Find("ShipHolder").GetComponent<RotateObjectMenu>();
    }

    void Update() {
        if (active) {
            rotateObject.canRotate = false;            
        } else {
            rotateObject.canRotate = true;
        }
    }

	public void StartGame(){
        SceneManager.LoadScene("Set-UP");        
    }
    
    public void Options(){
        optionsCanvas.SetActive(true);
        active = true;        
    }

    public void CloseOptions() {
        optionsCanvas.SetActive(false);
        active = false;
    }

    public void Credits(){
        creditsCanvas.SetActive(true);
        active = true;
    }
    
    public void CloseCredits() {
        creditsCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        active = false;
    }

    public void ExitGame(){
        Application.Quit();
    }
}
