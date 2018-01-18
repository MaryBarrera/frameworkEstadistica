using System;

public class generaVector_JW
{//Abre la clase que contiene a los métodos que generan los vectores X e Y para el cálculo de regresión multinomial por método de mínimos cuadrados

          public static void generaY(int n, double[,] Atemp, double[] Y)
         {//Inicia método que generan al vector Y
           int i; //Declara al subíndice local
             for(i=0;i<n;i++) //for de i que recorre renglones
               Y[i]=Atemp[i,1];//Asigna el valor de Abid[i,1] a Y[i]
         }//Termina método que generan al vector Y

          public static void generaX(int n, int k, double[,] Atemp, double[,] X)
         {//Inicia método que generan al vector X
            int i,j; //Declara a los subíndices locales
              for(i=0;i<n;i++)//for de i que recorre renglones
                for(j=0;j<k;j++){//for de j que recorre columnas hasta k
                  if(j==0)//if simple que evalúa si j es cero  
                    X[i, 0] = 1;//Asigna el valor de uno
                  if (j == 1)//if simple que evalúa si j es uno
                    X[i, 1] = Atemp[i, 0];//Asigna el valor de Atemp[i, 0]
                  if (j > 1)//if simple que evalúa si j es mayor a uno
                    X[i, j] = Math.Pow(Atemp[i,0], (double)j);//Asigna el valor de Atemp[i, 0] elevado a la potencia j                                                        
                                 }//Cierra for de j                                             
         }//Termina método que generan al vector X

}//Cierra la clase que contiene a los métodos que generan los vectores X e Y para el cálculo de regresión multinomial por método de mínimos cuadrados