using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

    float speed;
    Rigidbody rbd;
    int ammoAmount;
    
    void Start(){
        rbd = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        rbd.AddForce(0, 0, -10);
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Kill"){
            Destroy(gameObject);            
        }
    }
}
