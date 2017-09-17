using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ProjectCaustics : MonoBehaviour {

	public float fps = 15.0f;
	public Texture2D[] frames;

	private int frameIndex;
	private Projector projector;

	int count = 31; //Lazy implementation of frame count... 

	//IF frames are not set in the "Frames" array, implement this again with "Execute in Edit Mode" turned on

	/*
	void Awake(){

		frames = new Texture2D[count];

		for(int i = 0; i < count; i ++){
			frames[i] = Resources.Load("Caustics/Caustic-ImgSeq_" + i) as Texture2D;
		}

	}
*/

	void Start(){

		projector = GetComponent<Projector>();
		NextFrame();
		InvokeRepeating("NextFrame", 1 / fps, 1 / fps);

	}

	void NextFrame(){
		projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
		frameIndex = (frameIndex + 1) % frames.Length;
	}

}
