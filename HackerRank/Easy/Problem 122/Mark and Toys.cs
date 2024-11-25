public static int maximumToys(List<int> prices, int k)
{
    // Sort the prices in ascending order
    prices.Sort();

    int sum = 0; // Current total cost
    int count = 0; // Count of toys bought

    // Iterate over sorted prices
    for (int i = 0; i < prices.Count; i++)
    {
        if (sum + prices[i] <= k)
        {
            sum += prices[i];
            count++;
        }
        else
        {
            break; // Stop if the budget is exceeded
        }
    }

    return count;
}
