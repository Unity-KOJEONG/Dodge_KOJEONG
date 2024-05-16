using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward*speed;

        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null){
                playerController.IncreaseScore();
            }

            // Destroy the bullet upon collision with the player
            Destroy(gameObject);
        }

    }


}
