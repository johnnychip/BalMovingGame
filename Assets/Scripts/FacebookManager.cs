using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections.Generic;

public class FacebookManager : MonoBehaviour 
{

	public Text userIdText;

	private void Awake()
	{
		if(!FB.IsInitialized)
		{
			FB.Init();
		}
		else
		{
			FB.ActivateApp();
		}
	}

	public void LogIn()
	{
		FB.LogInWithReadPermissions(callback:OnLogIn);
	}

	private void OnLogIn(ILoginResult result)
	{
		if(FB.IsLoggedIn)
		{
			AccessToken token = AccessToken.CurrentAccessToken;
			userIdText.text = token.UserId;
		}
		else
		{
 			userIdText.text = "Not Working";
		}
	}

	public void Share()
	{
		FB.ShareLink(contentTitle:"Cool video music",contentURL:new System.Uri("https://www.youtube.com/watch?v=_hZCsgcKa-g"),
		contentDescription:"Here is a link to a cool video",
		callback:OnShare);
	}

	private void OnShare(IShareResult result)
	{
		if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
		{
			Debug.Log("Share link erro: " + result.Error);
		}
		else if (!string.IsNullOrEmpty(result.PostId))
		{
			Debug.Log(result.PostId);
		}
		else
			Debug.Log("Share succed");
	}

}
