using UnityEngine;

public class SFXController : MonoBehaviour
{
     public static SFXController instance;
    public AudioSource audioSourceSFX;

    public AudioClip danoSFX;

    public AudioClip SelectOptionSFX;



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

    private void TocarSom(AudioClip audioClipSFX, float volume = 1f)
    {
        this.audioSourceSFX.PlayOneShot(audioClipSFX, volume);
    }

    public void TocarSomDano()
    {
        TocarSom(this.danoSFX);
    }

    public void TocarSomSelectOption()
    {
        TocarSom(this.SelectOptionSFX);
    }

}
