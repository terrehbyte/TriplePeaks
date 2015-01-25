using UnityEngine;
using System.Collections;

public class MovingSky : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	
	
	
	  public float scrollSpeed = 0.5F;
    
        
		
		
		
	// Update is called once per frame
	void Update () {


		
		float offset = Time.time * scrollSpeed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));


	}
}
