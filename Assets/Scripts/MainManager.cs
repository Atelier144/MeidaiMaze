using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainManager : GameManager
{
    [SerializeField] GameObject gameObjectImageBackground;

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
    }
}
