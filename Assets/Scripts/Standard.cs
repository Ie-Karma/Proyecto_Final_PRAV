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
		shootSpeed = 1f;
		damagePerShot = 20f;
	}

	protected override void Update()
	{
		base.Update();
		// Lógica específica del Estándar
		// Puedes agregar comportamientos únicos aquí
	}
}