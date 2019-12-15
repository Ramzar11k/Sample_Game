using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform bulletOrigin;
    private float bulletSpeed = 1000f;
    public float shootCD;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0) && shootCD <= 0)
            bulletShoot();

        shootCooldown();
	}

    void bulletShoot()
    {
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
        bulletInstance.AddForce(bulletOrigin.forward * bulletSpeed);
        shootCD = 0.5f;
    }

    void shootCooldown()
    {
        if (shootCD >= 0)
            shootCD -= Time.deltaTime;
    }
}
