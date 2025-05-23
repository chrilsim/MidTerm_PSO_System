using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
 ////   -id
	////-SaleId
	////-ProductId
	////-Qty
	////-Price
	////-Total

    internal class SaleDetailManagerment
    {
        public bool anyUpdate = false;
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public static List<SaleDetailManagerment> saleDetailList = new List<SaleDetailManagerment>();
        public SaleDetailManagerment() { }

        public SaleDetailManagerment(int id, int saleId, int productId, int qty, double price, double total)
        {
            Id = id;
            SaleId = saleId;
            ProductId = productId;
            Qty = qty;
            Price = price;
            Total = total;
        }
        string UserAndAdmin;
        public  void MannuSaleDetail()
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
                Console.WriteLine("-----------------------Manu SaleDetei Managerment-------------------- ");
                Console.WriteLine("1.Add SaleDetei");
                Console.WriteLine("2.show SaleDetei");
                Console.WriteLine("3.Update SaleDetei");
                Console.WriteLine("4.Delete SaleDetei");
                Console.WriteLine("5.Search SaleDetei");
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
                            AddSaleDetail();                            
                            break;
                        case 2:
                            ShowSaleDetaie();
                            break;
                        case 3:
                            UpdateSaleDetail();
                            break;
                        case 4:
                            DeleteSaleDetail();
                            break;
                        case 5:
                            SearchSaleDetail();
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
        public void AddSaleDetail()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to add SaleDetail.!\n");
                MannuSaleDetail();
                return;
            }
            try
            {
                Console.Write("input Count Add SaleDetail:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information SaleDetail {i + 1}--------------------\n");
                   SaleDetailManagerment saledetail = new SaleDetailManagerment();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (saleDetailList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        saledetail.Id = inputId;

                    }
                    Console.Write("input SaleId:");
                    saledetail.SaleId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input ProductId:");
                    saledetail.ProductId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input Qty:");
                    saledetail.Qty = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input Price:");
                    saledetail.Price = Convert.ToDouble(Console.ReadLine());

                   saledetail.Total = saledetail.Price * saledetail.Qty;

                    saleDetailList.Add(saledetail);
                    Console.WriteLine("\n Add Sale Detail successfully!\n");

                    anyUpdate = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        } 
        public void ShowSaleDetaie()
        {
            Console.WriteLine("---------------------------------- Sale Detail Management List ------------------------------------");
            string header = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "Id", "SaleId", "ProductId", "Qty", "Price","Total");
            Console.WriteLine(header);

            foreach (SaleDetailManagerment saledetail in saleDetailList)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                string row = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}",
                    saledetail.Id, saledetail.SaleId, saledetail.ProductId, saledetail.Qty,saledetail.Price, saledetail.Total);

                Console.WriteLine(row);
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }
        public void UpdateSaleDetail()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to Update saleDetail.!\n");
                MannuSaleDetail();
                return;
            }
            try
            {

                Console.WriteLine("-------------------------Update Sale Detail---------------------- ");
                Console.Write("Please input ID of the Sale to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (SaleDetailManagerment saledetil in saleDetailList)
                    {
                        if (this.Id.Equals(saledetil.Id))
                        {
                            Console.Write("input SaleId:");
                            this.SaleId = Convert.ToInt32(Console.ReadLine());
                            saledetil.SaleId = this.SaleId;

                            Console.Write("input ProductId:");
                            this.ProductId = Convert.ToInt32(Console.ReadLine());
                            saledetil.ProductId = this.ProductId;

                            Console.Write("input Qty:");
                            this.Qty = Convert.ToInt32(Console.ReadLine());
                            saledetil.Qty = this.Qty;

                            Console.Write("input price:");
                            this.Price = Convert.ToDouble(Console.ReadLine());
                            saledetil.Price = this.Price;

                            Console.WriteLine("\nYou Update Sale Detail successfully!");
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
                                UpdateSaleDetail();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                MannuSaleDetail();
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
                            UpdateSaleDetail();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            MannuSaleDetail();
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
        public void DeleteSaleDetail()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to Delete sales Detail.!\n");
                MannuSaleDetail();
                return;
            }
            try
            {
                Console.WriteLine("-----------------------------------Delete Sale Detail-----------------------------");
                Console.Write("Please input ID of the Sale Detil to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        DeleteSaleDetail();
                        return;
                    }
                    foreach (SaleDetailManagerment saledetil in saleDetailList)
                    {
                        if (saledetil.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system CustomerId '{saledetil.SaleId}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteSaleDetail();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        MannuSaleDetail();
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
                                Console.Write($"Are you sure you want to delete Sale '{saledetil.SaleId}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    saleDetailList.Remove(saledetil);
                                    Console.WriteLine("\n Sale Detail deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    MannuSaleDetail();
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
                        Console.WriteLine($"\n Sale Detail with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteSaleDetail();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                MannuSaleDetail();
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
                            DeleteSaleDetail();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            MannuSaleDetail();
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
        public void SearchSaleDetail()
        {
            try
            {
                Console.WriteLine("--------------------------Search Sale Detail--------------------------\n");
                Console.Write("Please input ID of the Sale Detail to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        SearchSaleDetail();
                        return;
                    }

                    foreach (SaleDetailManagerment saledetail in saleDetailList )
                    {
                        if (this.Id == saledetail.Id)
                        {

                            Console.WriteLine("---------------------------------- Sale Detail Management List ------------------------------------");
                            string header = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "Id", "SaleId", "ProductId", "Qty", "Price", "Total");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}",
                                saledetail.Id, saledetail.SaleId, saledetail.ProductId, saledetail.Qty, saledetail.Price, saledetail.Total);

                            Console.WriteLine(row);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Sale Detail with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchSaleDetail();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                MannuSaleDetail();
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
                            SearchSaleDetail();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            MannuSaleDetail();
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
