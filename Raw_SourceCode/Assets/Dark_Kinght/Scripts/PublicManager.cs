using UnityEngine;
using System.Collections;

public class PublicManager : MonoBehaviour {

	[SerializeField] string SceneName = "";
	[SerializeField] GameObject introSound = null;

	void Start()
	{
		introSound.SetActive (true);
	}

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	void Update () {
		KeyboardInput ();	
	}

	void KeyboardInput()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	public void StartGame()
	{
		introSound.SetActive (false);
		Application.LoadLevel(SceneName);
	}

	public void Quit()
	{
		introSound.SetActive (false);
		Application.Quit ();
	}
}
