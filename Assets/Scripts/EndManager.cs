using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : GameManager
{
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void OnClickButtonRanking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Random.Range(0, 100000000));
    }
}
