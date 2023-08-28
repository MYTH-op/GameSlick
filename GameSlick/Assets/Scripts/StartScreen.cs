using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainScene");
    }

}
