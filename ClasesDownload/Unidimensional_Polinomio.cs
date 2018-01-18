using System;

public class polinomio_JW
//ESPAÑOL: Abre la clase que imprime un polinomio como cadena para el cálculo de regresión multinomial por método de mínimos cuadrados
//ENGLISH: Open the class that prints a polynomial as a string for the least-squares multinomial regression calculation
{
   public static string imprime_polinomio(int k, double[] b)
   //ESPAÑOL: Inicia método que genera una cadena de texto con el polinomio
   //ENGLISH: Start method that generates a text string with the polynomial
   { 
      //ESPAÑOL: Declara al subíndice local
      //ENGLISH: Declare the local subscript
      int i; 
      string sPolinomio = "";
      string sCadena1 = "\nEl análisis de modelo de regresión múltiple empleando el método de mínimos cuadrados generó el siguiente polinomio: \n Y = ";//Texto  
      string sCadena2 = "";
      string sCadena3 = "";
      string sCadenaEnter = "\n";
      string sCadenaTemp = "";
      
      //ESPAÑOL: for de i que recorre renglones hasta k
      //ENGLISH: for loop from i to k that to go through lines
      for(i=0;i<k;i++) 
         if (i == 0)
         {//Inicia if doble
            //printf(" %+f ", b[i]);//Imprime término independiente
            if (b[i] == 0)
               sCadenaTemp = Convert.ToString(Math.Round(b[i], 4));
            if (b[i] < 0)
               sCadenaTemp = " - " + Convert.ToString(Math.Abs(Math.Round(b[i],4)));
            if (b[i] > 0)
               sCadenaTemp = " + " + Convert.ToString(Math.Abs(Math.Round(b[i],4)));
               sCadena2 = sCadena2 + sCadenaTemp;
         }
         else
         {//Sino de if doble
            //printf(" %+f*X^%d ", b[i], i);//Imprime los siguientes términos del polinomio
            if (b[i] == 0)
               sCadenaTemp = Convert.ToString(Math.Round(b[i], 4)) + " X^" + Convert.ToString(i); ;
            if (b[i] < 0)
               sCadenaTemp = " - " + Convert.ToString(Math.Abs(Math.Round(b[i], 4))) + " X^" + Convert.ToString(i);
            if (b[i] > 0)
               sCadenaTemp = " + " + Convert.ToString(Math.Abs(Math.Round(b[i], 4))) + " X^" + Convert.ToString(i); ;

               sCadena3 = sCadena3 + sCadenaTemp; 
         }
         sPolinomio = sCadena1 + sCadena2 + sCadena3 + sCadenaEnter;//Genera la cadena final del polinomio 
         
         return sPolinomio;
   }
   //ESPAÑOL: Termina método que genera una cadena de texto con el polinomio 
   //ENGLISH: Ends method that generates a text string with the polynomial
}
//ESPAÑOL: Cierra la clase que imprime un polinomio como cadena para el cálculo de regresión multinomial por método de mínimos cuadrados
//ENGLISH: Close the class that prints a polynomial as a string for the multinomial regression calculation by least squares method