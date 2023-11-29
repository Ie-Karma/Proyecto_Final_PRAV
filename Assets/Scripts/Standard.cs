using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standard : Creature
{
	protected override void Start()
	{
		base.Start();
		// Inicialización específica del Estándar
		health = 60f;
		speed = 4f;
		shootSpeed = 2f;
		damagePerShot = 20f;
	}
}