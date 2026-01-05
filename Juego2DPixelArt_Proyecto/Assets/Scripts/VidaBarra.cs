using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class VidaBarra : MonoBehaviour
{

    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    public Image rellenodevida;
    private PlayerController playerController;
    private float vidaMaxima;

    // ESTE SCRIPT ES PARA QUE LA IMAGEN DE LA BARRA DE VIDA VAYA BAJANDO CONFORME AL DAÑO RECIBIDO
   
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        vidaMaxima = playerController.vida;
    }

   
    void Update()
    {
        rellenodevida.fillAmount = playerController.vida / vidaMaxima;
    }
}
