using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour
{
    public float speed;
    // Start
    void Start()
    {
        
    }

    // Update
    void Update()
    {
        if(PlayerController.instance != null){
            if(PlayerController.instance.flag == 1){
                Destroy(GetComponent<CandleController>());
            }
        }
        _CandleMove();
    }

    void _CandleMove(){
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    // void OnCollisionEnter2D(Collision2D target){

    // }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "CandleDestroy"){
            Destroy(gameObject);
        }
    }
}
