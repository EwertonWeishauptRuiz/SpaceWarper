using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour {

    public GameObject creditsCanvas;
    
    void Start(){
        creditsCanvas.SetActive(false);
    }

	public void StartGame(){
        SceneManager.LoadScene("Set-UP");
        print("StartGame");
    }
    
    public void Options(){
        print("Options");
    }
    
    public void Credits(){
        creditsCanvas.SetActive(true);
        print("OpenCredits");
    }
    
    public void CloseCredits(){
        creditsCanvas.SetActive(false);
        print("CloseCredits");
    }
    
    public void ExitGame(){
        Application.Quit();
    }
}
