using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Creature
{
	protected override void Start()
	{
		base.Start();
		// Inicialización específica del Asesino
		health = 50f;
		speed = 6f;
		shootSpeed = 3f;
		damagePerShot = 25f;
	}
}

