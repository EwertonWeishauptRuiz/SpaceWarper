using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicBackground : MonoBehaviour {
      

	// Use this for initialization
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
	}

}
