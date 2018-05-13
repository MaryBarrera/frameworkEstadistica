//ENGLISH: Class with the methods to calculate pearson correlation coefficient 
//this class needs the class media, varianza and desvacion_estandar
//parameters: n: is an int value with the size of the vector or with the number of elements of array
//temp: is a double array of size 2*n elements

using System;

   public class pearson_JW
        {//Abre la clase que contiene a los métodos para cálculo del coeficiente relacional de Pearson

            public static double calc_pearson(int n, double[,] temp)
            {//Inicia método que calcula la correlación de Pearson
                double r; //declara variable del resultado
                double x_media, y_media, desv_std_x, desv_std_y; //Declara variables a emplear para los cálculos
                double varianza_x, varianza_y, producto, acum = 0; //Declara variables a emplear para los cálculos

                double[] vec_x;//Declara vector para almacenar a variable x
                vec_x = new double[n];//Asigna tamaño a vec_x

                double[] vec_y;//Declara vector para almacenar a variable y
                vec_y = new double[n];//Asigna tamaño a vec_y

                int i, j; //Declara a los subíndices locales

                for (i = 0; i < n; i++) //for de i que recorre renglones
                    for (j = 0; j < 2; j++) //for de j que recorre columnas
                        if (j == 0)//if-else que separa 
                            vec_x[i] = temp[i, j];//Asignación de valores del vector x.
                        else//else del if doble
                            vec_y[i] = temp[i, j];//Asignación de valores del vector y.

                //Invoca a método que calcula la media aritmetica de los valores de X
                x_media = media_JW.calc_promedio(n, vec_x);

                //Invoca a método que calcula la media aritmetica de los valores de Y
                y_media = media_JW.calc_promedio(n, vec_y);

                //Invoca a método que calcula la varianza muestral del vector de x, dividiendo entre n-1
                varianza_x = varianza_JW.calc_varianza_muestral(n, vec_x);

                //Invoca a método que calcula la varianza muestral del vector de y, dividiendo entre n-1
                varianza_y = varianza_JW.calc_varianza_muestral(n, vec_y);

                //Invoca a método que calcula la desviación estándar del vector x
                desv_std_x = desviacion_estandar_JW.calc_desviacion_estandar(varianza_x);

                //Invoca a método que calcula la desviación estándar del vector y
                desv_std_y = desviacion_estandar_JW.calc_desviacion_estandar(varianza_y);


                for (i = 0; i < n; i++)
                {//Abre for de i que calcula el producto de la diferencia de los valores con los promedios.
                    producto = (vec_x[i] - x_media) * (vec_y[i] - y_media);//Calcula al término que contiene al producto de las diferencias.
                    acum = acum + producto;//acumulación de valores
                }//Cierra for de i

                r = (1 / ((double)n - 1)) * acum / (desv_std_x * desv_std_y);//Cálculo del coeficiente correlacional de Pearson

                return r;//Devuelve el valor calculado de r

            }//Termina  método que calcula la correlación de Pearson

        }//Cierra la clase que contiene a los métodos para cálculo del coeficiente relacional de Pearson