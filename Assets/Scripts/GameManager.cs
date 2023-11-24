using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private float horizontalDelta = 1.6f;
    [SerializeField] private float VerticalDelta = 1.3f;

    [SerializeField] private float horizontalStart = -8f;
    [SerializeField] private float verticalStart = 0;

    [SerializeField] private float horizontalMove = 0.2f;
    [SerializeField] private float moveDelay = 0.5f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemy2;

    [SerializeField] private float BORDER_MAP = 8.0f;

    private bool changeSide = false;
    void Start()
    {
        SpawnHexagon();
        InvokeRepeating("MoveEnemies", 0.5f, moveDelay);
    }

    // Update is called once per frame

    private void SpawnHexagon() {

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++) {
                if (i == 0) {
                    Instantiate(enemy2, new Vector3(horizontalStart + (j * horizontalDelta), verticalStart + (i * VerticalDelta), 0), Quaternion.identity);
                } else {
                    Instantiate(enemy, new Vector3(horizontalStart + (j * horizontalDelta), verticalStart + (i * VerticalDelta), 0), Quaternion.identity);
                }
            }
        }
    }

    private void MoveEnemies() { 


        foreach (var enemy in GameObject.FindGameObjectsWithTag("enemy")) {
            // Vérification si l'on est sur une bordure
            if (enemy.gameObject.transform.position.x >= BORDER_MAP && horizontalMove > 0 ) {

                changeSide = true;
            }

            else if(enemy.gameObject.transform.position.x <= -BORDER_MAP && horizontalMove < 0){

                changeSide = true;

            }

            Vector3 currentPos = enemy.transform.position;
            enemy.transform.position = currentPos + new Vector3(horizontalMove, 0, 0);

           }
        // Cas de bordure on descend de une rangée
        if (changeSide) {

            horizontalMove *= -1;
            foreach (var enemy in GameObject.FindGameObjectsWithTag("enemy")) {

                Vector3 currentPos = enemy.transform.position;
                enemy.transform.position = currentPos + new Vector3(horizontalMove, -VerticalDelta, 0);

            }

            changeSide = false;

        }
    }


}
