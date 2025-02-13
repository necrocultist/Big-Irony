﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShoot : MonoBehaviour
{
    [SerializeField] private string selectPlayer;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private float nextFire = 0.2F;
    [SerializeField] private AudioClip shotClip;

    [SerializeField] private ParticleSystem smokeParticle;

    private float myTime = 0.0F;
    private float fireDelta = 0.2F;

    public event Action OnDefaultFire;

    private void Update()
    {
        ShootBullets();
    }

    private void ShootBullets()
    {
        myTime += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.T) && selectPlayer == "Player1" || Input.GetKeyDown(KeyCode.Period) && selectPlayer == "Player2") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            if (playerBullet != null)
            {
                Instantiate(playerBullet, transform.position, transform.rotation);
            }
            nextFire = nextFire - myTime;

            myTime = 0f;

            HandleShootEvents();
        }
    }

    private void HandleShootEvents()
    {
        OnDefaultFire?.Invoke();
        smokeParticle.Play();
        SoundManager.Instance.PlaySound(shotClip);
    }
}