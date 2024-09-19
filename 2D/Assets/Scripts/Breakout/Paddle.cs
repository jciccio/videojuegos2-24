using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float ScreenSizeUnit = 17.76f;
    [SerializeField] float MinX = 0;
    [SerializeField] float MaxX = 17.76f;


    // Update is called once per frame
    void Update()
    {
        // Obtener el punto de la pantalla del mouse
        //Debug.Log("Posicion del mouse en X es: " + Input.mousePosition.x);

        // Cómo normalizar?
        // [0,1]
        //Debug.Log("Posicion relativa en pantalla en X es: " + Input.mousePosition.x/Screen.width * ScreenSizeUnit);
        float paddlePos = Input.mousePosition.x/Screen.width * ScreenSizeUnit;
        //transform.position = new Vector2(paddlePos , transform.position.y);

        float clampX = Mathf.Clamp(paddlePos, MinX, MaxX);     
        Vector2 position = new Vector2(clampX, transform.position.y );
        transform.position = position;
    }
}
