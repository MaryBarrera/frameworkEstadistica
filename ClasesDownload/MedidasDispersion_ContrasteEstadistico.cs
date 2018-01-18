public class ContrasteEstadistico_JW
{//Inicia clase ContrasteEstadistico_JW

  public static double calcContrasteUnif(double num, double denom)
  {//Inicia método que cálcula el contraste estadístico para ANOVA o ADEVA unifactorial
    double TS;//Declara variable local donde se almacenará el valor estadístico del contraste
    num = 5 * num;//Multiplica el numerador por cinco
    TS = num / denom ;//Divide numerador entre denominador
    return TS;//Devuelve el cociente de la división                                     
  }//Fin de método que cálcula el contraste estadístico para ANOVA o ADEVA unifactorial


  public static double calcContrasteBif(double suma_de_cuadrados_R_o_F, int j, double suma_de_cuadrados_errores, int i)
  {//Inicia método que cálcula el contraste estadístico para ANOVA o ADEVA bifactorial
    double TS;//Declara variable local donde se almacenará el valor estadístico del contraste
    double num;//Declara la variable del numerador
    double denom;//Declara la variable del denominador
    num = (suma_de_cuadrados_R_o_F) / (double)(j - 1);//Calcula el numerado
    denom = (suma_de_cuadrados_errores) / (double)((j - 1) * (i - 1));//Calcula el numerador
    TS = num / denom;//Divide numerador entre denominador
    return TS;//Devuelve el cociente de la división
  }//Fin de método que cálcula el contraste estadístico para ANOVA o ADEVA bifactorial
}//Termina clase ContrasteEstadistico_JW