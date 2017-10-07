using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Properties

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

    [Header("Skin")]

    [SerializeField]
    private Color backgroundColor;
    [SerializeField]
    private Color iconsColor;
    [SerializeField]
    private Color textColor;


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

    #endregion

    #region Buttons Functions

    public void Play()
    {
        Debug.Log("Play"); //TODO: Play
    }

    public void ShareWithFacebook()
    {
        Debug.Log("ShareWithFacebook"); //TODO: Share with Facebook
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
