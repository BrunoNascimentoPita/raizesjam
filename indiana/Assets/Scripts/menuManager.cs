using UnityEngine;
using UnityEngine.SceneManagement;  
public class menuManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    public float inactivityTime = 5f;
    
    // Timer para contar o tempo de inatividade
    private float timer = 0f;
    
    // Armazena a última posição do mouse
    private Vector3 lastMousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicia com a posição atual do mouse
        lastMousePosition = Input.mousePosition;
        Cursor.visible = true;

        if(SceneManager.GetActiveScene().name == "Menu")
        {
            MusicController.instance.TocarMusicaMenu();
        }
        if(SceneManager.GetActiveScene().name == "level1")
        {
            MusicController.instance.TocarMusicaJogo();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if(Input.mousePosition != lastMousePosition)
        {
            timer = 0f;
            if (!Cursor.visible)
            {
                Cursor.visible = true;
            }
            lastMousePosition = Input.mousePosition;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= inactivityTime)
            {
                Cursor.visible = false;
            }
        }
    }
    public void exit(){
        Application.Quit();
        Debug.Log("você saiu");
    }
    public void comecarJogo(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChamarMenu(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 0f;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
        }
    }
}
