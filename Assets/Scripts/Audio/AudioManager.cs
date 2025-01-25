using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;  // Para la m�sica de fondo
    public AudioSource sfxSource;   // Para los efectos de sonido

    [Header("Audio Clips")]
    public AudioClip backgroundMusic; // M�sica de fondo inicial

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Inicia la m�sica de fondo si hay un clip asignado
        if (backgroundMusic != null)
        {
            PlayMusic(backgroundMusic);
        }
    }

    // Reproducir m�sica de fondo
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true; // La m�sica suele repetirse
            musicSource.Play();
        }
    }

    // Reproducir un efecto de sonido
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip); // No interrumpe otros sonidos
        }
    }

    // Cambiar el volumen de la m�sica
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume); // Entre 0 y 1
    }

    // Cambiar el volumen de los efectos de sonido
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume); // Entre 0 y 1
    }
}
