using UnityEngine;
using System.Collections;

public class basicMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float speed;

	// Update is called once per frame
	void FixedUpdate () {


		GetComponent<Rigidbody>().velocity = transform.forward * speed + Physics.gravity;
		Ray moveRay = new Ray(transform.position, transform.forward);

		if(Physics.SphereCast(moveRay, 0.5f, 3f)){
			
			float randNo = Random.Range(0f,1f); 

			if(randNo <= 0.49f){
				transform.Rotate(new Vector3(0, 90, 0));
			}

			else if(randNo > 0.49f)
			{
				transform.Rotate(0, -90, 0);
			}
		}
	}
}
