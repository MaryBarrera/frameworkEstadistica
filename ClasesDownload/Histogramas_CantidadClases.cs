//ESPAÑOL: la clase cantidadClases_JW contiene el metodo que calcula la cantidad de clases para el histograma
//ENGLISH: this method claculates

using System;

public class cantidadClases_JW
{
    public static int calc_cantidad_clases(int num_datos, double rango)
    {//Inicia método
            double num_datos_frac; //Variables locales
            int cant_clases = 1; //Variable para cantidad de clases se inicializa en uno para evitar errores de ejecución y de compilación
            num_datos_frac = (double)num_datos;//Cantidad de datos en fraccionario para usar <math.h>

            //Correciones por valores numéricos inesperados
            if (num_datos_frac < 0)//Corrección por valor negativo
                num_datos_frac = Math.Abs(num_datos_frac);//Asignación de valor absoluto
            if (num_datos_frac == 0)//Corrección por valor cero
                num_datos_frac = 1.0;//Asignación del valor en 1.0
            if (num_datos_frac > 0 && num_datos_frac < 1)//Corrección por valor entre 0 y 1
                num_datos_frac = 1.0;//Asignación del valor en 1.0

            //Empleo de regla de Sturges C = 1+3.322 * log10(N)
            //Clasificación de 1 a 30, 30 a 30000 o mayores a 30000
            if (num_datos_frac >= 1 && num_datos_frac <= 30)
                //Redondeado hacia abajo
                cant_clases = (int)Math.Floor(1 + 3.322 * Math.Log10(num_datos_frac));
            if (num_datos_frac > 30 && num_datos_frac <= 30000)
                //Redondeado hacia arriba
                cant_clases = (int)Math.Ceiling(1 + 3.322 * Math.Log10(num_datos_frac));
            if (num_datos_frac > 30000 && num_datos_frac <= 50000)
                //Valor fijo para más de 30000 datos y menor o igual a 50000
                cant_clases = 16;
            if (num_datos_frac > 50000 && num_datos_frac <= 90000)
                //Valor fijo para más de 50000 datos y menor o igual a 90000
                cant_clases = 17;
            if (num_datos_frac > 90000 && num_datos_frac <= 100000)
                //Valor fijo para más de 90000 datos y menor o igual a 100000
                cant_clases = 18;
            if (num_datos_frac > 100000 && num_datos_frac <= 500000)
                //Valor fijo para más de 100000 datos y menor a 500000
                cant_clases = 19;
            if (num_datos_frac > 500000)
                //Valor fijo para más de 500000 datos
                cant_clases = 20;
            return cant_clases;//Devuelve cantidad de clases
    }//Termina método
}//Termina la clase cantidadClases_JW
