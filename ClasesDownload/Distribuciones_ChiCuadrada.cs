public class chi_cuadrada_JW
    {//Abre la clase que calcula chi cuadrada

    public static double calc_chi_cuadrada(int n, double[,] temp)
    {//Inicia método que calcula chi cuadrada
  
        double chi=0; //Declara variable acumulador del resultado
        double dif_cua;//Declara variable temporal donde se almacena la diferencia entre el valor esperado y el observado al cuadrado
        int i; //Declara subíndice local

            for(i=0;i<n;i++){ //for de i que recorre todos los valores hasta n en renglones
                dif_cua = Math.Pow((temp[i,0]-temp[i,1]),2);//Calcula la diferencia entre el valor esperado y el observado al cuadrado
                chi = chi + (dif_cua / temp[i,1]);//Acumula en chi la diferencia al cuadrado entre el valor esperado de cada experimento
            }//Cierra ciclo for

        return chi;//Devuelve el valor calculado de chi
                                                  
    }//Termina método que calcula chi cuadrada

}//Cierra la clase que calcula chi cuadrada