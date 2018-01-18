using System;

public class multiplicaB_JW
      {//Abre la clase que contiene al método que multiplica matrices bidimensionales con matrices bidimensionales o vectores 

          public static void matrices(int a, int b, int c, int d, double[,] Mbid_1, double[,] Mbid_2, double[,] Mbid_3)
          {//Inicia método que multiplica bidimensionales cuadradas o no cuadradas siempre y cuando el producto sea formateable
    
          // Multiplica matrices no cuadradas de dos dimensiones
          int i,j,k;//Declara subíndices locales
            if(b==c){//Abre if-else que verifica si las columnas de Mbid_1 es igual a los renglones de Mbid_2 y verifica que el producto sea formateable
              for(i=0;i<a;i++){//Ciclo for de i que recorre los valores hasta a
                for(j=0;j<d;j++){//Ciclo for de j que recorre los valores hasta d
                  Mbid_3[i,j] = 0;//Inializa los valores de la matriz Mbid_3
                    for(k=0;k<c;k++)//Ciclo for de k que recorre los valores hasta c
                       Mbid_3[i,j] = Mbid_3[i,j] + Mbid_1[i,k] * Mbid_2[k,j];//Multiplica los renglones de Mbid_1 por las columnas de Mbid_2 y los acumula en el elemento correspondiente de Mbid_3
                                 }//Cierra for de j
                              }//Cierra for de i

                    }//Cierra if doble
            else{//Sino del if doble
              for(i=0;i<a;i++)//Ciclo for de i que recorre los valores hasta a
                for(j=0;j<d;j++)//Ciclo for de j que recorre los valores hasta d
                  Mbid_3[i,j] = 0;//Cuando el producto no es formateable inializa los valores de la matriz Mbid_3 en cero únicamente
                }//Cierra else de if doble
          
          }//Termina método que multiplica bidimensionales cuadradas o no cuadradas siempre y cuando el producto sea formateable



          public static void matrizVector1(int k, int n, double[,] X_transpuesta, double[] Y, double[] X_transpuesta_por_Y)
          {//Inicia el método 1 que multiplica una matriz de dos dimensiones por un vector

            int i,j;//Declara subíndices locales
              for(i=0;i<k;i++){//Ciclo for de i que recorre los valores hasta k
                X_transpuesta_por_Y[i] = 0;//Inializa los valores de la matriz X_transpuesta_por_Y en cero
              for(j=0;j<n;j++)//Ciclo for de j que recorre los valores hasta n
                X_transpuesta_por_Y[i] = X_transpuesta_por_Y[i] + X_transpuesta[i,j] * Y[j];//Multiplica los valores correspondientes de  Mbid_1 por Vuni_1 y los acumula en el elemento correspondiente de Vuni_2
                              }//Cierra for de i

          }//Termina el método 1 que multiplica una matriz de dos dimensiones por un vector


          public static void calc_prod_matriz_vector_2(int k, double[,] inv_de_X_trans_por_X, double[] X_transpuesta_por_Y, double[] b)
          {//Inicia el método 2 que multiplica una matriz de dos dimensiones por un vector

            int i,j;//Declara subíndices locales
              for(i=0;i<k;i++){//Ciclo for de i que recorre los valores hasta a
                b[i] = 0;//Inializa los valores de la matriz b en cero
                  for(j=0;j<k;j++)//Ciclo for de j que recorre los valores hasta b
                    b[i] = b[i] + inv_de_X_trans_por_X[i,j] * X_transpuesta_por_Y[j];//Multiplica los valores correspondientes de  Mbid_1 por Vuni_1 y los acumula en el elemento correspondiente de Vuni_2
                              }//Cierra for de i

          }//Termina el método 2 que multiplica una matriz de dos dimensiones por un vector
  

      }//Cierra la clase que contiene al método que multiplica matrices bidimensionales con matrices bidimensionales o vectores