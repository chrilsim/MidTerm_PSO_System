using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_PSO_System
{
    internal class Manu_POS_System
    {
        public class UserCheck
        {
            public static bool chackUserOrAdmin = false;
        }
        public class ByAdmin
        {
            public static int ById;
        }
        public void Manu_POS_Admin()
        {
            try
            {
                ByAdmin.ById = 1;
                UserCheck.chackUserOrAdmin = true;
                start:
                Console.WriteLine("---------------------POS System Admin----------------------");
                Console.WriteLine("1.User Management");
                Console.WriteLine("2.User Role Management");
                Console.WriteLine("3.Role Management");
                Console.WriteLine("4.Product Management");
                Console.WriteLine("5.Category Management");
                Console.WriteLine("6.Add Stock Management");
                Console.WriteLine("7.Supplier Management");
                Console.WriteLine("8.Sale Management");
                Console.WriteLine("9.SaleDetail Management");
                Console.WriteLine("10.Customer Management");
                Console.WriteLine("11.witch User and Admin!");
                Console.WriteLine("-----------------------------------------------------");
                int option;
                Console.Write("Pleas Select Option:");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        User_Management user_Management = new User_Management();
                        user_Management.Manu_UserManagement();
                        break;
                    case 2:
                        User_Role_Management user_Role_Management = new User_Role_Management();
                        user_Role_Management.Manu_User_Role_Management();
                        break;

                    case 3:
                        RoleManagement roleManagerment = new RoleManagement();
                        roleManagerment.ManuRoleManagerment();
                        break;
                    case 4:
                        ProductManagerment productManagerment = new ProductManagerment();
                        productManagerment.ManuProductManagerment();
                        break;
                    case 5:
                        CategorManagerment categorManagerment = new CategorManagerment();
                        categorManagerment.ManuCategory();
                        break;
                    case 6:
                        AddStockManagerment addStockManagerment = new AddStockManagerment();
                        addStockManagerment.ManuAddStockManagerment();
                        break;
                    case 7:
                        SupplierManagerment supplierManagerment = new SupplierManagerment();
                        supplierManagerment.ManuSupplierManagerment();
                        break;
                    case 8:
                        SaleManagerment saleManagerment = new SaleManagerment();
                        saleManagerment.ManuSaleManagerment();
                        break;
                    case 9:
                        SaleDetailManagerment saleDetailManagerment = new SaleDetailManagerment();
                        saleDetailManagerment.MannuSaleDetail();
                        break;
                    case 10:
                        CustomerManagerment customerManagerment = new CustomerManagerment();
                        customerManagerment.ManuCustomeManagerment();
                        break;
                    case 11:
                        Login login = new Login();
                        login.AdminOrUser();
                        break;
                    default:
                        Console.WriteLine($"Invalid input!:{option} Please enter a valid number  1 - 11..");
                        break;
                }

                goto start;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Manu_POS_Admin();
                return;
            }
           
        }
        public void Manu_POS_User()
        {
            try
            {
                UserCheck.chackUserOrAdmin = false;
            start:
                Console.WriteLine("---------------------POS System User----------------------");
                Console.WriteLine("1.User Management");
                Console.WriteLine("2.User Role Management");
                Console.WriteLine("3.Role Management");
                Console.WriteLine("4.Product Management");
                Console.WriteLine("5.Category Management");
                Console.WriteLine("6.Add Stock Management");
                Console.WriteLine("7.Supplier Management");
                Console.WriteLine("8.Sale Management");
                Console.WriteLine("9.SaleDetail Management");
                Console.WriteLine("10.Customer Management");
                Console.WriteLine("11.witch User and Admin!");
                Console.WriteLine("-----------------------------------------------------");
                int option;
                Console.Write("Pleas Select Option:");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        User_Management user_Management = new User_Management();
                        user_Management.Manu_UserManagement();
                        break;
                    case 2:
                        User_Role_Management user_Role_Management = new User_Role_Management();
                        user_Role_Management.Manu_User_Role_Management();
                        break;

                    case 3:
                        RoleManagement roleManagerment = new RoleManagement();
                        roleManagerment.ManuRoleManagerment();
                        break;
                    case 4:
                        ProductManagerment productManagerment = new ProductManagerment();
                        productManagerment.ManuProductManagerment();
                        break;
                    case 5:
                        CategorManagerment categorManagerment = new CategorManagerment();
                        categorManagerment.ManuCategory();
                        break;
                    case 6:
                        AddStockManagerment addStockManagerment = new AddStockManagerment();
                        addStockManagerment.ManuAddStockManagerment();
                        break;
                    case 7:
                        SupplierManagerment supplierManagerment = new SupplierManagerment();
                        supplierManagerment.ManuSupplierManagerment();
                        break;
                    case 8:
                        SaleManagerment saleManagerment = new SaleManagerment();
                        saleManagerment.ManuSaleManagerment();
                        break;
                    case 9:
                        SaleDetailManagerment saleDetailManagerment = new SaleDetailManagerment();
                        saleDetailManagerment.MannuSaleDetail();
                        break;
                    case 10:
                        CustomerManagerment customerManagerment = new CustomerManagerment();
                        customerManagerment.ManuCustomeManagerment();
                        break;
                    case 11:
                        Login login = new Login();
                        login.AdminOrUser();
                        break;
                    default:
                        Console.WriteLine($"Invalid input!:{option} Please enter a valid number  1 - 11.");
                        break;
                }

                goto start;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Manu_POS_User();
                return;
            }
            
        }
    }
}
