using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int Score {get; set;}

    [SerializeField] public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
       ScoreText.text = $"Score: {Score}";
    }

    public void UpdateScore(int pts){
        Score += pts;
        ScoreText.text = $"Score: {Score}";
    }

}
