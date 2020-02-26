using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainManager : GameManager
{
    [SerializeField] GameObject gameObjectImageBackground;

    [SerializeField] GameObject gameObjectPanelHP;
    [SerializeField] GameObject gameObjectPanelGold;
    [SerializeField] GameObject gameObjectPanelAhead;

    int step = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        StartCoroutine(CoroutineIntroduction());
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    IEnumerator CoroutineIntroduction()
    {
        gameObjectImageBackground.GetComponent<Image>().DOColor(new Color(1.0f, 1.0f, 1.0f), 3.0f);
        yield return new WaitForSeconds(4.0f);

        gameObjectPanelHP.SetActive(true);
        gameObjectPanelGold.SetActive(true);
        gameObjectPanelAhead.SetActive(true);
    }

    public void OnClickButtonAhead()
    {
        StartCoroutine(CoroutineOnClickButtonAhead());
    }

    public void OnClickButtonEscape()
    {
        StartCoroutine(CoroutineOnClickButtonEscape());
    }

    IEnumerator CoroutineOnClickButtonAhead()
    {
        gameObjectImageBackground.GetComponent<RectTransform>().DOScale(new Vector3(5.0f, 5.0f, 5.0f), 2.0f);
        gameObjectImageBackground.GetComponent<Image>().DOColor(new Color(1.0f, 1.0f, 1.0f, 0.0f), 2.0f);
        gameObjectPanelAhead.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        gameObjectImageBackground.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gameObjectImageBackground.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        AddStep();
    }

    IEnumerator CoroutineOnClickButtonEscape()
    {
        gameObjectPanelAhead.SetActive(false);
        yield return new WaitForSeconds(2.0f);
    }

    void AddStep()
    {
        step++;
        switch (0)
        {
            case 0:
                gameObjectPanelAhead.SetActive(true);
                break;
        }
    }
}
