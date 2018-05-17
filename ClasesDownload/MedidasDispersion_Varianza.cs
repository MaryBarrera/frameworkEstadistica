///<summary>
///ESPAÑOL: la clase que calcula las varianza muestral y la varianza poblacional
///ENGLISH: the class that calculates the sample variance and the population variance
///</summary>
///<remarks>
/// Requiere de la clase media_JW | Requires the 'media_JW' class
///</remarks>

using System;

public class varianza_JW//Abre
{
   public static double calc_varianza_muestral(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia función que calcula la varianza muestral
      double vari_muestral; //Declara variable local vari_1 donde se almacenará la varianza muestral dividida entre n-1.
      double media; //Declara variable local donde se almacenará la media.
      double acum = 0; //Declara e inicializa variable acumulador.
      double valor;//Declara variable valor que almacenará temporalmente la diferencia.
      int i; //Declara al subíndice local.

      //Invoca a función que calcula la media aritmética.
      media = media_JW.calc_promedio(n, temp);

      for (i = 0; i < n; i++)
      { //Ciclo for para generar sumatoria de diferencias al cuadrado.
         valor = temp[i] - media;//Calcula diferencia entre valor i-esimo y la media.
         valor = Math.Pow(valor, 2);//Eleva las diferencias al cuadrado.
         acum += valor;//Acumulación de las operaciones anteriores.
      } //Cierra ciclo for de acumulaciones.

      vari_muestral = acum / (n - 1);//Calcula el cociente de la sumatoria entre n-1.
      return vari_muestral;//Devuelve la varianza muestral.
   }//Termina función que calcula la varianza muestral


   public static double calc_varianza_poblacional(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia función que calcula la varianza poblacional
      double vari_poblacional; //Declara variable local vari_poblacional donde se almacenará la varianza poblacional dividida entre n.
      double media; //Declara variable local donde se almacenará la media.
      double acum = 0; //Declara e inicializa variable acumulador.
      double valor;//Declara variable valor que almacenará temporalmente la diferencia.
      int i; //Declara al subíndice local.

      //Invoca a función que calcula la media aritmética.
      media = media_JW.calc_promedio(n, temp);

      for (i = 0; i < n; i++)
      { //Ciclo for para generar sumatoria de diferencias al cuadrado.
         valor = temp[i] - media;//Calcula diferencia entre valor i-esimo y la media.
         valor = Math.Pow(valor, 2);//Eleva las diferencias al cuadrado.
         acum += valor;//Acumulación de las operaciones anteriores.
      } //Cierra ciclo for de acumulaciones.

      vari_poblacional = acum / n;//Calcula el cociente de la sumatoria entre n.
      return vari_poblacional;//Devuelve la varianza poblacional.
   }//Termina función que calcula la varianza poblacional
}//Cierra la clase que calcula las varianzas
