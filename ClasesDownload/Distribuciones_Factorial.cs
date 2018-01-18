  public class factorial_JW
    {//Abre la clase que calcula el factorial
        public static double calc_factorial(double dfactorial)//El método recibe un arreglo de double's y devuelve un solo valor double
        {//Inicia método que calcula el factorial
           
            double total = 1;//Declara la variable que almacenará resultado
            int i;//Declara la variable del ciclo for
            

             try
             {//Abre try

                 dfactorial = Math.Abs(dfactorial);//Obtiene valor absoluto por si se ingresó un valor negativo

                if (dfactorial == 0)//Corrección de información en caso
                    dfactorial = 1;  //de que se ingrese un cero al programa

                if (dfactorial == 1)//Verifica si se ingreso el valor de 1
                    return 1;//Devuelve el valor de factorial igual a 1
          

                if (dfactorial > 34)
                {//if simple con corrección de información en caso de exceder 34
                    dfactorial = 34;  //de que se ingrese un cero al programa
                }//Cierra if simple

                // Invocación recursiva de la funcion calc_factorial, no se usa por posible excepción de Stack Overflow
                // total = calc_factorial((double)Math.Abs((dfactorial - 1) * dfactorial));

                 // Cálculo no recursivo del factorial para evitar excepción de Stack Overflow
                for (i = 2; i <= dfactorial; i++)
                {
                    total = (double)Math.Abs(total * i);
                }


             }//Cierra try
                
            catch (Exception excepcion)
            {//Abre catch
                Console.WriteLine("Informe de error: \n" + excepcion.Message);
                throw;
            }//Cierra catch

            return total;//Devuelve valor factorial calculado recursivamente 
        }//Termina método que calcula el factorial
    }//Termina la clase que calcula el factorial