using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float tempoParaCrescer;
    public GameObject proximoEstagio;

    private float timer;

    void Update()
    {
        if (proximoEstagio == null) return;

        timer += Time.deltaTime;

        if (timer >= tempoParaCrescer)
        {
            Instantiate(proximoEstagio, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}