using UnityEngine;

public class Player : Creature
{
	// Propiedades espec�ficas del jugador
	public int experience;
	public int level = 1;

	// Umbral de experiencia para subir de nivel
	private int[] levelThresholds = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };

	// M�todo de inicializaci�n espec�fico para el jugador
	protected override void Start()
	{
		base.Start();
		// Inicializaci�n adicional del jugador
	}

	// M�todo de actualizaci�n espec�fico para el jugador
	protected override void Update()
	{
		base.Update();
		// L�gica de actualizaci�n adicional del jugador
	}

	// M�todo espec�fico para el jugador para ganar experiencia
	public void GainExperience(int amount)
	{
		experience += amount;

		// Verificar si el jugador sube de nivel
		CheckLevelUp();

		// L�gica adicional relacionada con ganar experiencia
	}

	// M�todo para verificar y aplicar subida de nivel
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

	// M�todo para aplicar efectos al subir de nivel
	private void ApplyLevelUpEffects()
	{
		// Puedes agregar aqu� efectos espec�ficos al subir de nivel
		switch (level)
		{
			case 2:
				shootSpeed += 1f; // Aumenta la velocidad de disparo
				break;
			case 3:
				maxHealth += 10f; // Aumenta la salud m�xima
				break;
				// Agrega m�s casos seg�n sea necesario para m�s niveles y efectos
		}
	}

	// M�todo sobrescrito para manejar la muerte del jugador
	protected override void Die()
	{
		// L�gica de muerte espec�fica para el jugador
		// Puedes agregar aqu� el reinicio del nivel, animaciones de muerte, etc.
		base.Die();
	}


}
