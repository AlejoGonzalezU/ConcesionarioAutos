namespace ConcesionarioAutos.Shared
{
    public class ResponseApi<T>
    {
        public bool isCorrect { get; set; }

        public T? Valor { get; set; }
        public string? Mensaje { get; set; }



    }
}