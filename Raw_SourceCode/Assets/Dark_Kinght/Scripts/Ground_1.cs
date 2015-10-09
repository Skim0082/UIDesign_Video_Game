using UnityEngine;
using System.Collections;

public class Ground_1 : MonoBehaviour {

	[SerializeField] AudioClip soundMonsterScream = null;

	void OnTriggerEnter(Collider Get)
	{
		if (Get.gameObject.tag == "Monster") {

			Monster monster = Get.gameObject.GetComponent<Monster>();
			if( monster.GetMS != Monsterstate.Dead)
			{
				monster.Dead ();	//change the state of animation			
			}
			AudioSource.PlayClipAtPoint (soundMonsterScream,transform.position);
		}
	}
}
