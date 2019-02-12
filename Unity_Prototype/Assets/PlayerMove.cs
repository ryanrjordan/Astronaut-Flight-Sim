 using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

		public Rigidbody rb;
		public float RotateSpeed = 60f;
		public float MovementSpeed = 200f;

		void Start () {
			rb = GetComponent<Rigidbody>();
		}

		void Update (){
			Vector3 v;
			
			if(Input.GetKey("w")) {
				//move forward
				rb.AddForce(transform.forward * MovementSpeed * Time.deltaTime);
			}
			if(Input.GetKey("s")) {
				//move backward
				rb.AddForce(-transform.forward * MovementSpeed * Time.deltaTime);
			} 
			if(Input.GetKey("a")) {
				//roll left
				transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
			}
			if(Input.GetKey("d")) {
				//roll right
				transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);
			}
			if(Input.GetKey("up")) {
				//pitch forward
				transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
			}
			if(Input.GetKey("down")) {
				//pitch backward
				transform.Rotate(-Vector3.right * RotateSpeed * Time.deltaTime);
			}
			if(Input.GetKey("left")) {
				//yaw left
				transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
			}
			if(Input.GetKey("right")) {
				//yaw right
				transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
			}
			if(Input.GetKey("space")) {
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
			}
			if(Input.GetKeyDown("joystick button 5")) {
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
			}
			else {
				//using xbox controller instead of keyboard
				float stickSpeed = Input.GetAxis("LeftJoystickDir") * MovementSpeed;
				float stickRoll = Input.GetAxis("LeftJoystickRoll") * RotateSpeed;
				float stickPitch = Input.GetAxis("RightJoystickPitch") * RotateSpeed;
				float stickYaw = Input.GetAxis("RightJoystickYaw") * RotateSpeed;
				rb.AddForce(transform.forward * stickSpeed * Time.deltaTime);
				Debug.Log("roll " + stickRoll + "  pitch " + stickPitch
				+ " yaw " + stickYaw);
				if(stickRoll != 0 || stickPitch != 0 || stickYaw != 0) {
					transform.Rotate(Vector3.forward * stickRoll * Time.deltaTime);
					transform.Rotate(Vector3.right * stickPitch * Time.deltaTime);
					transform.Rotate(Vector3.up * stickYaw * Time.deltaTime);
				}
			}
			
		}

}
