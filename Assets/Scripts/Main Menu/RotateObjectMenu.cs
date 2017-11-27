using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectMenu : MonoBehaviour {

    public GameObject rotationInstructions;

    public float sensitivity = 0.4f;
    public float speedKeyboard = 2;
    Vector3 startRotation;
    Vector3 mouseReference;
    Vector3 mouseOffset;
    Vector3 newRotation;
    bool isRotating;

    void Start() {        
        newRotation = Vector3.zero;
        rotationInstructions.SetActive(false);
        startRotation = transform.eulerAngles;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            transform.eulerAngles = startRotation;
        }

        float w = 0;
        float h = Input.GetAxis("Horizontal") * speedKeyboard;
        float v = Input.GetAxis("Vertical") * speedKeyboard;
		
        if (Input.GetKey(KeyCode.Q))
			w = 30 * speedKeyboard * Time.deltaTime;

        if(Input.GetKey(KeyCode.E))
            w = 30 * speedKeyboard * Time.deltaTime * -1;   
            
        transform.Rotate(w, h,v);
        
        
        if (isRotating) {
            rotationInstructions.SetActive(false);
            
            mouseOffset = (Input.mousePosition - mouseReference);

			newRotation.y = -(mouseOffset.x) * sensitivity;
            newRotation.x = -mouseOffset.x * sensitivity;
            newRotation.z = -mouseOffset.y * sensitivity;
            
            transform.eulerAngles += newRotation;
            
            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown() {
        isRotating = true;
        mouseReference = Input.mousePosition;        
    }

    void OnMouseUp() {        
        isRotating = false;
    }
    
    void OnMouseOver() {        
        rotationInstructions.SetActive(true);
    }

    void OnMouseExit() {
        rotationInstructions.SetActive(false);    
    }

}

