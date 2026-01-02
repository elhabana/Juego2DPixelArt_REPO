using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{

    [Header("Points Management")]
    [SerializeField] int actualPoints;
    [SerializeField] int winPoints = 7;
    [SerializeField] GameObject winCoin;

    // Start is called before the first frame update
    void Start()
    {
        actualPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualPoints == winPoints)
        {
            winCoin.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            AudioManager.instance.PlaySFX(0);
            actualPoints += 1;
            collision.gameObject.SetActive(false);
            Debug.Log(actualPoints);
            if (actualPoints == winPoints)
            {
                Debug.Log("WinCoin Spawned");
            }
        }
    }
}
