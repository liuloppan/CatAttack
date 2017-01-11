using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cat_Lite_Demo : MonoBehaviour {

    public Light light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
			Camera.main.transform.RotateAround (Vector3.zero, Vector3.up, 40 * Time.deltaTime);
        light.intensity = 0.2f + 0.3f * Mathf.Sin(Time.realtimeSinceStartup );



    }
}
