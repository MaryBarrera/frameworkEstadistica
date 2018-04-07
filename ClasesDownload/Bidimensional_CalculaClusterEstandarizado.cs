using System;

public class calculaClusterEstandarizado_JW
{
	//ESPAÑOL: Abre la clase que contiene a los métodos que cálculan diversos parámetros de los clusters estandarizados
	//ENGLISH: This class contains the method that calculate different parameters of standardized clusters
    
    public static void calc_arreglo_estandarizado(int k, int n, double[] vec_medias_ca, double[] vec_desviaciones_std_ca, double[,] Abid_datos, double[,] Abid_Z_estandar)
    {//Inicia método 
      	
      	int i,j; //ESPAÑOL: Subíndices de renglones y columnas | ENGLISH: index for columns and rows 
      	
      	//ENGLISH: nested for loop to calculate the standar value of the variable 

      	for(i=0; i<n; i++){ //Inicia ciclo for de i que recorre el vector hasta n
        
      		for(j=0; j<k; j++){//Inicia ciclo for de j que recorre el vector hasta k

      			//Calcula el valor normalizado de la variable
          		Abid_Z_estandar[i,j] = (Abid_datos[i,j] - vec_medias_ca[j]) / vec_desviaciones_std_ca[j]; 

        	}//Termina ciclo for de j
      	}//Termina ciclo for de i
    }//Fin de método
}//Cierra la clase que contiene a los métodos que cálculan diversos parámetros de los clusters estandarizados