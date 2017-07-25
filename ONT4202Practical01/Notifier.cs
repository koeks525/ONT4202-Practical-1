using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    public class Notifier
    {
        public void SendSMS(String message, String phoneNumber)
        {
            Console.WriteLine("SENT SMS DETAILS: ");
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("Phone Number: " + phoneNumber);
            Console.WriteLine();
            Console.WriteLine("======================<END>=======================");
        }

        public void SendEmail(String message, String title, String emailAddress)
        {
            Console.WriteLine("SENT EMAIL DETAILS: ");
            Console.WriteLine();
            Console.WriteLine($"Subject: {title}");
            Console.WriteLine($"Recepient: {emailAddress}");
            Console.WriteLine("Message Details:");
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("=====================<END>=========================");
        }

        public void DisplayText(String text)
        {
            Console.WriteLine(text);
        }
    }
}
