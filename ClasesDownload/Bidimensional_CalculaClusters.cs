using System;

public class calculaClusters_JW
{//Abre la clase que contiene a los métodos que cálculan diversos parámetros de los clusters

  public static int TamVDE(int n)
  {//Inicia método que cálcula la cantidad de elementos que habrá en el vector de distancias euclideas
    int tam;//Declara variable que almacenará resultado
    tam = n*(n-1)/2;//Calcula el tamaño o cantidad de elementos que habrá en el vector de distancias euclideas 
    return tam;//Devuelve el resultado  
  }//Termina método que cálcula la media de una matríz bidimensional


  public static void calc_dist_euclideas(int n, int r,int tam_vde,double[,] Abid_estandar,double[] vec_dist_euclideas)
  {//Inicia método que cálcula los valores del vector de distancias euclideas      
    int i,j;//Subíndices de renglones y columnas
    int k;//Subíndice de multivariables en matríz de entrada
    int a = 0;//Subíndice del vector de distancias euclideas

    for(i=0;i<tam_vde;i++)//Inicia ciclo for de i que recorre el vector hasta tam_vde
      vec_dist_euclideas[i] = 0; //Inicializa todo el vector en ceros  

    for(i=0;i<n;i++){//Inicia ciclo for de i que recorre el vector hasta n
      for(j=i+1;j<n;j++){//Inicia ciclo for de j que recorre el vector hasta n iniciando en i+1
        for(k=0;k<r;k++){//Inicia ciclo for de k=1 que recorre el vector hasta r
          vec_dist_euclideas[a] = vec_dist_euclideas[a] + Math.Pow(Abid_estandar[i,k] - Abid_estandar[j,k],2);//Calcula la sumatoria de las diferencias al cuadrado para iniciar el cáclulo de la distancia euclidea entre dos puntos
        }//Termina ciclo for de k=1 que recorre el vector hasta r
        
        vec_dist_euclideas[a] = Math.Sqrt( Math.Abs(vec_dist_euclideas[a]) );//Calcula la raiz cuadrada para concluir el cálculo de la distancia entre los dos puntos
        a++;//Incrementa en uno el valor del contador temporal a      
      }//Termina ciclo for de j                    
    }//Termina ciclo for de i
  }//Termina de método que cálcula los valores del vector de distancias euclideas


  public static void calc_mat_dist_euclideas(int n, int tam_vde, double[] vec_dist_euclideas,double[,] dMatDistEuclideas)
  {//Inicia método que cálcula los la matríz de distancias euclideas

    int i, j; //subíndices de renglones y columnas
    int temp = 0;//Declara contador temporal y lo inicialia en cero

    for (i = 0; i < n; i++)//Inicia ciclo for de i que recorre el vector hasta n
      for (j = 0; j < n; j++)//Inicia ciclo for de j que recorre el vector hasta n
        dMatDistEuclideas[i, j] = 0; //Inicializa todo el arreglo en ceros  

    for (j = 0; j < n; j++)
    {//Inicia ciclo for de j que recorre el vector hasta n
      for (i = 0; i < n; i++)
      {//Inicia ciclo for de i que recorre el vector hasta n
        if (i != j && i > j)
        {//Abre if simple condicionado para calcular el triangulo inferior y superior de la matríz de distancias   
          dMatDistEuclideas[i, j] = vec_dist_euclideas[temp];
          dMatDistEuclideas[j, i] = vec_dist_euclideas[temp];
          temp++;//Incrementa en uno el valor del contador temporal
        }//Cierra if simple
      }//Termina ciclo for de j
    }//Termina ciclo for de i
  }//Termina método que cálcula los la matríz de distancias euclideas


