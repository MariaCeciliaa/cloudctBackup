using System.Text.RegularExpressions;
//using Renci.SshNet;

namespace panel_context_customer.Models
{
    public class Service 
    {
            public Service(string line)
            {
                //classe Regex para dividir a linha com base em um padrão 
                //de espaços em branco consecutivos (\s{2,}). Essa expressão regular considera 
                //dois ou mais espaços em branco consecutivos como o separador entre as colunas.

                string pattern = @"\s{2,}"; 
                string[] values = Regex.Split(line.Trim(), pattern);

                if (values.Length >= 7)
                {
                    Id = values[0];
                    Image = values[1];
                    Command = values[2];
                    Created = values[3];
                    Status = values[4];
                    Ports = values[5];
                    Names = values[6];

                    SplitPorts(Ports); //metodo q divide as variaveis do ports
                }
            }

            private void SplitPorts(string ports)
            {
                string[] portValues = ports.Split(',');

                //ipv4 valores
                string[] ipv4Values = portValues[0].Trim().Split(':');
                OriginIPV4 = ipv4Values[0];

                string[] ipv4ValuesPorts = ipv4Values[1].Trim().Split("->");
                ServerPortIPV4 = int.Parse(ipv4ValuesPorts[0].Trim());
                ContainerPortIPV4 = int.Parse(ipv4ValuesPorts[1].Trim().Replace("/tcp", string.Empty)); //tira o tcp do final 

                //ipv6 valores
                string separador = ":::";
                string[] ipv6Values = portValues[1].Split((separador), 2);
                OriginIPV6 = separador;

                string[] ipv6ValuesPorts = ipv6Values[1].Trim().Split("->");
                ServerPortIPV6 = int.Parse(ipv6ValuesPorts[0].Trim());
                ContainerPortIPV6 = int.Parse(ipv6ValuesPorts[1].Trim().Replace("/tcp", string.Empty));
                
            }

        public string Id { get; set; } = "";
        public string Image { get; set; } = "";
        public string Command { get; set; } = "";
        public string Created { get; set; } = "";
        public string Status { get; set; } = "";
        public string Ports { get; set; } = "";
        public string OriginIPV4 { get; set; } = "";
        public int ServerPortIPV4 { get; set; } 
        public int ContainerPortIPV4 { get; set; } 
        public string OriginIPV6 { get; set; } = "";
        public int ServerPortIPV6 { get; set; } 
        public int ContainerPortIPV6 { get; set; } 
        public string Names { get; set; } = "";
        

    }
}