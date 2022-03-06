using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageComponent : MonoBehaviour
{
    [SerializeField] private const float max_damage = 100.0f;
    [SerializeField] private float damage = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDamage(float damage) {
        this.damage = damage;
    }

    public float getDamage() {
        return damage;
    }
}
