using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
	private NavMeshAgent navMeshAgent;
	private Creature enemyCreature;
	private Transform playerTransform;

	public float stopDistance = 5f;
	private float timeBetweenShots;
	private float shotTimer;

	private void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		enemyCreature = GetComponent<Creature>();

		playerTransform = GameManager.Instance.player.transform;

		navMeshAgent.speed = enemyCreature.speed;

		timeBetweenShots = 1f / enemyCreature.shootSpeed;
		shotTimer = Random.Range(0f, timeBetweenShots);

	}

	private void Update()
	{
		float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

		// Configurar el destino del NavMeshAgent al jugador
		navMeshAgent.SetDestination(playerTransform.position);

		// Rotar para mirar al jugador
		RotateTowardsPlayer();

		shotTimer += Time.deltaTime;

		if (shotTimer >= timeBetweenShots)
		{
			Shoot();
			shotTimer = Random.Range(-timeBetweenShots, timeBetweenShots); ;
		}

		if (distanceToPlayer <= stopDistance)
		{
			navMeshAgent.isStopped = true;


		}
		else
		{
			navMeshAgent.isStopped = false;
		}

	}

	private void RotateTowardsPlayer()
	{
		// Obtener la direccion hacia el jugador, pero solo en el plano horizontal (Y)
		Vector3 directionToPlayer = playerTransform.position - transform.position;
		directionToPlayer.y = 0f;

		Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f), Time.deltaTime * navMeshAgent.angularSpeed);
	}

	private void Shoot()
	{
		enemyCreature.Shoot(true);
	}
}
