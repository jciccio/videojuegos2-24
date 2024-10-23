using System;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "HealthScriptableObject", menuName = "ScriptableObjects/Health Manager")]
public class HealthScriptableObject : ScriptableObject
{
    public int Health = 100;
    public int MaxHealth = 100;

    [System.NonSerialized] public UnityEvent<float> HealthEventChanged;


    private void OnEnable(){
        if(HealthEventChanged == null){
            HealthEventChanged = new UnityEvent<float>(); 
        }
    }  

    public void SetHealth(int qty){
        Health = Math.Clamp(Health + qty, 0 , MaxHealth);
        HealthEventChanged?.Invoke((float) Health / MaxHealth);
    } 
}