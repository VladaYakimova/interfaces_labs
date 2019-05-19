using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using SimpleJSON;
using System.Collections.Specialized;
using Telegram.Bot;
using System.Text.RegularExpressions;

namespace Lab1_Console
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("883601079:AAG6P60xi1Ycde9tDYE-nr8fg7-H-yJ4wKg");
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private static readonly Regex regID = new Regex(@"\d+");
        private static readonly Regex regName = new Regex(@"!\d+");
        static void Main(string[] args)
        {        
            Console.WriteLine("Отправка и получение сообщений. Бот: @VladaYakimovaBot ");

            Bot.OnMessage += Bot_OnMessage;
            string message = "";
            string userID = "";
            string command;
            bool exception = false;
            while (true)
            {
                Console.WriteLine("Для отправки сообщений введите - 1");
                Console.WriteLine("Для просмотра полученых сообщений введите - 2");
            
                Console.Write("$");
                command = Console.ReadLine();
                switch (command)
                {
                    case "2":
                        Console.WriteLine("Полученные сообщения:"+"\n"+"(для выхода нажмите любую клавишу)" + "\n");
                        Bot.StartReceiving();
                        Console.ReadKey();
                        Bot.StopReceiving();                     
                        break;
                    case "1":
                        do
                        {                         
                            foreach (KeyValuePair<string, string> keyValue in users)
                            {
                                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                            }

                            Console.Write('\n' + "ID пользователя, которому вы хотите отправит сообщение:" + "\n" + "(чтобы отправить сообщение администратору введите - a)" + "\n" + '\n');
                            userID = Console.ReadLine();
                            Console.Write('\n' + "Напишите сообщение" + '\n' + ">");
                            message = Console.ReadLine();
                            if(userID=="a")
                            Bot.SendTextMessageAsync("vladavh", message);
                            Bot.SendTextMessageAsync(userID, message);
                            exception = false;
                        }
                        while (exception);
                        break;
                    default:
                        Console.Write('\n' + "Неверная команда");
                        break;
                }
                Console.Write('\n' + "_________________________________________________________" + '\n');
            }
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                try
                {
                    users.Add(e.Message.From.ToString().Substring(0, e.Message.From.ToString().IndexOf(' ')), regID.Match(e.Message.From.ToString()).ToString());
                }
                catch (ArgumentException) { }
                if (e.Message.IsForwarded)
                {
                    try
                    {
                        users.Add(e.Message.ForwardFrom.ToString().Substring(0, e.Message.From.ToString().IndexOf(' ')), regID.Match(e.Message.ForwardFrom.ToString()).ToString());
                    }
                    catch (ArgumentException) { }
                    Console.Write("\n" + "Переслано от: " + e.Message.ForwardFrom.ToString().Substring(0, e.Message.From.ToString().IndexOf(' ')));
                }
                    Console.Write("\n" + e.Message.From.ToString().Substring(0, e.Message.From.ToString().IndexOf(' ')) + ": ");
                    Console.Write(e.Message.Text + "  ");
                    Console.Write(e.Message.Date.ToLocalTime()+"\n");
            }
            else {
                Console.WriteLine("Получен файл"); }
        }
    }
}
