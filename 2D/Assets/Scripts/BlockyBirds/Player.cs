using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] Vector2 jump = new Vector2(0.5f,3f);
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
           rb.velocity = jump;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        // Contra quien hay una colisión
        Debug.Log("Hay una colisión (OnTriggerEnter2D)");
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(Constants.DEATH_TAG)){
            
            AudioManager.instance.PlaySfx("BoxBreak");
            // Se acaba el juego 
            //Debug.Log("Hay una colisión (OnCollisionEnter2D) " + collision.gameObject.tag);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag(Constants.SCORE_TAG)){
            GameManager.instance.UpdateScore(10);
            AudioManager.instance.PlaySfx("Points");
        }
    }
}
