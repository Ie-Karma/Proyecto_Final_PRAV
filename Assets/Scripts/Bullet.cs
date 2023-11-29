using UnityEngine;

public class Bullet : MonoBehaviour
{
	private bool isEnemy;
	private float damage;
	public Material playerMat, enemyMat;

	private void Start()
	{
		// Usar un temporizador para devolver la bala al pool despu�s de 2 segundos
		Invoke("ReturnToPool", 5f);
	}

	// M�todo para configurar las propiedades de la bala al ser disparada
	public void SetProperties(Vector3 position, Vector3 direction, bool isEnemy, float damage, float speed)
	{
		transform.position = position;
		this.isEnemy = isEnemy;
		this.damage = damage;

		// Aplicar velocidad a la bala
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = direction.normalized * speed * 5;

		MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		if (isEnemy)
		{
			meshRenderer.material = enemyMat;
		}
		else
		{
			meshRenderer.material = playerMat;
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		// Comprobar si ha colisionado con una criatura
		IDamageable damageable = other.GetComponent<IDamageable>();

		if (damageable != null)
		{
			if (other.GetComponent<Player>())
			{
				if (isEnemy)
				{
					damageable.TakeDamage(damage);
					ReturnToPool();
				}
			}else if (!isEnemy) {

				damageable.TakeDamage(damage);
				ReturnToPool();
			}
			// Aplicar da�o a la criatura y devolver la bala al pool

		}
	}

	private void ReturnToPool()
	{
		// Desactivar la bala y devolverla al pool del GameManager
		gameObject.SetActive(false);
		GameManager.Instance.ReturnBulletToPool(this);
	}
}
