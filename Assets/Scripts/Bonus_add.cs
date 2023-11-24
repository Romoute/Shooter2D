using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_add : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
        }

    }

}
