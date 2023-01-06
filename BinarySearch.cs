public static class Search
{
    public static int BinarySolution(int[,] matrix, int N)
    {
        int low = 0;
        int high = N - 1;
        int max = int.MinValue;
        while (low + 1 != high)
        {
            int mid = (high + low) / 2;
            int upper = BinarySearch(matrix, N, mid + 1);
            int lower = BinarySearch(matrix, N, mid);
            if (lower > upper)
            {
                low = mid;
                max = max < lower ? lower : max;
            }
            else
            {
                high = mid;
                max = max < upper ? upper : max;
            }
        }
        
        return max;
    }
    private static int BinarySearch(int[,] matrix, int N, int row)
    {
        int low = 0;
        int high = N - 1;
        while (low + 1 != high)
        {
            
            int mid = (high + low) / 2;
            if (matrix[mid, row] > matrix[mid + 1, row])
                high = mid;
            else
                low = mid;
        }
        
        return matrix[low, row];
    }
}