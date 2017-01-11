using UnityEngine;
using System.Collections;

public class JumpTriggerScript : MonoBehaviour {

    public float jumpForce = 100f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Enemy")
        {
            print("Jump!");
            col.collider.GetComponent<Rigidbody>().AddForce( (col.collider.transform.up) * jumpForce , ForceMode.Impulse);
        }

    }
}
