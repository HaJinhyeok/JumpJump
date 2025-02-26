using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ScaffoldingProcess : MonoBehaviour
{
    public GameObject[] Scaffoldings;

    static int s_idx;

    private Vector3[] _spawnPos =
    {
        new Vector3(-5, 6, 0), new Vector3(-2, 6, 0),
        new Vector3(2, 6, 0), new Vector3(5, 6, 0),
        new Vector3(2, 6, 0), new Vector3(-2, 6, 0)
    };

    void Start()
    {
        s_idx = 3;
        StartCoroutine(CoSpawnScaffolding());
    }

    IEnumerator CoSpawnScaffolding()
    {
        Instantiate(Scaffoldings[(s_idx) % Scaffoldings.Length], _spawnPos[(s_idx++) % _spawnPos.Length], Quaternion.identity);
        
        yield return new WaitForSeconds(1.9f);
        StartCoroutine(CoSpawnScaffolding());
    }
}
