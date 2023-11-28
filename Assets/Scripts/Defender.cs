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
		shootSpeed = 0.5f;
		damagePerShot = 15f;
	}

	protected override void Update()
	{
		base.Update();
		// L�gica espec�fica del Defensor
		// Puedes agregar comportamientos �nicos aqu�
	}
}
