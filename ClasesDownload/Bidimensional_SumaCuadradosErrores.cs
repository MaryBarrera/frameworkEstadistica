using System;

public class sumaCuadradosErrores_JW
      {//Abre la clase que contiene al método que cálcula la media de una matríz bidimensional

          public static double CalcSumaCuadradosE(int i, int j, double[,] Atemp,double[] vec_medias_renglones,double[] vec_medias_columnas, double media_de_arreglo)
          {//Inicia método que cálcula la media de una matríz bidimensional
              
              int a,b; //subíndices de renglones y columnas
              double diferencia = 0;//Declara e inicializa la variable provisional que almacenará la diferencia
              double acumulador = 0;//Declara e inicializa el acumulador de los valores del arreglo    

                for(a=0;a<j;a++){//Inicia ciclo for de a que recorre el vector hasta j
                  for(b=0;b<i;b++){//Inicia ciclo for de b que recorre el vector hasta i
                      try
                      {//Abre try
                        diferencia = Atemp[a,b] - vec_medias_columnas[b] - vec_medias_renglones[a] + media_de_arreglo;//Calcula la diferencia de la iteración 
                      }//Cierra try  

                      catch (System.IndexOutOfRangeException eX3)
                      {//Inicia el catch para controlar excepción IndexOutOfRangeException
                        System.Console.WriteLine(eX3.Message);
                      }//Cierra el catch para controlar excepción IndexOutOfRangeException 
                      
                    acumulador = acumulador + Math.Pow(diferencia,2);//Acumula el valor de la diferencia
                                  }//Termina ciclo for de b que recorre el vector hasta i
                                }//Termina ciclo for de a que recorre el vector hasta j

              return acumulador;//Devuelve el resultado    

            }//Fin de método que cálcula la media de una matríz bidimensional

      }//Cierra la clase que contiene al método que cálcula la media de una matríz bidimensional
