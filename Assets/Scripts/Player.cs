using UnityEngine;

public class Player : Creature
{
	// Propiedades específicas del jugador
	public int experience;
	public int level = 1;

	// Umbral de experiencia para subir de nivel
	private int[] levelThresholds = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };

	// Método de inicialización específico para el jugador
	protected override void Start()
	{
		base.Start();
		// Inicialización adicional del jugador
	}

	// Método de actualización específico para el jugador
	protected override void Update()
	{
		base.Update();
		// Lógica de actualización adicional del jugador
	}

	// Método específico para el jugador para ganar experiencia
	public void GainExperience(int amount)
	{
		experience += amount;

		// Verificar si el jugador sube de nivel
		CheckLevelUp();

		// Lógica adicional relacionada con ganar experiencia
	}

	// Método para verificar y aplicar subida de nivel
	private void CheckLevelUp()
	{
		for (int i = 0; i < levelThresholds.Length; i++)
		{
			if (experience >= levelThresholds[i] && level < i + 2)
			{
				level = i + 2; // Sube de nivel
				ApplyLevelUpEffects(); // Aplica efectos al subir de nivel
			}
		}
	}

	// Método para aplicar efectos al subir de nivel
	private void ApplyLevelUpEffects()
	{
		// Puedes agregar aquí efectos específicos al subir de nivel
		switch (level)
		{
			case 2:
				shootSpeed += 1f; // Aumenta la velocidad de disparo
				break;
			case 3:
				maxHealth += 10f; // Aumenta la salud máxima
				break;
				// Agrega más casos según sea necesario para más niveles y efectos
		}
	}

	// Método sobrescrito para manejar la muerte del jugador
	protected override void Die()
	{
		// Lógica de muerte específica para el jugador
		// Puedes agregar aquí el reinicio del nivel, animaciones de muerte, etc.
		base.Die();
	}


}
