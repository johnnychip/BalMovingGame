using UnityEngine;

public class TouchManager : MonoBehaviour {

    #region Properties

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject loseMenu;

    public bool isRuning;

    #endregion

    #region Unity Functions

    public static TouchManager Instance
    {
        get;
        private set;
    }

    private void Awake ()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this; 
        
        DontDestroyOnLoad(gameObject);

        UIManager.Instance.onPlay += SetGameStart;
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
                Debug.Log("Player lose the game");
                SetSatateOfPlayer(false);             
            }
        }
    }

    #endregion

    #region Class Functions

    public void SetSatateOfPlayer(bool state)
    {
        isRuning = state;
        if(!state)
        {
            GameManager.Instance.End();
        }
    }

    public void SetGameStart()
    {
        isRuning = true;
    }

    #endregion
}
