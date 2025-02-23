using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    public AudioSource audioSourceMusic;

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip gameOverMusic;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TocarMusica(AudioClip audioClipMusic)
    {
        this.audioSourceMusic.Stop();
        this.audioSourceMusic.clip = audioClipMusic;
        this.audioSourceMusic.Play();        
    }

    public void TocarMusicaMenu()
    {
        TocarMusica(menuMusic);
    }

    public void TocarMusicaJogo()
    {
        TocarMusica(gameMusic);
    }

    public void TocarMusicaGameOver()
    {
        TocarMusica(gameOverMusic);
    }
}
