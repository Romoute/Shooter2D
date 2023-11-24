using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class Triangle : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    [SerializeField] int MAX_BULLET = 0;
    [SerializeField] public float speed = 0.02f;
    private int score = 0;
    public DisplayScore displayScore;

    private void Start() {
        if (displayScore == null) {
            // Attempt to find the DisplayScore script if not assigned in the Inspector
            displayScore = FindObjectOfType<DisplayScore>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed* Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }

        if(transform.position.x < limitL.position.x)   
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
        score = getScore();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("coin")) {
            score ++ ;
            print("+1 Points - Score = " + score);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("bonus_speed")) {
            speed *= 1.2f;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("bonus_shoot")) {
            MAX_BULLET +=1;
            Destroy(collision.gameObject);
        }

    }
    private void Shot() {
        if (GameObject.FindGameObjectsWithTag("projectile").Length <= MAX_BULLET) {
            if (MAX_BULLET != 0) {
                float split = 1f / (float)(MAX_BULLET+2f);
                for (int i = 1  ; i <= MAX_BULLET+1; i++) {
                    Instantiate(bullet, new Vector3(parent.position.x - 0.5f + split * i, parent.position.y, parent.position.z), parent.rotation);

                }
            }
            else Instantiate(bullet, parent.position, parent.rotation);
        }
    }

    public int getScore() {
        return score;
    }
}
