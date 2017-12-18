using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleBehaviour : MonoBehaviour {
	
	void Start () {
        StartCoroutine("Destroy");
	}
	
    IEnumerator Destroy() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
