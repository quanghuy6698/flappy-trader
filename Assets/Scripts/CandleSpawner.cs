using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] candleHolderList;

    // Start
    void Start()
    {
        StartCoroutine(_Spawner());
    }

    // Update
    void Update()
    {
        
    }

    IEnumerator _Spawner(){
        yield return new WaitForSeconds(2);

        Vector3 temp = candleHolderList[0].transform.position;
        temp.y = Random.Range(-2f, 3f);

        int candleRnd = Random.Range(0, 4);

        Instantiate (candleHolderList[candleRnd], temp, Quaternion.identity);
        StartCoroutine(_Spawner());
    }
}
