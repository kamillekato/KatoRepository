using BusinessLogicLibrary;
using EFModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic bLogic = new BusinessLogic();
            ConsoleIO IO = new ConsoleIO();

            while (true)
            {
                IO.DisplayMainChoices();
                string choice = IO.InputString(3);
                switch (choice.ToLower())
                {
                    case "a":
                        IO.DisplayListOfSalesReason(bLogic.DisplayAllSalesReason());
                        break;
                    case "b":
                        var id = IO.InputNumber(1);
                        if (!bLogic.CheckIfIdIsExisting(id))
                        {
                            IO.DisplayInvalid(2);
                            break;
                        }

                        IO.DisplaySalesReasonRecord(
                            bLogic.DisplaySalesReason(id)
                        );
                        break;
                    case "c":
                        IO.DisplayIfSuccess(
                            bLogic.AddSalesReason( new SalesReason() { 
                            Name = IO.InputString(1),
                            ReasonType = IO.InputString(2)
                            }),1
                            );
                        break;
                    case "d":
                        id = IO.InputNumber(1);
                        if (!bLogic.CheckIfIdIsExisting(id))
                        {
                            IO.DisplayInvalid(2);
                            break;
                        }
                        IO.DisplayIfSuccess(
                            bLogic.DeleteSalesReason(id),3
                            );
                        break;
                    case "e":
                        id = IO.InputNumber(1);
                        if (!bLogic.CheckIfIdIsExisting(id))
                        {
                            IO.DisplayInvalid(2);
                            break;
                        }
                        var salesReason = bLogic.DisplaySalesReason(id);
                        IO.DisplaySalesReasonRecord(salesReason);
                        salesReason.Name = IO.InputString(1);
                        IO.DisplayIfSuccess(
                        bLogic.UpdateSalesReason(
                            salesReason
                            ),
                        2
                        );
                        break;
                    case "f":
                        id = IO.InputNumber(1);
                        if (!bLogic.CheckIfIdIsExisting(id))
                        {
                            IO.DisplayInvalid(2);
                            break;
                        }
                        salesReason = bLogic.DisplaySalesReason(id);
                        IO.DisplaySalesReasonRecord(salesReason);
                        salesReason.ReasonType = IO.InputString(2);
                        IO.DisplayIfSuccess(
                        bLogic.UpdateSalesReason(
                            salesReason
                            ), 2
                        );
                        break;
                    case "g":
                        IO.DisplayCount(
                            bLogic.CountSalesReason()
                            );
                        break;
                    case "h":
                        IO.DisplayListOfManagers(
                            bLogic.DisplayEmployeeManagers(IO.InputNumber(2))
                            );
                        break;
                    case "i":
                        Environment.Exit(0);
                        break;
                    default:
                        IO.DisplayInvalid(1);
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
