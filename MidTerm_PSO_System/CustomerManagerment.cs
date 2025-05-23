using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
 //   +Customer
	//-id
	//-CustomerName
	//-Gender
	//-Tel
	//-Address
	//-Email
	//-Photo


    internal class CustomerManagerment
    {
        public int Id { get; set; }
		public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Photo { get; set; }
		public static List<CustomerManagerment> CustomerList = new List<CustomerManagerment>();
		public CustomerManagerment() { }

        public CustomerManagerment(int id, string customerName, string gender, string tel, string address, string email, string photo)
        {
            Id = id;
            CustomerName = customerName;
            Gender = gender;
            Tel = tel;
            Address = address;
            Email = email;
            Photo = photo;
        }
        string UserAndAdmin;
        public void ManuCustomeManagerment()
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
                Console.WriteLine("-----------------------Manu Customer Managerment-------------------- ");
                Console.WriteLine("1.Add Customer");
                Console.WriteLine("2.show Customer");
                Console.WriteLine("3.Update Customer");
                Console.WriteLine("4.Delete Customer");
                Console.WriteLine("5.Search Customer");
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
                            AddCustomer();
                            break;
                        case 2:
                            ShowCustomer();
                            break;
                        case 3:
                           UpdateCustomer();
                            break;
                        case 4:
                            DeleteCustomer();
                            break;
                        case 5:
                            SearchCustomer();
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
        public void AddCustomer()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to add Customer.!\n");
                ManuCustomeManagerment();
                return;
            }
            try
            {
                Console.Write("input Count Add SaleDetail:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information SaleDetail {i + 1}--------------------\n");
                    CustomerManagerment customer = new CustomerManagerment();
                start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (CustomerList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        customer.Id = inputId;

                    }
                    Console.Write("input CustomerName:");
                    customer.CustomerName = Console.ReadLine();

                    Console.Write("input Gender:");
                    customer.Gender =Console.ReadLine();

                    Console.Write("input Tel:");
                    customer.Tel = Console.ReadLine();

                    Console.Write("input Address:");
                    customer.Address =Console.ReadLine();

                    Console.Write("input Email:");
                    customer.Email = Console.ReadLine();

                    Console.Write("input Photo:");
                    customer.Photo = Console.ReadLine();

                    CustomerList.Add(customer);
                    Console.WriteLine("\n Add Customer successfully!\n");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void ShowCustomer()
        {
            Console.WriteLine("---------------------------------- Customer Management List ------------------------------------");
            string header = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "Id", "CustomerName", "Gender", "Tel", "Address", "Email", "Photo");
            Console.WriteLine(header);

            foreach (CustomerManagerment customer in CustomerList)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                string row = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
                    customer.Id, customer.CustomerName, customer.Gender, customer.Tel, customer.Address, customer.Email, customer.Photo);

                Console.WriteLine(row);
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }
        public void UpdateCustomer() 
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to Update Customer.!\n");
                ManuCustomeManagerment();
                return;
            }
            try
            {

                Console.WriteLine("-------------------------Update Customer---------------------- ");
                Console.Write("Please input ID of the Customer to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (CustomerManagerment customer in CustomerList)
                    {
                        if (this.Id.Equals(customer.Id))
                        {
                            Console.Write("input CustomerName:");
                            this.CustomerName =Console.ReadLine();
                            customer.CustomerName = this.CustomerName;

                            Console.Write("input Gender:");
                            this.Gender = Console.ReadLine();
                            customer.Gender = this.Gender;

                            Console.Write("input Tel:");
                            this.Tel =Console.ReadLine();
                            customer.Tel = this.Tel;

                            Console.Write("input Address:");
                            this.Address =Console.ReadLine();
                            customer.Address = this.Address;

                            Console.Write("input Photo:");
                            this.Photo = Console.ReadLine();
                            customer.Photo = this.Photo;

                            Console.WriteLine("\nYou Update Customer successfully!");
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
                                UpdateCustomer();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuCustomeManagerment();
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
                            UpdateCustomer();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuCustomeManagerment();
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
        public void DeleteCustomer()
        {
            if (!UserCheck.chackUserOrAdmin)
            {
                Console.WriteLine("You do not have permission to Delete Customer Detail.!\n");
                ManuCustomeManagerment();
                return;
            }
            try
            {
                Console.WriteLine("-----------------------------------Delete Customer-----------------------------");
                Console.Write("Please input ID of the Customer Detil to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        DeleteCustomer();
                        return;
                    }
                    foreach (CustomerManagerment customer in CustomerList)
                    {
                        if (customer.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system CustomerId '{customer.CustomerName}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteCustomer();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuCustomeManagerment();
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
                                Console.Write($"Are you sure you want to delete Sale '{customer.CustomerName}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    CustomerList.Remove(customer);
                                    Console.WriteLine("\n Customer deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuCustomeManagerment();
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
                        Console.WriteLine($"\n Custmer with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteCustomer();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuCustomeManagerment();
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
                            DeleteCustomer();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuCustomeManagerment();
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
        public void SearchCustomer()
        {
            try
            {
                Console.WriteLine("--------------------------Search Customer--------------------------\n");
                Console.Write("Please input ID of the Customer to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        SearchCustomer();
                        return;
                    }

                    foreach (CustomerManagerment customer in CustomerList)
                    {
                        if (this.Id == customer.Id)
                        {

                            Console.WriteLine("---------------------------------- Customer Management List ------------------------------------");
                            string header = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "Id", "CustomerName", "Gender", "Tel", "Address", "Email", "Photo");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}",
                                customer.Id, customer.CustomerName, customer.Gender, customer.Tel, customer.Address, customer.Email, customer.Photo);

                            Console.WriteLine(row);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Customer with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchCustomer();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuCustomeManagerment();
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
                            SearchCustomer();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuCustomeManagerment();
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
