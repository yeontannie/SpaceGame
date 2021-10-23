using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject laser;
    public GameObject laserGun;
    public float shotDelay;
    public float tilt;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    Rigidbody ship;
    float nextShotTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");
       ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float positionX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float positionZ = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(positionX, 0, positionZ);

        ship.rotation = Quaternion.Euler(tilt * ship.velocity.z, 0, -ship.velocity.x * tilt);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(laser, laserGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
    }
}
