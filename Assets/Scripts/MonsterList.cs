using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Monster
{
    public Sprite sprite;
    public string name;
    public int minAttack;
    public int maxAttack;
    public int minAttackTime;
    public int maxAttackTime;
    public int minGold;
    public int maxGold;
    public int weakpoint;
    public int level;
}
public class MonsterList : MonoBehaviour
{
    public Monster[] monsters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
