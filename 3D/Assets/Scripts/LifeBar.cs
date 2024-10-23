using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
   [SerializeField] Slider lifeSlider;
   [SerializeField] HealthScriptableObject HealthScriptableObject;


    public void OnEnable(){
        HealthScriptableObject.HealthEventChanged.AddListener(SetLifeBar);
    }

    public void OnDisable(){
        HealthScriptableObject.HealthEventChanged.AddListener(SetLifeBar);
    }

    void Start(){
        lifeSlider  = GetComponent<Slider>();
    }


    public void SetLifeBar(float pts){
        lifeSlider.value = pts;
    }

}
