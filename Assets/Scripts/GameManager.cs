using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static int score;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void MoveToMainSceneFromTitleScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MoveToEndSceneFromMainScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void SetScore(int score)
    {
        GameManager.score = score;
    }

    public int GetScore()
    {
        return score;
    }
}
