using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ejecucion del start");
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
    }
}
