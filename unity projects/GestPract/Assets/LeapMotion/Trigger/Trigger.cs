using UnityEngine;
using System.Collections;
using Leap;


public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
       			// Destroy(other.gameObject);
       			Debug.Log("Enter the area");
       
    }

	void OnTriggerExit(Collider other) {
       			// Destroy(other.gameObject);
       			Debug.Log("left the area");
    }

}
