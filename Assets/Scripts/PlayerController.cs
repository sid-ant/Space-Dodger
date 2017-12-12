using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundary{

	public float minX,maxX,minZ,maxZ,Z;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb; 
	public float speed; 
	public Boundary boundary;
	public float tilt,firerate;
	public GameObject shot; 
	public Transform shotspawn;
    private AudioSource laserAudio;
    private float nextFire = 0;
    private Vector3 move;


    void Start(){
        
        rb = GetComponent<Rigidbody> ();
        laserAudio = GetComponent<AudioSource>();
        
    }

    void Update()
    {

//        if (Input.GetButton("Fire1") && Time.time > nextFire)
//        {
//            nextFire = Time.time + firerate;
//            Instantiate(shot, shotspawn.position, shotspawn.rotation);
//            laserAudio.Play();
//        }

       

    }

    void FixedUpdate()
    {

        float moveX = Input.GetAxis("Horizontal");
        //float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0.0f, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

}
