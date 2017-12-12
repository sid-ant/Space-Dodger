using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionMover : MonoBehaviour {

    public float speed;
    GameObject leftPart,rightPart;
    private Rigidbody rbLeft,rbRight;
    void Start () {

        leftPart=this.gameObject.transform.GetChild(0).gameObject;
        rightPart = this.gameObject.transform.GetChild(1).gameObject;

        //GameObject leftPart = obstruction.transform.Find("LeftObstruction").gameObject;
        //GameObject rightPart = obstruction.transform.Find("RightObstruction").gameObject;

        float leftXScale = Random.Range(0, 12);
        float rightXScale = 12 - leftXScale;

        float xSpawnLeft = leftXScale / 2 - 7;
        float xSpawnRight = 7-rightXScale/2;

        leftPart.transform.localScale = new Vector3(leftXScale, 1, 1);
        rightPart.transform.localScale = new Vector3(rightXScale, 1, 1);

        leftPart.transform.position = new Vector3(xSpawnLeft,0,17);
        rightPart.transform.position = new Vector3(xSpawnRight, 0, 17);

        rbLeft = leftPart.GetComponent<Rigidbody>();
        rbRight = rightPart.GetComponent<Rigidbody>();
        rbLeft.velocity = -transform.forward * speed;
        rbRight.velocity = -transform.forward * speed;
    
    }
	
}