          public static void genera_arreglo_clusters(int tam_vde,int tam_vd_min,int n,double[] vec_dist_euclideas,double[] vec_dist_minimas,double[,] mat_dist_euclideas,int[,] arreglo_clusters)
          {//Inicia método que genera el arreglo con los clusters

              int tam_vde_lineal = tam_vde * 2;//Declara e inicializa el tamaño del vector de distancias euclideas unidimensional
              int i = 0, j = 0; //Declara e inicializa subíndices de renglones y columnas
              int q;//Subíndice que se emplea para los valores del vec_dist_minimas
              int dato_1 = 0, dato_2 = 0; //Variables que almacenarán los números de i, j en la distancia más corta
              int subindice_1;//Declara variable auxiliar que definirá el valor de inicio de ciclo for que levanta banderas
              int pivote;//Declara variable para almacenar valor pivote


              //Declara el arreglo de datos arreglo_completo_clusters que..., además lo inicializa en cero 
              int[,] arreglo_completo_clusters;            
              //Dimensiona el tamaño del arreglo bidimensional arreglo_completo_clusters
              arreglo_completo_clusters = new int[tam_vde, 4];

                for (i = 0; i < tam_vde; i++)//Inicia ciclo for de i que recorre el vector hasta tam_vd_min
                 for (j = 0; j < 4; j++)//Inicia ciclo for de j que recorre el vector hasta 2
                  arreglo_completo_clusters[i, j] = 0;//Inicializa el arreglo completo de clusters en cero

              //Declara el arreglo de datos banderas_clusters_uni que...., además lo inicializa en cero
              int[] banderas_clusters_uni = { 0 };
              //Redimensiona el arreglo a su tamaño definitivo
              banderas_clusters_uni = new int[tam_vde_lineal];             


              //Declara el arreglo de datos arreglo_clusters_uni que...., además lo inicializa en cero
              int[] arreglo_clusters_uni = { 0 };
              //Redimensiona el arreglo a su tamaño definitivo
              arreglo_clusters_uni = new int[tam_vde_lineal];

              int primer_aparicion = 0, no_primer_aparicion = 0;//Declara e inicializa los contadores que evaluarán cuantas primeras aparciones hay o no según el caso
              int cont;//Declara contador para almacenar datos en clusters primera y no primeras apariciones
              int primer_aparicion_duplicado;//Declara contador para almacenar cantidad de primera aparición en ambas observaciones
              int total_apariciones = 0;//Declara e inicializa variable que almacenará la suma de primeras apariciones y de apariciones duplicadas
              primer_aparicion_duplicado = 0;//Inicializa el contador de primeras apariciones duplicadas
              double valor = mat_dist_euclideas[1,0];//Asigna el valor de 1,0 de la matríz de distancias euclideas en la primer ocasión de forma arbitraria como punto de inicio a comparar

                for(i=0;i<tam_vd_min;i++)//Inicia ciclo for de i que recorre el vector hasta tam_vd_min
                  for(j=0;j<2;j++)//Inicia ciclo for de j que recorre el vector hasta 2
                     arreglo_clusters[i,j] = 0;//Inicializa el arreglo de clusters en cero

              //Declara el arreglo de datos mapa_dist_euclideas que..., además lo inicializa en cero 
              double[,] mapa_dist_euclideas = { { 0, 0 } };            
              //Dimensiona el tamaño del arreglo bidimensional mapa_dist_euclideas
              mapa_dist_euclideas = new double[n,n];

              for(i=0;i<n;i++)//Inicia ciclo for de i que recorre el vector hasta n
                for(j=0;j<n;j++)//Inicia ciclo for de j que recorre el vector hasta n
                  mapa_dist_euclideas[i,j] = 0;//Inicializa el arreglo mapa_dist_euclideas en cero

              for(q=0;q<tam_vde;q++){//Inicia ciclo for de q que recorre el vector hasta tam_vd_min

                if(q==0){//Abre if simple que entra a la primer parte solo cuando q es cero
   
                  //Código que ubica a los dos elementos que integran al primer cluster  
                  for(i=0;i<n;i++)
                  {//Inicia ciclo for de i que recorre el vector hasta n

                    for(j=0;j<n;j++)
                    {//Inicia ciclo for de j que recorre el vector hasta n

                      if(i!=j&&i>j)
                      {//Abre if simple condicionado para ingresar al triangulo inferior de la matríz de distancias   

                         if((mat_dist_euclideas[i,j]<valor)&&(vec_dist_euclideas[q]==mat_dist_euclideas[i,j]))
                         {//if simple que compara si el valor de la matríz es más pequeño que el valor enviado inicialmente y además coincide con ser el valor cero del vector de distancias mínimas

                           valor = mat_dist_euclideas [i,j];//Asigna a valor el dato encontrado
                           dato_1 = i;//Almacena en dato_1 el valor de la observación i
                           arreglo_completo_clusters[0,0] = i;//Almacena en arreglo_clusters[0,0] el valor de la observación i
                           dato_2 = j;//Almacena en dato_2 el valor de la observación j
                           arreglo_completo_clusters[0,1] = j;//Almacena en arreglo_clusters[0,1] el valor de la observación j
                           mapa_dist_euclideas[i,j] = -1;//Marca con menos uno la coordenada de un valor empleado previamente
                                                                                             
                         }//Cierra if simple que encuentra al valor más pequeño del arreglo
                      }//Cierra if simple condicionado para ingresar al triangulo inferior
                    }//Termina ciclo for de j
                  }//Termina ciclo for de i
  
                    //Código que ubica a los dos elementos que integran al primer cluster  
                }//Cierra if simple que entra a la primer parte solo cuando q es cero
  

    valor = mat_dist_euclideas[dato_1,dato_2];//Asigna el valor de dato_1,dato_2 de la matríz de distancias euclideas como nuevo punto de partida
      for(i=0;i<n;i++){//Inicia ciclo for de i que recorre el vector hasta n
        for(j=0;j<n;j++){//Inicia ciclo for de j que recorre el vector hasta n
          if(i!=j&&i>j){//Abre if simple condicionado para ingresar al triangulo inferior de la matríz de distancias   
            if(mat_dist_euclideas[i,j]>=valor&&vec_dist_euclideas[q]==mat_dist_euclideas[i,j]&&mapa_dist_euclideas[i,j]!=-1){//if simple que compara si el valor de la matríz es más pequeño que el valor enviado inicialmente y además coincide con ser el valor cero del vector de distancias mínimas

              if(arreglo_completo_clusters[q,0]==0&&arreglo_completo_clusters[q,1]==0){//Abre if simple que evita dejar espacios en blanco en arreglo_clusters
              dato_1 = i;//Almacena en dato_1 el valor de la observación i
              arreglo_completo_clusters[q,0] = i;//Almacena en arreglo_clusters[q,0] el valor de la observación i
              dato_2 = j;//Almacena en dato_2 el valor de la observación j
              arreglo_completo_clusters[q,1] = j;//Almacena en arreglo_clusters[q,1] el valor de la observación j
              mapa_dist_euclideas[i,j] = -1;//Marca con menos uno la coordenada de un valor empleado previamente
                                                                      }//Cierra if simple que evita dejar espacios en blanco en arreglo_clusters
                                                                                                                             }//Cierra if simple condicionado para ingresar al triangulo inferior
                      }//Termina ciclo for de j
                       }//Termina ciclo for de i
                    }//Cierra if simple que entra a la primer prte solo cuando q es cero
                  }//Termina ciclo for de q


    for(i=0;i<tam_vd_min;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vd_min
      arreglo_clusters[i,0] = arreglo_completo_clusters[i,0];//Realiza el recorte de arreglo_completo_clusters en arreglo_clusters
      arreglo_clusters[i,1] = arreglo_completo_clusters[i,1];//Realiza el recorte de arreglo_completo_clusters en arreglo_clusters
                             }//Termina ciclo for de i

  tr_ar_bid_uni(tam_vde,tam_vde_lineal,arreglo_completo_clusters,arreglo_clusters_uni);//Invoca a función que transforma primeras dos columnas de arreglo de clusters en un vector unidimensional

  for(i=0;i<tam_vde_lineal;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0
    banderas_clusters_uni[i] = -1;//Inicializa al vector de banderas unidimensional en menos uno
                               }//Termina ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0
                               
 
  for(i=0;i<tam_vde_lineal;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0

      try
      {//Abre try
         pivote = arreglo_clusters_uni[i];//Toma el valor del pivote actual
      }//Cierra try  

      catch (System.IndexOutOfRangeException B)
      {//Inicia el catch para controlar excepción IndexOutOfRangeException
   
         Console.WriteLine("Informe de error en excepción B: \n" + B.Message);

      }//Cierra el catch para controlar excepción IndexOutOfRangeException

    subindice_1=i;//Inicializa el valor del primer subíndice auxiliar             

      for(j=subindice_1;j<tam_vde_lineal;j++){//Inicia ciclo for de j que recorre el vector hasta tam_vde_lineal desde j=subindice_1
        if(i!=j){//Inicia if simple que filtra los valores iguales de i e j
          if(banderas_clusters_uni[i]==-1){//Inicia if simple que verifica la aparición de un nuevo elemento 
            banderas_clusters_uni[i]++;
                                          }//Termina if simple que verifica la aparición de un nuevo elemento  


            try
            {//Abre try

               if(arreglo_clusters_uni[i]==arreglo_clusters_uni[j]&&banderas_clusters_uni[i]!=-1){//Inicia if simple que verifica la aparición de un nuevo elemento
                  banderas_clusters_uni[j] = banderas_clusters_uni[i] + 1;
                                                                                              }//Termina if simple que verifica la aparición de un nuevo elemento

            }//Cierra try  
            catch (System.IndexOutOfRangeException A)
            {//Inicia el catch para controlar excepción IndexOutOfRangeException

                Console.WriteLine("Informe de error en excepción A: \n" + A.Message);

            }//Cierra el catch para controlar excepción IndexOutOfRangeException


                }//Inicia if simple que filtra los valores iguales de i e j
                                             }//Termina  ciclo for de j que recorre el vector hasta tam_vde_lineal desde j=subindice_1
                               }//Termina ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0


  for(i=0;i<tam_vde_lineal;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0
    banderas_clusters_uni[i]++;//Inicializa al vector de banderas unidimensional en menos uno
                               }//Termina ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0

   if(banderas_clusters_uni[i-1]==0){//Inicia if simple que verifica que el pivote sea igual a uno de los elementos del sub-arreglo
      banderas_clusters_uni[i-1]++;//Realiza ajuste de banderas_cluster para valor nuevo ubicado en la última posición
                                    }//Termina if simple que verifica que el pivote sea igual a uno de los elementos del sub-arreglo
                            

   tr_ar_uni_bid(tam_vde,tam_vde_lineal,arreglo_completo_clusters,banderas_clusters_uni);//Invoca a función que transforma primeras dos columnas de arreglo de clusters en un vector unidimensional

  for(i=0;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0

    if((arreglo_completo_clusters[i,2]*arreglo_completo_clusters[i,3])==1){//Inicia if doble que evalúa si hay una doble aparición
      primer_aparicion_duplicado++; 
 
                                                                            }//Termina if doble que evalúa si hay una doble aparición 
     else{//Inicia else de if doble que evalúa si hay una doble aparición    
       if((arreglo_completo_clusters[i,2]*arreglo_completo_clusters[i,3])==arreglo_completo_clusters[i,2]){//Inicia if doble que evalúa si hay una primer aparición en arreglo_completo_clusters[i,3]
         primer_aparicion++;//Incrementa el contador de primeras apariciones                                                                                                             
                                                                                                             }//Termina if doble que evalúa si hay una primer aparición en arreglo_completo_clusters[i,3]
       else{//Inicia else de if doble que evalúa si hay una primer aparición en arreglo_completo_clusters[i,3]
         if((arreglo_completo_clusters[i,2]*arreglo_completo_clusters[i,3])==arreglo_completo_clusters[i,3]){//Inicia if simple que evalúa si hay una primer aparición en arreglo_completo_clusters[i,2]
           primer_aparicion++;//Incrementa el contador de primeras apariciones                                                                                                             
                                                                                                               }//Termina if simple que evalúa si hay una primer aparición en arreglo_completo_clusters[i,2]
           }//Termina else de if doble que evalúa si hay una primer aparición en arreglo_completo_clusters[i,3]
         }//Termina else de if doble que evalúa si hay una doble aparición                                                                                                       
                        }//Termina ciclo for de i que recorre el vector hasta tam_vde_lineal desde i=0

  total_apariciones = primer_aparicion + primer_aparicion_duplicado;//Calcula la cantidad total de apariciones 
  no_primer_aparicion = tam_vde - total_apariciones;//Calcula la cantidad de no apariciones 

//Declara el arreglo de datos banderas_primeras_apariciones que..., además lo inicializa en cero 
 int[,] banderas_primeras_apariciones = { { 0, 0 } };            
//Dimensiona el tamaño del arreglo bidimensional banderas_primeras_apariciones
 banderas_primeras_apariciones = new int[total_apariciones, 2];
             
 //Declara el arreglo de datos banderas_no_primeras_apariciones que..., además lo inicializa en cero 
 int[,] banderas_no_primeras_apariciones = { { 0, 0 } };            
 //Dimensiona el tamaño del arreglo bidimensional banderas_no_primeras_apariciones
 banderas_no_primeras_apariciones = new int[no_primer_aparicion, 2];

 for (i = 0; i < total_apariciones; i++)
 {//Inicia ciclo for de i que recorre el vector hasta primer_aparicion
     for (j = 0; j < 2; j++)
     {//Inicia ciclo for de j que recorre el vector hasta 2
         try
         {//Abre try
             banderas_primeras_apariciones[i, j] = -1;//Inicializa el arreglo cluster_primeras_apariciones en - 1
         }//Cierra try  

         catch (System.IndexOutOfRangeException C)
         {//Inicia el catch para controlar excepción IndexOutOfRangeException

             Console.WriteLine("Informe de error en excepción C: \n" + C.Message);

         }//Cierra el catch para controlar excepción IndexOutOfRangeException

     }//Termina ciclo for de j que recorre el vector hasta 2
 }//Termina ciclo for de i que recorre el vector hasta primer_aparicion

  for(i=0;i<no_primer_aparicion;i++)//Inicia ciclo for de i que recorre el vector hasta no_primer_aparicion
    for(j=0;j<2;j++)//Inicia ciclo for de j que recorre el vector hasta 2
        banderas_no_primeras_apariciones[i,j] = - 1;//Inicializa el arreglo banderas_no_primeras_apariciones en - 1


  cont = 0;//Inicia el contador en cero
 
 
  for(i=0;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0
     try
     {//Abre try
         if(arreglo_completo_clusters[i,2]==1||arreglo_completo_clusters[i,3]==1){//Inicia if simple que evalúa si se encontro un uno en la tercer o cuarta columna de arreglo_completo_clusters
            banderas_primeras_apariciones[cont,0] = arreglo_completo_clusters[i,0];//Asigna valores
            banderas_primeras_apariciones[cont,1] = arreglo_completo_clusters[i,1];//Asigna valores
            cont++;//Incrementa el contador
                                                                                 }//Termina if simple que evalúa si se encontro un uno en la tercer o cuarta columna de arreglo_completo_clusters
     }//Cierra try  

     catch (System.IndexOutOfRangeException D)
     {//Inicia el catch para controlar excepción IndexOutOfRangeException
    
         Console.WriteLine("Informe de error en excepción D: \n" + D.Message);

     }//Cierra el catch para controlar excepción IndexOutOfRangeException
                        }//Termina ciclo for de i que recorre el vector hasta tam_vde desde i=0


  cont = 0;//Reinicia el contador en cero
  
    for(i=0;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0
        try
        {//Abre try
          if(arreglo_completo_clusters[i,2]!=1&&arreglo_completo_clusters[i,3]!=1){//Inicia if simple que evalúa si no hay un uno en la tercera y cuarta columna de arreglo_completo_clusters
             banderas_no_primeras_apariciones[cont,0] = arreglo_completo_clusters[i,0];//Asigna valores
             banderas_no_primeras_apariciones[cont,1] = arreglo_completo_clusters[i,1];//Asigna valores
             cont++;//Incrementa el contador
                                                                                  }//Termina if simple que evalúa si no hay un uno en la tercera y cuarta columna de arreglo_completo_clusters
        }//Cierra try  

        catch(System.IndexOutOfRangeException E)
        {//Inicia el catch para controlar excepción IndexOutOfRangeException
           //System.Console.WriteLine(E.Message);
           //System.Diagnostics.Process.Start(@"C:\Users\usuario\Desktop\E.exe");
           Console.WriteLine("Informe de error en excepción E: \n" + E.Message);

        }//Cierra el catch para controlar excepción IndexOutOfRangeException

                          }//Termina ciclo for de i que recorre el vector hasta tam_vde desde i=0

 //Declara el arreglo de arreglo_temp_clusters 
 int[,] arreglo_temp_clusters;            
 //Dimensiona el tamaño del arreglo bidimensional arreglo_temp_clusters
 arreglo_temp_clusters = new int[tam_vde,4];


 for (i = 0; i < tam_vde; i++)//Inicia ciclo for de i que recorre el vector hasta tam_vd_min
     for (j = 0; j < 4; j++)//Inicia ciclo for de j que recorre el vector hasta 2
         arreglo_temp_clusters[i, j] = 0;//Inicializa el arreglo temporal de clusters en cero

    for(i=0;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0
      for(j=0;j<4;j++){//Inicia ciclo for de j que recorre el vector hasta 4 desde j=0

            arreglo_temp_clusters[i,j] = arreglo_completo_clusters[i,j];//Copia en arreglo_temp_clusters los valores respectivos de arreglo_completo_clusters      

                      }//Termina ciclo for de j que recorre el vector hasta 4 desde j=0
                          }//Termina ciclo for de i que recorre el vector hasta tam_vde desde i=0
    
    
    for (i = 0; i < total_apariciones; i++)
    {//Inicia ciclo for de i que recorre el vector hasta total_apariciones desde i=0

        arreglo_temp_clusters[i,0] = banderas_primeras_apariciones[i,0];//Copia el valor de un arreglo a otro
        arreglo_temp_clusters[i,1] = banderas_primeras_apariciones[i,1];//Copia el valor de un arreglo a otro
        arreglo_temp_clusters[i,2] = arreglo_completo_clusters[i,2];//Copia el valor de un arreglo a otro
        arreglo_temp_clusters[i,3] = arreglo_completo_clusters[i,3];//Copia el valor de un arreglo a otro
                            
    }//Termina ciclo for de i que recorre el vector hasta total_apariciones desde i=0 

    for(i=total_apariciones;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=total_apariciones
      arreglo_temp_clusters[i,0] = banderas_no_primeras_apariciones[i - total_apariciones,0];//Copia el valor de un arreglo a otro
      arreglo_temp_clusters[i,1] = banderas_no_primeras_apariciones[i - total_apariciones,1];//Copia el valor de un arreglo a otro
      arreglo_temp_clusters[i,2] = arreglo_completo_clusters[i - total_apariciones,2];//Copia el valor de un arreglo a otro
      arreglo_temp_clusters[i,3] = arreglo_completo_clusters[i - total_apariciones,3];//Copia el valor de un arreglo a otro
                                          }//Termina ciclo for de i que recorre el vector hasta tam_vde desde i=total_apariciones 

    for(i=0;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0
        for(j=0;j<4;j++){//Inicia ciclo for de j que recorre el vector hasta 4 desde j=0
               arreglo_completo_clusters[i,j] = arreglo_temp_clusters[i,j];//Copia en arreglo_completo_clusters los valores respectivos de arreglo_temp_clusters      
                        }//Termina ciclo for de j que recorre el vector hasta 4 desde j=0
                          }//Termina ciclo for de i que recorre el vector hasta tam_vde desde i=0


  muuk_5(tam_vde,n,arreglo_completo_clusters,mat_dist_euclideas,vec_dist_euclideas);//Invoca a función que ajusta vec_dist_euclideas con los datos del cluster final, almacenados en arreglo_completo_clusters 

  
    for(i=0;i<tam_vd_min;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vd_min desde i=0

      vec_dist_minimas[i] = vec_dist_euclideas[i];//Realiza el recorte del vec_dist_euclideas en vec_dist_minimas

        for(j=0;j<2;j++){//Inicia ciclo for de j que recorre el vector hasta 2 desde j=0
    
                arreglo_clusters[i,j] = arreglo_completo_clusters[i,j];//Realiza el recorte del arreglo_completo_clusters[i,j] en arreglo_clusters[i,j]
            
                        }//Termina ciclo for de j que recorre el vector hasta 2 desde j=0
                             }//Termina ciclo for de i que recorre el vector hasta tam_vd_min desde i=0


          }//Termina método que genera el arreglo con los clusters


