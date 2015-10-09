using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	[SerializeField] GameObject TargetCharacter = null;
	[SerializeField] float Distance = 10f;
	[SerializeField] float Height = 10f;
	[SerializeField] float Speed = 10f;
	Vector3 POs = new Vector3();
	
	// Update is called once per frame
	void Update () {
		POs = new Vector3 (TargetCharacter.transform.position.x, Height, TargetCharacter.transform.position.z - Distance);
		this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, POs, Speed*Time.deltaTime);
	}
}
