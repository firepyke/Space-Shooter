﻿ /* 
  * ShipControls
  * 
  * Allows user to control the player ship
  * when added as a component of the "Player" GameObject
  * 
  * Controls:
  *     forward      -  W or Up-arrow
  *     backward     -  S or Down-arrow
  *     rotate left  -  A or Left-arrow
  *     rotate right -  D or Right-arrow
  *     
  * Author(s):  David Habinsky
  *             Kenneth Berry (added comments)
  */
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    public float thrust;                // forward or backwards force being applied
    public float rotateThrust;          // rotational force being applied

    private float thrustInput;          // keyboard input for thrust
    private float rotateInput;          // keyboard input for rotational thrust
    private Rigidbody rb;               // Rigidbody component of player ship
    private Vector3 eulerAngleVelocity; // Euler angle velocity of ship

    /*
     * Initialization
     */
    void Start () {
        // Get the Rigidbody component of player's ship
        rb = GetComponent <Rigidbody>();
	}

    /*
     * Update is called once per frame
     */
    void Update()
    {
        //Check for keyboard input.
        thrustInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");

        // Add forward thrust to ships velocity vector
        rb.AddRelativeForce(Vector3.forward * thrustInput * thrust);

        // Calculate eular angle velocity
        eulerAngleVelocity = new Vector3(0, rotateInput * rotateThrust, 0);

        // Calculate change in rotation
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);

        // Rotate the ship's Rigidbody
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
