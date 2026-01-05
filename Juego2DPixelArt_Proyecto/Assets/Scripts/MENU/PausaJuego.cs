using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PausaJuego : MonoBehaviour
{
    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    public GameObject menuPausa;
    public GameObject iconoPausa;
    public bool juegoPausado = false;


    private void Update()
    {
        //SI PULSAS ESC, SE ABRE EL MENU DE PAUSA.
        //Y SI ESTAS DENTRO DEL MENU Y PULSAS ESC REANUDA.

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }

        }
    }


    //ESTO PONE LA ESCALA DEL TIEMPO EN 1, QUE ES VELOCIDAD NORMAL, DESACTIVA EL MENU Y ACTIVA EL BOTON DE PAUSA

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
        iconoPausa.SetActive(true);
    }

    //ESTO PONE LA ESCALA DEL TIEMPO EN 0, QUE ES CONGELADO, ACTIVA EL MENU Y DESACTIVA EL BOTON DE PAUSA.

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
        iconoPausa.SetActive(false);
    }

}
