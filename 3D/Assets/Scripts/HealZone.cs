using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other){
        if(other.TryGetComponent(out Player player)){
            player.AddLife(10);
        }
    }

}
