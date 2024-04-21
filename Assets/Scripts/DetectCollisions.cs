using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroi o objeto atual
        Destroy(other.gameObject); // Destroi o objeto com o qual houve a colisão
    }
}
