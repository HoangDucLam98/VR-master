using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

	public static MainMenuController Instance;

	private void OnEnable()
	{
		if (Instance==null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		// else
		// {
		// 	Destroy(this.gameObject);
		// }
	}

	public void PlayButton()
	{
		SceneManager.LoadScene("race_track_lake");
	}
	
}
