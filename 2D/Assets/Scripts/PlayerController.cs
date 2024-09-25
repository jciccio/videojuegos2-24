using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] float ForceX = 100f;

    [Header("Read Only")]
    public float ForceDirection;

    private Rigidbody2D Physics;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            ForceDirection = 0.5f;
        }
        else if (Input.GetKey(KeyCode.A)){
            ForceDirection = -0.5f;
        }
        else{
            ForceDirection = 0;
        }
    }

    void FixedUpdate(){
        Physics.AddForce(new Vector2(ForceX* ForceDirection * Time.fixedDeltaTime, 0));
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
    }

    public void RunControl(InputAction.CallbackContext context){
        //Debug.Log($"Contexto: {context.phase} ->  {context.ReadValue<float>()}");
    }
}
