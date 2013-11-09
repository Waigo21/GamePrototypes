using UnityEngine;
using System.Collections;

public class WeaponArc : MonoBehaviour {
	
	public float speed = 5.0f;
	
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		  transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
}
