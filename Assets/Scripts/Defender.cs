using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Creature
{
	protected override void Start()
	{
		base.Start();
		// Inicializaci�n espec�fica del Defensor
		health = 80f;
		speed = 3f;
		shootSpeed = 1f;
		damagePerShot = 15f;
	}
}
