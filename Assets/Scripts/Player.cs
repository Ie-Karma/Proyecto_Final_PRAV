using System;
using UnityEditor;
using UnityEngine;

public class Player : Creature
{
	public int experience;
	public int level = 1;

	private int[] levelThresholds = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };

	protected override void Start()
	{
		base.Start();
		DeathNotifier.HasDied.AddListener(OnCreatureDeath);

	}

	private void OnCreatureDeath()
	{

		Debug.Log("Ive killed someone");
		GainExperience(10);

	}

	public void GainExperience(int amount)
	{
		experience += amount;

		CheckLevelUp();

	}

	private void CheckLevelUp()
	{
		for (int i = 0; i < levelThresholds.Length; i++)
		{
			if (experience >= levelThresholds[i] && level < i + 2)
			{
				level = i + 2;
				ApplyLevelUpEffects();
			}
		}
	}

	private void ApplyLevelUpEffects()
	{
		int levelUp = level % 5;

		switch (levelUp)
		{
			case 2:
				shootSpeed += 2 * level; 
				break;
			case 3:
				maxHealth += 10 * level; 
				break;
			case 4:
				damagePerShot += 5 * level; 
				break;
			case 5:
				speed += 1 * level;
				break;
		}
		health = maxHealth;
	}

	protected override void Die()
	{
		EndGame();
	}


	private void EndGame()
	{

		//termina el juego
		Debug.Log("Game Over");
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

	}

}
