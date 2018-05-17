///<summary>
///ESPAÑOL: Contien el método que calcula la marca de clase
///ENGLISH: Contains the method that calculates the class mark
///</summary>

using System;

public class marcasClase_JW
{//Inicia la clase marcasClase_JW
    public static void calc_marcas_clase(int iCantidadClases, double[,] dLimitesClases, double[] dMarcasClase)
    {//Inicia método que calcula la marca de clase
            //Declara subíndice local
        int i;
        //Genera el arreglo con las marcas de cada clase
        for (i = 0; i < iCantidadClases; i++)  //For que recorre el arreglo
            dMarcasClase[i] = (dLimitesClases[i, 0] + dLimitesClases[i, 1]) / 2;//Calculo de los valores de las marcas de clase
    }//Termina método
}//Termina la clase marcasClase_JW
