using panel_context_customer.Models;
using panel_services_core.Infrastructure.Repository;
using Renci.SshNet;

namespace panel_services_core.Services
{
    public interface IServicesService 
    {
        List<Service> Get();
    
    }

    public class ServicesService : IServicesService
    {
        readonly IServicesRepository _servicesRepository;
       
       public ServicesService(IServicesRepository servicesRepository)
       {
            _servicesRepository = servicesRepository;
       }

       public List<Service> Get() {

            /*
            * Requisição p um server linux
            * retornando uma lista d containers 
            */
            
            //var privateKey = new PrivateKeyFile(@"C:\Users\Cecilia Acadêmico\Downloads\puttyKeyOpenSSH");
            var privateKey = new PrivateKeyFile(@"C:\Users\maria\Downloads\puttyKeyOpenSSH");
                var client = new SshClient("18.230.31.13", 22, "ubuntu", privateKey);
                client.Connect();
                var command = "sudo docker ps -a";
                var result = client.RunCommand(command);

                var lista = new List<Service>();
                
                string[] lines = result.Result.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string line in lines)
                    {
                        if(!line.Contains("CONTAINER ID")) //P nn incluir a primeira linha q tem os nomes das colunas
                            {
                                lista.Add(new Service(line));
                            }   
                    }

           return lista;

       }

    }
}
