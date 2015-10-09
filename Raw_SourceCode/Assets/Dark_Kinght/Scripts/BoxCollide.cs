using UnityEngine;
using System.Collections;

public class BoxCollide : MonoBehaviour {
	
	[SerializeField] AudioClip collideMonster = null;
	[SerializeField] AudioClip collideBox = null;

	void OnCollisionEnter(Collision Get)
	{
		if (Get.gameObject.tag == "Monster") {
			AudioSource.PlayClipAtPoint (collideMonster,transform.position);
		}

		if (Get.gameObject.tag == "Box") {
			AudioSource.PlayClipAtPoint (collideBox,transform.position);
		}
	}
}