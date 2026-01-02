using UnityEngine;

public class MusicTrigger : MonoBehaviour
{

    [SerializeField] int musictoplay;


    void Start()
    {
        AudioManager.instance.PlayMusic(musictoplay);
    }
}
