using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100.0f;
    private Transform playerTransform;
	public Transform GetPlayerTransfom {  get { return playerTransform; } }
    private Transform cameraTransform;
    private float xRotation = 0.0f;

   private void Start()
    {
		//Cursor.lockState = CursorLockMode.Locked;
		cameraTransform = transform;
        playerTransform = cameraTransform.parent;
    }

	public void CalculateCameraAndPlayerRotations()
	{
		float mouseX, mouseY;
		GetPlayerInput(out mouseX, out mouseY);

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

		cameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
		playerTransform.Rotate(Vector3.up * mouseX);
	}

	private void GetPlayerInput(out float mouseX, out float mouseY)
	{
		mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
	}
}
