public class cuartiles_JW//Abre la clase que calcula los parámetros de los cuartiles
{
        public static int calc_medio_vector(int n)
        {//Inicia función que calcula el tamaño del primer medio vector
            int n_medio_Vuni; //Declara variable local del resultado
            if (n % 2 == 0)//if-else que aplica la operación para cantidad de valores pares o impares
                n_medio_Vuni = n / 2;//Asigna valor para arreglo de cantidad par
            else//else aplica la operación en arreglo de cantidad impar
                n_medio_Vuni = ((n - 1) / 2);//Asigna valor para arreglo de cantidad impar              
            return n_medio_Vuni;//Devuelve el tamaño del primer medio vector
        }//Termina función      

        
        public static double calc_cuartil_1(int n,double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
        {//Inicia función
           
             double q1;//Declara variable para almacenar el primer cuartil
             int n_medio_Vuni;//Declara variable local para almacenar el tamaño del 1er medio vector
             n_medio_Vuni = cuartiles_JW.calc_medio_vector(n); //Calcula la cantidad de elementos que existen en el primer vector

             //Declara Arreglo para almacenar las marcas de clase
             double[] medio_Vuni;
             //Define el tamaño del arreglo con iCantidadClases renglones
             medio_Vuni = new double[n_medio_Vuni];
                    
             int i;//Subíndice local
             for(i=0;i<n_medio_Vuni;i++)//for de i que copia los valores en medio Vector unidimensional
             medio_Vuni[i]=temp[i];//asignación temporal de valores
     
             //Llama a función que calcula la mediana del 1er medio vector
             q1 = mediana_JW.calc_mediana(n_medio_Vuni, medio_Vuni);
             return q1;//Devuelve el primer cuartil
        }//Termina función


        public static double calc_cuartil_3(int n, double[] temp)//El método recibe un arreglo de double's y devuelve un solo valor double
        {//Inicia función

            double q3;//Declara variable para almacenar el primer cuartil
            int n_medio_Vuni;//Declara variable local para almacenar el tamaño del 1er medio vector
            n_medio_Vuni = cuartiles_JW.calc_medio_vector(n); //Calcula la cantidad de elementos que existen en el primer vector

            //Declara Arreglo para almacenar las marcas de clase
            double[] medio_Vuni;
            //Define el tamaño del arreglo con iCantidadClases renglones
            medio_Vuni = new double[n_medio_Vuni];

            int i;//Subíndice local
                if(n%2==0)//if-else que aplica la operación para cantidad de valores pares o impares
                    for(i=0;i<n_medio_Vuni;i++)//for de i que copia los valores en medio Vector unidimensional
                        medio_Vuni[i]=temp[i+n_medio_Vuni];//asignación temporal de valores
                else
                    for(i=0;i<n_medio_Vuni;i++)//for de i que copia los valores en medio Vector unidimensional
                        medio_Vuni[i]=temp[i+1+n_medio_Vuni];//asignación temporal de valores con corrimiento

            //Llama a función que calcula la mediana del 1er medio vector
            q3 = mediana_JW.calc_mediana(n_medio_Vuni, medio_Vuni);
            return q3;//Devuelve el tercer cuartil
        }//Termina función


        public static double calc_desviacion_cuartilar(double dQuartil_1, double dQuartil_3)//El método recibe un arreglo de double's y devuelve un solo valor double
        {//Inicia función
            double desv_cuartilar; //Declara variable local desv_cuartilar
            desv_cuartilar = (dQuartil_3 - dQuartil_1) / 2;//Cálculo de la desviación cuartilar con el tercer y primer cuartiles
            return desv_cuartilar;//Devuelve la desviación cuartilar
        }//Termina función


         public static double calc_rango_intercuartilar(double dQuartil_1, double dQuartil_3)//El método recibe un arreglo de double's y devuelve un solo valor double
         {//Inicia función
             
             double ric; //declara variable local ric
             ric = dQuartil_3 - dQuartil_1;//Calculo del rango intercuartilar con el tercer y primer cuartiles
             // printf("El rango intercuartilar es %.4f \n",ric);//Impresión
             return ric;//Devuelve el rango intercuartilico

         }//Termina función
    
}//Cierra la clase que calcula los parámetros de los cuartiles