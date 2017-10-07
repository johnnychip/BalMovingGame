using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField]
	private TouchManager myTouchManager;

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.CompareTag("Coin"))
		{
			GameManager.Instance.DoCatchCoin();
			other.gameObject.SetActive(false);
		}

		if(other.gameObject.CompareTag("DeathZone"))
		{
			myTouchManager.SetSatateOfPlayer(false);
			Debug.Log("Show Menu & Stop Scrolling");
		}
	}

}
