using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 2f;
    private float StartY;
    // Start is called before the first frame update
    void Start()
    {
        StartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Para posicionar al elemento en un punto:
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        // Vector3.left => new Vector3(-1,0,0)
        // Time.deltaTime =? Tiempo transcurrio entrel eultimo llamado del update y el actual

        if(transform.position.x <= -10f){
            float yPos = StartY + UnityEngine.Random.Range(-2f, 2f);
            transform.position = new Vector3(10,yPos, transform.position.z);
            MoveSpeed += 0.05f;
        }

    }
}
