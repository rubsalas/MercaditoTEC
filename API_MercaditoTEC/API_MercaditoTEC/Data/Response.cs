
namespace API_MercaditoTEC.Data
{
    /*
     * Modelo para usar en las respuestas de ciertos requests de la web o del app, necesarios en los controladores
     */
    public class Response
    {
        //Constructor
        public Response(string _controller, string _route, string _action)
        {
            controller = _controller;
            route = _route;
            action = _action;
        }

        //Constructor con mensaje
        public Response(string _controller, string _route, string _action, string _message)
        {
            controller = _controller;
            route = _route;
            action = _action;
            message = _message;
        }

        public string controller { get; set; }
        public string route { get; set; }
        public string action { get; set; }
        public string message { get; set; }
        public int value { get; set; }


        public void setValue(int _value)
        {
            value = _value;
        }

        public void setMessage(string _message)
        {
            message = _message;
        }

    }
}
