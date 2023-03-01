using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class fireBullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;
    public float bulletLife = 2f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        
        

    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
                Destroy(newBullet, bulletLife);
            }
        }
    }
}
