public class anchoClases_JW
{//Inicia la clase cantidadClases_JW
        public static double calc_ancho_clases(int cant_clases, double rango)
        {//Inicia método que calcula el ancho de clases
            double ancho_clase; //Variables locales
            ancho_clase = rango / (double)cant_clases;//Calcula el ancho de clase
            return ancho_clase;//Devuelve el ancho de clase fijo
        }//Termina método
}//Termina la clase cantidadClases_JW