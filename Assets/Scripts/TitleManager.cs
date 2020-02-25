using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : GameManager
{
    [SerializeField] GameObject gameObjectImageBackground;
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


        StartCoroutine(CoroutineOnClickButtonStart());
    }

    public void OnClickButtonSettings()
    {

    }

    IEnumerator CoroutineOnClickButtonStart()
    {
        gameObjectImageBackground.GetComponent<RectTransform>().DOScale(new Vector3(5.0f, 5.0f, 5.0f), 2.0f);
        yield return new WaitForSeconds(1.0f);
        gameObjectImageBackground.GetComponent<Image>().DOColor(new Color(0.0f, 0.0f, 0.0f), 1.0f);
        yield return new WaitForSeconds(1.5f);
        MoveToMainSceneFromTitleScene();
    }
}
