using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;

    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;

    ParticleSystem hitParticles;



    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
