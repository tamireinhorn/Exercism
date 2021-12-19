using System;

static class SavingsAccount
{
    public const float NegativeInterestRate = 3.213f;
    public const float SmallInterestRate = 0.5f;
    public const float MediumInterestRate = 1.621f;
    public const float BigInterestRate = 2.475f;
    
    public static float InterestRate(decimal balance)
    {
        
        switch (balance){
            case <0:
                return NegativeInterestRate;
            case < 1000:
                return SmallInterestRate;
            case < 5000:
                return MediumInterestRate;
            default:
                return BigInterestRate;
                
        }
    }

    public static decimal Interest(decimal balance)
    {
        return ((decimal) InterestRate(balance) / 100) * balance;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
       return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance){
            balance = AnnualBalanceUpdate(balance);
            years = years + 1;
        }
        return years;
    }
}
