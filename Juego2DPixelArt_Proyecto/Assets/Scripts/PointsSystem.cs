using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{

    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    [Header("Points Management")]
    [SerializeField] int actualPoints;
    [SerializeField] int winPoints = 7;
    [SerializeField] GameObject winCoin;

    
    void Start()
    {
        actualPoints = 0;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            AudioManager.instance.PlaySFX(0);
            actualPoints += 1;
            collision.gameObject.SetActive(false);
            Debug.Log(actualPoints);
            //ESTO CADA VEZ QUE COJES UNA MONEDA, TE SUMA UNO, SUENA EL EFECTO DE AUDIO Y LO DESACTIVA.

            if (actualPoints == winPoints)
            {
                winCoin.SetActive(true);
                Debug.Log("WinCoin Spawned");
                //ESTO HARA APARECER LA MONEDA DE VICTORIA SI LAS MONEDAS SON LAS ESTABLECIDAS.
            }
        }
    }
}
