using System;

public class moda_JW
{//Inicia la clase moda_JW
        
   public static string calc_moda(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un string o cadena
   {//Inicia método que calcula la moda

      string sCadenaModa = "";//Declara e incializa la cadena para almacenar mediana con arreglo ordenado
      string s1 = "", s2 = "", sTemp = "";//Declara e incializa las tres cadenas a emplear cuando los valores no ocurran una sola vez
      int repeticiones_moda = 0;//Declara contador de repeticiones de moda
      int i, j;//Subíndices locales
      int m;//Tamaño de los arreglos auxiliares de empates y empates acumulados
      m = n - 1;//Definición del tamaño de los arreglos auxiliares          
      int[] emp = new int[m];//Declara el arreglo emp para guardar las banderas de empates entre valores
      int[] emp_acum = new int[m];//Declara el arreglo emp_acum que contara cuantas repeticiones tiene un empate
      int cont = 0;//Declara contador para cantidad de empates en emp_acum
      int subindice_moda;//Declara subíndice de moda
      int sum;//Declara el acumulador de sumatoria

      for (j = 0; j < m; j++)
      {//for de j que recorre todos los valores hasta m
         emp[j] = 0;//Inicializa los valores del arreglo de banderas de empates emp
         emp_acum[j] = 0;//Inicializa los valores del arreglo de acumuladores de empates emp_acum
      }//Cierra for de j que inicializa los dos arreglos

      for (i = 0; i < n; i++)
      {//Abre ciclo for de i que recorre todos los valores hasta n
         try
         {//Inicia el try para controlar excepción IndexOutOfRangeException 
            if (temp[i] == temp[i + 1])//Condición que verifica los empates
               emp[i] = 1;//Levanta la bandera del arreglo emp cuando encuentra un empate        
         }//Cierra el try para controlar excepción IndexOutOfRangeException 

         catch (System.IndexOutOfRangeException e)
         {//Inicia el catch para controlar excepción IndexOutOfRangeException
            System.Console.WriteLine(e.Message);
         }//Cierra el catch para controlar excepción IndexOutOfRangeException
      }//Cierra ciclo for de i que recorre todos los valores hasta n

      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp[j] != 0)
         {//Condición que verifica los empates
            cont++;//Incrementa el contador de empates
            emp_acum[j] = cont;//Levanta la bandera del arreglo emp cuando encuentra un empate        
         }//Cierra if
         else//Sino
            cont = 0;//Resetea el contador cuando no hay empates
      }//Cierra ciclo for de j que recorre todos los valores hasta m

      subindice_moda = 0;//Inicializa el subíndice de moda
      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp_acum[j] > repeticiones_moda)
            {//Abre if simple que busca la mayor cantidad de empates repetidos
               repeticiones_moda = emp_acum[j];//Guarda en repeticiones_moda el valor donde se encontro la moda
               subindice_moda = j;//Guarda en subindice_moda el valor de j 
            }//Cierra el if simple
      }//Cierra ciclo for de j que recorre todos los valores hasta m

      cont = 0;//Resetea el contador para usarlo nuevamente
      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp_acum[j] > 0 && emp_acum[j] == repeticiones_moda)
         {//Abre if simple que evalua cuantas modas ocurren
            cont++;//Incrementa el acumulador    
         }//Cierra el if simple
      }//Cierra ciclo for de j que recorre todos los valores hasta m

      sum = 0;//Inicializa el acumulador de suma en cero  
      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp_acum[j] > 0)//Evalua que los valores de los empates acumulados sean diferentes
            sum++;//Incrementa el acumulador de suma
      }//Cierra ciclo for de j que recorre todos los valores hasta m
      if (sum == 0)//Mensaje que ocurre cuando todos los valores aparecen solo una vez
         sCadenaModa = "Todos los valores ocurren solo una vez.";
      else
      {//Inicia sino
         repeticiones_moda = repeticiones_moda + 1;//Modifica repeticiones_moda para presentar a usuario
         s1 = "\nSe encuentra(n) " + Convert.ToString(cont) + " valor(es) modal(es) con " + Convert.ToString(repeticiones_moda) + " repeticiones.\n";
         repeticiones_moda = repeticiones_moda - 1;//Modifica repeticiones_moda para continuar usando en programa
         cont = 0;//Resetea el contador para usarlo nuevamente
         for (j = 0; j < m; j++)
         {//Abre ciclo for de j que recorre todos los valores hasta m
            if (sum != 0 && emp_acum[j] > 0 && emp_acum[j] == repeticiones_moda)
            {//Abre el if que imprime los valores modales
               cont++;//Incrementa el contador                                                          
               // printf("El valor modal %d es %.4f \n",cont,temp[j]);//Texto
               sTemp = "El valor modal " + Convert.ToString(cont) + " es " + Convert.ToString(temp[j]) + ".\n";
               s2 = s2 + sTemp; //Agrega todas las clases modales que aparecieron en el análisis     
            }//Cierra el if que imprime los valores modales
            sCadenaModa = s1 + s2; //Junta la primera parte de la cadena con la segunda             
         }//Cierra ciclo for de j que recorre todos los valores hasta m

      }//Termina sino
      return sCadenaModa;//Devuelve la cadena con la información del análisis de la moda muestral 
   }//Termina método que calcula la mediana
}//Termina la clase moda_JW