using UnityEngine;
using System.Collections;

public class bulletcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {	
		tr = this.transform;
		startpoint = tr.position;
	}

	[SerializeField] GameObject explosioneffect = null;

	IEnumerator ExplosionBullet(Vector3 pos)
	{
		Debug.Log ("ExplosionBullet");
		GameObject obj = GameObject.Instantiate (explosioneffect, pos, Quaternion.identity) as GameObject;
		ParticleSystem ps = obj.transform.GetChild(0).GetComponent<ParticleSystem> ();
		DestroyObject (this.gameObject);

		yield return null;
	}

	[SerializeField] float Power = 500f;
	[SerializeField] float Range = 10f;
	[SerializeField] AudioClip collideSound = null;
	[SerializeField] AudioClip collideBoxSound = null;

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Monster")
		{
			//Shot Sound Audio play when player shots.
			AudioSource.PlayClipAtPoint (collideSound,transform.position);
			
			c.rigidbody.AddForceAtPosition (transform.forward * Power, tr.position);
			StartCoroutine ("ExplosionBullet", tr.position);

			//Create Monster Object.
			Monster monster = c.gameObject.GetComponent<Monster>();
			if(monster.GetMS != Monsterstate.Damage)
			{
				monster.Hurt();	
			}
		}
		if(c.gameObject.tag == "Box")
		{
			//Shot Sound Audio play when player shots.
			AudioSource.PlayClipAtPoint (collideBoxSound,transform.position);			
			
			c.rigidbody.AddForceAtPosition (transform.forward * (Power / 2), tr.position);
			
			StartCoroutine ("ExplosionBullet", tr.position);			
		}
	}

	[SerializeField] float bulletspeed = 8f;
	Vector3 startpoint = new Vector3();
	Transform tr;
	// Update is called once per frame
	void Update () {

		tr.Translate (0, 0, bulletspeed * Time.deltaTime);

		if (Vector3.Distance (startpoint, tr.position) > Range) {
			DestroyObject (this.gameObject);
		}
	}
}
