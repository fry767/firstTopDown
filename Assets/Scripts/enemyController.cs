using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject currentCollider = collision.gameObject;

        damageComponent damage = currentCollider.GetComponent<damageComponent>();

        if (damage != null) {
            healthHandler health = GetComponent<healthHandler>();

            health.applyDamage(damage.getDamage());
        }
        
       
    }

}
