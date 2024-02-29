using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class enemy_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public float force = 20;
    public Transform player;
    public float playerHealth = 100;
    public bool gameState = true;
    public float Health = 20;

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void randy()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }
    void Start()
    {

    }

    void Update()
    {
        if (playerHealth == 0)
        {
            gameState = false;
            if (gameState == false)
            {
                SceneManager.LoadScene(0);
            }
        }
            randy();
    }

    private void OnTriggerEnter(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(other.transform.forward * -1 * force, ForceMode.Impulse);
            playerHealth -=1;
            
        }
    }

}
