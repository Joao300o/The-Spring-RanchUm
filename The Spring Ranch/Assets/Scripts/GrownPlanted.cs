using UnityEngine;

public class GrownPlanted : MonoBehaviour
{
    public float growthTimer;
    public float tempoParaCrescer;


    public GameObject[] estagiosIniciais;
    public GameObject[] estagiosFinais;
    void Start()
    {
        growthTimer = Time.deltaTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if(growthTimer >= tempoParaCrescer)
        {
            
        }
    }
}
