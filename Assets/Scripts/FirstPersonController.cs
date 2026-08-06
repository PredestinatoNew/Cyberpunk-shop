using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	private static FirstPersonController instance;

	public Cart cart;
	public MouseLook mouseLook;

	private FirstPersonController() { }

	public static FirstPersonController getInstance()
	{
		if (instance is null)
			instance = new FirstPersonController();
		return instance;
	}

	[SerializeField] private float speed = 10.0f;
	[SerializeField] private float runSpeed = 18.0f;
	[SerializeField] private float jumpHeight = 2f;
	[SerializeField] private float gravity = -10.0f;
	[SerializeField] private float rotationSpeed = 100.0f; // Velocità di rotazione (gradi al secondo)

	private CharacterController cc;

	// Vertical Velocity Current during jump
	private float verticalVelocity;

	private void Awake()
	{
		if (instance is null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		// Get the CharacterController component attached to this GameObject
		cc = GetComponent<CharacterController>();
	}

	void FixedUpdate()
	{
		// Rotazione con Q (sinistra) ed E (destra)
		float turnInput = 0f;
		if (Input.GetKey(KeyCode.E)) turnInput += 1f;
		if (Input.GetKey(KeyCode.Q)) turnInput -= 1f;

		// Applica la rotazione sull'asse Y (Yaw)
		transform.Rotate(0f, turnInput * rotationSpeed * Time.fixedDeltaTime, 0f);

		// Get input from default movement axes (WASD / Arrow keys)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Store input values in a Vector2
		Vector2 input = new Vector2(horizontal, vertical);

		// Corsa: tenendo premuto Shift sinistro si usa runSpeed al posto di speed
		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		float currentSpeed = isRunning ? runSpeed : speed;

		// Determine movement direction relative to player orientation
		Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
		Vector3 moveDir = new Vector3(desiredMove.x * currentSpeed, 0, desiredMove.z * currentSpeed);

		// Salto e gravità
		if (cc.isGrounded)
		{
			// Piccolo valore negativo per tenere il CharacterController "ancorato" a terra
			if (verticalVelocity < 0f)
				verticalVelocity = -2f;

			if (Input.GetButtonDown("Jump"))
			{
				// v = sqrt(h * -2 * g)
				verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
			}
		}
		else
		{
			// Applica la gravità mentre si è in aria
			verticalVelocity += gravity * Time.fixedDeltaTime;
		}

		moveDir.y = verticalVelocity;

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