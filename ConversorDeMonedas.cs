using System;

public class ConversorDeMonedas
{
    
    // Cordobas a Dólares
    public double CordobaADolar(double cordobas)
    {
        double resultado = cordobas * 0.027;
        Console.WriteLine($"{cordobas} córdobas son {resultado} dólares.");
        return resultado;
    }

 
    // Cordobas a Euros
    public double CordobaAEuro(double cordobas)
    {
        double resultado = cordobas * 0.023;
        Console.WriteLine($"{cordobas} córdobas son {resultado} euros.");
        return resultado;
    }


    // Dólares a Cordobas
    public double DolarACordoba(double dolares)
    {
        double resultado = dolares * 36.81;
        Console.WriteLine($"{dolares} dólares son {resultado} córdobas.");
        return resultado;
    }


    // Dólares a Euros
    public double DolarAEuro(double dolares)
    {
        double resultado = dolares * 0.85;
        Console.WriteLine($"{dolares} dólares son {resultado} euros.");
        return resultado;
    }

  
    // Euros a Cordobas
    public double EuroACordoba(double euros)
    {
        double resultado = euros * 43.28;
        Console.WriteLine($"{euros} euros son {resultado} córdobas.");
        return resultado;
    }

  
    // Euros a Dólares
    public double EuroADolar(double euros)
    {
        double resultado = euros * 1.17;
        Console.WriteLine($"{euros} euros son {resultado} dólares.");
        return resultado;
    }

   
    
}


class Program
{
    static void Main(string[] args)
    {
        ConversorDeMonedas conversor = new ConversorDeMonedas();

        // Ejemplos de uso
        conversor.CordobaADolar(1000);
        conversor.CordobaAEuro(1000);
        conversor.DolarACordoba(50);
        conversor.DolarAEuro(50);
        conversor.EuroACordoba(50);
        conversor.EuroADolar(50);
    }
}
