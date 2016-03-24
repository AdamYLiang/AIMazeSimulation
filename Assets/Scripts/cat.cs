using UnityEngine;
using System.Collections;

public class cat : MonoBehaviour {

	public Transform mouse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(mouse == null){
			return;
		}
		else{
			Vector3 directionToMouse = mouse.position - transform.position;
			float angle = Vector3.Angle(transform.forward, directionToMouse);

			if(angle < 90){
				Ray catRay = new Ray(transform.position, directionToMouse);
				RaycastHit catRayHitInfo = new RaycastHit();
				//Ray is not drawing fix it 
				Debug.DrawRay(transform.position, directionToMouse * 1000f, Color.yellow);

				if(Physics.Raycast(catRay, out catRayHitInfo, 100f)){
					if(catRayHitInfo.collider.tag == "Mouse"){
						if(catRayHitInfo.distance <= 5){
							Destroy(mouse);
						}
						else{
							GetComponent<Rigidbody>().AddForce(directionToMouse.normalized * 1000f);
						}
					}
				}
			}
		}
	}
}
