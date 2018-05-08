using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum RocketState { Alive, Dying, Transcending };

public class RocketCollision : MonoBehaviour {

	[SerializeField]
	float reloadTimer = 1f;

	public RocketState State {
		get { return state; }
	}
	RocketState state;
	
	void Start() {
		state = RocketState.Alive;
	}

	// Use this for initialization
	void OnCollisionEnter(Collision collision) {
		if(state != RocketState.Alive) return;

		switch(collision.gameObject.tag) {
			case "Friendly":
				// Do nothing
				break;
			case "Finish":
				state = RocketState.Transcending;
				Invoke("LoadNextScene", reloadTimer);
				break;
			case "Dangerous":
				state = RocketState.Dying;
				Invoke("RestartLevel", reloadTimer);
				break;
		}
	}

	void LoadNextScene() {
		state = RocketState.Alive;
		SceneManager.LoadScene(1);
	}

	void RestartLevel() {
		SceneManager.LoadScene(0);
		state = RocketState.Alive;
	}
}
