using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Creature
{
	protected override void Start()
	{
		base.Start();
		// Inicialización específica del Defensor
		health = 80f;
		speed = 3f;
		shootSpeed = 1f;
		damagePerShot = 15f;
	}
}
