using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordThrowController : MonoBehaviour
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
        SceneManager.LoadScene("SwordThrowGameScene");
    }

    public void vsPlayer()
    {
        SceneManager.LoadScene("SwordThrowGameScene");
    }


    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }

}
