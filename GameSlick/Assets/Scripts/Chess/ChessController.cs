using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChessController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void vsAI()
    {
        SceneManager.LoadScene("ChessGameScene");
    }

    public void vsPlayer()
    {
        SceneManager.LoadScene("ChessGameScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }

}
