using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//player
    public Transform target;
    //offset
    public float distance = 5.0f;
    //height above target
    public float height = 1.0f;

    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    [AddComponentMenu("Camera-Control/Smooth Follow")]

    void LateUpdate () {
        //current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        //damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        //damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        //convert angle into rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        //set the position of the camera on the x-z plane to:
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        //set height of camera
        transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);

        transform.LookAt(target);
    }
}
