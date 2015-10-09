using UnityEngine;
using System.Collections;

public class destroyexplosion : MonoBehaviour {
	
	IEnumerator DestroyExplosion()
	{
		yield return new WaitForSeconds(2.0f);
		
		DestroyObject (this.gameObject);
		yield return null;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyExplosion ());
	}
}
