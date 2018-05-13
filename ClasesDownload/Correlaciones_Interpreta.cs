using System;

public class interpreta_JW
{//Abre la clase que contiene a los métodos para interpretar los valores de las correlaciones

    public static string interpreta_correlacion(double r)
    {//Inicia método que interpreta la correlacion

                string A = "";//Declara e inicializa la cadena A
                string B = "";//Declara e inicializa la cadena B

                if (r > 0 && Math.Abs(r) <= 1)//if simple que evalua los valores positivos
                    A = "Se observa que la correlación es positiva o ascendente ";

                if (r < 0 && Math.Abs(r) <= 1)//if simple que evalua los valores negativos
                    A = "Se observa que la correlación es negativa o descendente ";

                if (r == 0)//if simple que evalua el valor cero
                    A = "Se observa que no existe la correlación. \n";

                if (Math.Abs(r) > 0.0 && Math.Abs(r) < 0.3)//if simple que evalua la correlación muy debil
                    B = "y es excesivamente débil. \n";

                if (Math.Abs(r) >= 0.3 && Math.Abs(r) < 0.5)//if simple que evalua la correlación débil
                    B = "y es débil. \n";

                if (Math.Abs(r) >= 0.5 && Math.Abs(r) < 0.7)//if simple que evalua la correlación moderada
                    B = "y es moderada. \n";

                if (Math.Abs(r) >= 0.7 && Math.Abs(r) < 1.0)//if simple que evalua la correlación fuerte
                    B = "y es fuerte. \n";

                if (Math.Abs(r) == 1.0)//if simple que evalua la correlación perfecta
                    B = "y es perfecta. \n";

                if (Math.Abs(r) > 1.0)//if simple que evalua la correlación perfecta
                    A = "\n\nCuidado: revisar los datos. \n El valor del coeficiente de correlación excede el intervalo entre -1 y +1. \n";

                return A + B;//Devuelve la concatenación de las cadenas A y B

    }//Termina método que interpreta la correlacion
}//Cierra la clase que contiene a los métodos para interpretar los valores de las correlaciones