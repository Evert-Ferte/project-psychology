using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float sensitivity = 100;
    public float acceleration = 2000;
    
    private Vector2 rotation;
    private Vector2 velocity;
    
    private void Update() {
        Look();
    }

    private void Look() {
        if (Input.GetMouseButton(0)) {
            Vector2 wantedVelocity = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X") * -1) * sensitivity;

            velocity = new Vector2(
                Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration * Time.deltaTime),
                Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration * Time.deltaTime));
            rotation += velocity * Time.deltaTime;
            transform.localEulerAngles = new Vector3(rotation.x, rotation.y, 0);
        }
    }
}
