namespace Application.Wrappers
{
    //clase estandar para responder las API.
    public class Response<T>
    {
        public Response() { }

        public Response(T data, string message = null) {
            Succeed = true;
            Message = message;
            Data = data;
        }
        public Response( string message = null)
        {
            Message = message;
            Succeed = false;
        }


        public bool Succeed { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set} 

        public T Data { get; set; }
    }
}
