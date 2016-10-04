using BusinessLogicLibrary.Entities;
using EFModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI
{
    public class ConsoleIO
    {
        public string InputString(int inputType)
        {
            if (inputType == 1)
            {
                Console.Write("Enter Name : ");
            }
            else if (inputType == 2)
            {
                Console.Write("Enter Reason Type : ");
            }
            else if (inputType == 3)
            {
                Console.Write("Choice : ");
            }
            return Console.ReadLine();
        }

        public int InputNumber(int inputType)
        {
            int input = 0;
            bool cntr = false;
            while (!cntr)
            {
                if (inputType == 1)
                {
                    Console.Write("Enter Sales Reason Id : ");
                }
                else if (inputType == 2)
                {
                    Console.Write("Enter Bussiness Entity Id : ");
                }
                cntr = int.TryParse(Console.ReadLine(), out input);
                if (!cntr)
                    Console.WriteLine("Invalid Input");
            }          

            return input ;
        }

        public DateTime InputDateTime()
        {
            Console.Write("Enter Modified Date : ");
            return DateTime.Parse(Console.ReadLine());
        }

        public void DisplayMainChoices()
        {
            Console.WriteLine(
                "Choose Bellow\n" +
                "[a] Display All\n" +
                "[b] Display Sales Reason Record\n" +
                "[c] Insert New Sales Reason\n" +
                "[d] Delete Sales Reason\n" +
                "[e] Update Name\n" +
                "[f] Update Reason Type\n" +
                "[g] Count Sales Reason\n" +
                "[h] Get Employee Managers\n" +
                "[i] Exit"
                );
        }

        public void DisplayListOfSalesReason(List<SalesReason> salesReasons)
        {
            foreach (var sReason in salesReasons)
            {
                Console.WriteLine(" {0} | {1} | {2}   ", sReason.SalesReasonID, sReason.Name, sReason.ReasonType );
            }
        }
        public void DisplayListOfManagers(List<EmployeeModel> employees)
        {
            if (employees.Count > 0)
            {
                Console.WriteLine("Managers");
                foreach (var employee in employees)
                {
                    Console.WriteLine("  {0} {1} - {2} {3}", employee.FirstName, employee.LastName, employee.ManagerFirstName,employee.ManagerLastName);
                }
            }
            else
            {
                Console.WriteLine("No Managers Found");
            }

        }

        public void DisplayIfSuccess(bool condition, int successType)
        {
            if (successType == 1)
            {
                if (condition == true)
                    Console.WriteLine("Successfully Input");
                if (condition == false)
                    Console.WriteLine("Failed to Input");
            }
            else if (successType == 2)
            {
                if (condition == true)
                    Console.WriteLine("Successfully Update");
                if (condition == false)
                    Console.WriteLine("Failed to Update");
            }
            else if (successType == 3)
            {
                if (condition == true)
                    Console.WriteLine("Successfully Delete");
                if (condition == false)
                    Console.WriteLine("Failed to Delete");
            }
        }

        public void DisplayInvalid(int type)
        {
            if (type == 1)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine("Id does not exist");
            }
        }
        public void DisplaySalesReasonRecord(SalesReason sReason)
        {
                Console.WriteLine(" {0} | {1} | {2} | {3} ", sReason.SalesReasonID, sReason.Name, sReason.ReasonType, sReason.ModifiedDate);
            
        }

        

        public void DisplayCount(int count)
        {
            Console.WriteLine("Total Sales Reason : " + count);
        }

    }
}