          public static void tr_ar_bid_uni(int tam_vde, int tam_vde_lineal, int[,] arreglo_temp_bid, int[] arreglo_temp_uni)
          {//Inicia método que transforma el arreglo bidimensional en unidimensional

             int i,j; //subíndices de renglones y columnas


             for(i=0;i<tam_vde;i++)//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0
                 for (j = 0; j < 2; j++)
                 {//Inicia ciclo for de j que recorre el vector hasta 2 desde j=0

                     try
                     {//Abre try
                         arreglo_temp_uni[2 * i + j] = arreglo_temp_bid[i, j];
                     }//Cierra try  

                     catch (System.IndexOutOfRangeException eQ)
                     {//Inicia el catch para controlar excepción IndexOutOfRangeException
                         //System.Console.WriteLine(eQ.Message);
                         //System.Diagnostics.Process.Start(@"C:\Users\usuario\Desktop\eQ.exe");
                         Console.WriteLine("Informe de error en excepción eQ: \n" + eQ.Message);
                     }//Cierra el catch para controlar excepción IndexOutOfRangeException

                 }//Termina ciclo for de j que recorre el vector hasta 2 desde j=0


          }//Termina método que transforma el arreglo bidimensional en unidimensional


          public static void tr_ar_uni_bid(int tam_vde,int tam_vde_lineal,int[,] arreglo_bid_temp,int[] arreglo_uni_temp)
          {//Inicia método que transforma el arreglo unidimensional en bidimensional
 
             int i,j; //subíndices de renglones y columnas



             for(i=0;i<tam_vde;i++)//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0
                 for (j = 0; j < 2; j++)
                 {//Inicia ciclo for de j que recorre el vector hasta 2 desde j=0


                     try
                     {//Abre try
                         arreglo_bid_temp[i, j + 2] = arreglo_uni_temp[2 * i + j];
                     }//Cierra try  

                     catch (System.IndexOutOfRangeException eP)
                     {//Inicia el catch para controlar excepción IndexOutOfRangeException
                         //MessageBox.Show("Informe de error: \n" + eP.Message);
                         //System.Diagnostics.Process.Start(@"C:\Users\usuario\Desktop\eP.exe");
                         Console.WriteLine("Informe de error en excepción eP: \n" + eP.Message);
                     }//Cierra el catch para controlar excepción IndexOutOfRangeException


                 }//Termina ciclo for de j que recorre el vector hasta 2 desde j=0

          }//Termina método que transforma el arreglo unidimensional en bidimensional


