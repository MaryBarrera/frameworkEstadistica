public class limitesHistograma_JW
    {//Inicia la clase limitesHistograma_JW

        public static void calc_limites_clases(int iCantidadElementosNumericos, int iCantidadClases, double dRango, double dAnchoClase,double[] Vuni, double[,] dLimitesClases)
        {//Inicia método que calcula el ancho de clases

            //Declara subíndices locales
            int i, j;

            //Genera el primer valor del arreglo con ancho de clases fijo
            dLimitesClases[0,0] = Vuni[0];

            //Genera la columna con los limites inferiores de clase 
            for (i = 1; i < iCantidadClases; i++)//for de i que va desde 1 hasta cant_clases-1  
                dLimitesClases[i,0] = dLimitesClases[i - 1,0] + dAnchoClase;

            //Genera los valores de los limites superiores de clase 
            for (i = 0; i < iCantidadClases - 1; i++)//for de i que va desde 0 hasta cant_clases-2    
                for (j = 0; j < 2; j++)//for de j que va desde 0 hasta 1
                    if (j == 1)//Condición que valida la columna  
                        dLimitesClases[i,j] = dLimitesClases[i,j - 1] + dAnchoClase;//Asignación del límite de clase

            //Genera el último valor del arreglo con ancho de clases fijo
            dLimitesClases[iCantidadClases - 1,1] = Vuni[iCantidadElementosNumericos - 1];
        }//Termina método


        public static void calc_limites_reales_clases(int iCantidadClases, double[,] dLimitesClases, double[,] dLimitesRealesClases)
        {//Inicia método que calcula el ancho de clases

            //Declara subíndices locales
            int i, j;

            //Genera la columna con los limites inferiores de clase 
            for (i = 0; i < iCantidadClases; i++)//for de i que recorre todos los renglones  
               for(j=0;j<2;j++)//for de j que recorre todas las columnas  
                  if(j==0)//if-else que identifica en que columna aplicar la operación  
                      dLimitesRealesClases[i,0] = dLimitesClases[i,0] - 0.5;//Asigna los límites inferiores reales de las clases
                  else//else que asigna cuando la condición es falsa
                      dLimitesRealesClases[i,1] = dLimitesClases[i,1] + 0.5;//Asigna los límites superiores reales de las clases  
   
        }//Termina método
    }//Termina la clase limitesHistograma_JW