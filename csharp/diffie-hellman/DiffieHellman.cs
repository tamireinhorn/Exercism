using System;
using System.Numerics;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        return new Random().NextInt64(2, (long)primeP-1);
    }
 
    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) 
    {
        return (BigInteger)Math.Pow((double)primeG, (double)privateKey) % primeP;
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) 
    {
        return (BigInteger)Math.Pow((double)publicKey, (double)privateKey) % primeP;
    }
}