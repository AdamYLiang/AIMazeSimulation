using UnityEngine;
using System.Collections;

public class mouse : MonoBehaviour {

	public Transform cat; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 directionToCat = cat.position - transform.position;
		float angle = Vector3.Angle(transform.forward, directionToCat);

		if(angle < 180){
			Ray mouseRay = new Ray(transform.position, directionToCat);
			RaycastHit mouseRayHitInfo = new RaycastHit();
			//Debug.DrawRay(transform.position, directionToCat * 1000f, Color.yellow);

			if(Physics.Raycast(mouseRay, out mouseRayHitInfo, 10f)){
				if(mouseRayHitInfo.collider.tag == "Cat"){
					//Debug.Log("ggwp");
					GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 1000f);
				}
			}
		}
	}
}
