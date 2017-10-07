using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Properties

    [SerializeField]
    private Text currentCoinsText;

    [SerializeField]
    private Text globalCoinsText;

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

        globalCoins = PlayerPrefs.GetInt("coins");
    }

    #endregion

    #region Class Functions

    public void SetHighScore(float newHighScore)
    {
        highScore = newHighScore;
    }

    public void DoCatchCoin()
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
        if(globalCoins >= cost)
        {
            globalCoins -= cost;
            PlayerPrefs.SetInt("coins", globalCoins);
            PlayerPrefs.Save();
            return true;
        }else
        {
            return false;
        }
       
    }

    #endregion
}
