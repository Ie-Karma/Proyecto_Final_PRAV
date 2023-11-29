using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
	public Player player;
	public TMP_Text statsText;

	private void Update()
	{
		UpdateStatsText();
	}

	private void UpdateStatsText()
	{
		if (player == null || statsText == null)
		{
			Debug.LogWarning("Player or TextMeshPro not assigned in UIManager.");
			return;
		}

		// Construir la cadena de texto con las estadísticas del jugador
		string statsString = "Stats:\n" +
							 "- Health: " + player.health + "\n" +
							 "- Speed: " + player.speed + "\n" +
							 "- Shoot Speed: " + player.shootSpeed + "\n" +
							 "- Damage Per Shot: " + player.damagePerShot + "\n" +
							 "- Experience: " + player.experience + "\n" +
							 "- Level: " + player.level;

		// Actualizar el texto en el TextMeshPro
		statsText.text = statsString;
	}
}
