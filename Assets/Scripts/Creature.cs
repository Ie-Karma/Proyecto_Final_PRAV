using UnityEngine;

// Interfaz para objetos dañables
public interface IDamageable
{
	void TakeDamage(float damage);
}

// Clase base de la criatura
public abstract class Creature : MonoBehaviour, IDamageable
{
	// Propiedades comunes para todas las criaturas
	public float health;
	public float maxHealth = 100f;
	public float speed = 5f;
	public float shootSpeed = 1f;
	public float damagePerShot = 10f;

	// Evento para manejar la muerte de la criatura
	public delegate void CreatureEventHandler(Creature creature);
	public event CreatureEventHandler OnDeath;

	// Referencia al GameManager para acceder a la pool de balas
	private static GameManager gameManager;

	// Inicialización estática para asignar el GameManager
	static Creature()
	{
	}

	protected virtual void Start()
	{
		health = maxHealth;
		gameManager = GameManager.Instance;

	}

	protected virtual void Update()
	{
		// Lógica de actualización común para todas las criaturas
	}

	public void TakeDamage(float damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	protected virtual void Die()
	{
		// Lógica de muerte común para todas las criaturas
		OnDeath?.Invoke(this);
		Destroy(gameObject);
	}

	// Método para que la criatura dispare una bala
	public void Shoot(bool isEnemy)
	{
		// Obtener una bala de la pool del GameManager
		Bullet bullet = gameManager.GetBulletFromPool();

		// Configurar la bala con la información de la criatura que la dispara
		bullet.SetProperties(transform.position, transform.forward, isEnemy, damagePerShot);
	}
}
