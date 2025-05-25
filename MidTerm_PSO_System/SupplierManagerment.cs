using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
    //    -id
    //	-Name
    //	-Tel
    //	-Address
    //	-CreateAt(date)
    //	-CreateBy
    //	-UpdateAt(Date)
    //	-UpdateBy(Optional)

    internal class SupplierManagerment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string  Address { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int CreateBy { get; set; } = ByAdmin.ById;
        public int UpdateBy { get; set; } = ByAdmin.ById;
        public bool anyUpdate = false;
        public static List<SupplierManagerment> SupplierList = new List<SupplierManagerment>()
        {
            new SupplierManagerment(1,"Manager","09612321","pp",DateTime.Parse("2025-5-2"),1,DateTime.Parse("2025-5-2"),1),
             new SupplierManagerment(2,"IT","09634521","Takeo",DateTime.Parse("2025-5-2"),1,DateTime.Parse("2025-5-2"),1)
        };
        public SupplierManagerment() { }
        public SupplierManagerment(int id, string name, string tel, string address, DateTime createAt, int createBy, DateTime updateAt,  int updateBy)
        {
            Id = id;
            Name = name;
            Tel = tel;
            Address = address;
            CreateAt = createAt;
            UpdateAt = updateAt;
            CreateBy = createBy;
            UpdateBy = updateBy;
        }
        string UserAndAdmin;
        public void ManuSupplierManagerment()
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
                Console.WriteLine("-----------------------Manu Supplier Managerment-------------------- ");
                Console.WriteLine("1.Add Supplier");
                Console.WriteLine("2.show Supplier");
                Console.WriteLine("3.Update Supplier");
                Console.WriteLine("4.Delete Supplier");
                Console.WriteLine("5.Search Supplier");
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

                            AddSupplierManagerment();
                            break;
                        case 2:
                            ShowSupplier();
                            break;
                        case 3:
                            UpdateSupplier();
                            break;
                        case 4:
                            DeleteSupplier();
                            break;
                        case 5:
                            SearchSupplier();
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
        public void AddSupplierManagerment()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to add Supplier.!\n");
                    ManuSupplierManagerment();
                    return;
                }

                Console.Write("input Count Add Supplier:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information Supplier {i + 1}--------------------\n");
                    SupplierManagerment supplier = new SupplierManagerment();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (SupplierList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        supplier.Id = inputId;

                    }
                    Console.Write("input Name:");
                    supplier.Name = Console.ReadLine();

                    Console.Write("input Tell:");
                    supplier.Tel = Console.ReadLine();

                    Console.Write("input Address:");
                    supplier.Address = Console.ReadLine();

                   
                    SupplierList.Add(supplier);
                    Console.WriteLine("\n Add Stock successfully!\n");
                    supplier.CreateAt = DateTime.Now;
                    anyUpdate = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void UpdateSupplier()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update Supplier.!\n");
                    ManuSupplierManagerment();
                    return;
                }
                Console.WriteLine("-------------------------Update Supplier---------------------- ");
                Console.Write("Please input ID of the Supplier to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (SupplierManagerment supplier in SupplierList)
                    {
                        if (this.Id.Equals(supplier.Id))
                        {
                            Console.Write("input Name:");
                            Name = Console.ReadLine();
                            supplier.Name = Name;

                            Console.Write("input Tel:");
                            Tel = Console.ReadLine();
                            supplier.Tel = Tel;

                            Console.Write("input Address:");
                            Address = Console.ReadLine();
                            supplier.Address = Address;

                            Console.WriteLine("\nYou Update Supplier successfully!");
                            found = true;
                            anyUpdate = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"\n Supplier with the given ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to update again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                               UpdateSupplier();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuSupplierManagerment();
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
                            UpdateSupplier();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuSupplierManagerment();
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
        public void ShowSupplier()
        {
            if (anyUpdate)
            {
                Console.WriteLine("-------------------------------------------------Supplier Management List (Update) ----------------------------------------------");
                string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-25}{5,-15}{6,-25}{7,-15}",
                "Id", "Name", "Tell", "Address", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy");

                Console.WriteLine(header);
                foreach (SupplierManagerment supplier in SupplierList)
                {

                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                    for (int i = 0; i < SupplierList.Count; i++)
                    {

                        if (supplier.Name == Name && supplier.Tel == Tel && supplier.Address == Address )
                        {
                            updateAtStr = KHDate.DateKH.UpdateGetKhmerDate(supplier.UpdateAt);
                            updateByStr = supplier.UpdateBy.ToString();

                        }
                        else
                        {
                            updateAtStr = supplier.UpdateBy.ToString("-");
                            updateByStr = supplier.UpdateAt.ToString("N/A");
                        }

                    }

                    string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-25}{5,-15}{6,-25}{7,-15}",
                    supplier.Id, supplier.Name, supplier.Tel, supplier.Address, KHDate.DateKH.GetKhmerDate(supplier.CreateAt), supplier.CreateBy, updateAtStr, updateByStr);


                    Console.WriteLine(row);
                }

                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("------------------------------------------ Supplier Management List ------------------------------------------");
                string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-25}{5,-25}", "Id", "Name", "Tell", "Address", "CreateAt", "CreateBy");
                Console.WriteLine(header);

                foreach (SupplierManagerment supplier in SupplierList)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-25}{5,-25}",
                        supplier.Id, supplier.Name, supplier.Tel, supplier.Address, KHDate.DateKH.GetKhmerDate(supplier.CreateAt), supplier.CreateBy);

                    Console.WriteLine(row);
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------");

            }
        }
        public void DeleteSupplier()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Delete Supplier.!\n");
                    ManuSupplierManagerment();
                    return;
                }
                Console.WriteLine("-----------------------------------Delete Supplier-----------------------------");
                Console.Write("Please input ID of the Supplier to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        DeleteSupplier();
                        return;
                    }
                    foreach (SupplierManagerment supplier in SupplierList)
                    {
                        if (supplier.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{supplier.Name}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteSupplier();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuSupplierManagerment();
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
                                Console.Write($"Are you sure you want to delete SupplierId '{supplier.Name}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    SupplierList.Remove(supplier);
                                    Console.WriteLine("\n Add Stock deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuSupplierManagerment();
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
                        Console.WriteLine($"\n Supplier with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteSupplier();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuSupplierManagerment();
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
                            DeleteSupplier();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuSupplierManagerment();
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
        public void SearchSupplier()
        {
            try
            {
                Console.WriteLine("--------------------------Search Supplier--------------------------\n");
                Console.Write("Please input ID of the Supplier to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        SearchSupplier();
                        return;
                    }

                    foreach (SupplierManagerment supplier in SupplierList)
                    {
                        if (this.Id == supplier.Id)
                        {
                            Console.WriteLine("------------------------------------------ Supplier Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-25}{5,-25}", "Id", "Name", "Tell", "Address", "CreateAt", "CreateBy");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-25}{5,-25}",
                                supplier.Id, supplier.Name, supplier.Tel, supplier.Address, KHDate.DateKH.GetKhmerDate(supplier.CreateAt), supplier.CreateBy);

                            Console.WriteLine(row);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Supplier with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchSupplier();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuSupplierManagerment();
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
                            SearchSupplier();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuSupplierManagerment();
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
