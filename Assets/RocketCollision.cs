using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision collision) {
		switch(collision.gameObject.tag) {
			case "Friendly":
				// Do nothing
				break;
			case "Dangerous":
				Destroy(gameObject);
				break;
		}
	}
}
