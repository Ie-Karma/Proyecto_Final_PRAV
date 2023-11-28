using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameObject bulletPrefab;
	public int bulletPoolSize = 1000;
	public Player player;

	private List<Bullet> bulletPool;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			InitializeBulletPool();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void InitializeBulletPool()
	{
		bulletPool = new List<Bullet>();

		for (int i = 0; i < bulletPoolSize; i++)
		{
			GameObject bulletObject = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
			Bullet bullet = bulletObject.GetComponent<Bullet>();
			bullet.gameObject.SetActive(false);
			bulletPool.Add(bullet);
		}
	}

	public Bullet GetBulletFromPool()
	{
		foreach (Bullet bullet in bulletPool)
		{

			if (!bullet.gameObject.activeInHierarchy)
			{
				bullet.gameObject.SetActive(true);
				return bullet;
			}
			
		}

		GameObject bulletObject = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
		Bullet newBullet = bulletObject.GetComponent<Bullet>();
		bulletPool.Add(newBullet);

		return newBullet;
	}

	public void ReturnBulletToPool(Bullet bullet)
	{
		bulletPool.Remove(bullet);
		bulletPool.Add(bullet);
	}
}
