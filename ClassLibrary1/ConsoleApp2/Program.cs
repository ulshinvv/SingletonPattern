using ClassLibrary1;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Servers servers = Servers.Instance;

            // Добавление серверов
            Console.WriteLine(servers.AddServer("http://example.com"));  // True
            Console.WriteLine(servers.AddServer("https://example.org"));  // True
            Console.WriteLine(servers.AddServer("ftp://example.net"));    // False (не добавлен)

            // Добавление дубликатов
            Console.WriteLine(servers.AddServer("http://example.com"));  // False (уже существует)

            // Получение списка серверов по критериям
            Console.WriteLine("HTTP servers:");
            foreach (var server in servers.GetHttpServers())
            {
                Console.WriteLine(server);
            }

            Console.WriteLine("HTTPS servers:");
            foreach (var server in servers.GetHttpsServers())
            {
                Console.WriteLine(server);
            }
        }
    }
}