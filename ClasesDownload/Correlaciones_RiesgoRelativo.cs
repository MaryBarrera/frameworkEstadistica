   public class riesgo_relativo_JW
        {//Abre la clase que contiene a los métodos para calcular al coeficiente relacional de riesgo relativo

            public static double calc_riesgo_relativo(int ren, int col, double[,] datos)
            {//Inicia método que calcula el coeficiente coeficiente relacional de riesgo relativo

                double p;//Declara donde guardara el resultadon final 
                double a, b, c, d;//Declara variables que almacenarán los valores para calcular el coeficiente relacional de riesgo relativo
                a = datos[0, 0];//Asigna a la variable a el dato almacenado en la localidad [0][0]
                b = datos[0, 1];//Asigna a la variable b el dato almacenado en la localidad [0][1]
                c = datos[1, 0];//Asigna a la variable c el dato almacenado en la localidad [1][0]
                d = datos[1, 1];//Asigna a la variable d el dato almacenado en la localidad [1][1]
                p = (a / (a + b)) / (c / (c + d));//Realiza el cáculo del coeficiente del coeficiente relacional de riesgo relativo
                return p;//Devuelve el valor de p

            }//Cierra método que calcula el coeficiente coeficiente relacional de riesgo relativo


        }//Cierra la clase que contiene a los métodos para calcular al coeficiente relacional de riesgo relativo