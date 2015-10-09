using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	[SerializeField] public Shot shot = null;
	[SerializeField] Animation anim = null;
	[SerializeField] GameObject ps = null;
	public float MoveSpeed;
	public Vector3 lookDirection;

	// Update is called once per frame
	void Update () {
		KeyboardInput ();	
	}

	void KeyboardInput()
	{
		bool iswalking = false;

		if(Input.GetKey (KeyCode.Escape)){
			Application.Quit ();
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)  || Input.GetKey (KeyCode.RightArrow) ||
		    Input.GetKey (KeyCode.UpArrow)    || Input.GetKey (KeyCode.DownArrow)) {

			iswalking = true;

			float xx = Input.GetAxisRaw ("Vertical");
			float zz = Input.GetAxisRaw ("Horizontal");	

			lookDirection = xx * Vector3.forward + zz * Vector3.right;		

			Quaternion R = Quaternion.LookRotation (lookDirection);
			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, R, 8f);			
			this.transform.Translate (Vector3.forward * MoveSpeed * Time.deltaTime);
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {			
			StartCoroutine (shot.ShotBullet ());
		} else if(!anim.IsPlaying("Attack")) {
			if (iswalking)
			{
				ps.SetActive (true);
				anim.Play ("Walk");
			}
			else
			{
				ps.SetActive (false);
				anim.Play ("Wait");
			}
		}
	}
}
