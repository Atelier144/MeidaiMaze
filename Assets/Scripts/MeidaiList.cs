using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Meidai
{
    public string meidai;
    public string fire;
    public string thunder;
    public string ice;
}

public class MeidaiList : MonoBehaviour
{
    public Meidai[] meidais = new Meidai[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
