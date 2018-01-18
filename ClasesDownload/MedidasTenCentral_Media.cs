using System; 

public class media_JW
{//Abre la clase que calcula las medias

   public static double calc_promedio(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia método que calcula el promedio
      double acum = 0, media_aritmetica; //declara variables de acumulador y resultado
      int i; //Declara al subíndice local
      for (i = 0; i < n; i++) //Ciclo for para acumular valores
      {
         acum += temp[i];//Acumulación de valores del arreglo
      }
      media_aritmetica = acum / (double)n;//Calculo de la media aritmetica o promedio
      return media_aritmetica;//Devuelve la media aritmetica o promedio
   }//Termina método que calcula el promedio

   public static double calc_media_geometrica(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia método que calcula la media geométrica

      double media_geometrica; //Declara variable que almacenará el resultado
      double acum = 1; //Declara e inicializa variable acumulador para el producto
      double raiz;
      raiz = (double)(1 / (double)n);
      int i; //Declara al subíndice local

      for (i = 0; i < n; i++) //Ciclo for para acumular valores
         acum *= Math.Abs(temp[i]);//Acumulación del producto de los valores del arreglo

      media_geometrica = (ulong)Math.Pow(acum, raiz);//Calculo de la media geométrica
      media_geometrica = Convert.ToDouble(media_geometrica);
      return media_geometrica;//Devuelve la media geométrica

   }//Termina método que calcula la media geométrica


   public static double calc_media_ponderada(int n, double[,] Atemp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia método que calcula la media ponderada

      double sum_wx;//Declara variable para almacenar la sumatoria w*x del arreglo
      sum_wx = sumatoria_arreglo_xy_frac(n, Atemp);//Invoca a método que calcula la sumatoria de w*x

      double sum_w;//Declara variable para almacenar la sumatoria de la columna w del arreglo
      sum_w = sumatoria_arreglo_bid_frac_col_0(n, Atemp);//Invoca a método que calcula la sumatoria de w

      double media_pond;//Declara variable que almacenará resultado
      media_pond = divide_a_entre_b(sum_wx, sum_w);//Llama a función que divide las dos sumatorias de la media ponderada

      return media_pond;//Devuelve la media ponderada

   }//Termina método que calcula la media ponderada


   public static double sumatoria_arreglo_xy_frac(int n, double[,] Atemp)//El método recibe un arreglo de double's y devuelve un solo valor double
   {//Inicia método que calcula la sumatoria xy para calcular la media ponderada
      double acumulador = 0; //declara variable de acumulador
      int i; //Declara al subíndice local

      for (i = 0; i < n; i++) //Ciclo for para acumular valores
         acumulador = acumulador + Atemp[i, 0] * Atemp[i, 1];//Acumulación de los productos xy del arreglo

      return acumulador;//Devuelve valor acumulado de la sumatoria
   }//Termina método que calcula la sumatoria xy para calcular la media ponderada

   public static double sumatoria_arreglo_bid_frac_col_0(int n, double[,] Atemp)//El método recibe un arreglo de double's y devuelve un solo valor double  
   {//Inicia método que calcula la sumatoria de la columna cero para calcular la media ponderada
      double acumulador = 0; //declara variable de acumulador
      int i; //Declara al subíndice local

      for (i = 0; i < n; i++) //Ciclo for para acumular valores
         acumulador = acumulador + Atemp[i, 0];//Acumulación de valores de la columna cero del arreglo

      return acumulador;//Devuelve valor acumulado de la sumatoria

   }//Inicia método que calcula la sumatoria de la columna cero para calcular la media ponderada

   public static double divide_a_entre_b(double a, double b)
   {//Inicia método que divide la sumatoria x*y con la sumatoria de la columna cero
      double c; //Declara variable del resultado 
      c = a / b;//Divide a entre b
      return c;//Devuelve el cociente de la división fraccionaria
   }//Termina método que divide la sumatoria x*y con la sumatoria de la columna cero
}//Cierra la clase que calcula las medias