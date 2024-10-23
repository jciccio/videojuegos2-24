using UnityEngine;


[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public int Health = 100;
    public float Speed = 5f;
    public int MaxHealth = 100;

    public void Awake () => Debug.Log("Awake");
    public void OnEnable () => Debug.Log("On Enable");
    public void OnDisable () => Debug.Log("On Disable");
    public void OnDestroy () => Debug.Log("On Destroy");
    public void OnValidate () => Debug.Log("On Validate");
}