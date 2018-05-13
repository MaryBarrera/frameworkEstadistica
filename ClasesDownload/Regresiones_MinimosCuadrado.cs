//ENGLISH: This method calculate the least squares

using System;

public class minimos_cuadrados_JW
{//Inicia la clase minimos_cuadrados_JW
         
    public static double sumatoria_arreglo_xy_frac(int n, double[,] bid_temp)
    {//Inicia método que la sumatoria de x*y    
      double acumulador=0; //declara variable de acumulador
      int i; //Declara al subíndice local
            
      for(i=0;i<n;i++) //Ciclo for para acumular valores
        acumulador = acumulador + bid_temp[i, 0] * bid_temp[i, 1];//Acumulación de los productos xy del arreglo
         
      return acumulador;//Devuelve valor acumulado de la sumatoria                                            
    }//Termina método que calcula la sumatoria de x*y

    public static double sumatoria_vector_frac(int n, double[] unid_temp)
    {//Inicia método que calcula la sumatoria del vector
  
      double acumulador=0; //declara variable de acumulador
      int i; //Declara al subíndice local
 
      for(i=0;i<n;i++) //Ciclo for para acumular valores
        acumulador=acumulador + unid_temp[i];//Acumulación de valores del arreglo
     
      return acumulador;//Devuelve valor acumulado de la sumatoria
    }//Termina método que calcula la sumatoria del vector


    public static double sumatoria_vector_cuadrado_frac(int n, double[] unid_temp)
    {//Inicia método que calcula la sumatoria del vector al cuadrado
 
      double acumulador=0; //declara variable de acumulador
      int i; //Declara al subíndice local
    
      for(i=0;i<n;i++) //Ciclo for para acumular valores
        acumulador = acumulador + Math.Pow(unid_temp[i], 2);//Acumulación de valores cuadráticos del arreglo
 
        return acumulador;//Devuelve valor acumulado de la sumatoria
    }//Termina método que calcula la sumatoria del vector al cuadrado

         public static double calc_mc_m(int n, double[,] bid_temp)
         {//Inicia método que calcula m
             double m; //declara variable del resultado
             double sum_xy, sum_x, sum_y, sum_x2; //Declara variables a emplear para calcular
             int i, j; //Declara a los subíndices locales

             //Declara vector para almacenar a variable x 
             double[] vec_x;
             //Define el tamaño del arreglo con valor n
             vec_x = new double[n];

             //Declara vector para almacenar a variable y 
             double[] vec_y;
             //Define el tamaño del arreglo con valor n
             vec_y = new double[n];

             for (i = 0; i < n; i++) //for de i que recorre renglones
                 for (j = 0; j < 2; j++) //for de j que recorre columnas
                     if (j == 0)//if-else que separa 
                         vec_x[i] = bid_temp[i, j];//Asignación de valores del vector x.
                     else//else del if doble
                         vec_y[i] = bid_temp[i, j];//Asignación de valores del vector y.

             sum_xy = sumatoria_arreglo_xy_frac(n, bid_temp);//Invoca a función de sumatoria del término xy
             sum_x = sumatoria_vector_frac(n, vec_x);//Invoca a función de sumatoria del término x
             sum_y = sumatoria_vector_frac(n, vec_y);//Invoca a función de sumatoria del término y
             sum_x2 = sumatoria_vector_cuadrado_frac(n, vec_x);//Invoca a función de sumatoria del término x al cuadrado

             m = (n * sum_xy - sum_x * sum_y) / (n * sum_x2 - Math.Pow(sum_x, 2));//Cálculo de la pendiente de mínimos cuadrados

             return m;//Devuelve el valor calculado de m

         }//Termina método que calcula m


         public static double calc_mc_b(int n, double[,] bid_temp)
         {//Inicia método que calcula b
 
             double b; //declara variable del resultado
             double sum_xy, sum_x, sum_y, sum_x2; //Declara variables a emplear para calcular
             int i,j; //Declara a los subíndices locales


             //Declara vector para almacenar a variable x 
             double[] vec_x; 
             //Define el tamaño del arreglo con valor n
             vec_x = new double[n];

             //Declara vector para almacenar a variable y 
             double[] vec_y; 
             //Define el tamaño del arreglo con valor n
             vec_y = new double[n];

          
                for(i=0;i<n;i++) //for de i que recorre renglones
                   for(j=0;j<2;j++) //for de j que recorre columnas
                       if(j==0)//if-else que separa 
                           vec_x[i] = bid_temp[i, j];//Asigna valor a vec_x[i] 
                       else
                           vec_y[i] = bid_temp[i, j];//Asigna valor a vec_y[i]

             sum_xy = sumatoria_arreglo_xy_frac(n, bid_temp);//Invoca a función de sumatoria del término xy
             sum_x = sumatoria_vector_frac(n,vec_x);//Invoca a función de sumatoria del término x
             sum_y = sumatoria_vector_frac(n,vec_y);//Invoca a función de sumatoria del término y
             sum_x2 = sumatoria_vector_cuadrado_frac(n,vec_x);//Invoca a función de sumatoria del término x al cuadrado
  
             b = (sum_y*sum_x2 - sum_x*sum_xy)/(n*sum_x2-Math.Pow(sum_x,2));//Cálculo del término independiente en mínimos cuadrados

             return b;//Devuelve el valor calculado de b
                                                  
         }//Termina método que calcula b



