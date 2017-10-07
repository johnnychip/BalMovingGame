using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0)
		{
			Touch swipeTouch = Input.GetTouch(0);
			if(swipeTouch.deltaPosition.x!=0)
					rb.AddForce(Vector2.right*speed*Mathf.Sign(swipeTouch.deltaPosition.x));
				
			
		}
	}
}
