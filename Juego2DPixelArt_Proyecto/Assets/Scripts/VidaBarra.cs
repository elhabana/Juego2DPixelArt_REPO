using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class VidaBarra : MonoBehaviour
{

    public Image rellenodevida;
    private PlayerController playerController;
    private float vidaMaxima;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        vidaMaxima = playerController.vida;
    }

    // Update is called once per frame
    void Update()
    {
        rellenodevida.fillAmount = playerController.vida / vidaMaxima;
    }
}
