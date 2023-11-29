using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float rotationSpeed = 10f;

	private Rigidbody playerRb;
	private Creature player;

	public delegate void PlayerShootHandler();
	public static event PlayerShootHandler OnPlayerShoot;

	private float timeBetweenShots;  // Tiempo entre disparos
	private float shotTimer;          // Temporizador para el siguiente disparo

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		player = GetComponent<Creature>();

		OnPlayerShoot += HandlePlayerShoot;

		// Inicializar el temporizador
		timeBetweenShots = 1f / player.shootSpeed;
		shotTimer = 0f;
	}

	private void Update()
	{
		RotatePlayer();

		// Actualizar el temporizador
		shotTimer += Time.deltaTime;

		// Permitir disparo si se hace clic y ha pasado el tiempo necesario desde el último disparo
		if (Input.GetMouseButtonDown(0) && shotTimer >= timeBetweenShots)
		{
			Shoot();
			shotTimer = 0f;  // Reiniciar el temporizador después de un disparo
			timeBetweenShots = 1f / player.shootSpeed;

		}
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(horizontal, 0f, vertical) * player.speed * Time.fixedDeltaTime;
		playerRb.MovePosition(transform.position + movement);
	}

	private void RotatePlayer()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
			Vector3 direction = targetPosition - transform.position;

			if (direction != Vector3.zero)
			{
				Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
			}
		}
	}

	private void Shoot()
	{
		OnPlayerShoot?.Invoke();
	}

	private void HandlePlayerShoot()
	{
		player.Shoot(false);
	}
}
