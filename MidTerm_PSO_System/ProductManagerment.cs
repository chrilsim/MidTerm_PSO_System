using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System 
{ 

 //   -id
	//-ProductName
	//-Barcode
	//-sellPrice
	//-QtyInstock(Optional)
	//-Image(Optional)
	//-CateogoryId

    internal class ProductManagerment
    {
        public int Id { get; set; }
		public string ProductName { get; set; }
        public int Barcode { get; set; }
        public double SellPrice { get; set; }
		public int QtyInstock { get; set; }
        public string Image { get; set; }
        public int CateogoryId { get; set; }
        public bool anyUpdate=false;
        public static List<ProductManagerment> ProductList = new List<ProductManagerment>()
        {
            new ProductManagerment(1,"CoCa",1122,1,24,"not",10),
            new ProductManagerment(2,"Carabav",12312,0.5,212,"not",20)
        };
        public ProductManagerment() { }

        public ProductManagerment(int id, string productName, int barcode, double sellPrice, int qtyInstock, string image, int cateogoryId)
        {
            Id = id;
            ProductName = productName;
            Barcode = barcode;
            SellPrice = sellPrice;
            QtyInstock = qtyInstock;
            Image = image;
            CateogoryId = cateogoryId;
        }
        string UserAndAdmin;
        public void ManuProductManagerment()
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
                Console.WriteLine("-----------------------Manu Product Managerment-------------------- ");
                Console.WriteLine("1.Add Product");
                Console.WriteLine("2.show Product");
                Console.WriteLine("3.Update Product");
                Console.WriteLine("4.Delete Product");
                Console.WriteLine("5.Search Product");
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

                            AddProductManagerment();
                            break;
                        case 2:
                            ShowProductManagerment();
                            break;
                        case 3:

                            UpdateProductManagerment();
                            break;
                        case 4:
                           DeleteProductManagerment();
                            break;
                        case 5:
                            SearchProductManagerment();
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
        public void AddProductManagerment()
        {
            try
            {

                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Add Product.!\n");
                    ManuProductManagerment();
                    return;
                }
                Console.Write("input Count Add User:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information Product {i + 1}--------------------\n");
                    ProductManagerment product = new ProductManagerment();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (ProductList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        product.Id = inputId;
                        
                    }
                    Console.Write("input ProductName:");
                    product.ProductName = Console.ReadLine();

                    Console.Write("input Barcoe:");
                    product.Barcode =Convert.ToInt32(Console.ReadLine());

                    Console.Write("input SellPrice:");
                    product.SellPrice = Convert.ToDouble(Console.ReadLine());

                    Console.Write("input QtyInstock:");
                    product.QtyInstock = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input Image:");
                    product.Image =Console.ReadLine();

                    Console.Write("input CategoryId:");
                    product.CateogoryId = Convert.ToInt32(Console.ReadLine());
                    ProductList.Add(product);
                    Console.WriteLine("\n Product added successfully!\n");

                    anyUpdate = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void ShowProductManagerment()
        {


            Console.WriteLine("------------------------------------------ User Role Management List ------------------------------------------");
            string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-10}{6,-15}", "Id", "ProductName", "Barcode", "SellPrice", "QtyInstock", "Image", "CateogoryId");
            Console.WriteLine(header);

            foreach (ProductManagerment product in ProductList)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-10}{6,-15}",
                  product.Id, product.ProductName, product.Barcode, product.SellPrice, product.QtyInstock, product.Image, product.CateogoryId);


                Console.WriteLine(row);
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }
        public void UpdateProductManagerment()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update Product.!\n");
                    ManuProductManagerment();
                    return;
                }
                Console.WriteLine("-------------------------Update Product---------------------- ");
                Console.Write("Please input ID of the user to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (ProductManagerment product in ProductList)
                    {
                        if (this.Id.Equals(product.Id))
                        {
                            Console.Write("input ProductName:");
                            this.ProductName = Console.ReadLine();
                            product.ProductName = this.ProductName;
                            

                            Console.Write("input Barcoe:");
                            this.Barcode = Convert.ToInt32(Console.ReadLine());
                            product.Barcode = this.Barcode;

                            Console.Write("input SellPrice:");
                            this.SellPrice = Convert.ToDouble(Console.ReadLine());
                            product.SellPrice = this.SellPrice;


                            Console.Write("input QtyInstock:");
                            this.QtyInstock = Convert.ToInt32(Console.ReadLine());
                            product.QtyInstock = this.QtyInstock;

                            Console.Write("input Image:");
                            this.Image = Console.ReadLine();
                            product.Image = this.Image;

                            Console.Write("input CategoryId:");
                            this.CateogoryId = Convert.ToInt32(Console.ReadLine());
                            product.CateogoryId = this.CateogoryId;

                            Console.WriteLine("\nYou updated successfully!");
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"\nUser with the given ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to update again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                UpdateProductManagerment();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuProductManagerment();
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
                            UpdateProductManagerment();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuProductManagerment();
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
        public void DeleteProductManagerment()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Delete Product.!\n");
                    ManuProductManagerment();
                    return;
                }
                Console.WriteLine("-----------------------------------Delete role User-----------------------------");
                Console.Write("Please input ID of the Product to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        DeleteProductManagerment();
                        return;
                    }
                    foreach (ProductManagerment product in ProductList)
                    {
                        if (product.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{product.ProductName}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteProductManagerment();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuProductManagerment();
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
                                Console.Write($"Are you sure you want to delete user '{product.ProductName}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    ProductList.Remove(product);
                                    Console.WriteLine("\nUser deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuProductManagerment();
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
                        Console.WriteLine($"\n Product with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteProductManagerment();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuProductManagerment();
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
                            DeleteProductManagerment();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuProductManagerment();
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
        public void SearchProductManagerment()
        {
            try
            {
                Console.WriteLine("--------------------------Search Role User--------------------------\n");
                Console.Write("Please input ID of the Product to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        SearchProductManagerment();
                        return;
                    }

                    foreach (ProductManagerment product in ProductList)
                    {
                        if (this.Id == product.Id)
                        {
                            Console.WriteLine("------------------------------------------ Product Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-10}{6,-15}", "Id", "ProductName", "Barcode", "SellPrice", "QtyInstock", "Image", "CateogoryId");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}{5,-10}{6,-15}",
                            product.Id, product.ProductName, product.Barcode, product.SellPrice, product.QtyInstock, product.Image, product.CateogoryId);
                            Console.WriteLine(row);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Product with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchProductManagerment();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuProductManagerment();
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
                            SearchProductManagerment();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuProductManagerment();
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
