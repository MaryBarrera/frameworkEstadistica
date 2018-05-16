//ESPAÑOL: la clase que calcula binomial bernoulli
//ENGLISH: this class content the method that calculate binomial bernoulli

using System;
 
public class binomialBernoulli_JW
{
    public static string calc_binomial_bernoulli(double n_pruebas, double n_inicio, double n_fin, double num_exitos, double prob_exito)//El método recibe cinco variables double y devuelve un solo valor double
    {//Inicia método que calcula las combinaciones
        
        string sCadenaBernoulli = "";
        string sParte1 = "", sParte2 = "", sParte3 = "";//Declara e incializa las cadenas a emplear cuando los valores no ocurran una sola vez
        string sTempBernoulli = "";//Declara e incializa las cadenas a emplear cuando los valores no ocurran una sola vez
            
        double prob_binom = 0;//Declara la variable que almacenará el valor del resultado
        double prob_frac;//Declara la variable que almacenará el valor de las probabilidades de fracaso
        int i=(int)n_inicio;//Subíndice local
        double sum = 0;
        double dValorTemp;//Valor para intercambio

        n_pruebas = Math.Abs(n_pruebas);//Obtiene valor absoluto por si se ingresó un valor negativo
        n_inicio = Math.Abs(n_inicio);//Obtiene valor absoluto por si se ingresó un valor negativo
        n_fin = Math.Abs(n_fin);//Obtiene valor absoluto por si se ingresó un valor negativo
        num_exitos = Math.Abs(num_exitos);//Obtiene valor absoluto por si se ingresó un valor negativo
        prob_exito = Math.Abs(prob_exito);//Obtiene valor absoluto por si se ingresó un valor negativo
        prob_frac = 1 - prob_exito;//Cálcula y asigna el valor de las probabilidades de fracaso 

        try
        {//Abre try
            if (n_inicio > n_fin)
            {//Abre if simple que calcula la binomial en un rango donde fin sea menor que inicio
                dValorTemp = n_inicio;//Asigna a variable temporal el valor de inicio
                n_inicio = n_fin;//Asigna a inicio el valor de fin
                n_fin = dValorTemp;//Asigna a valor final el valor de la temporal y concluye el intercambio

                sParte1 = "\nNum de exitos\tProbabilidad \n";
                for (i = (int)n_inicio; i <= (int)n_fin; i++)
                {//Abre for de i que recorre el rango solicitado cuando inicio sea menor que fin
                    prob_binom = (double)Math.Abs(combinacion_JW.calc_combinacion(n_pruebas, i) * Math.Pow(prob_exito, i) * Math.Pow(prob_frac, (n_pruebas - i)));//Cálculo de la la probabilidad de la distribución binomial o de Bernoulli
                    // printf("    %.4f    \t     %.4f \n", i, prob_binom);//Imprime el resultado
                    sum = (double)sum + (double)prob_binom;//Acumula la suma de valores de la probabilidad de la distribución binomial         
                    sTempBernoulli = Convert.ToString(i) + "\t   \t" + Convert.ToString(Math.Round((double)prob_binom, 4)) + "\n";
                    sParte2 = sParte2 + sTempBernoulli; //Agrega todas las clases modales que aparecieron en el análisis 
                }//Cierra for de i    

                // printf("\nLa probabilidad total del rango en distribucion binomial es %.4f \n", sum);//Imprime el resultado 
                sParte3 = "\nLa probabilidad total del rango en distribucion binomial es " + Convert.ToString(Math.Round((double)sum, 4)) + "\n";
                sCadenaBernoulli = sParte1 + sParte2 + sParte3; //Junta las cadenas

                //sCadenaBernoulli = "\n (SWAP) Entró a: n_inicio > n_fin con: \n n_inicio = " + Convert.ToString(n_inicio) + "\n n_fin = " + Convert.ToString(n_fin);//Texto de prueba
            }//Cierra if simple
            else
                
            if (n_inicio == n_fin)
            {//Abre if simple que calcula la binomial en un caso único
                //prob_binom = calc_combinacion(n_pruebas, num_exitos) * pow(prob_exito, num_exitos) * pow(prob_frac, (n_pruebas - num_exitos));//Cálculo de la la probabilidad de la distribución binomial o de Bernoulli
                prob_binom = combinacion_JW.calc_combinacion(n_pruebas, num_exitos) * Math.Pow(prob_exito, num_exitos) * Math.Pow(prob_frac, (n_pruebas - num_exitos));//Cálculo de la la probabilidad de la distribución binomial o de Bernoulli
                   
                //  printf("\nLa probabilidad de la distribucion binomial es %.4f \n", prob_binom);//Imprime el resultado             
                sCadenaBernoulli = "\nLa probabilidad de la distribucion binomial es " + Convert.ToString(Math.Round(prob_binom, 4)) + "\n";
                //  sCadenaBernoulli = "\n Entró a: n_inicio == n_fin con: \n n_inicio = " + Convert.ToString(n_inicio) + "\n n_fin = " + Convert.ToString(n_fin);//Texto de prueba
                return sCadenaBernoulli;//Devuelve valor de la combinación
            }//Cierra if simple
            else

            if (n_inicio < n_fin)
            {//Abre if simple que calcula la binomial en un rango donde inicio sea menor que fin
                //  printf("\nNum de exitos \t Probabilidad \n");//Imprime encabezado
                sParte1 = "\nNum de exitos\tProbabilidad \n";
                for (i = (int)n_inicio; i <= (int)n_fin; i++)
                {//Abre for de i que recorre el rango solicitado cuando inicio sea menor que fin
                    prob_binom = (double)Math.Abs(combinacion_JW.calc_combinacion(n_pruebas, i) * Math.Pow(prob_exito, i) * Math.Pow(prob_frac, (n_pruebas - i)));//Cálculo de la la probabilidad de la distribución binomial o de Bernoulli
                    // printf("    %.4f    \t     %.4f \n", i, prob_binom);//Imprime el resultado
                    sum = (double)sum + (double)prob_binom;//Acumula la suma de valores de la probabilidad de la distribución binomial         
                    sTempBernoulli = Convert.ToString(i) + "\t   \t" + Convert.ToString(Math.Round((double)prob_binom, 4)) + "\n";
                    sParte2 = sParte2 + sTempBernoulli; //Agrega todas las clases modales que aparecieron en el análisis 
                }//Cierra for de i    
                    
                // printf("\nLa probabilidad total del rango en distribucion binomial es %.4f \n", sum);//Imprime el resultado 
                sParte3 = "\nLa probabilidad total del rango en distribucion binomial es " + Convert.ToString(Math.Round((double)sum, 4)) + "\n";
                sCadenaBernoulli = sParte1 + sParte2 + sParte3; //Junta las cadenas
                // sCadenaBernoulli = "\n Entró a: n_inicio < n_fin con: \n n_inicio = " + Convert.ToString(n_inicio) + "\n n_fin = " + Convert.ToString(n_fin);//Texto de prueba
            }//Cierra if simple            
        }//Cierra try

        catch (Exception excepcion)
        {//Abre catch
            Console.WriteLine("Informe de error: \n" + excepcion.Message);
            throw;
        }//Cierra catch

        return sCadenaBernoulli;//Devuelve valor de la combinación

    }//Termina método que calcula las combinaciones

}//Termina la clase que calcula binomial bernoulli