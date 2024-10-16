using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public GameObject FollowObject;
    [SerializeField] public Vector2 FollowOffset;
    private Vector2 _threshold;
    public Rigidbody2D FollowObjectRb;
   
    // Start is called before the first frame update
    void Start()
    {
        FollowObjectRb = FollowObject.GetComponent<Rigidbody2D>();
        CalculateThreshold();
    }

    // Update is called once per frame
    void Update()
    {
        // Mover la cámara con respecto al jugador
        _threshold = CalculateThreshold();
        Vector2 follow = FollowObject.transform.position;
        float xDiff = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x); // (1,0)
        float yDiff = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y); // (0,1)
        Vector3 newPosition = transform.position;
        if(xDiff > _threshold.x){
            newPosition.x = follow.x;
        }
        if(yDiff > _threshold.y){
            newPosition.y = follow.y;
        }
        //transform.position = newPosition;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * FollowObjectRb.velocity.magnitude);
    }

    private  Vector3 CalculateThreshold(){
        Rect aspect = Camera.main.pixelRect;
        //Debug.Log($"Ortographic Size {Camera.main.orthographicSize}");  
        //Debug.Log($"Width Size {aspect.width}");
        //Debug.Log($"Height Size {aspect.height}"); 
        Vector2 threshold = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize );
        threshold.x -= FollowOffset.x;
        threshold.y -= FollowOffset.y;
        return threshold;
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.magenta;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x*2, border.y * 2, 1));
    }
}
