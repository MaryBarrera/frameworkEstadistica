        public class odds_ratio_JW
        {//Abre la clase que contiene a los métodos para calcular al coeficiente odds ratio

            public static double calc_odds_ratio(int ren, int col, double[,] datos)
            {//Inicia método que calcula el coeficiente odds ratio

                double p;//Declara donde guardara el resultadon final 
                double a, b, c, d;//Declara variables que almacenarán los valores para calcular odds ratio
                a = datos[0,0];//Asigna a la variable a el dato almacenado en la localidad [0][0]
                b = datos[0,1];//Asigna a la variable b el dato almacenado en la localidad [0][1]
                c = datos[1,0];//Asigna a la variable c el dato almacenado en la localidad [1][0]
                d = datos[1,1];//Asigna a la variable d el dato almacenado en la localidad [1][1]
                p = (a * d) / (b * c);//Realiza el cáculo del coeficiente "odds ratio"
                return p;//Devuelve el valor de p

            }//Cierra método que calcula el coeficiente odds ratio


        }//Cierra la clase que contiene a los métodos para calcular al coeficiente odds ratio