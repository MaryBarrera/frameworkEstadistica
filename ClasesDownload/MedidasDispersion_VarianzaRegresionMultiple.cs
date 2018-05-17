//ESPAÑOL: Contiene el método que calcula la varianza de la regresión múltiple.
//ENGLISH: Contains the method that calculates the variance of the multiple regression.

using System;

public class varianzaRegMult_JW
{//Inicia la clase varianzaRegMult_JW
    public static double calc_varianza_reg_mult(int n, int k, double Valor_1, double Valor_2)
    {//Inicia
        double SSE;//Declara variable que almacenará el resultado de Ytrans por Y - b Xtrans Y
        double S;//Declara variable que almacenará la varianza de la regresión múltiple
        double denominador;//Declara variable que almacenará el denominador del cálculo de la varianza de la regresión
        SSE = Valor_1 - Valor_2;//Calcula la diferencia entre Y * Ytrans con btrans * Xtrans * Y
        denominador = (double)(n - k);//Calcula el denominador
        S = SSE / denominador;//Calcula la varianza de la regresión
        return S;//Devuelve la varianza de la regresión
    }//Termina método que calcula la varianza de la regresión múltiple.
}//Termina la clase varianzaRegMult_JW
