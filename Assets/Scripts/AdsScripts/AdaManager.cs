using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdaManager : MonoBehaviour {

	public static AdaManager Instace {set;get;}

	public string bannerId;
	public string videoId;

	 
	private void Start ()
	{
		Instace = this;
		DontDestroyOnLoad(gameObject);

		Admob.Instance().initAdmob(bannerId, videoId);
		Admob.Instance().loadInterstitial ();
	}

	public void ShowBanner()
	{
		Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER,1);

	}

}
