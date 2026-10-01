using UnityEngine;

public class GrownPlanted : MonoBehaviour
{
    public float growthTimer;
    public float tempoParaCrescer;
    public bool jaCresceu;

    public GameObject estagioAtual;
    public GameObject[] estagiosIniciais;
    public GameObject[] estagiosFinais;

    void Update()
    {
        if (jaCresceu) return;

        growthTimer += Time.deltaTime;

        if (growthTimer >= tempoParaCrescer)
        {
            Destroy(gameObject);
            Instantiate(estagioAtual, transform.position, Quaternion.identity);
            jaCresceu = true;
        }
    }
}