using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Properties

    //Hidden
    public float highScore
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
    }

    #endregion

    #region Class Functions

    public void SetHighScore(float newHighScore)
    {
        highScore = newHighScore;
    }

    #endregion
}
