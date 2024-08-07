
namespace Application
{
    public class Operacoes
    {
        public static float Dividir(float n1, float n2)
        {
            if (n2 == 0)
                throw new DivideByZeroException("Não é possível dividir por zero");

            return n1 / n2;
        }

        public static float Multiplicar(float n1, float n2)
        {
            return n1 * n2;
        }

        public static float Somar(float n1, float n2)
        {
            return n1 + n2;
        }

        public static float Subtrair(float n1, float n2)
        {
            return n1 - n2;
        }
    }
}