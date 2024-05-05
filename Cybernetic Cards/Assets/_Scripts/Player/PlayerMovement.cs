using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float speed = 15.0f;
	private CharacterController characterController;
    private float gravity = -9.81f;
    private Vector3 velocity;
	private Transform groundCheck;
    private float groundCheckRadius = 0.4f;
    private LayerMask groundMask;
    private bool isGrounded;
	private Transform playerTransform;
	public Transform GetPlayerTransfom { get { return playerTransform; } }

	// Start is called before the first frame update
	void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundMask = LayerMask.GetMask("Ground");
        groundCheck = transform.GetChild(2).GetComponent<Transform>();
		playerTransform = transform;

	}

	public void HandleMovement()
	{
		HandleGroundCheck();
		float x, z;
		GetPlayerInput(out x, out z);
		MovePlayer(x, z);
	}

	private void MovePlayer(float x, float z)
	{
		Vector3 direction = playerTransform.right * x + playerTransform.forward * z; // vector calculation

		characterController.Move(direction * speed * Time.deltaTime);
		HandleGravity();
	}

	private void HandleGravity()
	{
		velocity.y += gravity * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime); // apply gravity
	}

	private static void GetPlayerInput(out float x, out float z)
	{
		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");
	}

	private void HandleGroundCheck()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask); // ground check
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2.0f;
		}
	}
}
