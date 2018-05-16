//ESPAÑOL: la clase que contiene a los métodos para cálculo del coeficiente relacional de Spearman o Rho
//ENGLISH: the class content the methods to calculate Spearman or Rho correlation coefficient

using System;
 
public class spearman_rho_JW
{

  public static double calc_spearman_rho(int n, int col, double[,] datos)
  {//Inicia método que cálcula el coeficiente relacional de Spearman o Rho
      
      int i;//Subíndice local para asignar valores en arreglo rango_x
      double r;//Declara variable que almacenará el valor final de rho
      double acum;//Declara el acumulador que guardará la sumatoria del cuadrado de las diferencias

      double[,] copia_x;//Declara arreglo copia_x donde guardará los valores de la variable y ordenará posteriormente
      copia_x = new double[n, 2];//Asigna tamaño a copia_x

      double[,] copia_y;//Declara arreglo copia_y donde guardará los valores de la variable y ordenará posteriormente
      copia_y = new double[n, 2];//Asigna tamaño a copia_y

      double[,] concentrado_rho;//Declara arreglo copia_y donde guardará los valores de la variable y ordenará posteriormente
      concentrado_rho = new double[n, 5];//Asigna tamaño a concentrado_rho

      double[] vector_temp_A;//Declara arreglo temporal A para invertir los valores de copia_x y copia_y
      vector_temp_A = new double[n];//Asigna tamaño a vector_temp_A

      double[] vector_temp_B;//Declara arreglo temporal B para invertir los valores de copia_x y copia_y
      vector_temp_B = new double[n];//Asigna tamaño a vector_temp_B


      for(i=0;i<n;i++) {//Abre ciclo for
         copia_x[i,0]=datos[i,0];//Copia los datos originales de x en copia_x
         copia_x[i,1]=i;//Genera el subíndice i del arreglo copia_x           

         copia_y[i,0]=datos[i,1];//Copia los datos originales de y en copia_y
         copia_y[i,1]=i;//Genera el subíndice i del arreglo copia_y            
      }//Cierra el for


      detecta_rangos_x(n,2,copia_x);//Función que cálcula los rangos de la variable x en estudio

      detecta_rangos_y(n,2,copia_y);//Función que cálcula los rangos de la variable y en estudio

      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
         vector_temp_A[i] = copia_x[i,0];//Toma los valores de copia_x[i][0] y los guarda en el vector temporal A
         vector_temp_B[i] = copia_x[i,1];//Toma los valores de copia_x[i][1] y los guarda en el vector temporal B    
      }//Cierra el for

      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
       copia_x[i,0] = vector_temp_B[i];//Realiza el intercambio de copia_x[i][0] con el vector temporal B
       copia_x[i,1] = vector_temp_A[i];//Realiza el intercambio de copia_x[i][1] con el vector temporal A    
      }//Cierra el for

      //Función ordena_qs_bid invoca a ordenamiento rápido de copia_x a partir del subíndice i
      ordenaBidimensional_JW.ordena_qs_bid(n, 2, copia_x);

      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
         vector_temp_A[i] = copia_y[i,0];//Toma los valores de copia_y[i][0] y los guarda en el vector temporal A
         vector_temp_B[i] = copia_y[i,1];//Toma los valores de copia_y[i][1] y los guarda en el vector temporal B    
      }//Cierra el for

      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
         copia_y[i,0] = vector_temp_B[i];//Realiza el intercambio de copia_y[i][0] con el vector temporal B
         copia_y[i,1] = vector_temp_A[i];//Realiza el intercambio de copia_y[i][0] con el vector temporal A    
      }//Cierra el for

      //Función ordena_qs_bid invoca a ordenamiento rápido de copia_y a partir del subíndice i
      ordenaBidimensional_JW.ordena_qs_bid(n, 2, copia_y);

      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
         concentrado_rho[i,0]=i;//Guarda en la columna cero de concentrado_rho el valor de i a manera de llave primaria
         concentrado_rho[i,1]=copia_x[i,1];//Guarda en la columna 1 de concentrado_rho los rangos encontrados de la variable x
         concentrado_rho[i,2]=copia_y[i,1];//Guarda en la columna 2 de concentrado_rho los rangos encontrados de la variable y    
      }//Cierra el for

      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
         concentrado_rho[i,3]=concentrado_rho[i,1]-concentrado_rho[i,2];//Guarda en la columna 3 de concentrado_rho la diferencia entre los rangos de x e y
         concentrado_rho[i,4]=Math.Pow(concentrado_rho[i,3],2);//Guarda en la columna 4 de concentrado_rho el valor al cuadrado de la diferencia entre los rangos
      }//Cierra el for

      acum=0;//Inicializa el acumulador en cero
      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores de n
         acum = acum + concentrado_rho[i,4];//Acumula el valor de los cuadrados de las diferencias
      }//Cierra el for

      r = 1 - (6*acum)/(n*(n-1)*(n+1));//Formula para el cálculo de rho  
      return r;//Devuelve el valor de r
                                                         
   }//Termina método que cálcula el coeficiente relacional de Spearman o Rho



   public static void detecta_rangos_x(int n, int col, double[,] datos_rango_x)
   {//Inicia método que detecta los rangos de arreglos bidimensionales que esten previamente ordenados

        //El arreglo datos_rango recibirá la información en el siguiente formato
        //la columna cero correspondera a los valores de la variable x o y en su defecto
        //ordenados de menor a mayor, la columna 1 tendra los valores del subíndice i
        //que provienen del orden original, i será la llave primaria para emplear 
        //el arreglo original posteriormente en sus respectivos pares ordenados.
  
        int i,j;//Subíndices locales
        int m;//Tamaño de los arreglos auxiliares de empates y empates acumulados
        m=n-1;//Definición del tamaño de los arreglos auxiliares
        
        int[] emp = { 0 };//Declara e inicializa el arreglo emp para guardar las banderas de empates entre valores
        emp = new int[m];//Asigna tamaño a emp

        int[] emp_acum = { 0 };//Declara e inicializa el arreglo emp_acum que contara cuantas repeticiones tiene un empate
        emp_acum = new int[m];//Asigna tamaño a emp_acum

        int cont=0;//Declara contador para cantidad de empates en emp_acum
        int prod;//Declara variable que servira de bandera para evaluar si existe un empate completo en los datos
        double sum;//Declara variable que guardara la sumatoria previo a promediar

        double[,] rangos_temp_x;//Declara arreglo temporal para almacenar los rangos calculados
        rangos_temp_x = new double[n,2];//Asigna tamaño a rangos_temp_x

        //Función ordena_qs_bid invoca a ordenamiento rápido y envía límites de inicio y fin
        ordenaBidimensional_JW.ordena_qs_bid(n, 2, datos_rango_x);

 
    for(j=0;j<m;j++){//for de j que recorre todos los valores hasta m
      emp[j]=0;//Inicializa los valores del arreglo de banderas de empates emp
      emp_acum[j]=0;//Inicializa los valores del arreglo de acumuladores de empates emp_acum
                    }//Cierra for de j que inicializa los dos arreglos

    for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
        
        try
        {//Inicia el try para controlar excepción IndexOutOfRangeException
            if(datos_rango_x[i,0]==datos_rango_x[i+1,0])//Condición que verifica los empates
                emp[i]=1;//Levanta la bandera del arreglo emp cuando encuentra un empate
        }//Cierra el try para controlar excepción IndexOutOfRangeException 

        catch (System.IndexOutOfRangeException e)
        {//Inicia el catch para controlar excepción IndexOutOfRangeException
            System.Console.WriteLine(e.Message);
        }//Cierra el catch para controlar excepción IndexOutOfRangeException

                    }//Cierra ciclo for de i que recorre todos los valores hasta n

    for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
      if(emp[j]!=0){//Condición que verifica los empates
        cont++;//Incrementa el contador de empates
        emp_acum[j]=cont;//Levanta la bandera del arreglo emp cuando encuentra un empate        
                   }//Cierra if
      else//Sino
         cont=0;//Resetea el contador cuando no hay empates
                    }//Cierra ciclo for de j que recorre todos los valores hasta m


    for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
      rangos_temp_x[i,1] = datos_rango_x[i,1];//Copia en la columna 1 de rangos_temp los datos de i del arreglo datos_rango
      rangos_temp_x[i,0]=(double)i+1;//Asigna en la columna cero de rangos_temp el valor de i+1 como que serian los valores de los rango si no hubiera empates
                    }//Cierra ciclo for de i que recorre todos los valores hasta n

    //Asignación de los valores de datos_rango en rangos_temp
    for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
         datos_rango_x[i,0] = rangos_temp_x[i,0];//Copia en la columna 1 de rangos_temp los datos de i del arreglo datos_rango
                    }//Cierra ciclo for de i que recorre todos los valores hasta n

    prod=1;//Inicializa bandera de productos
    for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
           prod=prod*emp[j];//Calcula una serie de productos de emp[j] para evaluar con una bandera si todos los valores de x estan empatados  
                    }//Cierra for

     if(prod==1){//Cuando todos los valores de x estan empatados               
       
      //Cálculo de un rango completamente empatado
     sum = 0;//Inicializa acumulador en cero
      for(i=0;i<n;i++)//Abre ciclo for de i que recorre todos los valores hasta n  
        sum=sum + rangos_temp_x [i,0];//Acumulación de todos los valores de rangos_temp[i][0]
        
      sum = sum/n;//Promedia los valores acumulados
      
       for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n   
       rangos_temp_x [i,0]=sum;//Asigna el valor promediado a rangos_temp[i][0]
       datos_rango_x [i,0]=sum;//Asigna el valor promediado a datos_rango[i][0]       
                       }//Cierra for                               
                }//Cierra if
     else//Inicio de sino
       for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
          if(emp_acum[j]!=0&&emp_acum[j+1]==0||emp_acum[j]!=0&&j==m-1){//Abre if simple 
            //   printf("\nFin de empate encontrado en subindice j = %d \n",j);//Impresión de prueba
            //   printf("Con el numero = %d \n",emp_acum[j]);//Impresión de prueba
               calc_rangos(j,emp_acum[j],n,2,rangos_temp_x,datos_rango_x);//Invoca a función que calcula rangos y modifica el arreglo de rangos temporal
                                                                     }//Cierra if simple
                       }//Cierra for

    }//Inicia método que detecta los rangos de arreglos bidimensionales que esten previamente ordenados




   public static void detecta_rangos_y(int n, int col, double[,] datos_rango_y)
   {//Inicia método que detecta los rangos de arreglos bidimensionales que esten previamente ordenados

      //El arreglo datos_rango recibirá la información en el siguiente formato
      //la columna cero correspondera a los valores de la variable x o y en su defecto
      //ordenados de menor a mayor, la columna 1 tendra los valores del subíndice i
      //que provienen del orden original, i será la llave primaria para emplear 
      //el arreglo original posteriormente en sus respectivos pares ordenados

      int i,j;//Subíndices locales
      int m;//Tamaño de los arreglos auxiliares de empates y empates acumulados
      m=n-1;//Definición del tamaño de los arreglos auxiliares

      int[] emp;//Declara el arreglo emp para guardar las banderas de empates entre valores
      emp = new int[m];//Asigna tamaño a emp
           
      int[] emp_acum;//Declara el arreglo emp_acum que contara cuantas repeticiones tiene un empate
      emp_acum = new int[m];//Asigna tamaño a emp_acum
   
      int cont=0;//Declara contador para cantidad de empates en emp_acum
      int prod;//Declara variable que servira de bandera para evaluar si existe un empate completo en los datos
      double sum;//Declara variable que guardara la sumatoria previo a promediar

      double[,] rangos_temp_y;//Declara arreglo temporal para almacenar los rangos calculados
      rangos_temp_y = new double[n,2];//Asigna tamaño a rangos_temp_y

      //Función ordena_qs_bid invoca a ordenamiento rápido y envía límites de inicio y fin
      ordenaBidimensional_JW.ordena_qs_bid(n, 2, datos_rango_y);

      for(j=0;j<m;j++){//for de j que recorre todos los valores hasta m
         emp[j]=0;//Inicializa los valores del arreglo de banderas de empates emp
         emp_acum[j]=0;//Inicializa los valores del arreglo de acumuladores de empates emp_acum
      }//Cierra for de j que inicializa los dos arreglos


      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
         try
         {//Inicia el try para controlar excepción IndexOutOfRangeException
            if(datos_rango_y[i,0]==datos_rango_y[i+1,0])//Condición que verifica los empates
               emp[i]=1;//Levanta la bandera del arreglo emp cuando encuentra un empate 
         }//Cierra el try para controlar excepción IndexOutOfRangeException 
         catch (System.IndexOutOfRangeException e)
         {//Inicia el catch para controlar excepción IndexOutOfRangeException
            System.Console.WriteLine(e.Message);
         }//Cierra el catch para controlar excepción IndexOutOfRangeException
      }//Cierra ciclo for de i que recorre todos los valores hasta n

      for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
         if(emp[j]!=0){//Condición que verifica los empates
            cont++;//Incrementa el contador de empates
            emp_acum[j]=cont;//Levanta la bandera del arreglo emp cuando encuentra un empate        
      }//Cierra if
      else//Sino
         cont=0;//Resetea el contador cuando no hay empates
      }//Cierra ciclo for de j que recorre todos los valores hasta m


      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
         rangos_temp_y[i,1] = datos_rango_y[i,0];//Copia en la columna 1 de rangos_temp los datos de i del arreglo datos_rango
         rangos_temp_y[i,0]=(double)i+1;//Asigna en la columna cero de rangos_temp el valor de i+1 como que serian los valores de los rango si no hubiera empates
      }//Cierra ciclo for de i que recorre todos los valores hasta n

      //Asignación de los valores de datos_rango en rangos_temp
      for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
         datos_rango_y[i,0] = rangos_temp_y[i,0];//Copia en la columna 1 de rangos_temp los datos de i del arreglo datos_rango
      }//Cierra ciclo for de i que recorre todos los valores hasta n


      prod=1;//Inicializa bandera de productos
      for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m
         prod=prod*emp[j];//Calcula una serie de productos de emp[j] para evaluar con una bandera si todos los valores de x estan empatados  
      }//Cierra for

      if(prod==1){//Cuando todos los valores de y estan empatados               

         //Cálculo de un rango completamente empatado
         sum = 0;//Inicializa acumulador en cero
         for(i=0;i<n;i++)//Abre ciclo for de i que recorre todos los valores hasta n  
            sum=sum + rangos_temp_y [i,0];//Acumulación de todos los valores de rangos_temp[i][0]  
         sum = sum/n;//Promedia los valores acumulados
         
         for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n   
            rangos_temp_y [i,0]=sum;//Asigna el valor promediado a rangos_temp[i][0]
            datos_rango_y [i,0]=sum;//Asigna el valor promediado a datos_rango[i][0]       
         }//Cierra for                               
      }//Cierra if
      else//Inicio de sino
         for(j=0;j<m;j++){//Abre ciclo for de j que recorre todos los valores hasta m       
            try
            {//Abre try
               if(emp_acum[j]!=0&&emp_acum[j+1]==0||emp_acum[j]!=0&&j==m-1)//Abre if simple 
                  calc_rangos(j,emp_acum[j],n,2,rangos_temp_y,datos_rango_y);//Invoca a función que calcula rangos y modifica el arreglo de rangos temporal                                                                     }//Cierra if simple                 
            }//Cierra try
           catch (System.IndexOutOfRangeException e)
           {//Inicia el catch para controlar excepción IndexOutOfRangeException
               System.Console.WriteLine(e.Message);
           }//Cierra el catch para controlar excepción IndexOutOfRangeException

         }//Cierra for                                          
    }//Termina método que detecta los rangos de arreglos bidimensionales que esten previamente ordenados


   public static void calc_rangos(int j,int num, int ren,int col,double[,] rangos_temp,double[,] datos_rango)
   {//Inicia método que calcula rangos empatados de arreglos bidimensionales que esten previamente ordenados

      int i;//Subíndice locales
      int inicio;//Valor de inicio donde se encuentran rangos empatados con las banderas de los arreglos
      int fin;//Valor final donde se encuentran rangos empatados con las banderas de los arreglos
      double sum;//Declara variable que guardara la sumatoria previo a promediar
      double r;//Declara variable que contendra el valor del rango promediado

      sum=0;//Inicializa el acumulador de los valores a promediar                 
      inicio=j+1-num;//Inicializa el valor de inicio para calcular rangos empatados
      fin=j+1;//Inicializa el valor de fin para calcular rangos empatados  
    
      for(i=inicio;i<=fin;i++)//Abre ciclo for de i que recorre todos los valores hasta n
         sum = sum + rangos_temp[i,0];//Acumula en sum los valores de rangos_temp[i][0]

      r = sum/(double)(num+1);//r obtiene el promedio de los rangos empatados

      for(i=inicio;i<=fin;i++){//Abre ciclo for de i que recorre todos los valores hasta n
         rangos_temp[i,0] = r;//Asigna a todos los valores de rangos que estan empatados el valor promediado          
         datos_rango[i,0] = r;//Asigna a todos los valores de datos rango que estan empatados el valor promediado          
      }//Cierra for
                                                                                                                                 
   }//Termina método que calcula rangos empatados de arreglos bidimensionales que esten previamente ordenados

}//Cierra la clase que contiene a los métodos para cálculo del coeficiente relacional de Spearman o Rho