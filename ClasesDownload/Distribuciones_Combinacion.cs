//ESPAÑOL: la clase que calcula las combinaciones
//ENGLISH: this class calculate the combinations

using System;

public class combinacion_JW
{
    public static double calc_combinacion(double n, double r)//El método recibe un arreglo de double's y devuelve un solo valor double
    {//Inicia método que calcula las combinaciones          
        double p = 1;//Declara la variable que almacenará el valor de la combinación
        try
        {//Abre try   
            n = Math.Abs(n);//Obtiene valor absoluto por si se ingresó un valor negativo
            r = Math.Abs(r);//Obtiene valor absoluto por si se ingresó un valor negativo
            //Cálculo de la combinación invocando al cálculo del factorial
            p = (double)Math.Abs(factorial_JW.calc_factorial(n)) / (double)(Math.Abs(factorial_JW.calc_factorial(r) * factorial_JW.calc_factorial(n - r)));
        }//Cierra try
        catch (Exception excepcion)
        {//Abre catch
            Console.WriteLine("Informe de error: \n" + excepcion.Message);
            throw;
        }//Cierra catch  
        return p;//Devuelve valor de la combinación
    }//Termina método que calcula las combinaciones 
}//Termina la clase que calcula las combinaciones