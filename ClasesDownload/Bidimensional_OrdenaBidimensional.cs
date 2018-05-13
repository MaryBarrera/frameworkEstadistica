//ENGLISH: this class content the quick sort method to sort two-dimensional matrix

using System;

public class ordenaBidimensional_JW
{//Abre la clase que contiene a los métodos de ordenamiento rápido por quick sort bidimensional

    public static void ordenamiento_rapido_bid(double[,] datos, int lim_inf, int lim_sup)
    {//Método de ordenamiento rápido para arreglos bidimensionales implementado con recursividad

        int inf,sup;//Declara las variables que almacenarán a los valores inferior y superior respectivamente
        double pivote_central;//Se implementa le método de ordenamiento rápido empleando el pivote al centro
        double aux_0, aux_1;//La variables aux_0 y aux_1 serviran para almacenar temporalmente los intercambios de valores
        inf=lim_inf;//Define el valor inferior de cada invocación
        sup=lim_sup;//Define el valor superior de cada invocación
        pivote_central=datos[(inf+sup)/2,0];//Define el pivote al centro del intervalo en cada invocación
    
            do{//Inicia do-while que evalua si el valor inferior es menor o igual que el superior

                while(datos[inf,0]<pivote_central&&inf<lim_sup)//while que incrementa al valor inferior en columna cero
                    inf++;//Incrementa el valor inferior

                  try
                  {//Abre try
                    while (pivote_central < datos[sup, 0] && sup > lim_inf)//while que decrementa al valor superior en columna cero
                      sup--;//Decrementa el valor superior
                  }//Cierra try  

                  catch (System.IndexOutOfRangeException e)
                  {//Inicia el catch para controlar excepción IndexOutOfRangeException
                    System.Console.WriteLine(e.Message);
                  }//Cierra el catch para controlar excepción IndexOutOfRangeException



                if(inf<=sup){//if simple que evalua si el valor inferior es menor o igual que el superior
                    aux_0=datos[inf,0];//La variable aux_0 toma provisionalmente el valor de datos[inf] en columna cero
                    aux_1=datos[inf,1];//La variable aux_1 toma provisionalmente el valor de datos[inf] en columna uno
                    datos[inf,0]=datos[sup,0];//datos[inf] [0] toma el valor de datos[sup][0]
                    datos[inf,1]=datos[sup,1];//datos[inf] [1]toma el valor de datos[sup][1]
                    datos[sup,0]=aux_0;//Se realiza el intercambio "swap" de valores entre variables de coluna cero
                    datos[sup,1]=aux_1;//Se realiza el intercambio "swap" de valores entre variables de coluna uno
                    inf++;//Incrementa el valor inferior
                    sup--;//Decrementa el valor superior
                      }//Fin de if simple
   
            }while(inf<=sup);//Fin de do-while
      
            if(lim_inf<sup)//if simple que evalua si el límite inferior es menor al valor superior para invocar a ordenamiento_rapido
                ordenamiento_rapido_bid(datos,lim_inf,sup);//Invoca a ordenamiento rápido con los parámetros de inicio y fin
 
            if(lim_sup>inf)//if simple que evalua si el límite superior es mayor al valor inferior para invocar a ordenamiento_rapido
                ordenamiento_rapido_bid(datos,inf,lim_sup);//Invoca a ordenamiento rápido con los parámetros de inicio y fin
     
        }//Fin de método ordenamiento_rapido_bid



        public static void ordena_qs_bid(int ren, int col, double[,] datos)
        {//Función ordena_qs_bid invoca a ordenamiento rápido y envía límites de inicio y fin
       
            ordenamiento_rapido_bid(datos,0,ren-1);//Invoca a ordenamiento rápido con los parámetros de inicio y fin

        }//Fin de método ordena_qs_bid

}//Cierra la clase que contiene a los métodos de ordenamiento rápido por quick sort bidimensional