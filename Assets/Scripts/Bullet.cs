using UnityEngine;

public class Bullet : MonoBehaviour
{
	private bool isEnemy; // Indica si la bala fue disparada por un enemigo
	private float damage; // Daño que causará la bala
	private float speed = 10f; // Velocidad de la bala

	private void Start()
	{
		// Usar un temporizador para devolver la bala al pool después de 2 segundos
		Invoke("ReturnToPool", 2f);
	}

	// Método para configurar las propiedades de la bala al ser disparada
	public void SetProperties(Vector3 position, Vector3 direction, bool isEnemy, float damage)
	{
		transform.position = position;
		this.isEnemy = isEnemy;
		this.damage = damage;

		// Aplicar velocidad a la bala
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = direction.normalized * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		// Comprobar si ha colisionado con una criatura
		IDamageable damageable = other.GetComponent<IDamageable>();

		if (damageable != null)
		{
			// Aplicar daño a la criatura y devolver la bala al pool
			damageable.TakeDamage(damage);
			ReturnToPool();
		}
	}

	private void ReturnToPool()
	{
		// Desactivar la bala y devolverla al pool del GameManager
		gameObject.SetActive(false);
		GameManager.Instance.ReturnBulletToPool(this);
	}
}
