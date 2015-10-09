using UnityEngine;
using System.Collections;

public enum Monsterstate{
	Wait,
	Damage,
	Dead
}
public class Monster : MonoBehaviour {
	
	[SerializeField] Animation anim = null;	
	Monsterstate MS = Monsterstate.Wait;
	public Monsterstate GetMS { get { return MS; } }

	public void Hurt()
	{
		StartCoroutine (HurtCo ());
	}

	IEnumerator HurtCo()
	{
		MS = Monsterstate.Damage;

		anim.Play ("Damage");

		while (anim.IsPlaying("Damage")) {
			yield return new WaitForSeconds(0.1f);
		}

		StartCoroutine (Wait ());
		
		yield return null;
	}

	IEnumerator Wait()
	{	
		MS = Monsterstate.Wait;
		anim.Play ("Wait");

		yield return null;
	}

	public void Dead()
	{
		MS = Monsterstate.Dead;
		anim.Play ("Dead");
	}
}
