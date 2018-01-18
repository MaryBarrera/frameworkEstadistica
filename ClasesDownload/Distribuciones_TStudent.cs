    public class t_student_JW
    {//Abre la clase que calcula la t de student 

        public static double calc_t_student(int n, double promedio_muestra, double desv_est, double promedio_poblacion)//El método recibe un arreglo de double's y devuelve un solo valor double
        {//Inicia método que calcula t de student

            double t_student; //declara variable del resultado

            t_student = (promedio_muestra - promedio_poblacion) / (desv_est / Math.Sqrt((float)n));//Calcula el valor de t de student

            return t_student;//Devuelve el valor calculado de t_student

        }//Termina método que calcula t de student

    }//Termina la clase que calcula t de student