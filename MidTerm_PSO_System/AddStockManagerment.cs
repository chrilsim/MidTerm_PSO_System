using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
 //   -id
	//-SupplierId
	//-Qty
	//-Price
	//-Amount
	//-CreateAt(date)
	//-CreateBy
	//-UpdateAt(Date)
	//-UpdateBy(Optional)

    internal class AddStockManagerment
    {
        public int Id { get; set; }
		public int SupplierId { get; set; }
		public int Qty { get; set; }
		public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; } = DateTime.Now;
        public int CreateBy { get; set; } = ByAdmin.ById;
		public int UpdateBy { get; set; } = ByAdmin.ById;
        public bool anyUpdate=false;

        public static List<AddStockManagerment> AddStockList = new List<AddStockManagerment>()
		{
			new AddStockManagerment(1,11,24,0.5,1,DateTime.Parse("2025-5-2"),1,DateTime.Parse("2025-5-2"),1),
            new AddStockManagerment(2,22,24,0.5,1,DateTime.Parse("2025-5-2"),1,DateTime.Parse("2025-5-2"),1)
        };
		public AddStockManagerment() { }

        public AddStockManagerment(int id, int supplierId, int qty, double price, double amount, DateTime createAt, int createBy, DateTime updateAt, int updateBy)
        {
            Id = id;
            SupplierId = supplierId;
            Qty = qty;
            Price = price;
            Amount = amount;
            CreateAt = createAt;
            UpdateAt = updateAt;
            CreateBy = 1;
            UpdateBy = 1;
        }
        string UserAndAdmin;
        public void ManuAddStockManagerment()
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
                Console.WriteLine("-----------------------Manu Stock Managerment-------------------- ");
                Console.WriteLine("1.Add Stock Managerment");
                Console.WriteLine("2.show Stock Managerment");
                Console.WriteLine("3.Update Stock Managerment");
                Console.WriteLine("4.Delete Stock Managerment");
                Console.WriteLine("5.Search Stock Managerment");
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

                            AddStock();
                            break;
                        case 2:
                           ShowAddStock();
                            break;
                        case 3:
                            UpdateAddstock();
                            break;
                        case 4:
                            DeleteAddStock();
                            break;
                        case 5:
                           SearchAddStock();
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
        public void AddStock()
        {
            try
            {

                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Add Stock.!\n");
                    ManuAddStockManagerment();
                    return;
                }
                Console.Write("input Count Add User:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information Àdd Stock {i + 1}--------------------\n");
                    AddStockManagerment AddStock = new AddStockManagerment();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (AddStockList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        AddStock.Id = inputId;

                    }
                    Console.Write("input SupplierId:");
                    AddStock.SupplierId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input Qty:");
                    AddStock.Qty = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input Price:");
                    AddStock.Price =Convert.ToDouble(Console.ReadLine());

                    Console.Write("input Amount:");
                    AddStock.Amount = Convert.ToDouble(Console.ReadLine());

                    AddStockList.Add(AddStock);
                    Console.WriteLine("\n Add Stock successfully!\n");

                    anyUpdate = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void UpdateAddstock()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update Stock.!\n");
                    ManuAddStockManagerment();
                    return;
                }
                Console.WriteLine("-------------------------Update Add Stock ---------------------- ");
                Console.Write("Please input ID of the user to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (AddStockManagerment AddStock in AddStockList)
                    {
                        if (this.Id.Equals(AddStock.Id))
                        {
                            Console.Write("input SupplierId:");
                            SupplierId = Convert.ToInt32(Console.ReadLine());
                            AddStock.SupplierId= SupplierId;

                            Console.Write("input Qty:");
                            Qty = Convert.ToInt32(Console.ReadLine());
                            AddStock.Qty = Qty;

                            Console.Write("input Price:");
                            Price = Convert.ToDouble(Console.ReadLine());
                            AddStock.Price = Price;

                            Console.Write("input Amount:");
                            Amount = Convert.ToDouble(Console.ReadLine());
                            AddStock.Amount = Amount;

                            AddStock.UpdateAt = DateTime.Now;
                            Console.WriteLine("\nYou Add Stock successfully!");
                            found = true;
                            anyUpdate = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"\n Add Stock with the given ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to update again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                UpdateAddstock();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuAddStockManagerment();
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
                            UpdateAddstock();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuAddStockManagerment();
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
        string updateAtStr, updateByStr;
        public void ShowAddStock()
        {
           
            if (anyUpdate)
            {
                Console.WriteLine("-------------------------------------------------AddStock Management List (Update) ----------------------------------------------");
                string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-10}{5,-25}{6,-10}{7,-25}{8,-15}", "Id", "SupplierId", "Qty", "Price", "Amount", "CreateAt", "CreateBy","UpdateAt","UpdateBy");
                Console.WriteLine(header);
                foreach (AddStockManagerment AddStock in AddStockList)
                {

                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                    for (int i = 0; i < AddStockList.Count; i++)
                    {
                        
                        if (AddStock.SupplierId == SupplierId && AddStock.Qty == Qty && AddStock.Price == Price && AddStock.Amount == Amount)
                        {
                            updateAtStr= AddStock.UpdateAt.ToString("yyyy-MM-dd HH:mm");
                            updateByStr= AddStock.UpdateBy.ToString();

                        }
                        else
                        {
                            updateAtStr=AddStock.UpdateBy.ToString("-");
                            updateByStr= AddStock.UpdateAt.ToString("N/A");
                        }

                    }

                    string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-10}{5,-25}{6,-10}{7,-25}{8,-15}",
                        AddStock.Id, AddStock.SupplierId, AddStock.Qty, AddStock.Price, AddStock.Amount, AddStock.CreateAt, AddStock.CreateBy, updateAtStr, updateByStr);

                    Console.WriteLine(row);
                }

                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("------------------------------------------ Add Stock Management List ------------------------------------------");
                string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-25}{6,-10}", "Id", "SupplierId", "Qty", "Price", "Amount", "CreateAt", "CreateBy");
                Console.WriteLine(header);

                foreach (AddStockManagerment AddStock in AddStockList)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-25}{6,-10}",
                         AddStock.Id, AddStock.SupplierId, AddStock.Qty, AddStock.Price, AddStock.Amount, AddStock.CreateAt, AddStock.CreateBy);

                    Console.WriteLine(row);
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------");

            }
        }
        public void DeleteAddStock()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Delete Stock.!\n");
                    ManuAddStockManagerment();
                    return;
                }
                Console.WriteLine("-----------------------------------Delete Add Stock-----------------------------");
                Console.Write("Please input ID of the Category to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        DeleteAddStock();
                        return;
                    }
                    foreach (AddStockManagerment AddStock in AddStockList)
                    {
                        if (AddStock.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{AddStock.SupplierId}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteAddStock();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuAddStockManagerment();
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
                                Console.Write($"Are you sure you want to delete SupplierId '{AddStock.SupplierId}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    AddStockList.Remove(AddStock);
                                    Console.WriteLine("\n Add Stock deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuAddStockManagerment();
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
                        Console.WriteLine($"\n Add Stock with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteAddStock();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuAddStockManagerment();
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
                            DeleteAddStock();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuAddStockManagerment();
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
        public void SearchAddStock()
        {
            try
            {
                Console.WriteLine("--------------------------Search Add Stock--------------------------\n");
                Console.Write("Please input ID of the Category to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        SearchAddStock();
                        return;
                    }

                    foreach (AddStockManagerment AddStock in AddStockList)
                    {
                        if (this.Id == AddStock.Id)
                        {
                            Console.WriteLine("------------------------------------------ Add Stock Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-25}{6,-10}", "Id", "SupplierId", "Qty", "Price", "Amount", "CreateAt", "CreateBy");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-25}{6,-10}",
                                 AddStock.Id, AddStock.SupplierId, AddStock.Qty, AddStock.Price, AddStock.Amount, AddStock.CreateAt, AddStock.CreateBy);

                            Console.WriteLine(row);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");

                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Add Stock with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchAddStock();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuAddStockManagerment();
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
                            SearchAddStock();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuAddStockManagerment();
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
