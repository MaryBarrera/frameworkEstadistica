///<summary>
///ESPAÑOL: Contien el método que calcula el valor mayor de las frecuencias absolutas de los histogramas
///ENGLISH: Contains the method that calculates the highest value of the absolute frequencies of the histograms
///</summary>

using System;

public class modaHistograma_JW
{//Inicia la clase modaHistograma_JW

    public static double calc_mayor(int n,double[] a)
    {//Inicia
        double valor_maximo = 0 ;//Declara e inicializa a valor maximo
        int i;//Subídice local i
            for(i=0;i<n;i++)//Inicia for de i que recorre el arreglo hasta n
                if(a[i]>valor_maximo)//If simple que compara si a[i] es mayor que valor_maximo
                    valor_maximo = a[i];//Asignación de valor maximo según lo almacenado en i
            return valor_maximo;//Devolución de valor maximo
    }//Termina método

    public static int calc_veces_clase_modal(int n, double[] temp, double mayor)
    {//Inicia método que cuenta la cantidad de veces que se repite la cantidad de elementos de la clase modal
        //double mayor;//Declara variable que almacenará resultado
        int i;//Subíndice local
        int cont=0;//Declara contador para cantidad de empates en emp_acum

        //mayor = calc_mayor(n,temp);//Llama a función que calcula el mayor valor del arreglo

        for(i=0;i<n;i++){//Abre ciclo for de i que recorre todos los valores hasta n
            if(temp[i]==mayor)//Condición que verifica cuantas veces se presenta la moda
                cont++;//Incrementa el contador cada vez que vuelve a encontrar el valor modal
        }//Cierra ciclo for de i que recorre todos los valores hasta n
                 return cont;//Devolución de valor maximo
    }//Termina método que cuenta la cantidad de veces que se repite la cantidad de elementos de la clase modal
}//Termina la clase modaHistograma_JW
