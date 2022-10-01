﻿using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private string selectPlayer;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private float nextFire = 0.2F;
    private float myTime = 0.0F;
    private float fireDelta = 0.2F;

    void Update()
    {
        ShootBullets();
    }

    void ShootBullets()
    {
        myTime += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.T) && selectPlayer == "Player1" || Input.GetKeyDown(KeyCode.Keypad1) && selectPlayer == "Player2") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            if (playerBullet != null)
            {
                Instantiate(playerBullet, transform.position, transform.rotation);
            }
            nextFire = nextFire - myTime;

            myTime = 0f;
        }
    }
}