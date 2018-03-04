using System;

//ESPAÑOL: Abre la clase que calcula la mediana
//ENGLISH: open the class that calculate the median value 
public class mediana_JW
{
	//ESPAÑOL: El método recibe un arreglo de double's y devuelve un solo valor double
	//ENGLISH: the method get a double array and return a value
   	public static double calc_mediana(int n, double[] temp)
   {
   		//ESPAÑOL: Inicia método que calcula el promedio |  steps to calculate the average

   		//ESPAÑOL: Declara variable para almacenar mediana con arreglo ordenado
   		//ENGLISH: declare a variable to store the sorted array 
      	double mediana;

      	//ESPAÑOL: if-else que aplica la operación para cantidad de valores pares o impares
      	// ENGLISH: check if the number of elements are even or odd
      	if (n % 2 == 0) 
      		//ESPAÑOL: Asigna valor de la mediana para arreglo de pares |ENGLISH: calculate the average for even array
        	mediana = (temp[n / 2] + temp[n / 2 - 1]) / 2;

        //ESPAÑOL: else aplica la operación en valores impares | ENGLISH: aply when the number of elements are odd
      	else
      		//ESPAÑOL: Asigna valor de la mediana para arreglo de impares | ENGLISH: calculate the average for odd array
        	mediana = (temp[(n - 1) / 2]);                              
      	return mediana;//ESPAÑOL: Devuelve la mediana o valor de enmedio | ENGLISH: return the median value

   }//ESPAÑOL: Termina método que calcula la mediana | ENGLISH:
}//ESPAÑOL: Cierra la clase que calcula la mediana | ENGLISH: