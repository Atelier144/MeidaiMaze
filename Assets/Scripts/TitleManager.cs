using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : GameManager
{
    [SerializeField] GameObject gameObjectImageTitle;
    [SerializeField] GameObject gameObjectButtonStart;
    [SerializeField] GameObject gameObjectButtonSettings;
    [SerializeField] GameObject gameObjectTextCopyrights;

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void OnClickButtonStart()
    {
        gameObjectButtonSettings.SetActive(false);
        gameObjectButtonStart.SetActive(false);
        gameObjectImageTitle.SetActive(false);
        gameObjectTextCopyrights.SetActive(false);
    }

    public void OnClickButtonSettings()
    {

    }
}
