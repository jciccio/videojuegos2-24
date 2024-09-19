using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

   [SerializeField] ParticleSystem Particles;

   SpriteRenderer _sprite;
   BoxCollider2D _boxCollider;


    void Awake(){
        _sprite = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other){
            //Destroy(this.gameObject);
            StartCoroutine(DeleteObject());
    }

    IEnumerator DeleteObject(){
        _sprite.enabled = false;
        _boxCollider.enabled = false;
        Particles.Play();
        yield return new WaitForSeconds(Particles.main.startLifetime.constantMax);
        Destroy(this.gameObject);
        yield return null;
    }
}
