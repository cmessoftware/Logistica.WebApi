namespace Logistica.WebApi.Api.Helpers
{
    public class ShorterDistancesHelpers
    {

        public static int CalculateTotalDistance(int[] route, int[,] distanceMatrix)
        {
            int totalDistance = 0;
            for (int i = 0; i < route.Length - 1; i++)
            {
                totalDistance += distanceMatrix[route[i], route[i + 1]];
            }
            totalDistance += distanceMatrix[route[route.Length - 1], route[0]]; // Retornar al origen
            return totalDistance;
        }

        public static IEnumerable<int[]> GetPermutations(int[] cities)
        {
            int n = cities.Length;
            int[] indexes = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexes[i] = i;
            }

            do
            {
                yield return cities;
            } while (NextPermutation(indexes, cities));
        }

        static bool NextPermutation(int[] indexes, int[] cities)
        {
            int n = indexes.Length;

            int k = n - 2;
            while (k >= 0 && indexes[k] >= indexes[k + 1])
            {
                k--;
            }
            if (k < 0) return false;

            int l = n - 1;
            while (indexes[k] >= indexes[l])
            {
                l--;
            }

            Swap(indexes, k, l);
            Swap(cities, k, l);

            Array.Reverse(indexes, k + 1, n - k - 1);
            Array.Reverse(cities, k + 1, n - k - 1);
            return true;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
