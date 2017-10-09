using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAdButton : MonoBehaviour {

    [SerializeField]
    private GameObject loseMenu;

    [SerializeField]
    private TouchManager myTouchManager;

    #region Class Functions

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }

    private void HandleAdResult(ShowResult result)
    {

        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("RestartGame");
                loseMenu.gameObject.SetActive(false);
                myTouchManager.SetSatateOfPlayer(true);
                break;
            case ShowResult.Skipped:
                Debug.Log("Player did not fully watch the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad? Internet");
                break;
        }
    }

    #endregion
}
