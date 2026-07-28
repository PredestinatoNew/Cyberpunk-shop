using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	private static FirstPersonController instance;

	private FirstPersonController() { }

	public static FirstPersonController getInstance()
	{
		if (instance == null)
			instance = new FirstPersonController();
		return instance;
	}

	// Player movement speed
	[SerializeField] private float speed = 10.0f;

	// CharacterController component
	private CharacterController cc;

	void Start()
	{
		// Get the CharacterController component attached to this GameObject
		cc = GetComponent<CharacterController>();
	}

	void FixedUpdate()
	{
		// Get input from default movement axes (WASD / Arrow keys)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Store input values in a Vector2
		Vector2 input = new Vector2(horizontal, vertical);

		// Determine movement direction relative to player orientation
		Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
		Vector3 moveDir = new Vector3(desiredMove.x * speed, 0, desiredMove.z * speed);

		// Move the CharacterController
		cc.Move(moveDir * Time.fixedDeltaTime);
	}

	public void Stop()
	{
		speed = 0f;
	}

	public void Go()
	{
		speed = 10.0f;
	}
}