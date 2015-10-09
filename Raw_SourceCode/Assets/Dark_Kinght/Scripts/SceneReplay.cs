using UnityEngine;
using System.Collections;

public class SceneReplay : MonoBehaviour {

	[SerializeField] string sceneName = "";

	public void Replay()
	{
		Application.LoadLevel(sceneName);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
