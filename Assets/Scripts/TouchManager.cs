using UnityEngine;

public class TouchManager : MonoBehaviour {

    #region Properties

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    public bool isRuning;

    #endregion

    #region Unity Functions

    private void Start()
    {
        isRuning = true;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && isRuning)
        {
            Touch swipeTouch = Input.GetTouch(0);

            if (swipeTouch.deltaPosition.x != 0)
                rb.AddForce(Vector2.right * (speed * Mathf.Sign(swipeTouch.deltaPosition.x)));

            if (swipeTouch.phase == TouchPhase.Ended)
            {
                isRuning = false;

                Debug.Log("Player lose the game");
            }
        }
    }

    #endregion

    #region Class Functions

    public void SetSatateOfPlayer(bool state)
    {
        isRuning = state;
    }

    #endregion
}
