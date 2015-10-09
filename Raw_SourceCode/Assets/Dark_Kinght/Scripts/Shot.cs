using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	[SerializeField] GameObject effectfireball = null;
	[SerializeField] Animation anim = null;
	[SerializeField] AudioClip shot_sound = null;
	float offsetofbullet = 1;

	public IEnumerator ShotBullet()
	{
		anim.Play ("Attack");
		GameObject.Instantiate(effectfireball, this.transform.position + this.transform.forward * offsetofbullet, this.transform.rotation);
	
		AudioSource.PlayClipAtPoint (shot_sound,transform.position);

		yield return null;
	}
}
