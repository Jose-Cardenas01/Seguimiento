namespace Tareas.Core
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Result{ get; set; }

        public static Response<T> Succeded(T result, string Message="Tarea realizada con extio")
        {
            return new Response<T>
            {
                Success = true,
                Message = Message,
                Result = result
            };
        }
        public static Response<T> Succeded(string Message="Tarea realizada con extio")
        {
            return new Response<T>
            {
                Success = true,
                Message = Message
            };
        }
        public static Response<T> Failure(Exception ex, string Message = "No se pudo completar la tarea")
        {
            return new Response<T>
            {
                Success = false,
                Errors = new List<string>
                {
                    ex.Message
                },
                Message = Message,
            };
        }
    }
}
