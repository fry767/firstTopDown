using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private float Speed       = 4.5f;
    private float timeToLive  = 10.0f;
    private float timeOfSpawn = 0;
    
    private void Start() {
        timeOfSpawn = Time.fixedTime;
    }

    private void Update() {
        transform.position += transform.right * Time.deltaTime * Speed;
        if (((Time.fixedTime - timeOfSpawn) >= timeToLive)) {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
