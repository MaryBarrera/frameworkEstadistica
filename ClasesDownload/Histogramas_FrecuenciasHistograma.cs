public class frecuenciasHistograma_JW
    {//Inicia la clase frecuenciasHistograma_JW

        public static void calc_frecuencia_absoluta(int iCantidadClases, int iCantidadElementosNumericos, double[,] dLimitesClases, double[] Vuni, double[] dFrecuenciaAbsoluta)
        {//Inicia método que calcula la frecuencia absoluta
            //Declara subíndices locales
            int i, j;

            for (j = 0; j < iCantidadClases; j++)//For que va de cero a cantidad de clases 
                dFrecuenciaAbsoluta[j] = 0;//Inicializa arreglo de acumuladores de frecuencia sencillas

            //Código que calcula la frecuencia absoluta
            for (i = 0; i < iCantidadElementosNumericos; i++)//For de i que va de cero a cantidad de valores en el arreglo
                for (j = 0; j < iCantidadClases; j++)
                {//For de j que va de cero a cantidad de clases en número de renglones 
                    if (j < iCantidadClases - 1)
                    {//if simple para las primeras clases sin considerar la última
                        if (Vuni[i] >= dLimitesClases[j,0] && Vuni[i] < dLimitesClases[j,1])
                        {//Condición para if simple de valores de las primeras clases
                            // Impresiones provisionales de valores
                            //printf("if 1 Valor = %.4f, LIC = %.4f, LSC = %.4f Clase = %d \n",valores[i],(*lim_clase)[j][0],(*lim_clase)[j][1],j);
                            dFrecuenciaAbsoluta[j]++;//Incrementa contador de frecuencia de clase                    
                        }//Cierra if simple de primeras clases
                    }//Cierra if de primeras clases
                    if (j == iCantidadClases - 1)
                    {//if simple de última clase                                                                       
                        if ((Vuni[i] >= dLimitesClases[j,0]) && (Vuni[i] <= dLimitesClases[j,1]))
                        {//Condición para if simple de valores de la última clase
                            // Impresiones provisionales de valores
                            //printf("if 2 Valor = %.4f, LIC = %.4f, LSC = %.4f Clase = %d \n",valores[i],(*lim_clase)[j][0],(*lim_clase)[j][1],j);
                            dFrecuenciaAbsoluta[j]++;//Incrementa contador de frecuencia de clase                                                                                                                                                     
                        }//Cierra if simple de última clase
                    }//Cierra if simple de última clase                                                                        
                }//Cierra for de subíndice j
            //Código que calcula la frecuencia absoluta

        }//Termina método

        public static void calc_frecuencia_relativa(int iCantidadClases, int iCantidadElementosNumericos, double[] dFrecuenciaAbsoluta, double[] dFrecuenciaRelativa)
        {//Inicia método que calcula la frecuencia relativa
            //Declara subíndice local
            int i;
            //For que va de cero a cantidad de clases
            for (i = 0; i < iCantidadClases; i++) 
                dFrecuenciaRelativa[i] = dFrecuenciaAbsoluta[i] / iCantidadElementosNumericos;//Divide cada valor entre el total y lo asigna al arreglo de frecuencias;//Inicializa arreglo de acumuladores de frecuencia sencillas
             //Código que calcula la frecuencia relativa
        }//Termina método


        public static void calc_frecuencia_acumulada(int iCantidadClases, double[] dFrecuenciaAbsoluta, double[] dFrecuenciaAcumulada)
        {//Inicia método que calcula la frecuencia acumulada
            //Declara subíndice local
            int i;
            //Asignación de primer valor
            dFrecuenciaAcumulada[0] = dFrecuenciaAbsoluta[0];  
            //For que va de cero a cantidad de clases
            for (i = 1; i < iCantidadClases; i++)
                dFrecuenciaAcumulada[i] = dFrecuenciaAcumulada[i - 1] + dFrecuenciaAbsoluta[i];//Divide cada valor entre el total y lo asigna al arreglo de frecuencias;//Inicializa arreglo de acumuladores de frecuencia sencillas
            //Código que calcula la frecuencia acumulada
        }//Termina método

        public static void calc_frecuencia_porcentual(int iCantidadClases, int iCantidadElementosNumericos, double[] dFrecuenciaAbsoluta, double[] dFrecuenciaPorcentual)
        {//Inicia método que calcula la frecuencia acumulada
            //Declara subíndice local
            int i;
            //For que va de cero a cantidad de clases
            for (i = 0; i < iCantidadClases; i++)
                dFrecuenciaPorcentual[i] = dFrecuenciaAbsoluta[i] / iCantidadElementosNumericos * 100; ;//Divide cada valor entre el total y lo asigna al arreglo de frecuencias;//Inicializa arreglo de acumuladores de frecuencia sencillas
            //Código que calcula la frecuencia acumulada
        }//Termina método

        public static void calc_frecuencia_porcentual_acumulada(int iCantidadClases, double[] dFrecuenciaPorcentual, double[] dFrecuenciaPorcentualAcumulada)
        {//Inicia método que calcula la frecuencia acumulada
            //Declara subíndice local
            int i;
            dFrecuenciaPorcentualAcumulada[0] = dFrecuenciaPorcentual[0];
            //For que va de cero a cantidad de clases
            for (i = 1; i < iCantidadClases; i++)
                dFrecuenciaPorcentualAcumulada[i] = dFrecuenciaPorcentual[i] + dFrecuenciaPorcentualAcumulada[i - 1]; ;//Divide cada valor entre el total y lo asigna al arreglo de frecuencias;//Inicializa arreglo de acumuladores de frecuencia sencillas
            //Código que calcula la frecuencia acumulada
        }//Termina método

}//Termina la clase frecuenciasHistograma_JW
