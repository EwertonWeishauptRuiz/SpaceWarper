using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramBehaviour : MonoBehaviour {

    /*
        0 = Belts
        1 = Blue
        2 = Shuttle
        3 = Window
        4 = Yellow
        5 = Hologram
    */
    public Material[] materials;
    public Renderer[] renderers;
    PlayerMovement player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.godMode){
            Hologram();
        } else {
            NormalMaterials();
        }
	}
        
    void Hologram(){
        renderers[0].material = materials[5];
        renderers[1].material = materials[5];
        renderers[2].material = materials[5];
        renderers[3].material = materials[5];
        renderers[4].material = materials[5];
        renderers[5].material = materials[5];
        renderers[6].material = materials[5];
        renderers[7].material = materials[5];
        renderers[8].material = materials[5];
        renderers[9].material = materials[5];
        renderers[10].material = materials[5];
        renderers[11].material = materials[5];        
    }
    
    void NormalMaterials(){
        renderers[0].material = materials[0];
        renderers[1].material = materials[0];
        renderers[2].material = materials[1];
        renderers[3].material = materials[2];
        renderers[4].material = materials[2];
        renderers[5].material = materials[2];
        renderers[6].material = materials[2];
        renderers[7].material = materials[2];
        renderers[8].material = materials[2];
        renderers[9].material = materials[2];
        renderers[10].material = materials[3];
        renderers[11].material = materials[5];        
    }
}
