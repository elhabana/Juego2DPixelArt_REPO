using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    [SerializeField] int sceneToLoad;


    //AL PRINCIPIO LA MONEDA DE WIN ESTA DESACTIVADA

    private void Start()
    {
        gameObject.SetActive(false);
    }

    //SI EL PLAYER CHOCA CON LA COLISION DE LA MONEDA SE CARGA LA SIGUIENTE ESCENA.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(2);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
