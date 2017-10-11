using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Properties

    [Header("Scripts")]


    [SerializeField]
    private FacebookManager myFacebookManager;


    [Header("Texts")]

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text highScore;

    [Header("Icons")]

    [SerializeField]
    private Image playIcon;
    [SerializeField]
    private Image facebookIcon;
    [SerializeField]
    private Image twitterIcon;
    [SerializeField]
    private Image removeAddsIcon;
    [SerializeField]
    private Image soundIcon;
    [SerializeField]
    private Sprite soundOn;
    [SerializeField]
    private Sprite soundOff;

    [Header("Canvas")]

    [SerializeField]
    private GameObject upperCanvas;
    [SerializeField]
    private GameObject menuCanvas;

    [Header("Skin")]

    [SerializeField]
    private Color backgroundColor;
    [SerializeField]
    private Color iconsColor;
    [SerializeField]
    private Color textColor;

    //Events
    public delegate void OnPlay();
    public event OnPlay onPlay;

    public delegate void OnRestart();
    public event OnPlay onRestart;

    //Hidden
    private bool audioState = true;
    
    //Singleton!
    public static UIManager Instance
    {
        get; private set;
    }

    #endregion

    #region Unity Functions

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
        GameManager.Instance.onEnd += SetEndMenu;
    }

    private void Start()
    {
        Setup();
        SetupSkin();
    }

    #endregion

    #region Class Functions

    private void Setup()
    {
        highScore.text = string.Format("High Score: {0}", GameManager.Instance.highScore);
    }

    private void SetupSkin()
    {
        //Set texts
        highScore.color = textColor;
        nameText.color = textColor;

        //Set icons
        Camera.main.backgroundColor = backgroundColor;

        playIcon.color = iconsColor;
        facebookIcon.color = iconsColor;
        twitterIcon.color = iconsColor;
        removeAddsIcon.color = iconsColor;
        soundIcon.color = iconsColor;
    }

    public void SetEndMenu()
    {

    }

    #endregion

    #region Buttons Functions

    public void Play()
    {
        upperCanvas.SetActive(false);
        menuCanvas.SetActive(false);

        if (onPlay != null)
            onPlay();
    }

    public void Restart()
    {
        
    }


    public void ShareWithFacebook()
    {
        Debug.Log("ShareWithFacebook"); //TODO: Share with Facebook
        myFacebookManager.Share();
    }

    public void ShareWithTwitter()
    {
        Debug.Log("ShareWithTwitter"); //TODO: Share with Twitter
    }

    public void RemoveAdds()
    {
        Debug.Log("RemoveAdds"); //TODO: Remove Adds
    }

    public void Sound()
    {
        audioState = !audioState;

        AudioManager.Instance.Music(audioState);
        AudioManager.Instance.Effects(audioState);

        switch (audioState)
        {
            case true:
                soundIcon.sprite = soundOff;
                break;

            case false:
                soundIcon.sprite = soundOn;
                break;
        }
    }

    #endregion
}
