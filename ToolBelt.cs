using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBelt
{
    class Program
    {
        static void Main(string[] args)
        {
            ToolBelt tool = new ToolBelt();



            tool.Read();
        }
    }

    class ToolBelt //BlaccSunV1
    {
        //To Initialize --->    ToolBelt (Instance Name) = new ToolBelt();
        //To Use Function(s) -->  (InstanceName).(ToolName)();

        // Temporary Variables
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Email;
        static string numbers = "0123456789";
        // grab Commands- Directly Ask The User To Enter Variable Value(s) Through Prompts
        public string grabContact()
        {
            bool keepGoing = true; string FullName = "";
            while (keepGoing)
            {
                grabFirstName();
                grabLastName();
                FullName = LastName + "," + FirstName;
                grabPhoneNumber();
                grabEmail();
                Write("Contact\n" + FullName + "\n" + PhoneNumber + "\n" + Email + "\n\nSave Contact?[Y]/[N]");
                string input = ReadLow();
                if (input == "y") { clear(); Write($"Contact \"{FullName}\" Saved\n\nPress[Enter]To Continue..."); Read(); keepGoing = false; clear(); }
                if (input == "n") { clear(); Write($"Contact \"{FullName}\" Deleted\n\nPress[Enter]To Continue..."); Read(); }
                else { Write("Invalid Answer. Please Select\n[Y]Yes\nOr\n[N]NO\n\nPress[Enter]To Continue..."); Read(); }
            }
            return FullName + "\nPhone Number: " + PhoneNumber + "\nEmail Address: " + Email;
        }
        public string grabFirstName()
        {
            clear(); FirstName = grabString("Please Enter First Name:"); clear();
            return FirstName;
        }
        public string grabLastName()
        {
            clear(); LastName = grabString("Please Enter Last Name:"); clear();
            return LastName;
        }
        public string grabPhoneNumber()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                clear();
                PhoneNumber = grabIntString("Please Enter Phone Number:");
                if (PhoneNumber.Length != 10)
                { Write("There Should be Exactly 10 Numbers In Your Phone Number\nXXX-XXX-XXXX\n\nPress[Enter]To Continue..."); Read(); }
                if (PhoneNumber.Length == 10)
                { clear(); keepGoing = false; }
            }
            return PhoneNumber;
        }
        public string grabEmail()
        {
            clear(); Email = grabString("Please Enter Email:"); clear();
            return Email;
        }
        public string[,] grab2DStringArray(string prompt)
        {
            int x = 0; int y = 0;
            x = grabInt(prompt + "\n\nHow Many Rows Will It Have?");
            y = grabInt(prompt + "\n\nHow Many Columns Will It Have?");
            string[,] Array = new string[x, y];
            return Array;
        }
        public string[] grabStringArray(string prompt)
        {
            int x = 0;
            x = grabInt(prompt + "\n\nHow Long Will It Be?");
            string[] Array = new string[x];
            return Array;
        }
        public string grabString(string prompt)
        {
            bool keepGoing = true; string words = "";
            while (keepGoing)
            {
                clear(); Write(prompt + "\n"); string input = Read();
                for (int i = 0; i < input.Length; i++)
                {
                    if (numbers.Contains(input[i]))
                    { clear(); Write("Invalid Entry, Please Enter A-Z Or A Symbol Only.\n\nPress[Enter] To Continue..."); Read(); }
                    else
                    { words = input; keepGoing = false; clear(); }
                }
            }
            return words;
        }
        public string grabIntString(string prompt)
        {
            bool keepGoing = true; string number = "";
            {
                while (keepGoing)
                {
                    clear(); Write(prompt + "\n");
                    string input = Read(); clear();
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (numbers.Contains(input[i]))
                        { number = input; keepGoing = false; clear(); }
                        else
                        { Write("Invalid Entry, Please Enter Numbers Only.\n\nPress[Enter] To Continue..."); Read(); }
                    }
                }
            }
            return number;
        }
        public int[,] grab2DIntArray(string prompt)
        {
            int x = 0; int y = 0;
            x = grabInt(prompt + "\n\nHow Many Rows Will It Have?");
            y = grabInt(prompt + "\n\nHow Many Columns Will It Have?");
            int[,] Array = new int[x, y];
            return Array;
        }
        public int[] grabIntArray(string prompt)
        {
            int x = 0;
            x = grabInt(prompt + "\n\nHow Long Will It Be?");
            int[] Array = new int[x];
            return Array;
        }
        public int grabInt(string prompt)
        {
            bool keepGoing = true; int number = 0;
            {
                while (keepGoing)
                {
                    clear(); Write(prompt + "\n"); string input = Read(); clear();
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (numbers.Contains(input[i]))
                        { number = toInt(input); keepGoing = false; clear(); }
                        else
                        { Write("Invalid Entry, Please Enter Numbers Only.\n\nPress[Enter] To Continue..."); Read(); }
                    }
                }
            }
            return number;
        }

        // Short Commands- To Be Used For ShortHand References
        public void clear()
        {
            Console.Clear();
        }
        public string Read()
        {
            return Console.ReadLine();
        }
        public string ReadLow()
        {
            return Read().ToLower();
        }
        public string ReadUp()
        {
            return Console.ReadLine().ToUpper();
        }
        public void Write(string prompt)
        {
            Console.WriteLine(prompt);
        }
        public int toInt(string input)
        {
            return Convert.ToInt16(input);
        }
        public string toString(int input)
        {
            return input.ToString();
        }
    }
}
