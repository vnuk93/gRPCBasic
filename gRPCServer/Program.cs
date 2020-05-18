using System;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;

namespace gRPCServer
{
    class GreeterImpl : Greeter.GreeterBase
    {
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }

    class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Greeter.BindService(new GreeterImpl()) }, //Bindea los metodos del codigo "Impl" con los servicio generado por proto (En este caso con el service Greeter de proto)
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) } //asignacion de direccion, puerto y seguridad
            };
            server.Start(); 

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }
    }
}
