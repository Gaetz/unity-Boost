using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision collision) {
		switch(collision.gameObject.tag) {
			case "Friendly":
				// Do nothing
				break;
			case "Finish":
				SceneManager.LoadScene(1);
				break;
			case "Dangerous":
				SceneManager.LoadScene(0);
				break;
		}
	}
}
