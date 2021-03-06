﻿using UnityEngine;

public class GumBallCanon : MonoBehaviour {
    [SerializeField] string gumBallPool;
    [SerializeField] Transform gumBallSpawnPos;
    [SerializeField] float gumballSpawnRate;
    [SerializeField] AudioSource myAudio;
    [SerializeField] Animator myAnimation;

    public ParticleSystem cannonSmoke;

    void Update() {
        GumballCheck();
    }

    float currentSpawnTime;

    void GumballCheck() {
        currentSpawnTime -= Time.deltaTime;

        if(currentSpawnTime <= 0) {
            currentSpawnTime = gumballSpawnRate;
            ObjectPooler.instance.GetFromPool(gumBallPool, gumBallSpawnPos.position, gumBallSpawnPos.rotation);
            myAudio.Play();
            myAnimation.SetTrigger("Shoot");
            cannonSmoke.Play();
        }
    }
}
