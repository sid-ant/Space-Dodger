using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject explosion;
    private GameController gameController; 
    
    void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            gameController = GameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("GameController Script Not Found!");
        }
      
    }  

	void OnTriggerEnter(Collider other){

		if(other.tag=="Boundary"){
			return; 
		}
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver(); 
		}

		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		Destroy (other.gameObject);
        gameController.AddScore();        
   
	}
		
}
