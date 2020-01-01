using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{

	private float dirX;

	[SerializeField] private float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirX = Input.acceleration.x;
	}

	private void FixedUpdate()
	{
		float rotateY = dirX * speed * Time.fixedDeltaTime;
		transform.Rotate(0,rotateY,0);
	}
}
