using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standard : Creature
{
	protected override void Start()
	{
		base.Start();
		// Inicializaci�n espec�fica del Est�ndar
		health = 60f;
		speed = 4f;
		shootSpeed = 1f;
		damagePerShot = 20f;
	}

	protected override void Update()
	{
		base.Update();
		// L�gica espec�fica del Est�ndar
		// Puedes agregar comportamientos �nicos aqu�
	}
}