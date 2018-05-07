using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rb;

	AudioSource thrustSourse;

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		thrustSourse = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	void ProcessInput() {
		if(Input.GetKey(KeyCode.Space)) {
			rb.AddRelativeForce(Vector3.up);
			if(!thrustSourse.isPlaying) {
				thrustSourse.Play();
			}
		} else {
			if(thrustSourse.isPlaying) {
				thrustSourse.Stop();
			}
		}
		Rotate();
	}

	void Rotate() {
		rb.freezeRotation = true;
		if(Input.GetKey(KeyCode.Q)) {
			transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);
		}
		rb.freezeRotation = false;
	}
}
