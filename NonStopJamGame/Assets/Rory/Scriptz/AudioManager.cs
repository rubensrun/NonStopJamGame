using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source-------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("-------Audio Clip-------")]
    public AudioClip background;
    public AudioClip screamingStart;


    public static AudioManager Instance { get; private set; }
    AudioManager audioManager;

    public AudioMixer mixer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
      
        musicSource.clip = screamingStart;
        musicSource.Play();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    private void Start()
    {

       musicSource.clip = background;
       musicSource.Play();

        SFXSource.PlayOneShot(screamingStart);
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
}




