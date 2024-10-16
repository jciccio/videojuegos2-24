using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // 4 tipos de movimiento
    // Translate -> No usa las fisicas de Unity
    
    // Los demás usan las físicas de Unity
    // AddForce ->
    // Velocity -> Override de las físicas (e.g gravedad)
    // MovePosition -> 


    [SerializeField] float Speed = 5f;
    [SerializeField] Vector3 Direction;  
    

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        Direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate(){
        Move(Direction);   
    }

    void Move(Vector3 direction){
        // Ejemplo 1: Usando transform Translate -- Desde el update 
        //transform.Translate(direction * Speed * Time.deltaTime);

        // Ejemplo 2: Addforce
        //rb.AddForce(direction * Speed, ForceMode.Force);

        // Ejemplo 3: Velocity
        //rb.velocity = direction * Speed; 
        
        // Ejemplo 4: Move Position
        rb.MovePosition(transform.position + (direction * Speed * Time.fixedDeltaTime));
    }
}
