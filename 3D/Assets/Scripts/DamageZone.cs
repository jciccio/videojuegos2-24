using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] int Damage = 5;
    private void OnTriggerEnter(Collider other){
        if(other.TryGetComponent(out Player player)){
            player.AddLife(Damage);
        }
    }
}
