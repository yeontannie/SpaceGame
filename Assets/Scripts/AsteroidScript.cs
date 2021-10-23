using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float speed;
    public float rotationspeed;
    Rigidbody asteroid;
    public float restartDelay = 2.0f;

    float mult;
    // Start is called before the first frame update
    void Start()
    {
        mult = Random.Range(0.8f, 1.8f);
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationspeed;
        asteroid.velocity = new Vector3(0, 0, -speed * mult);
        asteroid.transform.localScale /= mult;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "Grinder")
        {
            return;
        }

        GameObject newExplotion = Instantiate(asteroidExplosion, asteroid.transform.position, Quaternion.identity);
        newExplotion.transform.localScale /= mult;

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            SceneManager.LoadScene(0);
            GameController.score = 0;
            return;
        }
        GameController.score += 10;

        Destroy(gameObject);
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
