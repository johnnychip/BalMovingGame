using UnityEngine;

public class Ball : MonoBehaviour {

    #region Properties

    [SerializeField]
    private TouchManager myTouchManager;

    #endregion

    #region Unity Functions

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.DoCatchCoin();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            myTouchManager.SetSatateOfPlayer(false);
            Debug.Log("Show Menu & Stop Scrolling");
        }
    }

    #endregion
}
