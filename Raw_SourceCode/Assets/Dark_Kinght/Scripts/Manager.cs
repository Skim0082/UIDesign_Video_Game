using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public int Count = 0;
	public int MaxCount = 16;
	public float _time = 0;
	int time_score = 0;
	int time_clear = 0;
	public bool End = false;

	public Text Text_Time = null;
	[SerializeField] Text Text_Monster = null;
	[SerializeField] Text Text_FinalScore = null;
	[SerializeField] Text Text_FinalScoreBG = null;

	[SerializeField] GameObject ClearGUI = null;
	[SerializeField] GameObject FailGUI = null;
	[SerializeField] GameObject SoundStart = null;
	[SerializeField] AudioClip soundFail = null;
	[SerializeField] AudioClip soundClear = null;
	
	[SerializeField] Transform maincharactertr = null;
	[SerializeField] AudioClip soundShowingKnight = null;

	[SerializeField] GameObject spawncharactereffect = null;
	[SerializeField] AudioClip soundShowingMonster = null;
	[SerializeField] Move charactermove = null;

	IEnumerator ReadyToStart()
	{
		// add new Knight character prfab in the scene as a position information
		GameObject newobj = GameObject.Instantiate (spawncharactereffect, maincharactertr.position, Quaternion.identity) as GameObject;
		
		// get the child Component of Particle System in the Knight character 
		ParticleSystem ps = newobj.transform.GetChild(0).GetComponent<ParticleSystem> ();		 
		
		yield return new WaitForSeconds (0.2f);
		
		maincharactertr.GetChild (0).gameObject.SetActive (true);
		
		AudioSource.PlayClipAtPoint (soundShowingKnight, transform.position);
		
		yield return new WaitForSeconds (1.6f);
		
		GameObject.DestroyObject (newobj);
		
		yield return StartCoroutine (ReadyToStartForMonster ());
		
		SoundStart.SetActive (true);
		
		//cursor of main character make active
		maincharactertr.GetChild (2).gameObject.SetActive (true);
		
		charactermove.enabled = true;
		
		yield return null;
	}

	[SerializeField] List<Transform> monstertrs = new List<Transform>();
	IEnumerator ReadyToStartForMonster()
	{
		List<GameObject> monstereffects = new List<GameObject> ();
		List<ParticleSystem> monsterps = new List<ParticleSystem> ();
		foreach (var v in monstertrs) {
			GameObject newobj = GameObject.Instantiate (spawncharactereffect, v.position, Quaternion.identity) as GameObject;
			ParticleSystem ps = newobj.transform.GetChild(0).GetComponent<ParticleSystem> ();
			monstereffects.Add(newobj);
			monsterps.Add(ps);
		}

		yield return new WaitForSeconds (0.2f);

		foreach (var v in monstertrs) {
			v.gameObject.SetActive(true);
		}

		AudioSource.PlayClipAtPoint (soundShowingMonster,transform.position);

		yield return new WaitForSeconds (1.6f);
		int i=0;
		foreach (var v in monsterps) {
			GameObject.DestroyObject(monstereffects[i]);
			i++;
		}

		yield return null;
	}

	void Start()
	{
		StartCoroutine(ReadyToStart());
	}

	void OnTriggerEnter(Collider Get)
	{
		if (Get.gameObject.tag == "Monster") {
			Count += 1;
			DestroyObject(Get.gameObject);
		}

		if (Get.gameObject.tag == "Player" && End == false) {
			End = true;
			FailGUI.SetActive (true);
			AudioSource.PlayClipAtPoint (soundFail,transform.position);
		}

		if (Count >= 16 && End == false) {
			End = true;
			ClearGUI.SetActive (true);
			AudioSource.PlayClipAtPoint (soundClear,transform.position);
		}

		if (End) {

			SoundStart.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		if (End == false) {
			_time += Time.deltaTime;
		} 

		if (((float)_time) > 15f) {
			time_score = Count;
		}

		//Display GUI(Time and remain number of monsters)
		Text_Time.text = "Time: " + System.Math.Round (_time , 2).ToString();
		Text_Monster.text = "Monster: " + (MaxCount - Count).ToString ();

		//Calculate the final score
		if (End) {

			time_clear = (int)_time;

			if(time_score >= 16){
				time_score += 5;
			}else if(time_score >= 14){
				time_score += 4;
			}else if(time_score >= 12){
				time_score += 3;
			}else if(time_score >= 10){
				time_score += 2;
			}

			time_score = MaxCount * 100 + time_score * 100 + (int)((250f / (float)time_clear) * 100);
			Text_FinalScore.text = string.Format ("{0:N0}",time_score);
			Text_FinalScoreBG.text = Text_FinalScore.text;
		}
	}
}
