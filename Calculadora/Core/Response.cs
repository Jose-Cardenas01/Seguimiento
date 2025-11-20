namespace Calculadora.Core
{
    public class Response<T>
    {
        public bool success { get; set; }
        public T? Result { get; set; }
    }
}
