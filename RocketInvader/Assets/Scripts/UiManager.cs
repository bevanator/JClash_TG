using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public RectTransform healthBar;
    public RectTransform resBar;
    public RectTransform ammoBar;
    public GameObject gameOverPanel;
    #region Singleton area

    
    public static UiManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
