using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public float movement_speed = 5;
    private const float weapons_y_offset = 0.30f;
    private const float weapons_x_offset = -0.008f;
    bool dir; /* false - right, true - left*/
    private Rigidbody2D _rigidbody;
    
    Animator anim;
    SpriteRenderer player_sprite;
    SpriteRenderer weaponsRender;
    GameObject activeWeapons;

    private float timeIdle = 0;
    private bool charGoingBored = false;
    // Start is called before the first frame update

    /* Gun bullet (projectile) */
    public projectile bullet;
    public Vector3 bulletLaunchOffset;

    void Start() {
        anim = GetComponent<Animator>();
        /* Disable all weapons */
        GameObject.Find("Weapons_0").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Weapons_1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Weapons_2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Weapons_3").GetComponent<SpriteRenderer>().enabled = false;

        /* Show starting weapons */
        activeWeapons = GameObject.Find("Weapons_1"); 
        
        bulletLaunchOffset = activeWeapons.GetComponent<tipCalculator>().getTip();
        weaponsRender = activeWeapons.GetComponent<SpriteRenderer>();
        weaponsRender.enabled = true;
        weaponsRender.sortingOrder   = 2;
        player_sprite = GetComponent<SpriteRenderer>();
        anim.SetBool("isWalking", false);
        /* Set right as first direction */
        dir = false;
        /* Char is not bored at startup */
        charGoingBored = false;

        /* Attach weapons to Char*/
        Vector3 gunPlacement = new Vector3(player_sprite.transform.position.x + weapons_x_offset, player_sprite.transform.position.y + weapons_y_offset, 0);
        weaponsRender.transform.position = gunPlacement;
    }

    // Update is called once per frame
    void Update() {
        var x_mov = Input.GetAxis("Horizontal");
        var y_mov = Input.GetAxis("Vertical");

        transform.position += new Vector3(x_mov, y_mov, 0) * Time.deltaTime * movement_speed;
        
        if (dir == false && x_mov < 0) {
            dir = true;
            player_sprite.flipX = true;
            weaponsRender.flipX = true;

        } else if (dir == true && x_mov > 0) {
            dir = false;
            player_sprite.flipX = false;
            weaponsRender.flipX = false;
        }
        if (x_mov == 0 && y_mov == 0) {
            /* Litterally no movement */
            anim.SetBool("isWalking", false);
            if (!charGoingBored) {
                timeIdle = Time.fixedTime;
                charGoingBored = true;
            } else if (charGoingBored && ((Time.fixedTime - timeIdle) >= 5)) {
                charGoingBored = false;
                anim.SetTrigger("boredTrigger");
            } 
        } else {
            /* Any movement */
            charGoingBored = false;
            anim.SetBool("isWalking", true);
        }
        Vector3 gunPlacement = new Vector3(player_sprite.transform.position.x + weapons_x_offset, player_sprite.transform.position.y + weapons_y_offset, 0);
        weaponsRender.transform.position = gunPlacement;

        /* Handle Fire */
        if (Input.GetButtonDown("Fire1")) {
            bulletLaunchOffset = activeWeapons.GetComponent<tipCalculator>().getTip();
            if (dir == true) {
                /* Character flip */
                 Instantiate(bullet, bulletLaunchOffset, Quaternion.Euler(new Vector3(0, 180, 0)));
            } else {
                 Instantiate(bullet, bulletLaunchOffset, transform.rotation);
            } 
        }
    } 
}
