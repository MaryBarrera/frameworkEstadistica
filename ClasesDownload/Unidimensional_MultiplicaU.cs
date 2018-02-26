public class multiplicaU_JW

//ESPAÑOL: Abre la clase que multiplica un vector por otro vector
//ENGLISH: Open the class that multiplies a vector by another vector
{
    public static double VectorPorVector(int a, double[] Vuni_1, double[] Vuni_2)
    //ESPAÑOL: Inicia método que multiplica un vector por otro vector
    //ENGLISH: Start method that multiplies a vector by another vector
    {
        //ESPAÑOL: Multiplica dos vectores unidimensionales
        //ENGISH: Multiply two one-dimensional vectors
        int i; //Declara subíndice local | Declare local subscript
        double r=0; //Declara e inicializa r en cero para almacenar el resultado | Declare and initialize r as zero to store the result
          for(i=0;i<a;i++)//Ciclo for de i que recorre los valores hasta a | for loop that traverses from i to a
          	//Multiplica los valores correspondientes de  Mbid_1 por Vuni_1 y los acumula en el elemento correspondiente de Vuni_2
          	//Multiply the corresponding values of Mbid_1 by Vuni_1 and accumulate them in the corresponding element of Vuni_2
            r = r + Vuni_1[i] * Vuni_2[i];
        return r;//Devuelve el resultado r | Returns the result r
    }//ESPAÑOL: Termina método que multiplica un vector por otro vector

}
//ESPAÑOL: Cierra la clase que multiplica un vector por otro vector
//ENGLISH: Close the class that multiplies a vector by another vector