          public static void muuk_5(int tam_vde, int n, int[,] arreglo_completo_clusters_temp, double[,] mat_dist_euclideas_temp, double[] vec_dist_euclideas_temp)
          {//Inicia método que ajusta vec_dist_euclideas con los datos del cluster final, almacenados en arreglo_completo_clusters


             int i;//Subíndice local de renglones 
    
               for(i=0;i<tam_vde;i++){//Inicia ciclo for de i que recorre el vector hasta tam_vde desde i=0

                   try
                   {//Abre try
                       vec_dist_euclideas_temp[i] = mat_dist_euclideas_temp[arreglo_completo_clusters_temp[i, 0], arreglo_completo_clusters_temp[i, 1]];//Copia el valor de un arreglo a otro
                   }//Cierra try  

                   catch (System.IndexOutOfRangeException eA)
                   {//Inicia el catch para controlar excepción IndexOutOfRangeException
                       Console.WriteLine("Informe de error en excepción eA: \n" + eA.Message);
                   }//Cierra el catch para controlar excepción IndexOutOfRangeException

                                     }//Termina ciclo for de i que recorre el vector hasta tam_vde desde i=0

          }//Fin método que ajusta vec_dist_euclideas con los datos del cluster final, almacenados en arreglo_completo_clusters



  
          
