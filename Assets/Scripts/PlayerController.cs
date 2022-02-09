using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float bounceForce;

    private Rigidbody2D playerBody;
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    public float flag = 0;
    public int score = 0;
    private GameObject candleSpawner;

    private bool isAlive;
    private bool isFlapped;

    // Initial
    void Awake()
    {
        isAlive = true;
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MakeInstance();
        candleSpawner = GameObject.Find("CandleSpawner");
    }

    // Update
    void FixedUpdate()
    {
        _PlayerMove();
    }

    void MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    void _PlayerMove(){
        if(isAlive){
            if(isFlapped){
                isFlapped = false;
                playerBody.velocity = new Vector2(0, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if(playerBody.velocity.y > 0){
            float angel = 0;
            angel = Mathf.Lerp(0, 90, playerBody.velocity.y/7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        } else if(playerBody.velocity.y == 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if(playerBody.velocity.y < 0){
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -playerBody.velocity.y/7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void _onFlapButton(){
        isFlapped = true;
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "CandleHolder"){
            score++;
            if(GamePlayController.instance != null){
                GamePlayController.instance._setScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Candle" || target.gameObject.tag == "Ground"){
            flag = 1;
            if(isAlive){
                isAlive = false;
                Destroy(candleSpawner);
                audioSource.PlayOneShot(diedClip);
                animator.SetTrigger("Dead");
            }
            if(GamePlayController.instance != null){
                GamePlayController.instance._onPlayerDied();
            }
        }
    }
}
