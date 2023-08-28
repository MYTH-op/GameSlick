using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirHockeyController : MonoBehaviour
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
        SceneManager.LoadScene("AirHockeyGameScene");
    }

    public void vsPlayer()
    {
        SceneManager.LoadScene("AirHockeyGameScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }

}
