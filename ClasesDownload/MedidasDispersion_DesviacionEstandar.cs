public class desviacion_estandar_JW//Abre la clase que calcula la desviación estándar
{
    public static double calc_desviacion_estandar(double varianza)//El método recibe un arreglo de double's y devuelve un solo valor double
    {//Inicia método
        double desv_est; //Declara variable local desv_est
        desv_est = Math.Sqrt(varianza);//Calcula raíz cuadrada de la varianza
        return desv_est;//Devuelve desv_est
    }//Termina método


    public static void calc_desviaciones_std_muestras(int k,double[] vec_varianzas_ca,double[] vec_desviaciones_std_cavec_varianzas_ca)
    {//Inicia método
        int i; //Subíndice local
        for(i=0;i<k;i++)//Inicia ciclo for de i que recorre el vector hasta k
        vec_desviaciones_std_cavec_varianzas_ca[i] = Math.Sqrt(vec_varianzas_ca[i]);//Calcula la desviación estándar de cada varianza                                                                                                         
    }//Fin de método
}//Cierra la clase que calcula la desviación estándar