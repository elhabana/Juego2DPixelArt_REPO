using UnityEngine;

//ESTE SCRIPT, CREA UN OBJETO CON LA MUSICA DEL JUEGO SIEMPRE EN MARCHA, HASTA ENTRE ESCENAS, HAY UNA PISTA SIN AUDIO ASIGNADO, POR SI ALGUIEN NO QUIERE AUDIO EN UNA ESCENA.

public class AudioManager : MonoBehaviour
{
    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    public static AudioManager instance;

    [Header("Audio Source References")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips Arrays")]
    public AudioClip[] musiclist;
    public AudioClip[] sfxlist;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }

    }

    public void PlayMusic(int musicIndex)
    {
        musicSource.clip = musiclist[musicIndex];
        musicSource.Play();
    }

    public void PlaySFX(int sfxIndex)
    {
        sfxSource.PlayOneShot(sfxlist[sfxIndex]);
    }
}
