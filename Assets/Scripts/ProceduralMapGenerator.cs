using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public class ProceduralMapGenerator : MonoBehaviour
{
	public int mapSize = 100;
	public float scale = 10f;
	public float heightMultiplier = 5f;
	public Material material;

	private NativeArray<float> heightMap;

	private void Start()
	{
		GenerateMap();
	}

	private void GenerateMap()
	{
		heightMap = new NativeArray<float>(mapSize * mapSize, Allocator.Persistent);

		// Crear y programar el Job para generar el mapa
		MapGenerationJob mapGenerationJob = new MapGenerationJob
		{
			heightMap = heightMap,
			mapSize = mapSize,
			scale = scale,
			heightMultiplier = heightMultiplier
		};

		JobHandle mapJobHandle = mapGenerationJob.Schedule(heightMap.Length, 32);

		// Esperar a que el Job termine antes de continuar
		mapJobHandle.Complete();

		// Aplicar el mapa a la escena (este es solo un ejemplo, ajusta según tus necesidades)
		ApplyMapToScene();

		// Liberar la memoria de NativeArray
		heightMap.Dispose();
	}
	private void ApplyMapToScene()
	{
		Terrain terrain = GetComponent<Terrain>();

		// Crear un nuevo TerrainData
		TerrainData terrainData = new TerrainData();
		terrainData.heightmapResolution = mapSize;
		terrainData.alphamapResolution = mapSize;
		terrainData.baseMapResolution = mapSize;

		// Establecer el tamaño del terreno
		terrainData.size = new Vector3(mapSize, 10f, mapSize);

		// Aplicar el nuevo TerrainData al Terrain
		terrain.terrainData = terrainData;

		// Obtener el mapa de alturas actualizado
		float[,] heightMapCopy = new float[mapSize, mapSize];

		for (int y = 0; y < mapSize; y++)
		{
			for (int x = 0; x < mapSize; x++)
			{
				heightMapCopy[y, x] = heightMap[y * mapSize + x];
			}
		}

		// Aplicar el nuevo mapa de alturas al TerrainData
		terrainData.SetHeights(0, 0, heightMapCopy);


		terrain.materialTemplate = material;

		TerrainCollider terrainCollider = gameObject.AddComponent<TerrainCollider>();
		terrainCollider.terrainData = terrainData;
	}


	// Job que realiza la generación del mapa en paralelo
	public struct MapGenerationJob : IJobParallelFor
	{
		public NativeArray<float> heightMap;
		public int mapSize;
		public float scale;
		public float heightMultiplier;

		public void Execute(int index)
		{
			// Obtener las coordenadas 2D del índice
			int x = index % mapSize;
			int y = index / mapSize;

			// Aplicar el ruido Perlin para la generación del terreno
			float xCoord = (float)x / mapSize * scale;
			float yCoord = (float)y / mapSize * scale;
			float heightValue = Mathf.PerlinNoise(xCoord, yCoord) * heightMultiplier;

			// Asignar el valor al mapa de alturas
			heightMap[index] = heightValue;
		}
	}
}
