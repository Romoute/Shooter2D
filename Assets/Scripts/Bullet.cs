using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }
    private void Update() {
        if(monRigidBody.position.y >= 5) Destroy(gameObject); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bonus_shoot" || collision.gameObject.tag == "bonus_speed" || collision.gameObject.tag == "coin") {
            Destroy(gameObject);
        }
    }



}
