using UnityEngine;
using System.Collections;

public class TrailAnimationTest : MonoBehaviour {
	
	public float tTraillTime, tTimeToTween, tTweenSpeed;
	public float startTimeToTweenTo, startFadeInTime;
	
	public WeaponTrail swordSwipe;
	
	
	public GameObject weaponArcPrefab;
	
	
	private AnimationState animationIdle;
	private AnimationState animationAttack01;
	private AnimationState animationAttack02;
	private AnimationState animationAttack03;
	
	protected AnimationController animationController;
	
	
	
	
    protected void Awake ()
	{
		animationController = GetComponent<AnimationController> ();
		transform.position = Vector3.zero;
	}
	protected void Start ()
	{
		animationController.AddTrail (swordSwipe); // Adds the trails to the animationController which will run them

		Initialise ();
		//
		// This is just making him jump at the start... normally you would just hit PlayAnimation(idle)...		
		
		// swordSwipe.SetTime (2.1f, 0, 1);
		//
	}

	protected void Initialise ()
	{
		// The Animation Controller feeds on AnimationStates. You've got to assign your animations to variables so that you can call them from the controller
		//    
		animation["attack01"].speed = 2.0f;
		animation["attack02"].speed = 2.0f;		
		//
		//
		animationAttack01 = animation["attack01"];
		//
		animationAttack02 = animation["attack02"];
		animationAttack03 = animation["attack03"];
		//		
		animationIdle = animation["idle"];		
		animationIdle.speed = 0.4f;		
		animationAttack03.speed = 0.8f;
		//		
		swordSwipe.SetTime (0.0f, 0f, 1.0f);
		//		
	}
	//
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1)){
			animationController.PlayAnimation (animationAttack01);
			// swordSwipe.StartTrail(0.5f, 0.4f); // Fades the trail in		
			
			swordSwipe.SetTime(0f, 0, 1.0f);
			swordSwipe.StartTrail(0.5f, 0.4f); // Fades the trail in		
			swordSwipe.FadeOut(0.1f);
			
			// swordSwipe.SetTime(2.0f, 2.5f, 2.0f);
			
			
			Debug.Log("-------- 1");
			//swordSwipe.SetTime(tTraillTime, tTimeToTween, tTweenSpeed);
			//swordSwipe.StartTrail(startTimeToTweenTo, startFadeInTime); 
			
		
			StartCoroutine(GenerateWeaponArc(0.12f, transform.position,  Quaternion.Euler(0, 0, -60.0f)));
		}
			

		if (Input.GetKeyDown(KeyCode.Alpha2)){
			animationController.PlayAnimation (animationAttack02);
			//swordSwipe.SetTime(0f, 0, 1.0f);
			//swordSwipe.StartTrail(0.9f, 1.5f); // Fades the trail in			
			Debug.Log("-------- 2");
			swordSwipe.SetTime(tTraillTime, tTimeToTween, tTweenSpeed);
			swordSwipe.StartTrail(startTimeToTweenTo, startFadeInTime); 
			
			
			StartCoroutine(GenerateWeaponArc(0.1f, transform.position,  Quaternion.Euler(0, 0, -50.0f)));
			StartCoroutine(GenerateWeaponArc(0.3f, transform.position,  Quaternion.Euler(0, 0, 60.0f)));
			
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)){
			animationController.PlayAnimation (animationAttack03);
			//swordSwipe.SetTime(2f, 3f, 1.0f);
			//swordSwipe.StartTrail(0.5f, 1.5f); // Fades the trail in			
			// swordSwipe.FadeOut(0.5f);
			Debug.Log("-------- 3");
			swordSwipe.SetTime(tTraillTime, tTimeToTween, tTweenSpeed);
			swordSwipe.StartTrail(startTimeToTweenTo, startFadeInTime); 
			
			StartCoroutine(GenerateWeaponArc(0.2f, transform.position,  Quaternion.Euler(0, 0, 65.0f)));
			
		}		
		
		
		
		
	}
	
	
	
	IEnumerator GenerateWeaponArc(float waitForTime, Vector3 pos, Quaternion rot){
		
		yield return new WaitForSeconds(waitForTime);
		GameObject weaponArc = (GameObject)Instantiate(weaponArcPrefab, pos + new Vector3(0, 0.7f, 0), rot);
	}
	
	void LateUpdate(){
		swordSwipe.UpdateTrail(Time.time, 0.033f);
	}
}
