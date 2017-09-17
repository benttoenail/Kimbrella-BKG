using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetLeafAnimation : MonoBehaviour {

	List<Transform> leaf = new List<Transform>();
	private int count;

	public float Slowest = 0.1f;
	public float Fastest = 0.5f;

	// Use this for initialization
	void Start () {

		count =  gameObject.transform.childCount;

		for(int i = 0; i < count; i ++){

			Transform temp = gameObject.transform.GetChild(i);
			leaf.Add(temp);
		}
			
		ScatterAnimations();

	}

	//Play animations at different interval
	void ScatterAnimations(){

		Animator anim;

		for(int i = 0; i < count; i++){
			float speed = Random.Range(Slowest, Fastest);

			anim = leaf[i].gameObject.GetComponent<Animator>();
			anim.Play("Sway", -1, Random.Range(0f, 1.0f));
			anim.speed = speed;
		}

	}

}
