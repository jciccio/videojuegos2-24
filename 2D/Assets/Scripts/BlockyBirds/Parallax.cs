using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private float Velocity;
    float XSize;
    // Start is called before the first frame update
    void Start()
    {
        float size = Camera.main.orthographicSize;
        XSize = size * 16/9 * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * Velocity;
        if(transform.position.x < -18){
            transform.position = new Vector2(18,0);
        }
    }
}