          public static string imprime_clusters(int a, int b,int[,] arreglo_clusters,double[] vec_dist_minimas,string[] Auni_nombres)
          {//Inicia método que imprime los clusters 


  int contador;//Declara variable de tipo contador 
  int k,j;//Declara subíndices para contar repeticiones de conglomerados
  int i;//subíndices de renglones
  int max = a;//Contador inicializado en a que decrementará hasta el valor uno para indicar la integración total de los elementos
  string sClusterEnCadena = "";//Texto que almacenará la información del cluster final
  string status_cluster_inicial ="Primer conglomerado";//Texto de status del cluster
  string status_cluster_nuevo = "Nuevo conglomerado";//Texto de status del cluster
  string status_cluster_agregado = "Agregado a existente";//Texto de status del cluster
  string status_cluster_final = "Integración concluida";//Texto de status del cluster
  string sEnter = "\n";
  string s1 = "";
  string s2 = "";
  string s3 = "";
  string s4 = "";
  string s5 = "";
  string sTemp = "";

  s1 = "\nNo. de\tPar de \t\t\t\t\tSimilitud o\t   No. de \n";//Imprime el nombre de la observación respectiva
              

  s2 = "Etapa\t   Observaciones\t\tStatus\t\tDistancia\t   Conglomerados\n";//Imprime el nombre de la observación respectiva
             


    for(i=0;i<a;i++){//Inicia ciclo for de los renglones


    if(i==0)//if simple que imprime el aviso del primer conglomerado
       s3 = Convert.ToString(i + 1) + "\t\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 0]]) + "\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 1]]) + "\t" + status_cluster_inicial + "\t" + Convert.ToString(Math.Round(vec_dist_minimas[i], 4)) + "\t   " + Convert.ToString(max) + "\n";

    if(i>0&&i<a-1){//if simple para evaluar si es un nuevo conglomerado o se agrega a un existente
      contador = 0;//Inicializa el contador en cero
        for(j=0;j<i;j++){
          for(k=0;k<i;k++)
            if(arreglo_clusters[i,0]==arreglo_clusters[j,0]||arreglo_clusters[i,1]==arreglo_clusters[j,1]||arreglo_clusters[i,0]==arreglo_clusters[j,1]||arreglo_clusters[i,1]==arreglo_clusters[j,0]||arreglo_clusters[i,0]==arreglo_clusters[j,1])//Condición que evalúa si existe una repetición entre valores previos
              contador++;//Incrementa el contador de repeticiones
                        }
    if(contador>=1)//if doble que imprime si se trata de un nuevo conglomerado o de una adición a uno existente   
        sTemp = Convert.ToString(i + 1) + "\t\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 0]]) + "\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 1]]) + "\t" + status_cluster_agregado + "\t" + Convert.ToString(Math.Round(vec_dist_minimas[i], 4)) + "\t   " + Convert.ToString(max) + "\n";
    else//Sino del if doble
        sTemp = Convert.ToString(i + 1) + "\t\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 0]]) + "\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 1]]) + "\t" + status_cluster_nuevo + "\t" + Convert.ToString(Math.Round(vec_dist_minimas[i], 4)) + "\t   " + Convert.ToString(max) + "\n";

    s4 = s4 + sTemp;
              }//Cierra if simple para evaluar si es un nuevo conglomerado o se agrega a un existente

    if(i==a-1)//if simple que imprime el aviso de la integracion concluida
          s5 = Convert.ToString(i + 1) + "\t\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 0]]) + "\t" + Convert.ToString(Auni_nombres[arreglo_clusters[i, 1]]) + "\t" + status_cluster_final + "\t" + Convert.ToString(Math.Round(vec_dist_minimas[i], 4)) + "\t   " + Convert.ToString(max) + "\n";
          max--;//Decrementa el contador de clusters o conglomerados
                    }//Termina ciclo for de los renglones
  

  //Genera la cadena de texto final del cluster
  sClusterEnCadena = s1 + s2 + s3 + s4 + s5 + sEnter + sEnter;

          //Devuelve la cadena de texto final
  return sClusterEnCadena;   
                                                                                        
          }//Termina método que imprime los clusters




          public static string calc_distancias_repetidas(int m,double[] vec_dist_minimas)
          {//Inicia método que cálcula las distancias repetidas en el cluster

              //Declara las cadenas dónde se almacenará la información de los clusters
              string sDistanciasRepetidas ="";
              string s1 = "";
              string s2 = "";
              string sTemp = "";
              string sEnter = "\n";

  int i;//Subíndice local
  int cont = 0;//Declara e inicializa contador para cantidad de empates o valores repetidos en emp_acum_dist


             //Declara el arreglo de datos emp_dist que almacenará los empates entre las distancias, además lo inicializa en cero
            int[] emp_dist = { 0 };

            //Redimensiona el arreglo a su tamaño definitivo
            emp_dist = new int[m];
              
             //Declara el arreglo de datos emp_acum_dist que almacenará los empates acumulados entre las distancias, además lo inicializa en cero
            int[] emp_acum_dist = { 0 };

            //Redimensiona el arreglo a su tamaño definitivo
            emp_acum_dist = new int[m];//Declara el arreglo emp_acum que contara cuantas repeticiones tiene un empate

  int acum = 0;//Declara e inicializa el acumulador del total de valores repetidos

    for(i=0;i<m;i++){//for de i que recorre todos los valores hasta m
      emp_dist[i]=0;//Inicializa los valores del arreglo de banderas de empates de distancias emp_dist
      emp_acum_dist[i]=0;//Inicializa los valores del arreglo de acumuladores de empates de distancias emp_acum_dist
                    }//Cierra for de i que inicializa los dos arreglos

    for(i=0;i<m;i++){//Abre ciclo for de i que recorre todos los valores hasta m

        try
        {//Abre try
           if(vec_dist_minimas[i]==vec_dist_minimas[i+1])//Condición que verifica valores repetidos
              emp_dist[i]=1;//Levanta la bandera del arreglo emp_dist cuando encuentra un empate o valores repetidos entre distancias 
        }//Cierra try  

        catch (System.IndexOutOfRangeException e1)
        {//Inicia el catch para controlar excepción IndexOutOfRangeException

           Console.WriteLine("Informe de error en excepción e1: \n" + e1.Message);

        }//Cierra el catch para controlar excepción IndexOutOfRangeException

                    }//Cierra ciclo for de i que recorre todos los valores hasta m

    for(i=0;i<m;i++){//Abre ciclo for de j que recorre todos los valores hasta m
      if(emp_dist[i]!=0){//Condición que verifica los empates o valores repetidos
        cont++;//Incrementa el contador de empates o valores repetidos
        emp_acum_dist[i]=cont;//Levanta la bandera del arreglo emp cuando encuentra un empate o valor repetido       
                        }//Cierra if
      else//Sino
         cont=0;//Resetea el contador cuando no hay empates o valores repetidos
                    }//Cierra ciclo for de j que recorre todos los valores hasta m



  for(i=0;i<m;i++){//Abre ciclo for de i que recorre todos los valores hasta m
    if(emp_acum_dist[i]!=0&&emp_acum_dist[i+1]==0){//if simple con condición que verifica valores repetidos
        sTemp = "Valor de distancia o similitud " + Convert.ToString(Math.Round(vec_dist_minimas[i], 4)) + " repetido en " + Convert.ToString(emp_acum_dist[i] + 1) + " ocasiones. \n";
        acum = acum + emp_acum_dist[i]+1;//Acumula la cantidad total de valores repetidos
        s1 = s1 + sTemp;
                                                  }//Cierra if simple con condición que verifica valores repetidos
      
                  }//Cierra ciclo for de i que recorre todos los valores hasta m

  if(acum!=0)//Condición que verifica el acumulador distinto de cero
   // printf("En total hay %d valores de distancia o similitud repetidos \n",acum);//Texto
      s2 = "En total hay " + Convert.ToString(acum) + " valores de distancia o similitud repetidos. \n";
 

     sDistanciasRepetidas = sEnter + s1 + s2;
     return sDistanciasRepetidas;
  
        }//Termina método que cálcula las distancias repetidas en el cluster


          
  public static string calc_no_eslabonadas(int m,int n,int[,] arreglo_clusters_estandar,string[] Auni_nombres)
  {//Inicia método que cálcula las distancias no eslabonadas

  string sNoEslabonadas = "";
  string sTemp1 = "";
  string sTemp2 = "";
  int i,j;//Subíndices locales

  //Declara el arreglo de datos mapa_nombres que almacenará las letras de los nombres, además lo inicializa en cero
  int[] mapa_nombres = { 0 };

  //Redimensiona el arreglo a su tamaño definitivo
  mapa_nombres = new int[n];                      

  //Declara el arreglo de datos subindices_nombres que almacenará los subíndices de los nombres, además lo inicializa en cero
  int[] subindices_nombres = { 0 };

  //Redimensiona el arreglo a su tamaño definitivo
  subindices_nombres = new int[n];                      

  for(i=0;i<n;i++){//for de i que recorre todos los valores hasta n
    mapa_nombres[i]=0;//Inicializa los valores del arreglo mapa_nombres
    subindices_nombres[i]=i;//Inicializa los valores del arreglo subindices_nombres
  }//Cierra for de i que inicializa el arreglo

  //Código para validar la columna cero de arreglo_clusters
  for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
    for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
      try
      {//Abre try
        if(arreglo_clusters_estandar[j,0]==subindices_nombres[i])//Condición que verifica valores iguales en arreglo_clusters_estandar[j,0] con subindices_nombres[i]
          mapa_nombres[i]=1;//Levanta la bandera del arreglo mapa_nombres[i] cuando encuentra un empate o valor repetido
      }//Cierra try  

      catch (System.IndexOutOfRangeException eS)
      {//Inicia el catch para controlar excepción IndexOutOfRangeException
        Console.WriteLine("Informe de error en excepción eS: \n" + eS.Message);
      }//Cierra el catch para controlar excepción IndexOutOfRangeException
    }//Cierra ciclo for de j que recorre todos los valores hasta m
  }//Cierra ciclo for de i que recorre todos los valores hasta n

  //Código para validar la columna uno de arreglo_clusters
  for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
    for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
      try
      {//Abre try
        if(arreglo_clusters_estandar[j,1]==subindices_nombres[i])//Condición que verifica valores iguales en arreglo_clusters_estandar[j,1] con subindices_nombres[i]
          mapa_nombres[i]=1;//Levanta la bandera del arreglo mapa_nombres[i] cuando encuentra un empate o valor repetido
      }//Cierra try            
      
      catch (System.IndexOutOfRangeException eD)
      {//Inicia el catch para controlar excepción IndexOutOfRangeException
        //System.Console.WriteLine(eD.Message);
        //System.Diagnostics.Process.Start(@"C:\Users\usuario\Desktop\eD.exe");
        Console.WriteLine("Informe de error en excepción eD: \n" + eD.Message);
      }//Cierra el catch para controlar excepción IndexOutOfRangeException 
    }//Cierra ciclo for de j que recorre todos los valores hasta m
  }//Cierra ciclo for de i que recorre todos los valores hasta n

  for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
    try
    {//Abre try
      if(mapa_nombres[i]==0){//Condición que verifica si una observación no se pudo eslabonar
        //printf("La observacion ");//Impresión de prueba
        sTemp1 = "La observación ";
        //for(j=0;Auni_nombres[i,j]!='\0';j++)
        //for (j = 0; Auni_nombres[j] != null; j++)
        if(Auni_nombres[i] != null)
        {
        //putchar(Auni_nombres[i, j]);
        //printf(" no se pudo eslabonar \n");//Impresión de prueba      
          sTemp2 = Convert.ToString(Auni_nombres[i]) + " no se pudo eslabonar. \n";     
        }
      }//Cierra if simple que verifica si una observación no se pudo eslabonar

      sNoEslabonadas = sTemp1 + sTemp2;
    }//Cierra try            
      
    catch (System.IndexOutOfRangeException eF)
    {//Inicia el catch para controlar excepción IndexOutOfRangeException
      //System.Console.WriteLine(eF.Message);
      //System.Diagnostics.Process.Start(@"C:\Users\usuario\Desktop\eF.exe");
      Console.WriteLine("Informe de error en excepción eF: \n" + eF.Message);

    }//Cierra el catch para controlar excepción IndexOutOfRangeException
  }//Cierra ciclo for de i que recorre todos los valores hasta n

  return sNoEslabonadas;
  }//Termina método que cálcula las distancias no eslabonadas     
}//Cierra la clase que contiene a los métodos que cálculan diversos parámetros de los clusters