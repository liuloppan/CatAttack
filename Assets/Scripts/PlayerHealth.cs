using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 1000;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 10f;
    public Color flashColour = new Color(1f,0f,0f,0.5f); // red

    public Image Fill;
    public Color lowHealthColor = new Color(1f, 1f, 0.5f, 0.8f); //yellow

    public Animator enemyAnim;

    Animator anim;
    AudioSource playerAudio;
    //PlayerMovement playerMovement;

    public bool isDead;
    bool damaged;
    public GameAndScoreManager gameManager;

    

    // Use this for initialization
    void Awake ()
    {
        //anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //playerMovement = GetComponent<PlayerMovement>();

        currentHealth = startHealth;

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            if(!isDead)
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	
	}

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
            Death();
            healthSlider.value = 0;

        }
        if (currentHealth <= (startHealth/2) && !isDead)
        {
            Fill.color = lowHealthColor;
        }
        if (currentHealth <= (startHealth / 5) && !isDead)
        {
            Fill.color = flashColour;
        }
    }

    void Death()
    {
        isDead = true;

        damageImage.color = flashColour;

        playerAudio.clip = deathClip;
        playerAudio.PlayOneShot(deathClip);

        print("DEAD");

        gameManager.GameOver();
    }
}
