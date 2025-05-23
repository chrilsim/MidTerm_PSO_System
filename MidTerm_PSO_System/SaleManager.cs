using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
    //   -id
    //-CustomerId(Optional)
    //-SaleDate(date)
    //-UserId
    //-TotalAmount

    internal class SaleManagerment
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public bool anyUpdate = false;
        public static List<SaleManagerment> SaleList = new List<SaleManagerment>();
        public SaleManagerment() { }

        public SaleManagerment(int id, int customerId, DateTime saleDate, int userId, double totalAmount)
        {
            Id = id;
            CustomerId = customerId;
            SaleDate = saleDate;
            UserId = userId;
            TotalAmount = totalAmount;
        }
        string UserAndAdmin;
        public void ManuSaleManagerment()
        {
            while (true)
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    UserAndAdmin = "User";

                }
                else
                {
                    UserAndAdmin = "Admin";
                }
                Console.WriteLine("-----------------------Manu Sale Managerment-------------------- ");
                Console.WriteLine("1.Add Sale");
                Console.WriteLine("2.show Sale");
                Console.WriteLine("3.Update Sale");
                Console.WriteLine("4.Delete Sale");
                Console.WriteLine("5.Search Sale");
                Console.WriteLine($"6.Back POS System {UserAndAdmin}");
                Console.WriteLine("------------------------------------------------------------------");

                Console.Write("Pleas Select option :");
                string input = Console.ReadLine();
                int option;
                int Case;
                if (int.TryParse(input, out Case))
                {
                    option = Case;
                    switch (option)
                    {
                        case 1:

                            AddSale();
                            break;
                        case 2:
                            ShowSale();
                            break;
                        case 3:
                            UpdateSale();
                            break;
                        case 4:
                            DeleteSale();
                            break;
                        case 5:
                            SearchSale();
                            break;
                        case 6:
                            if (!UserCheck.chackUserOrAdmin)
                            {
                                Manu_POS_System manu_POS_System = new Manu_POS_System();
                                manu_POS_System.Manu_POS_User();
                            }
                            else
                            {
                                Manu_POS_System manu_POS_System = new Manu_POS_System();
                                manu_POS_System.Manu_POS_Admin();
                            }
                            
                            break;
                        default:
                            Console.WriteLine("Please input Number To 1 and 6!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!:{input} Please enter a valid number  Not string!.");
                }
            }
        }
        public void AddSale()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to add sales.!\n");
                ManuSaleManagerment();
                return;
            }
            try
            {
                Console.Write("input Count Add Sale:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information Sale {i + 1}--------------------\n");
                    SaleManagerment sale = new SaleManagerment();
                start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (SaleList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        sale.Id = inputId;

                    }
                    Console.Write("input CustomerId:");
                    sale.CustomerId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("input UserId:");
                    sale.UserId = Convert.ToInt32(Console.ReadLine());

                    SaleList.Add(sale);
                    Console.WriteLine("\n Add Sale successfully!\n");

                    anyUpdate = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
      
        public void ShowSale()
        {
            foreach (SaleManagerment sale in SaleList)
            {
                double totalAmount = SaleDetailManagerment.saleDetailList
                    .Where(detail => detail.SaleId == sale.Id)
                    .Sum(detail => detail.Qty * detail.Price);

                sale.TotalAmount = totalAmount;
            }


            Console.WriteLine("------------------------------------------ Sale Management List ------------------------------------------");
            string header = string.Format("{0,-10}{1,-25}{2,-20}{3,-15}{4,-15}", "Id", "CustomerId", "SaleDate", "UserId", "TotalAmount");
            Console.WriteLine(header);

            foreach (SaleManagerment sale in SaleList)
            {
                
                sale.SaleDate = DateTime.Now;

                Console.WriteLine("---------------------------------------------------------------------------------------------");
                string row = string.Format("{0,-10}{1,-25}{2,-20}{3,-15}{4,-15}",
                    sale.Id, sale.CustomerId,sale.SaleDate,sale.UserId, sale.TotalAmount);

                Console.WriteLine(row);
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }
        public void UpdateSale()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to Update sales.!\n");
                ManuSaleManagerment();
                return;
            }
            try
            {

                Console.WriteLine("-------------------------Update Sale---------------------- ");
                Console.Write("Please input ID of the Sale to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (SaleManagerment sale in SaleList)
                    {
                        if (this.Id.Equals(sale.Id))
                        {
                            Console.Write("input CustomerId:");
                            this.CustomerId = Convert.ToInt32(Console.ReadLine());
                            sale.CustomerId = this.CustomerId;

                            Console.Write("input SaleDate:");
                            this.SaleDate =Convert.ToDateTime(Console.ReadLine());
                            sale.SaleDate = this.SaleDate;

                            Console.Write("input UserId:");
                            this.UserId = Convert.ToInt32(Console.ReadLine());
                            sale.UserId = this.UserId;

                            Console.Write("input TotalAmount:");
                            this.TotalAmount = Convert.ToDouble(Console.ReadLine());
                            sale.TotalAmount = this.TotalAmount;

                            Console.WriteLine("\nYou Update Sale successfully!");
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"\n `Sale with the given ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to update again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                UpdateSale();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuSaleManagerment();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid input: {choice}. Please type Y or N.\n");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid input!:{input} Please enter a valid number  Not string!.");
                    while (true)
                    {
                        Console.Write("Do you want to try Update again? (Y/N): ");
                        string choice = Console.ReadLine();

                        if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            UpdateSale();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuSaleManagerment();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void DeleteSale()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to Delete sales.!\n");
                ManuSaleManagerment();
                return;
            }
            try
            {
                Console.WriteLine("-----------------------------------Delete Sale-----------------------------");
                Console.Write("Please input ID of the Sale to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        DeleteSale();
                        return;
                    }
                    foreach (SaleManagerment sale in SaleList)
                    {
                        if (sale.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system CustomerId '{sale.CustomerId}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteSale();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuSaleManagerment();
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                                    }
                                }
                            }
                            while (true)
                            {
                                Console.Write($"Are you sure you want to delete Sale '{sale.CustomerId}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    SaleList.Remove(sale);
                                    Console.WriteLine("\n Sale deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuSaleManagerment();
                                    Console.WriteLine("\n Delete operation canceled.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid input: {confirm}. Please enter Y or N.");

                                }
                            }

                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Sale with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteSale();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuSaleManagerment();
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid input!:{input} Please enter a valid number  Not string!.");
                    while (true)
                    {
                        Console.Write("Do you want to try Delete again? (Y/N): ");
                        string choice = Console.ReadLine();

                        if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            DeleteSale();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuSaleManagerment();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void SearchSale()
        {
            try
            {
                Console.WriteLine("--------------------------Search Sale--------------------------\n");
                Console.Write("Please input ID of the Sale to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        SearchSale();
                        return;
                    }

                    foreach (SaleManagerment sale in SaleList)
                    {
                        if (this.Id == sale.Id)
                        {

                            Console.WriteLine("------------------------------------------ Sale Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-25}{2,-20}{3,-15}{4,-15}", "Id", "CustomerId", "SaleDate", "UserId", "TotalAmount");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-25}{2,-20}{3,-15}{4,-15}",
                                sale.Id, sale.CustomerId, sale.SaleDate, sale.UserId, sale.TotalAmount);

                            Console.WriteLine(row);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Sale with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchSale();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuSaleManagerment();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!{input} Please enter a valid number  Not string!.");
                    while (true)
                    {
                        Console.Write("Do you want to try Search again? (Y/N): ");
                        string choice = Console.ReadLine();

                        if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            SearchSale();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuSaleManagerment();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

    }
     
  
}
