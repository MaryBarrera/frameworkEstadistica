using System;

public class moda_JW
{
   //ESPAÑOL: Inicia la clase moda_JW | ENGLISH: start the class that calculate the mode value
        
   //ESPAÑOL: El método recibe un arreglo de double's y devuelve un string o cadena
   //ENGLISH: the method get a double array and return a string
   public static string calc_moda(int n, double[] temp)
   {
      //ESPAÑOL: Inicia método que calcula la moda | ENGLISH: start  the method that calculate the mode

      //ESPAÑOL: Declara e incializa la cadena para almacenar mediana con arreglo ordenado 
      //ENGLISH: variable to store the median sorted array 
      string sCadenaModa = "";

      //ESPAÑOL: Declara e incializa las tres cadenas a emplear cuando los valores no ocurran una sola vez
      //ENGLISH: variables to save the values when it doesn't  happen once 
      string s1 = "", s2 = "", sTemp = "";

      //ESPAÑOL: Declara contador de repeticiones de moda |  ENGLISH: declare a counter for the repetitions
      int repeticiones_moda = 0;
      
      int i, j;//ESPAÑOL: Subíndices locales | ENGLISH: local index
      
      int m;//ESPAÑOL: Tamaño de los arreglos auxiliares de empates y empates acumulados | ENGLISH: sizes for the arrays
      
      m = n - 1;//ESPAÑOL: Definición del tamaño de los arreglos auxiliares | ENGLISH: define the size for the auxiliar array     
      
      //ESPAÑOL: Declara el arreglo emp para guardar las banderas de empates entre valores 
      //ENGLISH: array to save equal values 
      int[] emp = new int[m];
      
      //ESPAÑOL: Declara el arreglo emp_acum que contara cuantas repeticiones tiene un empate 
      //ENGLISH: declare an array to count the repetitions 
      int[] emp_acum = new int[m];
      
      int cont = 0;//ESPAÑOL: Declara contador para cantidad de empates en emp_acum  | ENGLISH: declare a counter
      
      int subindice_moda;//ESPAÑOL: Declara subíndice de moda | ENGLISH: declare a mode index
      
      int sum;//ESPAÑOL: Declara el acumulador de sumatoria | ENGLISH: declare a store of summation

      //ESPAÑOL: for de j que recorre todos los valores hasta m 
      //ENGLISH: for loop to initialize arrays
      for (j = 0; j < m; j++)
      {
         emp[j] = 0;//ESPAÑOL: Inicializa los valores del arreglo de banderas de empates emp 
         emp_acum[j] = 0;//ESPAÑOL: Inicializa los valores del arreglo de acumuladores de empates emp_acum
      }//ESPAÑOL: Cierra for de j que inicializa los dos arreglos 

      //ESPAÑOL: Abre ciclo for de i que recorre todos los valores hasta n 
      //ENGLISH: for loop to check both arrays  
      for (i = 0; i < n; i++)
      {
         try
         {//ESPAÑOL: Inicia el try para controlar excepción IndexOutOfRangeException 
            if (temp[i] == temp[i + 1])//ESPAÑOL: Condición que verifica los empates
               emp[i] = 1;//ESPAÑOL: Levanta la bandera del arreglo emp cuando encuentra un empate        
         }//ESPAÑOL: Cierra el try para controlar excepción IndexOutOfRangeException 

         catch (System.IndexOutOfRangeException e)
         {//ESPAÑOL: Inicia el catch para controlar excepción IndexOutOfRangeException
            System.Console.WriteLine(e.Message);
         }//ESPAÑOL: Cierra el catch para controlar excepción IndexOutOfRangeException
      }//ESPAÑOL: Cierra ciclo for de i que recorre todos los valores hasta n


      //ESPAÑOL: Abre ciclo for de j que recorre todos los valores hasta m
      //ENGLISH: for loop to check and count the modal value, if doesn't exist a modal value reset the counter   
      for (j = 0; j < m; j++)
      {
         if (emp[j] != 0)
         {//ESPAÑOL: Condición que verifica los empates
            cont++;//ESPAÑOL: Incrementa el contador de empates
            emp_acum[j] = cont;//ESPAÑOL: Levanta la bandera del arreglo emp cuando encuentra un empate        
         }//ESPAÑOL: Cierra if
         else//Sino
            cont = 0;//Resetea el contador cuando no hay empates
      }//Cierra ciclo for de j que recorre todos los valores hasta m


      subindice_moda = 0;//Inicializa el subíndice de moda | ENGLISH: initialize the modal index
      //ENGLISH: for loop to check the majority of repetitions and save the modal value and its index
      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp_acum[j] > repeticiones_moda)
            {//Abre if simple que busca la mayor cantidad de empates repetidos
               repeticiones_moda = emp_acum[j];//Guarda en repeticiones_moda el valor donde se encontro la moda
               subindice_moda = j;//Guarda en subindice_moda el valor de j 
            }//Cierra el if simple
      }//Cierra ciclo for de j que recorre todos los valores hasta m

      
      cont = 0;//Resetea el contador para usarlo nuevamente | ENGLISH: restart the counter again
      //ENGLISH: for loop to check how often has occurred the modal values
      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp_acum[j] > 0 && emp_acum[j] == repeticiones_moda)
         {//Abre if simple que evalua cuantas modas ocurren
            cont++;//Incrementa el acumulador    
         }//Cierra el if simple
      }//Cierra ciclo for de j que recorre todos los valores hasta m


      sum = 0;//Inicializa el acumulador de suma en cero | ENGLISH: initialize the counter woth zero
      //ENGLISH: for loop to evalue that all values has been different
      for (j = 0; j < m; j++)
      {//Abre ciclo for de j que recorre todos los valores hasta m
         if (emp_acum[j] > 0)//Evalua que los valores de los empates acumulados sean diferentes
            sum++;//Incrementa el acumulador de suma
      }//Cierra ciclo for de j que recorre todos los valores hasta m

      //ENGLISH: print a message when all values are different
      if (sum == 0)//Mensaje que ocurre cuando todos los valores aparecen solo una vez
         sCadenaModa = "Todos los valores ocurren solo una vez.";

      //ENGLISH: pritn a message with the the number of repetitions and the modal value(s)   
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