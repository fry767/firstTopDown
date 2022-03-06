using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipCalculator : MonoBehaviour
{
    private SpriteRenderer weaponSprite;
    public Vector3 tip = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        weaponSprite = gameObject.GetComponent<SpriteRenderer>();
        Vector3 actualTip = new Vector3(weaponSprite.transform.position.x + weaponSprite.bounds.size.x, weaponSprite.transform.position.y + weaponSprite.bounds.size.y / 2, 0);
        tip = actualTip;
    }

    // Update is called once per frame
    void Update() {
        weaponSprite = gameObject.GetComponent<SpriteRenderer>();
        if (weaponSprite.flipX == true) {
            Vector3 actualTip = new Vector3(weaponSprite.transform.position.x - weaponSprite.bounds.size.x / 2, weaponSprite.transform.position.y, 0);
            tip = actualTip;
        } else {
            Vector3 actualTip = new Vector3(weaponSprite.transform.position.x + weaponSprite.bounds.size.x / 2, weaponSprite.transform.position.y, 0);
            tip = actualTip;
        }
    }

    public Vector3 getTip() {
        return tip;
    }
}
