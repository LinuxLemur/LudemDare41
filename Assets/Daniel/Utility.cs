using System.Collections;

public class Utility
{
    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        var prng = new System.Random(seed);
        
        for (int i = 0; i < array.Length -1; i++)
        {
            int randomindex = prng.Next(i, array.Length);
            
            T tempItem = array[randomindex];
            
            array[randomindex] = array[i];
            
            array[i] = tempItem;
        }

        return array;
    }
}