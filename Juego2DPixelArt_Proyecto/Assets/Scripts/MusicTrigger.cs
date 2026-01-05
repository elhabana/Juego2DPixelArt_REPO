using UnityEngine;

public class MusicTrigger : MonoBehaviour
{

    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    [SerializeField] int musictoplay;

    //ESTO LE DA EL PLAY A LA MUSICA AL INICIAR

    void Start()
    {
        AudioManager.instance.PlayMusic(musictoplay);
    }
}
