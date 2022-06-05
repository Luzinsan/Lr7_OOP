using luMath;


public class Program
{
    public static int Sqr(int i) => i * i;

    static void Main(string[] args)
    {
        Matrix m = new Matrix();
        Vector v = new Vector();
        double[] vec = new double[3] {1, 2, 3};
        Vector v1 = new Vector(3, vec, true);
        Vector v2 = new Vector(3, vec, false);
        Vector v3 = new Vector(3, vec, false);

       
        
        Console.WriteLine("Vector v1: \n{0}", v1);
        Console.WriteLine("Vector v2: {0}", v2);

        Console.WriteLine("v1 * v2:\n{0}", v1 * v2);

        m = v1 * v2;

        Console.WriteLine("Матрица из произведений векторов:\n{0}", m);

        //v = v1 * v2;

        v = v2 + v3;

        Console.WriteLine("Вектор суммы векторов: {0}", v);

        Console.WriteLine("Транспонированный вектор:\n{0}", Vector.Transpose(v));

        m = v2 + v3;

        v2 =  (Vector)m + v3;

        Console.WriteLine("Матрица из суммы векторов: {0}", v2);

        Console.WriteLine("Максимальный элемент вектора: {0}\n", Matrix.MaxValue(v));

        Console.WriteLine("Минимальный элемент вектора: {0}\n", Matrix.MinValue(v));
    }
}
