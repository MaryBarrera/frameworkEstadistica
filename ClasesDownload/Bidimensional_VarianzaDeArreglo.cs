using System;
public class varianzasDeArreglo_JW
{//Abre la clase que contiene al método que cálcula las varianzas de una matríz bidimensional

          public static void calc_varianzas_de_muestras(int i, int j, double[,] Mbid_2, double[] vec_varianzas)
          {//Inicia método que cálcula las varianzas de una matríz bidimensional

              int a,b; //Subíndices de renglones y columnas
              
              //Declara vector temporal  
              double[] vec_temp;
              //Define el tamaño del arreglo con valor j
              vec_temp = new double[j];

                  for(b=0;b<i;b++)//Inicia ciclo for de b que recorre el vector hasta i
                     vec_varianzas[b] = 0;//Inicializa el vector de varianzas en cero

                  for(a=0;a<j;a++)//Inicia ciclo for de a que recorre el vector hasta j
                     vec_temp[a] = 0;//Inicializa el vector de varianzas en cero

                  for(b=0;b<i;b++){//Inicia ciclo for de b que recorre el vector hasta i
                       for(a=0;a<j;a++){//Inicia ciclo for de a que recorre el vector hasta j
                          vec_temp[a] =  Mbid_2[a,b];
                                       }//Termina ciclo for de a

                       vec_varianzas[b] = varianza_JW.calc_varianza_muestral(j, vec_temp);//Llama a función que calcula la varianza muestral dividiendo entre n-1
                     }//Termina ciclo for de b
                                                                                
          }//Fin de método que cálcula las varianzas de una matríz bidimensional

}//Cierra la clase que contiene al método que cálcula las varianzas de una matríz bidimensional