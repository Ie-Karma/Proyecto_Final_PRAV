using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		IDamageable damageable = other.GetComponent<IDamageable>();

		if (damageable != null)
		{
			if (other.GetComponent<Player>())
			{
				damageable.TakeDamage(10000);
			}
			else
			{
				damageable.TakeDamage(10000);
			}

		}
	}

}
