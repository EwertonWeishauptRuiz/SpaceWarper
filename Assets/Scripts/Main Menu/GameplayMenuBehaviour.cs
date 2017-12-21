using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenuBehaviour : MonoBehaviour {

	public void RestartGame() {
        SceneManager.LoadScene("Game");
        print("Restart");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        print("Menu");
    }
}
