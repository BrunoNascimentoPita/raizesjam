using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource audioSource;

    public AudioClip danoSFX;
    public AudioClip lifeSFX;
    public AudioClip jumpSFX;


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

    private void TocarSom(AudioClip audioClip, float volume = 1f)
    {
        this.audioSource.PlayOneShot(audioClip, volume);
    }

    public void TocarSomDano()
    {
        TocarSom(this.danoSFX);
    }
    public void TocarSomJump()
    {
        TocarSom(this.jumpSFX, 0.2f);
    }


}
