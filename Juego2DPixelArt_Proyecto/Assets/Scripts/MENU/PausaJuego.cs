using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PausaJuego : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject iconoPausa;
    public bool juegoPausado = false;


    private void Update()
    {
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

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
        iconoPausa.SetActive(true);
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
        iconoPausa.SetActive(false);
    }

}
