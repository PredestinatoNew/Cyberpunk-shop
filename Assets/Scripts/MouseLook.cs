using UnityEngine;

public class MouseLook : MonoBehaviour
{
	// Mouse sensitivity for both axes
	[SerializeField] private float sensitivityX = 1.0f, sensitivityY = 1.0f;

	// Minimum and maximum rotation on the X axis
	[SerializeField] private float minX = -90.0f, maxX = 90.0f;

	// Rotation mode options
	private enum Options { X, Y, XandY }

	// Selected rotation mode
	[SerializeField] private Options options;

	// Current target rotation
	private Quaternion targetRot;

	void Start()
	{
		// Store the initial rotation
		targetRot = transform.rotation;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		// Get mouse movement input and apply sensitivity multiplier
		float rotY = Input.GetAxis("Mouse X") * sensitivityX;
		float rotX = Input.GetAxis("Mouse Y") * sensitivityY;

		// Apply rotation based on the selected option
		if (options == Options.X)
			// Set target rotation for X axis only
			targetRot *= Quaternion.Euler(-rotX, 0.0f, 0.0f);
		else if (options == Options.Y)
			targetRot *= Quaternion.Euler(0.0f, rotY, 0.0f);
		else if (options == Options.XandY)
			targetRot *= Quaternion.Euler(-rotX, rotY, 0.0f);

		// Apply rotation to the object
		transform.localRotation = targetRot;
	}
}