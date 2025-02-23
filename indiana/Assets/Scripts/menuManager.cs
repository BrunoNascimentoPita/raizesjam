using UnityEngine;
using UnityEngine.SceneManagement;  
public class menuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
public void exit(){
    Application.Quit();
    Debug.Log("você saiu");
}
public void comecarJogo(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
