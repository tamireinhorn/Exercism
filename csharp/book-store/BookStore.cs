using System;
using System.Collections.Generic;
using System.Linq;
public static class BookStore
{
    public const decimal BookPrice = 8; 

    public static decimal DiscountedPrice(decimal discount) => (1 - discount) * BookPrice;

    public static decimal ApplyDiscount(int differentBooks)
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
        //The method should take a grouped cart. 
        var groupedCart = basketOfBooks.GroupBy(x => x).Select(c => c.Count()).ToList();
        
        return RecursiveTest(groupedCart, 0);
        
    }

    
    public static decimal RecursiveTest(IEnumerable<int> basketOfBooks, decimal currentPrice){
        // Base case of recursion: return the price.
        if (basketOfBooks.Count() == 0){
            return currentPrice;
        }
        var groupedCart = basketOfBooks.ToList();
        //Verify the biggest bundle possible:
        
        int maxBundle = groupedCart.Count();
        decimal minEval = decimal.MaxValue;
        foreach(int bundleSize in Enumerable.Range(1, maxBundle))
        {
            var restofCart = groupedCart.Skip(bundleSize);
            var newCart = groupedCart.Take(bundleSize).Select(x => x- 1).Where(book => book != 0)
                            .ToList().Concat(restofCart);
            var eval = RecursiveTest(newCart, currentPrice + ApplyDiscount(bundleSize));
            minEval = Math.Min(minEval, eval);
            return minEval;
        }
       
        return 3;


    }
}  