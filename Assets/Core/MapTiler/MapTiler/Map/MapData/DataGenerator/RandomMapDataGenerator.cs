public class RandomMapDataGenerator : IMapDataGenerator {
	
	public int width, height; 

	public RandomMapDataGenerator(int width, int height) 
	{
		this.width = width; 
		this.height = height; 
	}

	public int[,] GenerateMapData ()
	{
		int[,] data = new int[width, height];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				data[x,y] = UnityEngine.Random.Range(1,3); 
			}
		}

		return data;
	}

}
