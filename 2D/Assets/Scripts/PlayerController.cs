using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] float ForceX = 100f;
    [SerializeField] float JumpSpeed = 6f;

    public float Gravity = 1f;
    public float fallMultiplier = 5f;
    public float linearDrag  = 1f;

    [Header("Read Only")]
    public float ForceDirection;

    [Header("Ground")]
    public bool OnGround = false;
    public bool Jumping  = false;
    public float groundLength = 0.6f;
    public LayerMask groundLayer;



    private Rigidbody2D Physics;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        Physics.AddForce(new Vector2(ForceX* ForceDirection * Time.fixedDeltaTime, 0));
        OnGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        Jumping = !Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        ModifyPhysics();
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKey(KeyCode.D)){
            ForceDirection = 0.5f;
        }
        else if (Input.GetKey(KeyCode.A)){
            ForceDirection = -0.5f;
        }
        else{
            ForceDirection = 0;
        }*/
    }

    public void ModifyPhysics(){
        if(!Jumping){
            Physics.gravityScale = 0;
        }
        else{
            Physics.gravityScale = Gravity;
            Physics.drag = linearDrag * 0.15f;
            if(Physics.velocity.y < 0 ){
                Physics.gravityScale = Gravity * fallMultiplier;
            }
            else if (Physics.velocity.y > 0){
                Physics.gravityScale = Gravity * (fallMultiplier/2);
            }
        }

    }


    public void Jump(InputAction.CallbackContext context){
        if(context.performed){
            // Iniciar el brinco
            if(!Jumping){
                Jump();
            }
        }
        else if(context.canceled){
            // Cancelar el brinco
        }
    }
  
    public void Jump(){
        Physics.AddForce((Vector2.up * JumpSpeed), ForceMode2D.Impulse);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }

    public void RunControl(InputAction.CallbackContext context){
        Debug.Log($"Contexto: {context.phase} ->  {context.ReadValue<float>()}");
        if(context.performed){
            ForceDirection = context.ReadValue<float>();
        }
        else if(context.canceled){
            ForceDirection = 0;
        }
    }
}
