//ENGLISH: This class calculate logistic binomial regression

using System;

public class logistica_JW
{//Inicia la clase logistica_JW

    public static void calc_reg_binomial_o_logistica(int n,double[] temp,double[,] odds_logit)
    {//Inicia método
        int i; //Declara al subíndice local
        
        for(i=0;i<n;i++){//Ciclo for de i que recorre todos los valores hasta n
            odds_logit[i,0]=temp[i]/(1-temp[i]);//Asigna el valor de odds_logit en la columna cero
            odds_logit[i, 1] = Math.Log(temp[i] / (1 - temp[i]));//Asigna el valor de odds_logit en la columna uno
        }//Cierra ciclo for                                                                                                  
    }//Termina método
}//Termina la clase logistica_JW