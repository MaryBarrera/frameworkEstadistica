using System;
 public class inversa_JW
      {//Abre la clase que calcula la inversa de una matríz bidimensional y sus métodos auxiliares

          public static void calcInversa(int n, double[,] Mbid, double[,] Mbid_inversa)
          {//Inicia el método que calcula la inversa de una matríz
              int i,j;//Declara subíndices locales

              //Declara arreglo_temporal de tamaño n,n y lo inicializa en cero 
              double[,] arreglo_temporal = { { 0, 0 } };
              //Redimensiona el arreglo a su tamaño definitivo
             arreglo_temporal = new double[n, n];

             double tolerancia_positiva = 0.0000001;//Declara el valor de la tolerancia positiva para la bandera
             double tolerancia_negativa = -0.0000001;//Declara el valor de la tolerancia negativa para la bandera
             double valor_de_pivote;//Declara la variable del valor del pivote para realizar el procedimiento de inversión
             double primer_valor = 0;//Declara e inicializa la variable del primer valor que servira para realizar operaciones sobre Mbid únicamente
             double segundo_valor = 0;//Declara e inicializa la variable del segundo valor que servira para realizar operaciones sobre Mbid_inversa únicamente
             int bandera;//Declara la variable de la bandera
             int columna;//Declara la variable para almacenar el valor de la columna
             int temp;//Declara la variabñe del valor temporal para almacenar datos
  
             almacena_en_arreglo_temporal(n,Mbid,arreglo_temporal);//Invoca a función que guarda en arreglo_temporal los valores de Mbid
             inicializa_identidad(n,Mbid_inversa);//Invoca a función que inicializa Mbid_inversa como la matríz identidad

               for(columna=0;columna<n;columna++){//for que recorre las columnas desde cero hasta n
                 bandera=0;//Guarda cero en la bandera
                 temp=columna;//Guarda en temp el valor de la columna
                   while(bandera==0){//Abre ciclo while que evalúa si bandera este en valor cero

                     try
                     {//Abre try
                       if((Mbid[temp,columna]>tolerancia_positiva)||(Mbid[temp,columna]<tolerancia_negativa))//Abre selección if-else que evalúa el valor del arreglo Mbid con las tolerancias positivas y negativas 
                         bandera=1;//Guarda uno en la bandera        
                       else//Sino
                           temp++;//Incrementa la variable temporal
                     }//Cierra try
            
                     catch (System.IndexOutOfRangeException e1)
                     {//Inicia el catch para controlar excepción IndexOutOfRangeException
                       System.Console.WriteLine(e1.Message);
                     }//Cierra el catch para controlar excepción IndexOutOfRangeException                  
                                  
                                    }//Cierra ciclo while
       
                 valor_de_pivote=Mbid[temp,columna];//Asigna valor del pivote

               for(i=0;i<n;i++){//for de i que recorre todos los valores hasta n
                 primer_valor=Mbid[temp,i];//Asigna el valor de Mbid[temp][i] en la variable que almacena el primer valor
                 Mbid[temp,i]=Mbid[columna,i];//Asigna a Mbid[temp][i] el valor de Mbid[columna][i]
                 Mbid[columna,i]=primer_valor/valor_de_pivote;//Almacena en Mbid_inversa[columna][i] el resultado de dividir el segundo valor con el valor del pivote
                 segundo_valor=Mbid_inversa[temp,i];//Asigna el valor de Mbid_inversa[temp][i] en la variable que almacena el segundo valor
                 Mbid_inversa[temp,i]=Mbid_inversa[columna,i];//Asigna a Mbid_inversa[temp][i] el valor de Mbid_inversa[columna][i]
                 Mbid_inversa[columna,i]=segundo_valor/valor_de_pivote;//Almacena en Mbid_inversa[columna][i] el resultado de dividir el segundo valor con el valor del pivote
                               }//Cierra ciclo for de i que recorre todos los valores hasta n

  
               for(j=columna+1;j<=n;j++){//for de j que inicia en columna+1 y recorre los valores hasta n
              
                 try
                 {//Abre try
                   primer_valor=Mbid[j,columna];//Asigna a primer_valor el valor de Mbid[j][columna]
                 }//Cierra try

                 catch (System.IndexOutOfRangeException e1)
                 {//Inicia el catch para controlar excepción IndexOutOfRangeException
                   System.Console.WriteLine(e1.Message);
                 }//Cierra el catch para controlar excepción IndexOutOfRangeException

                   
                   for(i=0;i<n;i++){//for de i que recorre todos los valores hasta n
                    
                     try
                     {//Abre try
                       Mbid[j,i]=Mbid[j,i]-primer_valor*Mbid[columna,i];//Calcula el nuevo valor de Mbid[j][i]              
                     }//Cierra try

                     catch (System.IndexOutOfRangeException e2)
                     {//Inicia el catch para controlar excepción IndexOutOfRangeException
                       System.Console.WriteLine(e2.Message);
                     }//Cierra el catch para controlar excepción IndexOutOfRangeException

                     try
                     {//Abre try
                       Mbid_inversa[j,i]=Mbid_inversa[j,i]-primer_valor*Mbid_inversa[columna,i];//Calcula el nuevo valor de Mbid_inversa[j][i]
                     }//Cierra try  

                     catch (System.IndexOutOfRangeException e3)
                     {//Inicia el catch para controlar excepción IndexOutOfRangeException
                       System.Console.WriteLine(e3.Message);
                     }//Cierra el catch para controlar excepción IndexOutOfRangeException
                 
                   
                   
                   }//Cierra ciclo for de i que recorre todos los valores hasta n
                                        }//Termina for de j que inicia en columna+1 y recorre los valores hasta n
                                                 }//fin del for inicial que recorre todas las columnas

               for(columna=n;columna>=1;columna--)//for de columna que inicia en n y decrementa hasta >=1
                 for(i=(columna-1);i>=0;i--){//for de i que inicia en columna-1 y decrementa hasta >=0

                       try
                       {//Abre try
                         primer_valor=Mbid[i,columna];//Asigna a primer_valor el valor de Mbid[i][columna] 
                       }//Cierra try

                       catch (System.IndexOutOfRangeException e4)
                       {//Inicia el catch para controlar excepción IndexOutOfRangeException
                           System.Console.WriteLine(e4.Message);
                       }//Cierra el catch para controlar excepción IndexOutOfRangeException

                     for(j=0;j<n;j++){//for de j que recorre todos los valores hasta n

                       try
                       {//Abre try
                         Mbid[i,j]=Mbid[i,j]-primer_valor*Mbid[columna,j];//Asigna el nuevo valor de Mbid[i][j] 
                       }//Cierra try  
      
                       catch (System.IndexOutOfRangeException e5)
                       {//Inicia el catch para controlar excepción IndexOutOfRangeException
                         System.Console.WriteLine(e5.Message);
                       }//Cierra el catch para controlar excepción IndexOutOfRangeException


                       try
                       {//Abre try
                         Mbid_inversa[i,j]=Mbid_inversa[i,j]-primer_valor*Mbid_inversa[columna,j];//Asigna el nuevo valor de Mbid_inversa[i][j] 
                        }//Cierra try  

                       catch (System.IndexOutOfRangeException e6)
                       {//Inicia el catch para controlar excepción IndexOutOfRangeException
                         System.Console.WriteLine(e6.Message);
                       }//Cierra el catch para controlar excepción IndexOutOfRangeException
                 
                                     }//Termina for de j
                                             }//Termina for de i que inicia en columna-1 y decrementa hasta >=0
                                                    
             devuelve_a_arreglo(n,Mbid,arreglo_temporal);//Invoca a función que devuelve a Mbid sus valores originales

           }//Termina el método que calcula la inversa de una matríz


          public static void inicializa_identidad(int n, double[,] Mbid_inversa)
          {//Inicia método que inicializa M_bid_inversa como matriz identidad
            int i,j;//Declara subíndices locales
              for(i=0;i<n;i++)//for de i que recorre todos los valores hasta n que son los renglones
                for(j=0;j<n;j++)//for de j que recorre todos los valores hasta n que son las columnas
                  if(i==j)//if-else que evalua si el subíndice de las columnas es igual al de los renglones
                    Mbid_inversa[i,j]=1;//En los valores de la diagonal principal escribe 1
                  else//Sino de if doble
                    Mbid_inversa[i,j]=0;//En los valores encima y debajo de la diagonal principal escribe 0
          }//Termina método que inicializa M_bid_inversa como matriz identidad

          public static void almacena_en_arreglo_temporal(int n, double[,] Mbid, double[,] arreglo_temporal)
          {//Inicia método que guarda en arreglo_temporal los valores de Mbid
            int i,j;//Declara subíndices locales
              for(i=0;i<n;i++)//for de i que recorre todos los valores hasta n que son los renglones
                for(j=0;j<n;j++)//for de j que recorre todos los valores hasta n que son las columnas
                   arreglo_temporal[i,j]=Mbid[i,j];//Copia en arreglo_temporal[i][j] los valores de Mbid[i][j]
          }//Termina método que guarda en arreglo_temporal los valores de Mbid


          public static void devuelve_a_arreglo(int n, double[,] Mbid, double[,] arreglo_temporal)
          {//Inicia método que guarda en arreglo_temporal los valores de Mbid
            int i,j;//Declara subíndices locales
              for(i=0;i<n;i++)//for de i que recorre todos los valores hasta n que son los renglones
                for(j=0;j<n;j++)//for de j que recorre todos los valores hasta n que son las columnas
                  Mbid[i,j]=arreglo_temporal[i,j];//Copia en Mbid[i][j] los valores de arreglo_temporal[i][j]
          }//Termina  método que guarda en arreglo_temporal los valores de Mbid


      }//Cierra la clase que calcula la inversa de una matríz bidimensional y sus métodos auxiliares
