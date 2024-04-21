using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float speed = 20;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Procura o script do jogador para verificar o estado do jogo
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Rotaciona o objeto em -90 graus no eixo Y
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Move o objeto que chamar esse componente para a esquerda
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        // Destroi o objeto se ele ultrapassar o limite esquerdo e for uma obstáculo
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
