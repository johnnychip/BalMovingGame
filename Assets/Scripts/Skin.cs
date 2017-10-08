using UnityEngine;

[System.Serializable]
public class Skin {

    #region Properties

    public string name;

    public Sprite skinSprite;

    public int skinCost;

    public bool isOnSale;

    #endregion

    #region Class Functions

    private void LoadStatus()
    {
        Debug.Log("LoadStatus"); //TODO: Load status
    }

    #endregion
}
