﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {

	public string nameOfInteractableObject;
	public GameObject destroyParticles;
	float dist = 0f;

	MyInventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
		//print("Distance to other: " + dist);
	}

	public void Go(){
		Debug.Log ("Yay! Interaction!!!");
		if ((inventory.getItemInHand ().name == nameOfInteractableObject) && dist < 4f) {
			//inventory.removeItem (inventory.getItemInHand ());
			if (destroyParticles != null) {
				var expl = Instantiate (destroyParticles, transform.position, Quaternion.identity);
				Destroy (inventory.getItemInHand ().gameObject);

				inventory.removeItem (inventory.getItemInHand ());
				Destroy (gameObject);
				Destroy (expl, 3);
			}
			Debug.Log ("Boom");
		} else {
			Debug.Log ("Wrong item!");
		}
	}

	public bool CheckIfInteractable(string name){
		if (dist < 4f) {
			return name == nameOfInteractableObject;
		} else
			return false;
			
		
	}
}
