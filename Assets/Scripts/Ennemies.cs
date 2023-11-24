using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_ennemies : MonoBehaviour {

    public GameObject coin;
    public GameObject bonus_speed;
    public GameObject max_ammo_on_screen;
    public Transform parent_ennemies;
    private int health = 3;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        float randomNumber = Random.Range(0, 11);
        if (randomNumber <= 7 ) setHp(1);
        if (randomNumber == 8 || randomNumber == 9) setHp(2);
        if (randomNumber == 10 ) setHp(3);  

        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    private void UpdateColor() {
        switch (health) {
            case 3:
                spriteRenderer.color = Color.red;
                break;
            case 2:
                spriteRenderer.color = Color.yellow;
                break;
            case 1:
                spriteRenderer.color = Color.green;
                break;
            default:
                spriteRenderer.color = Color.gray;
                break;
        }
    }
    private void Update() {
        UpdateColor();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "projectile") {
            health -= 1;
        }
        if (collision.gameObject.tag == "projectile" && health == 0) {
            Destroy(gameObject);
            float randomNumber = Random.Range(0, 10);

            if (randomNumber <= 7) Instantiate(coin, parent_ennemies.position, Quaternion.identity);

            else if (randomNumber == 8) Instantiate(max_ammo_on_screen, parent_ennemies.position, Quaternion.identity);
            else if (randomNumber == 9) Instantiate(bonus_speed, parent_ennemies.position, Quaternion.identity);

        }
    }
    private void setHp(int x){
        this.health = x;
    }

}
