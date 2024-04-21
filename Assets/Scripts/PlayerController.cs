using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 15f; // Set a default jump force value
    private float gravityModifier = 2f; // Set a default gravity modifier value
    private bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public GameObject projectilePrefab;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    private float timer;
    public float maxTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //acessando o rigidbody e adicionanado um modificador de gravidade
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        timer = maxTime;
    }

    // Update is called once per frame 
    void Update()
    {
        // caso a tecla de espaço seja precionada e o personagem esteja o chão ele irá pular
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Vector3 spawnPosition = transform.position + transform.forward + Vector3.up * 2f;

            Instantiate(projectilePrefab, spawnPosition, projectilePrefab.transform.rotation);
        }
        if (!gameOver)
        {
            // Decrementa o contador regressivo
            timer -= Time.deltaTime;

            // Verifica se o tempo acabou
            if (timer <= 0)
            {
                gameOver = true;
                Debug.Log("You Wins");
                
            }
        }


    }


    //muda o estado pra quando ele não estiver no chão
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }else if(collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over!");
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
            }
        
        
    }
}
