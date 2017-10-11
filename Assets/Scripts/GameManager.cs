using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Properties

    [SerializeField]
    private Text currentCoinsText;
    [SerializeField]
    private Text globalCoinsText;

    [Header("Game Settings")]

    [SerializeField]
    private float startVelocity;
    [SerializeField]
    private float increaseVelocity;

    //Hidden
    public float highScore
    {
        get; private set;
    }

    public int currentCoins
    {
        get; private set;
    }

    public int globalCoins
    {
        get; private set;
    }

    public float velocity
    {
        get; private set;
    }

    //Events

    public delegate void OnEnd();
    public event OnEnd onEnd;

    //Singleton!
    public static GameManager Instance
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

        Setup();
    }

    #endregion

    #region Class Functions

    public void Setup()
    {
        globalCoins = PlayerPrefs.GetInt("coins");

        velocity -= startVelocity;
    }

    public void End()
    {
        if(onEnd!=null)
            onEnd();
    }

    public void SetHighScore(float newHighScore)
    {
        highScore = newHighScore;
    }

    public void IncreaseCoins()
    {
        currentCoins++;
    }

    public void MergeCoins()
    {
        globalCoins += currentCoins;

        currentCoins = 0;

        PlayerPrefs.SetInt("coins", globalCoins);
        PlayerPrefs.Save();
    }

    public bool SpendCoins(int cost)
    {
        if (globalCoins >= cost)
        {
            globalCoins -= cost;

            PlayerPrefs.SetInt("coins", globalCoins);
            PlayerPrefs.Save();

            return true;
        }
        else
        {
            return false;
        }
       
    }

    public void IncreaseVelocity()
    {
        velocity -= increaseVelocity;
    }

    #endregion
}
