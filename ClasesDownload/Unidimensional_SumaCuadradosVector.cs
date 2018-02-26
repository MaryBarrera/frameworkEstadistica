public class sumaCuadradosVector_JW
//ESPAÑOL: Abre la clase que cálcula la suma de los cuadrados del vector que recibe
//ENGLISH: Open the class that calculate the sum of the   
{
  public static double CalculaSumaCuadrados(int j, double[] Vtemp, int i,double MediaDeArregloUnid)
  {//Inicia método que cálcula la suma de los cuadrados del vector que recibe

    int a; //subíndice de renglones o columnas
    double diferencia = 0;//Declara e inicializa la variable provisional que almacenará la diferencia
    double acumulador = 0;//Declara e inicializa el acumulador de los valores del arreglo    

    //ESPAÑOL: Inicia ciclo for de a que recorre el vector hasta j
    //ENGLISH: Start for loop from vector to j
    for(a=0; a<j; a++){
      try
      {//Abre try - Open try       
        //ESPAÑOL: Calcula la diferencia de la iteración entre el valor del vector y la media del arreglo
        //ENGLISH: Calulate the diference between 
        diferencia = Vtemp[a] - MediaDeArregloUnid;
      }//Cierra try - Close try

      catch (System.IndexOutOfRangeException eA1)
      {//Inicia el catch para controlar excepción IndexOutOfRangeException
        System.Console.WriteLine(eA1.Message);
      }//Cierra el catch para controlar excepción IndexOutOfRangeException                     
                                            
      acumulador = acumulador + Math.Pow(diferencia,2);//Acumula el valor de la diferencia
    }//Termina ciclo for de a que recorre el vector hasta j

    acumulador = acumulador * (double)i;//Calcula el valor final de la ssuma de cuadrados
    return acumulador;//Devuelve el resultado    
                                                             
  }//Termina método que cálcula la suma de los cuadrados del vector que recibe
}//Cierra la clase que cálcula la suma de los cuadrados del vector que recibe