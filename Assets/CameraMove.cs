using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {
	const float SPEED = 0.1f;
	public Canvas canvas;
	public Text file_name;

	// Use this for initialization
	void Start () {
		foreach( Transform child in canvas.transform){
			file_name = child.gameObject.GetComponent<Text>();
			file_name.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		Vector3 v = ray.GetPoint (100);
//		transform.LookAt (v);

		//transform.localRotation = Quaternion.Euler(direction.x*45, direction.y*90, direction.z*90);
		//Debug.Log (mousePos);
		if(Input.GetKey(KeyCode.UpArrow)){
			GetComponent<Rigidbody>().velocity = transform.forward * 100.0f;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			//GetComponent<Rigidbody>().velocity = transform.right *  -100.0f;
			transform.Rotate(new Vector3(0,-0.8f,0));
		}
		if(Input.GetKey(KeyCode.DownArrow)){ 
			GetComponent<Rigidbody>().velocity = transform.forward * -100.0f;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			//GetComponent<Rigidbody>().velocity = transform.right * 100.0f;
			transform.Rotate(new Vector3(0,0.8f,0));
		}
		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<Rigidbody>().velocity = transform.up * 100.0f;
		}
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, 10000)) {
			file_name.text =  hit.transform.name;
		} else {
			file_name.text = "";
		}

//		this.transform.Translate ( 0, 0,( Input.GetAxis ( "Vertical" ) * 1 ) );
//		this.transform.Rotate (0,( Input.GetAxis ("Horizontal" )  * 1 ),0);
	}
	void OnCollisionEnter(Collision collision){
		 //file_name.text = collision.transform.name;
	}
	void OnCollisionExit(Collision collision){
		//file_name.text = "";
	}
}
