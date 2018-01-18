using System;

public class mediana_JW
{//Abre la clase que calcula la mediana

   public static double calc_mediana(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia método que calcula el promedio
      double mediana;//Declara variable para almacenar mediana con arreglo ordenado
      if (n % 2 == 0)//if-else que aplica la operación para cantidad de valores pares o impares
         mediana = (temp[n / 2] + temp[n / 2 - 1]) / 2;//Asigna valor de la mediana para arreglo de pares
      else//else aplica la operación en valores impares
         mediana = (temp[(n - 1) / 2]);//Asigna valor de la mediana para arreglo de impares                                    
      return mediana;//Devuelve la mediana o valor de enmedio
   }//Termina método que calcula la mediana
}//Cierra la clase que calcula la mediana