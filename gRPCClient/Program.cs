using System;
using Grpc.Core;
using Helloworld;


namespace gRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure); //Creamos un nuevo canal de cliente incresando direccion y puerto del servidor

            var client = new Greeter.GreeterClient(channel); //Creamos un nuevo cliente, pasandole el servicio de proto (Greeter) y junto con el canal.
            
            String user = "you";
            var reply = client.SayHello(new HelloRequest { Name = user }); //Podemos invocar todos los metodos asociados al servicio de proto. En este caso todos los metodos del servicio Geeter. Hello Request es el modelo de datos de proto.
            Console.WriteLine("Greeting: " + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
