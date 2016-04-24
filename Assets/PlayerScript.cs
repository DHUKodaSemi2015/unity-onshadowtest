using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	float speed = 0.1f;
	private Color defaultColor;

	void Start () {
		Debug.Log("Start");

		defaultColor = GetComponent<Renderer>().material.color;
	}

	void RayShadow() {
		GameObject light = GameObject.Find ("Light");
		Ray ray = new Ray (transform.position - new Vector3(0f, 1f, 0f), light.transform.forward * -1);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			GetComponent<Renderer>().material.color = Color.red;
		} else {
			GetComponent<Renderer>().material.color = defaultColor;
		}
		//Debug.DrawRay(ray.origin, ray.direction * 500, Color.red, 5, false);
	}

	void Control() {
		if (Input.GetKey ("w")) {
			transform.position += transform.forward * speed;
		} 
		if (Input.GetKey ("s")) {
			transform.position -= transform.forward * speed;
		}
		if (Input.GetKey ("d")) {
			transform.position += transform.right * speed;
		}
		if (Input.GetKey ("a")) {
			transform.position -= transform.right * speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		RayShadow ();
		Control ();
	}
}
