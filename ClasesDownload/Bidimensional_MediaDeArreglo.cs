//ENGLISH: This method calculate the average of two-dimensional matrix
//ESPAÑOL: la clase que contiene al método que cálcula la media de una matríz bidimensional
using System;

public class mediaDeArreglo_JW
{
  public static double calc_media_aritmetica_arreglo_bid(int i, int j,double[,] Atemp)
  {//Inicia método que cálcula la media de una matríz bidimensional
    int a,b; //subíndices de renglones y columnas
    double acumulador = 0;//Declara e inicializa el acumulador de los valores del arreglo    

    for(b=0;b<i;b++)//Inicia ciclo for de a que recorre el vector hasta j
      for(a=0;a<j;a++)//Inicia ciclo for de a que recorre el vector hasta j
        acumulador = acumulador + Atemp[a,b];//Acumula todos los valores del arreglo
        acumulador = acumulador / (double)(i * j);//Calcula el promedio de todos los valores del arreglo
      return acumulador;//Devuelve el resultado    

  }//Fin de método que cálcula la media de una matríz bidimensional  
}//Cierra la clase que contiene al método que cálcula la media de una matríz bidimensional