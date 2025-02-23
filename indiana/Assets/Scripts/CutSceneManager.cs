using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public string nextScene; // Nome da cena principal que virá após a cutscene

    void Start()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;  
        Cursor.lockState = CursorLockMode.None;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndCutscene();
        }
    }
    public void EndCutscene()
    {
        SceneManager.LoadScene(nextScene); // Avança para o jogo
    }
}
