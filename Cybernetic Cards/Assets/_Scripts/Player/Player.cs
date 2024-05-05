using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerCamera playerCamera;
    private bool overridePlayerControls = false;
    public bool GetOverridePlayerControls { get { return  overridePlayerControls; } }
    public bool SetOverridePlayerControls(bool OverridePlayerControls) { return overridePlayerControls = OverridePlayerControls; }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera = GetComponentInChildren<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!overridePlayerControls)
        {
			playerMovement.HandleMovement();
			playerCamera.CalculateCameraAndPlayerRotations();
		}
	}
}
