using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rb;

	AudioSource thrustSource;

	[SerializeField]
	float rotationSpeed = 100f;

	[SerializeField]
	float thrustSpeed = 100f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		thrustSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	void ProcessInput() {
		Thrust();
		Rotate();
	}

	void Thrust() {
		if(Input.GetKey(KeyCode.Space)) {
			rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
			if(!thrustSource.isPlaying) {
				thrustSource.Play();
			}
		} else {
			if(thrustSource.isPlaying) {
				thrustSource.Stop();
			}
		}
	}

	void Rotate() {
		rb.freezeRotation = true;
		Vector3 rotation = Vector3.forward * Time.deltaTime * rotationSpeed;
		if(Input.GetKey(KeyCode.Q)) {
			transform.Rotate(rotation);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(-rotation);
		}
		rb.freezeRotation = false;
	}
}
