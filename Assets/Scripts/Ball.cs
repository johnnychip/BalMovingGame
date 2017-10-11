using UnityEngine;

public class Ball : MonoBehaviour {

    #region Properties

    #endregion

    #region Unity Functions

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.IncreaseCoins();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            TouchManager.Instance.SetSatateOfPlayer(false);
            GameManager.Instance.End();
            Debug.Log("Show Menu & Stop Scrolling");
        }
    }



    #endregion
}
