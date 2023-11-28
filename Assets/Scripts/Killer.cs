using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Creature
{
	protected override void Start()
	{
		base.Start();
		// Inicializaci�n espec�fica del Asesino
		health = 50f;
		speed = 6f;
		shootSpeed = 1.5f;
		damagePerShot = 25f;
	}

	protected override void Update()
	{
		base.Update();
		// L�gica espec�fica del Asesino
		// Puedes agregar comportamientos �nicos aqu�
	}
}

