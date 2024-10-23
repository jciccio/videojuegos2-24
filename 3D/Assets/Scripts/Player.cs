using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] HealthScriptableObject HealthScriptableObject;

    public void AddLife(int pts){
        HealthScriptableObject.SetHealth(pts);
    }

}
