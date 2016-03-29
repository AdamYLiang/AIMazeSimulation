using UnityEngine;
using System.Collections;

public class cat : MonoBehaviour {

	public GameObject mouse;
	public AudioClip mouseDeath;
	AudioSource myAudio;

	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(mouse == null){
			return;
		}

		else{
			Vector3 directionToMouse = mouse.transform.position - transform.position;
			float angle = Vector3.Angle(transform.forward, directionToMouse);
			if(angle < 90){
				Ray catRay = new Ray(transform.position, directionToMouse);
				RaycastHit catRayHitInfo = new RaycastHit();
				//Ray is not drawing fix it 
				//Debug.DrawRay(transform.position, directionToMouse * 1000f, Color.yellow);

				if(Physics.Raycast(catRay, out catRayHitInfo, 10f)){
					if(catRayHitInfo.collider.tag == "Mouse"){

						Debug.Log (catRayHitInfo.distance);
						if(catRayHitInfo.distance <= 3f){
							myAudio.PlayOneShot (mouseDeath);
							Destroy(mouse);
						}
						else{
							myAudio.PlayOneShot (myAudio.clip, 0.5f);
							GetComponent<Rigidbody>().AddForce(directionToMouse.normalized * 1000f);
						}
					}
				}
			}
		}
	}
}
