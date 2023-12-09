using System;
using System.Net.Sockets;
using System.Text;
namespace ConsoleApp94
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Встановлюємо адресу сервера та порт для підключення
                TcpClient client = new TcpClient("127.0.0.1", 8888);
                Console.WriteLine("Підключено до сервера...");

                // Отримуємо NetworkStream для читання та запису даних
                NetworkStream stream = client.GetStream();

                // Введення запиту від користувача
                Console.Write("Введіть 'date' або 'time': ");
                string request = Console.ReadLine();

                // Відправляємо запит серверу
                byte[] requestData = Encoding.ASCII.GetBytes(request);
                stream.Write(requestData, 0, requestData.Length);

                // Отримуємо відповідь від серверу
                byte[] responseData = new byte[256];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                Console.WriteLine($"Отримано відповідь: {response}");

                // Закриваємо з'єднання
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

        }
    }
}