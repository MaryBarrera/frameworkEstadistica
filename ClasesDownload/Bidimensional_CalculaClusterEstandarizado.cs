using System;

public class calculaClusterEstandarizado_JW
{//Abre la clase que contiene a los métodos que cálculan diversos parámetros de los clusters estandarizados

    public static void calc_arreglo_estandarizado(int k, int n, double[] vec_medias_ca, double[] vec_desviaciones_std_ca, double[,] Abid_datos, double[,] Abid_Z_estandar)
    {//Inicia método
      int i,j; //Subíndices de renglones y columnas
      for(i=0;i<n;i++){//Inicia ciclo for de i que recorre el vector hasta n
        for(j=0;j<k;j++){//Inicia ciclo for de j que recorre el vector hasta k
          Abid_Z_estandar[i,j] = (Abid_datos[i,j] - vec_medias_ca[j]) / vec_desviaciones_std_ca[j]; //Calcula el valor normalizado de la variable   
        }//Termina ciclo for de j
      }//Termina ciclo for de i
    }//Fin de método
}//Cierra la clase que contiene a los métodos que cálculan diversos parámetros de los clusters estandarizados