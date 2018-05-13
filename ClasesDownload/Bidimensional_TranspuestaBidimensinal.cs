//ENGLISH: this class calculate the calculate the matrix transpose of two-dimensional array
//EAPAÑOL: contiene a los métodos de cálculo de la matríz transpuesta bidimensional

using System;

public class transpuestaBidimensional_JW
{//Abre la clase          
    public static void calc_trans(int ren, int col,double[,] A_entrada,double[,] A_transpuesta)
    {//Inicia método que calcula la transpuesta
 
        int i,j; //subíndices de renglones y columnas
        for(i=0;i<ren;i++) //Inicia ciclo for de los renglones
            for(j=0;j<col;j++){  //Inicia ciclo for de las columnas
                A_transpuesta[j,i] = A_entrada[i,j];//Transpone cada elemento del arreglo | ENGLISH: exchange each element of the array
            }  //Termina ambos ciclos for
    }//Termina método que calcula la transpuesta                
}//Cierra la clase que contiene a los métodos de cálculo de la matríz transpuesta bidimensional