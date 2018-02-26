using System; 

//ESPAÑOL: Abre la clase que calcula las medias
//ENGLISH: Open the class that calculate measures of central tendency   
public class media_JW
{
   //ESPAÑOL: El método recibe un arreglo de double's y devuelve un solo valor double
   //ENGLISH: The method gets a double's array and return a double's value 
   public static double calc_promedio(int n, double[] temp)
   {
      //ESPAÑOL: Inicia método que calcula el promedio | ENGLISH: Start method that calculate the average

      //ESPAÑOL: declara variables de acumulador y resultado | ENGLISH: declare acumulator variable and result variable
      double acum = 0, media_aritmetica; 

      //ESPAÑOL: Declara al subíndice local | ENGLISH: declare a local index   
      int i; 
      
      //ESPAÑOL: Ciclo for para acumular valores | ENGLISH: for loop to accumulate values
      for (i = 0; i < n; i++)  
      {
         acum += temp[i];//ESPAÑOL: Acumulación de valores del arreglo | ENGLISH: accumulation of values from array
      }
      
      //ESPAÑOL: Calculo de la media aritmetica o promedio | ENGLISH: calculate arithmetic average
      media_aritmetica = acum / (double)n;
      
      //Devuelve la media aritmetica o promedio | ENGLISH: return arithmetic average
      return media_aritmetica;

   }//ESPAÑOL: Termina método que calcula el promedio | ENGLISH: end the average class 

   
   //ESPAÑOL: El método recibe un arreglo de double's y devuelve un solo valor double
   //ENGLISH: the method gets a double's array and return a value
   public static double calc_media_geometrica(int n, double[] temp)
   {//ESPAÑOL: Inicia método que calcula la media geométrica

      double media_geometrica; //ESPAÑOL: Declara variable que almacenará el resultado
      double acum = 1; //ESPAÑOL: Declara e inicializa variable acumulador para el producto
      double raiz;
      raiz = (double)(1 / (double)n); //ENGLISH: calculate the sqr
      int i; //ESPAÑOL: Declara al subíndice local

      //ESPAÑOL: Ciclo for para acumular valores | ENGLISH: for loop to acumulate values
      for (i = 0; i < n; i++) 
         acum *= Math.Abs(temp[i]);//ESPAÑOL: Acumulación del producto de los valores del arreglo | ENGLISH: accumulation of the multiplied values  

      media_geometrica = (ulong)Math.Pow(acum, raiz);//ESPAÑOL: Calculo de la media geométrica | ENGLISH: calculate arithmetic average
      media_geometrica = Convert.ToDouble(media_geometrica); //ENGLISH: convert to double the result 
      return media_geometrica;//ESPAÑOL: Devuelve la media geométrica | ENGLISH: return the arithmetic average

   }//ESPAÑOL: Termina método que calcula la media geométrica | ENGLISH: end the method 


   //ESPAÑOL: El método recibe un arreglo de double's y devuelve un solo valor double
   //ENGLISH: The method gets an array and array a value
   public static double calc_media_ponderada(int n, double[,] Atemp)
   {
      //ESPAÑOL: Inicia método que calcula la media ponderada | ENGLISH: Start method that calculate Weighted average

      //ESPAÑOL: Declara variable para almacenar la sumatoria w*x del arreglo | ENGLISH: declarate variable to store the summation of w*x 
      double sum_wx;

      //ESPAÑOL: Invoca a método que calcula la sumatoria de w*x | ENGLISH: call the method that calculate the summation
      sum_wx = sumatoria_arreglo_xy_frac(n, Atemp);

      //ESPAÑOL: Declara variable para almacenar la sumatoria de la columna w del arreglo | ENGLISH: declatate a variable to store the summation of array column 
      double sum_w;

      //ESPAÑOL: Invoca a método que calcula la sumatoria de w | ENGLISH: call the method to calculate summation
      sum_w = sumatoria_arreglo_bid_frac_col_0(n, Atemp);
      
      double media_pond;//ESPAÑOL: Declara variable que almacenará resultado | ENGLISH: declarate variable to save the result
      
      //ESPAÑOL: Llama a función que divide las dos sumatorias de la media ponderada | ENGLISH: call the function to divide the summation
      media_pond = divide_a_entre_b(sum_wx, sum_w);

      return media_pond;//ESPAÑOL: Devuelve la media ponderada | ENGLISH: return the Weighted average

   }//ESPAÑOL: Termina método que calcula la media ponderada | ENGLISH: end method


   //ESPAÑOL: El método recibe un arreglo de double's y devuelve un solo valor double
   //ENGLISH: the method gets an array and return a double value
   public static double sumatoria_arreglo_xy_frac(int n, double[,] Atemp)
   {
      //ESPAÑOL: Inicia método que calcula la sumatoria xy para calcular la media ponderada
      // ENGLISH: start the method that calculate the summation 

      double acumulador = 0; //ESPAÑOL: declara variable de acumulador | ENGLISH: declarate a store variable
      int i; //ESPAÑOL: Declara al subíndice local | ENGLISH: declarate a local index

      //ESPAÑOL: Ciclo for para acumular valores | ENGLISH: for loop to store values
      for (i = 0; i < n; i++) 
         acumulador = acumulador + Atemp[i, 0] * Atemp[i, 1];//ESPAÑOL: Acumulación de los productos xy del arreglo | ENGLISH: accumulation of the multiplication xy array

      return acumulador;//ESPAÑOL: Devuelve valor acumulado de la sumatoria | ENGLISH: return summation result 

   }//ESPAÑOL: Termina método que calcula la sumatoria xy para calcular la media ponderada | ENGLISH: end the method 


   //ESPAÑOL: El método recibe un arreglo de double's y devuelve un solo valor double  
   //ENGLISH: the method gets an array and return a double value
   public static double sumatoria_arreglo_bid_frac_col_0(int n, double[,] Atemp)
   {
      //ESPAÑOL: Inicia método que calcula la sumatoria de la columna cero para calcular la media ponderada | ENGLISH: star the method that calculate the summation of the zero column
      double acumulador = 0; //ESPAÑOL: declara variable de acumulador| ENGLISH: declarate a store variable
      int i; //ESPAÑOL: Declara al subíndice local | ENGLISH: declarate a local index

      for (i = 0; i < n; i++) //ESPAÑOL: Ciclo for para acumular valores | ENGLISH: for loop to store values
         acumulador = acumulador + Atemp[i, 0];// ESPAÑOL:Acumulación de valores de la columna cero del arreglo | ENGLISH: store of values of column zero

      return acumulador;//ESPAÑOL: Devuelve valor acumulado de la sumatoria | ENGLISH: return the summmation result

   }//ESPAÑOL: termina método que calcula la sumatoria de la columna cero para calcular la media ponderada | ENGLISH: end method


   public static double divide_a_entre_b(double a, double b)
   {
      //ESPAÑOL: Inicia método que divide la sumatoria x*y con la sumatoria de la columna cero 
      // ENGLISH: start method that divide the summation of x*y between the summation of zero column

      double c; // ESPAÑOL: Declara variable del resultado | ENGLISH: declarate a result variable
      c = a / b;//ESPAÑOL: Divide a entre b | ENGLISH: Divide 'a' between 'b'
      return c;//ESPAÑOL: Devuelve el cociente de la división fraccionaria | ENGLISH: Return quotient of the fractional division
   }//Termina método que divide la sumatoria x*y con la sumatoria de la columna cero | ENGLISH: end method 

}//Cierra la clase que calcula las medias | ENGLISH: end class