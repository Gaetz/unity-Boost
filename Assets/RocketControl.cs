using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour {
	[SerializeField] float rotationSpeed = 100f;
	[SerializeField] float thrustSpeed = 1000f;
	[SerializeField] AudioClip mainEngine;

	Rigidbody rb;
	AudioSource audioSource;

	RocketCollision collisions;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		collisions = GetComponent<RocketCollision>();
	}
	
	// Update is called once per frame
	void Update () {
		if(collisions.State == RocketState.Alive) {
			ProcessInput();
		}
	}

	void ProcessInput() {
		Thrust();
		Rotate();
	}

	void Thrust() {
		if(Input.GetKey(KeyCode.Space)) {
			rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
			if(!audioSource.isPlaying) {
				audioSource.PlayOneShot(mainEngine);
			}
		} else {
			if(audioSource.isPlaying) {
				audioSource.Stop();
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
