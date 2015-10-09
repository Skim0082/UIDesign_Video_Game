using UnityEngine;
using System.Collections;

public class RotateCursor : MonoBehaviour {

	[SerializeField] float Speed = 5f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0f, Speed, 0f));
	}
}
