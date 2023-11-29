using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

// Interfaz para objetos dañables
public interface IDamageable
{
	void TakeDamage(float damage);
}

public interface IDeathObserver
{
	void OnCreatureDeath(Creature creature);
}

public class DeathNotifier
{
	public static UnityEvent HasDied = new UnityEvent();

	public void NotifyDeath(Creature creature)
	{
		HasDied.Invoke();
	}
}

public abstract class Creature : MonoBehaviour, IDamageable
{
	public float health;
	public float maxHealth = 100f;
	public float speed = 5f;
	public float shootSpeed = 1f;
	public float damagePerShot = 10f;

	protected DeathNotifier deathNotifier = new DeathNotifier();

	protected GameManager gameManager;

	protected virtual void Start()
	{
		health = maxHealth;
		gameManager = GameManager.Instance;

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
		Debug.Log("Creature died");
		deathNotifier.NotifyDeath(this);
		Destroy(gameObject);
	}
	public void Shoot(bool isEnemy)
	{
		Bullet bullet = gameManager.GetBulletFromPool();

		bullet.SetProperties(transform.position, transform.forward, isEnemy, damagePerShot, shootSpeed);
	}
}
