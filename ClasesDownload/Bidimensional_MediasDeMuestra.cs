//ENGLISH: This class content the average columns and rows of the two-dimensional matrix

using System;

public class mediasDeMuestras_JW
{//Abre la clase que contiene a los métodos de las medias de columnas y renglones de una matríz bidimensional
      
    public static void calc_media_muestras_colu(int i, int j, double[,] Atemp, double[] vec_medias_columnas)
    {//Inicia método que cálcula la muestras de las columnas
        int a,b; //subíndices de renglones y columnas

        for(b=0;b<i;b++) //Inicia ciclo for de b que recorre el vector hasta i
            vec_medias_columnas[b] = 0;//Inicializa el vector de medias

        for(b=0;b<i;b++){//Inicia ciclo for de las columnas
            for(a=0;a<j;a++){//Inicia ciclo for de los renglones
                vec_medias_columnas[b] = vec_medias_columnas[b] + Atemp[a,b];//Acumula en vec[b] la cantidad de la muestra 
            }//Termina ciclo for
        }//Termina ciclo for

        for(b=0;b<i;b++) //Inicia ciclo for de b que recorre el vector hasta i
            vec_medias_columnas[b] = vec_medias_columnas[b] / (float) j;//Promedia los valores acumulados en el vector

    }//Termina método que cálcula la muestras de las columnas


         public static void calc_media_muestras_reng(int i, int j,double[,] Atemp,double[] vec_medias_renglones)
         {//Inicia método que cálcula la muestras de los renglones
 
             int a,b; //subíndices de renglones y columnas

             for (a = 0; a < j; a++)
             {//Inicia ciclo for de a que recorre el vector hasta j

                 try
                 {//Abre try
                     vec_medias_renglones[a] = 0;//Inicializa el vector de medias
                 }//Cierra try  
                 catch (System.IndexOutOfRangeException eA)
                 {//Inicia el catch para controlar excepción IndexOutOfRangeException
                     System.Console.WriteLine(eA.Message);
                 }//Cierra el catch para controlar excepción IndexOutOfRangeException

             }//Termina ciclo for de a que recorre el vector hasta j


                for(a=0;a<j;a++){//Inicia ciclo for de los renglones
                    for(b=0;b<i;b++)
                    {//Inicia ciclo for de las columnas

                        try
                        {//Abre try
                        vec_medias_renglones[a] = vec_medias_renglones[a] + Atemp[a,b];//Acumula en vec[b] la cantidad de la muestra 
                        }//Cierra try  

                        catch (System.IndexOutOfRangeException eB)
                        {//Inicia el catch para controlar excepción IndexOutOfRangeException
                          System.Console.WriteLine(eB.Message);
                        }//Cierra el catch para controlar excepción IndexOutOfRangeException                  
                    
                    }//Termina ciclo for
                                }//Termina ciclo for

                for (a = 0; a < j; a++)
                {//Inicia ciclo for de a que recorre el vector hasta j

                    try
                    {//Abre try
                        vec_medias_renglones[a] = vec_medias_renglones[a] / (double)i;//Promedia los valores acumulados en el vector
                    }//Cierra try
 
                    catch (System.IndexOutOfRangeException eC)
                    {//Inicia el catch para controlar excepción IndexOutOfRangeException
                      System.Console.WriteLine(eC.Message);
                    }//Cierra el catch para controlar excepción IndexOutOfRangeException


                }//Termina ciclo for

         }//Fin de método que cálcula la muestras de los renglones


    }//Cierra la clase que contiene a los métodos de las medias de columnas y renglones de una matríz bidimensional

