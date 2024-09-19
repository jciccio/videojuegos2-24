using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [Header("Physics")]
    [SerializeField] Vector2 Velocity = new Vector2(1f,3f);
    [SerializeField] float _collisionFloatMargin = 0.45f;

    [Header("References")]
    [SerializeField] Paddle Paddle;


    // Private!
    Rigidbody2D _ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _ballRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){ // 50 veces por segundo
        _ballRigidBody.velocity = Velocity;
    }

    void OnHorizontalCollision(){
        Velocity = new Vector2(Velocity.x, Velocity.y * -1);
    }
    
    void OnVerticalCollision(){
        Velocity = new Vector2(Velocity.x *-1 , Velocity.y);
    }

    void OnBlockCollision(Collision2D element){
        //https://docs.unity3d.com/ScriptReference/ContactPoint2D.html
        Vector2 collision = element.GetContact(0).point;
        float xColPoint = collision.x - element.transform.position.x;
        float yColPoint = collision.y - element.transform.position.y;
        Debug.Log($" Punto de colision x {xColPoint} y {yColPoint}");

        if(Mathf.Abs(yColPoint)  > _collisionFloatMargin){
            OnHorizontalCollision();
        }else if(Mathf.Abs(xColPoint) > _collisionFloatMargin){
            OnVerticalCollision();
        }

    }

    void OnPaddleCollision(){
        // Llenar como parte de la tarea
        // La firma del método puede variar como necesite
        // Puede agregar atributos, métodos lo lo que considere necesario.
        // La idea es que si la bola rebota hacia un costado el angulo de rebote cambie respecto
        // Al punto de colision
    }

    void OnCollisionEnter2D(Collision2D collision){
      // Contra quién colisiona?
      // Pared:
      //    - Horizontal
      //    - Vertical
      // Caja (Bloque)
      // Paleta (Paddle)

      Debug.Log($"Colisiona con {collision.gameObject.name}");
      string collisionTag = collision.gameObject.tag;
      if(collisionTag == Constants.HORIZONTAL_WALL_TAG){
        OnHorizontalCollision();
      }  
      if(collisionTag == Constants.VERTICAL_WALL_TAG){

        OnVerticalCollision();
      }
      if(collisionTag == Constants.BLOCK_TAG){
        OnBlockCollision(collision);
      }
      if(collisionTag == Constants.PADDLE_TAG){
        // Tarea -> Agregar aqui el rebote contra el pad del jugador
        OnPaddleCollision();
      }


    }
}