  public static string calc_errores_mc(int n, double[,] bid_temp, double m, double b)
  {//Inicia método que calcula los errores del ajuste de mínimos cuadrados

                string informe_error_mc = "";//Declara e inicializa cadena de reporte para método de mínimos cuadrados
                string informe_error_parte_1 = "";//Declara e inicializa cadena de reporte para método de mínimos cuadrados
                string informe_error_parte_2 = "";//Declara e inicializa cadena de reporte para método de mínimos cuadrados
                string informe_error_parte_3 = "";//Declara e inicializa cadena de reporte para método de mínimos cuadrados
                string informe_error_parte_4 = "";//Declara e inicializa cadena de reporte para método de mínimos cuadrados
                string informe_error_temp = "";//Declara e inicializa cadena de reporte para método de mínimos cuadrados


                double acum_error_lineal=0, acum_error_cuadratico=0; //Declara e inicializa acumuladores de la función 
                int i; //Declara al subíndice local

                //Declara vector para almacenar el resultado de evaluar el modelo 
                double[] valores_mc; 
          
                //Define el tamaño del arreglo con valor n
                valores_mc = new double[n];

                //Declara vector para almacenar el resultado de evaluar el resultado del error lineal 
                double[] error_lineal_mc; 
                
                //Define el tamaño del arreglo con valor n
                error_lineal_mc = new double[n];

                //Declara vector para almacenar el resultado de evaluar el resultado del error cuadratico 
                double[] error_cuadratico_mc; 
                
                //Define el tamaño del arreglo con valor n
                error_cuadratico_mc = new double[n];


                  for(i=0;i<n;i++){//for de i que recorre renglones hasta n

                    valores_mc[i] = m * bid_temp[i, 0] + b;//Asigna valor a valores_mc[i]
                    error_lineal_mc[i] = bid_temp[i, 1] - valores_mc[i];//Asigna valor a error_lineal_mc[i]
                    acum_error_lineal += error_lineal_mc[i];//Acumula acum_error_lineal 
                    error_cuadratico_mc[i] = Math.Pow(error_lineal_mc[i], 2);//Asigna valor a error_cuadratico_mc[i]
                    acum_error_cuadratico += error_cuadratico_mc[i];//Acumula acum_error_cuadratico
                  }//Cierra for de i
  

                  informe_error_parte_1 = "Impresión de errores lineales: \n";//Asigna cadena de reporte
           
                  for (i = 0; i < n; i++){//Inicia ciclo for de los renglones
                      informe_error_temp = informe_error_temp + Convert.ToString(String.Format("{0:0.00}", Math.Round(error_lineal_mc[i], 4))) + "\n";//Asigna cadena de reporte
                  }//Termina ciclo for de los renglones

                  informe_error_parte_1 = informe_error_parte_1 + informe_error_temp;
                  informe_error_parte_2 = "\n" + "La suma de los errores lineales del modelo es " + Convert.ToString(String.Format("{0:0.0000}", Math.Round(acum_error_lineal, 4)));//Asigna cadena de reporte
                  informe_error_parte_3 = "\nImpresión de errores cuadráticos: \n";//Asigna cadena de reporte
                  informe_error_temp = "";//Limpia la cadena temporal

                   for (i = 0; i < n; i++){//Inicia ciclo for de los renglones
                       informe_error_temp = informe_error_temp + Convert.ToString(String.Format("{0:0.00}", Math.Round(error_cuadratico_mc[i], 4))) + "\n";//Asigna cadena de reporte 
                    }//Termina ciclo for de los renglones

                  informe_error_parte_3 = informe_error_parte_3 + informe_error_temp;//Asigna cadena de reporte
                  informe_error_parte_4 = "La suma de los errores al cuadrado del modelo es SSE = " + Convert.ToString(String.Format("{0:0.0000}", Math.Round(acum_error_cuadratico, 4))) + " \n";//Asigna cadena de reporte
                  informe_error_mc = informe_error_parte_1 + informe_error_parte_2 + informe_error_parte_3 + informe_error_parte_4;//Asigna cadena de reporte
                  
                  return informe_error_mc;//Devuelve la cadena con los valores calculados de acum_error_cuadratico
                                                                
  }//Termina método que calcula los errores del ajuste de mínimos cuadrados
}//Termina la clase minimos_cuadrados_JW