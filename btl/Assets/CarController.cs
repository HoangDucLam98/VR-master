using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

	[SerializeField] private float runSpeed;

	[SerializeField] private float rotateSpeed;
	[SerializeField] private float timeToReturn;
	[SerializeField] private float speedUp;

	[SerializeField] private GameObject endPanel;
	
	private float dirX;
	private float dirZ;
	private bool moved;
	
	// Use this for initialization
	void Start () {
		AudioManager.instance.Play("Freeze");
		endPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirX = Input.acceleration.x;
		dirZ = Input.acceleration.z;
		// dirX = Input.GetAxis("Horizontal");
		// dirZ = Input.GetAxis("Vertical");
	}

	private void FixedUpdate()
	{
		float moveZ = dirZ * runSpeed * Time.fixedDeltaTime;
		Debug.Log(moveZ);
		if( moveZ < -.25 && moved == false ) {
			moved = true;
			AudioManager.instance.Play("AccelerationHigh");
		}
		if( moveZ >= -.25 && moved == true ) {
			moved = false;
			AudioManager.instance.DestroyLoop("AccelerationHigh");
		}
		transform.Translate(new Vector3(0,0,-moveZ));
		float rotateY = dirX * rotateSpeed * Time.fixedDeltaTime;
		transform.Rotate(0,rotateY,0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Item"))
		{
			Destroy(other.gameObject);
			runSpeed = speedUp;
			StartCoroutine(ReturnSpeed());
		}

		if (other.CompareTag("FinishLine"))
		{
			Time.timeScale = 0;
			endPanel.SetActive(true);
		}
	}

	IEnumerator ReturnSpeed()
	{
		yield return new WaitForSeconds(timeToReturn);
		runSpeed = 30;
	}

	public void HomeButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}

	public void RestartButton()
	{
		SceneManager.LoadScene("race_track_lake");
		Time.timeScale = 1;
	}
	
}
