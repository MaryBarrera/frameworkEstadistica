///<summary>
///ESPAÑOL: la clase que calcula el rango de un arreglo unidimensional ordenado
///ENGLISH: the class that calculates the range of an ordered one-dimensional array
///</summary>

using System;

public class rango_JW//Abre
{
    public static double calc_rango_uni_frac(double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
    {//Inicia función
        double rg; //Declara variable local rango
        int iNumElementos;//Declara variable local para contar la cantidad de elementos del arreglo
        iNumElementos = temp.Length;//Cuenta la cantidad de elementos del arreglo
        rg = temp[iNumElementos - 1] - temp[0];//Calculo del rango de un arreglo unidimensional ordenado
        return rg;//Devuelve el rango
    }//Termina función
}//Cierra la clase que calcula el rango de un arreglo unidimensional ordenado
