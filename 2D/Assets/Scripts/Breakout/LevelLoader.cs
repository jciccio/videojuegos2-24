using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelLoader : MonoBehaviour
{

    //Prefab de las cajas
    [SerializeField] private GameObject Block;
    // Punto de inicio
    [SerializeField] private Transform StartingPoint;
    // Referencia al contenedor de las cajas
    [SerializeField] private Transform BlocksContainer;

    // Movimiento en X y Y para cada caja colocada
    [SerializeField] private float xMovement;
    [SerializeField] private float yMovement;

    // Start is called before the first frame update
    void Start()
    {
        /*float x = 2;
        for(int i = 0 ; i < 5; i++){
            GameObject block = GameObject.Instantiate(Block);
            block.name = "Block" + i;
            block.transform.position = new Vector2(x,5);
            x+= 1.5f;
        }*/
        LoadLevel("Assets/Levels/Level1.txt");
    }

    public bool LoadLevel(string path){
        string data = LoadLevelFile(path);
        // Level 1:
        //XXXXXXX
        // X X X 
        string [] line = data.Split("\n"); //[2] XXXXXX , X X X
        Vector2 position = StartingPoint.position;
        int count = 1;
        for(int i = 0; i < line.Length; i++){ // Representa las filas
            for(int j = 0; j < line[i].Length; j++ ){// Representa las columnas
                if(line[i][j] == 'X'){
                    // Instanciar el Prefab
                    GameObject block = GameObject.Instantiate(Block);
                    // Colocarlo en posicion
                    //block.transform.position = position;
                    StartCoroutine(AnimateToPosition(block, position));
                    // Bautizarlo
                    block.name = $"Block {count}";
                    // Asignarle un padre
                    block.transform.SetParent(BlocksContainer);

                    count++;
                }
                position.x += xMovement;
            }
            position.y += yMovement;
            position.x = StartingPoint.position.x;
        }
        return count > 1;
    }

    IEnumerator AnimateToPosition(GameObject obj, Vector2 targetPosition){
        Transform objTransform = obj.transform;
        while(obj != null && Vector2.Distance(objTransform.position, targetPosition) > 0.1f){
            objTransform.position = Vector2.Lerp(objTransform.position, targetPosition, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        objTransform.position = targetPosition;
        yield return null;
    }

   
    string LoadLevelFile(string path){ // Assets/Levels/Level.txt
        string data = "";
        try{
            using(StreamReader sr = new StreamReader(path)){
                string line;
                while((line = sr.ReadLine())!= null){
                    data += line +"\n";
                }
            }
        }
        catch(IOException e){
            Debug.LogError( $"File not found {e}");
        }
        return data;
    }
}
