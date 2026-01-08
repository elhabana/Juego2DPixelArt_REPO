using System.Runtime.CompilerServices;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public bool going;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedpositoin = Vector3.zero;

        if (going)
        {
            wantedpositoin = pointB.position;
        }
        else
        {
            wantedpositoin = pointA.position;
        }

        Vector3 direction = wantedpositoin - transform.position;
        transform.position += direction.normalized * Time.deltaTime * 3f;

        if (direction.magnitude < 1f)
        {
            going = !going;
        } }



       private void OnColisionenter2D (Collision2D col){
          
        col.transform.parent = transform;
    }

    private void OnColisionexit2D (Collision2D other){
          
        other.transform.parent = null;
    }
       
    
    



}
