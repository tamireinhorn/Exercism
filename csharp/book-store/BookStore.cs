using System;
using System.Collections.Generic;
using System.Linq;
public static class BookStore
{
    // Define the constant book price
    private const decimal BookPrice = 8; 
    // Define the basic math of the book's discounted price being 1 - percentage of discount times price.
    private static decimal DiscountedPrice(decimal discount) => (1 - discount) * BookPrice;
    // This simply applies the discount percentage to the bundle of n books and returns its price.
    private static decimal ApplyDiscount(int differentBooks)
    {
        switch(differentBooks){
            case 2:  return differentBooks * DiscountedPrice(0.05m);
            case 3:  return differentBooks * DiscountedPrice(0.1m);
            case 4:  return differentBooks * DiscountedPrice(0.2m);
            case 5:  return differentBooks * DiscountedPrice(0.25m);
            default: return differentBooks * DiscountedPrice(0);
        }
    }



    public static decimal Total(IEnumerable<int> basketOfBooks)
    {
        //The method should take a grouped AND order by descending cart. 
        var groupedCart = basketOfBooks.GroupBy(x => x).Select(c => c.Count()).OrderByDescending(i => i).ToList();
  
        return RecursiveTest(groupedCart, 0);
        
    }

    
    private static decimal RecursiveTest(List<int> groupedCart, decimal currentPrice){
        // Base case of recursion: return the price.
        if (groupedCart.Count() == 0){
            return currentPrice;
        }
        
        // Verify the biggest bundle possible:
        
        int maxBundle = groupedCart.Count();
        // Just sets the worst possible price as a basis for initial comparison.
        decimal minEval = decimal.MaxValue;
        // We always iterate over every possible bundle, from 1 to the biggest possible.
        foreach(int bundleSize in Enumerable.Range(1, maxBundle))
        {
            var restofCart = groupedCart.Skip(bundleSize); // The rest of the cart is the part we didn't bundle.
            // The new cart is simply removing the bundle out of the old cart
            // Which means walking over the bundle size, removing 1 from each position and removing the 0s
            // We then join with the rest of the cart.
            var newCart = groupedCart.Take(bundleSize).Select(x => x- 1).Where(book => book != 0)
                            .Concat(restofCart).ToList();
                    
            // We then call the function recursively, with the new cart and the current price of this new cart being:
            // It's old current price + the price of the bundle we made. 
            var eval = RecursiveTest(newCart, currentPrice + ApplyDiscount(bundleSize));
            // We then save the best (smallest) current price! 
            minEval = Math.Min(minEval, eval);
            
        }
        // Return the smallest price.
        return minEval;


    }
}  