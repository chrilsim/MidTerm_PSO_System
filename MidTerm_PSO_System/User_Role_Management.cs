using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{

    internal partial class User_Role_Management
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CreateBy { get; set; } = ByAdmin.ById ;
        public int UpdateBy { get; set; } = ByAdmin.ById;
        public DateTime UpdateAt { get; set; } 

        public bool anyUpdate = false;
        public int OriginalUserId { get; set; }

        public static List<User_Role_Management> UserRoleList = new List<User_Role_Management>()
        {
            new User_Role_Management(1,1,1, DateTime.Parse("2025-5-2"),1,DateTime.Now,1),
            new User_Role_Management(2,2,1, DateTime.Parse("2025-5-2"),1,DateTime.Now,1)

        };
        public User_Role_Management() { }
        User_Role_Management(int Id,int UserId,int RoleId, DateTime CreateAt, int CreateBy, DateTime UpdateAt, int UpdateBy)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.RoleId = RoleId;
            this.CreateAt = CreateAt;
            this.UpdateAt = UpdateAt;
            this.UpdateBy =UpdateBy;
            this.CreateBy = CreateBy;
           
           
        }
        string UserAndAdmin;
        public void Manu_User_Role_Management()
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
                Console.WriteLine("-----------------------Manu User Role Managerment-------------------- ");
                Console.WriteLine("1.Add User Role");
                Console.WriteLine("2.show User Role");
                Console.WriteLine("3.Update User Role");
                Console.WriteLine("4.Delete User Role");
                Console.WriteLine("5.Search User Role");
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

                            Add_User_Role();
                            break;
                        case 2:
                            Show_User_Role();
                            break;
                        case 3:
                            Update_Role_User();

                            break;
                        case 4:
                            Delete_User_RoleById();
                            break;
                        case 5:
                            Search_Role_UserById();
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
        public void Add_User_Role()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Add User Role.!\n");
                    Manu_User_Role_Management();
                    return;
                }
                Console.Write("input Count Add User:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information User Role {i + 1}--------------------\n");
                    User_Role_Management UserRole = new User_Role_Management();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (UserRoleList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        UserRole.Id = inputId;

                    }

                    Console.Write("input UserId:");
                    UserRole.UserId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("input RoleId:");
                    UserRole.RoleId = Convert.ToInt32(Console.ReadLine());

                    UserRoleList.Add(UserRole);
                    Console.WriteLine("\n User Role added successfully!\n");
                   
                    anyUpdate = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
        public void Update_Role_User()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update User Role.!\n");
                    Manu_User_Role_Management();
                    return;
                }
                Console.WriteLine("-------------------------Update User Role---------------------- ");
                Console.Write("Please input ID of the user to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId)) 
                {
                    this.Id = userId;
                    foreach (User_Role_Management UserRole in UserRoleList)
                    {
                        if (this.Id.Equals(UserRole.Id))
                        {
                            Console.Write("Input UserId: ");
                            UserId = Convert.ToInt32(Console.ReadLine());
                            UserRole.UserId = UserId;

                            Console.Write("Input RoleId: ");
                            RoleId = Convert.ToInt32(Console.ReadLine());
                            
                            UserRole.RoleId = RoleId;

                            UserRole.UpdateAt = DateTime.Now;
                            Console.WriteLine("\nYou updated successfully!");
                            found = true;
                            anyUpdate = true;
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
                                Update_Role_User();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Manu_User_Role_Management();
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
                            Update_Role_User();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            Manu_User_Role_Management();
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
        public void Show_User_Role()
        {
            if (anyUpdate)
            {
                Console.WriteLine("------------------------------------------ User Role Management List (Update) ------------------------------------------");
                string header = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}{5,-25}{6,-15}", "Id", "UserId", "RoleId", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy");
                Console.WriteLine(header);

                foreach (User_Role_Management UserRole in UserRoleList)
                {

                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                    if(UserRole.UserId == UserId && UserRole.RoleId == RoleId)
                    {
                        updateAtStr = UserRole.UpdateAt.ToString("yyyy-MM-dd HH:mm");
                        updateByStr = UserRole.UpdateBy.ToString();

                    }
                    else
                    {
                        updateAtStr = UserRole.UpdateBy.ToString("-");
                        updateByStr = UserRole.UpdateAt.ToString("N/A");
                    }

                    string row = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}{5,-25}{6,-15}",
                        UserRole.Id, UserRole.UserId, UserRole.RoleId, UserRole.CreateAt, UserRole.CreateBy, updateAtStr, updateByStr);

                    Console.WriteLine(row);
                }

                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("------------------------------------------ User Role Management List ------------------------------------------");
                string header = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}", "Id", "UserId", "RoleId", "CreateAt", "CreateBy");
                Console.WriteLine(header);

                foreach (User_Role_Management UserRole in UserRoleList)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    string row = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}",
                        UserRole.Id, UserRole.UserId, UserRole.RoleId, UserRole.CreateAt, UserRole.CreateBy);

                    Console.WriteLine(row);
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------");

            }

        }

        public void Delete_User_RoleById()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Delete User Role.!\n");
                    Manu_User_Role_Management();
                    return;
                }
                Console.WriteLine("-----------------------------------Delete role User-----------------------------");
                Console.Write("Please input ID of the user to delete: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                   
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        Delete_User_RoleById();
                        return;
                    }
                    foreach (User_Role_Management UserRole in UserRoleList)
                    {
                        if (UserRole.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{UserRole.RoleId}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Delete_User_RoleById();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Manu_User_Role_Management();
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
                                Console.Write($"Are you sure you want to delete user '{UserRole.RoleId}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    UserRoleList.Remove(UserRole);
                                    Console.WriteLine("\nUser deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    Manu_User_Role_Management();
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
                        Console.WriteLine($"\nUser with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                Delete_User_RoleById();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Manu_User_Role_Management();
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
                            Delete_User_RoleById();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            Manu_User_Role_Management();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }

                }
            }
            catch (Exception ex) {Console.WriteLine(ex.Message);}
        }

        public void Search_Role_UserById()
        {
            try
            {
                Console.WriteLine("--------------------------Search Role User--------------------------\n");
                Console.Write("Please input ID of the user to Search: ");
                string input = Console.ReadLine();
                int userId;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    bool found = false;
                    if (this.Id < 1)
                    {
                        Console.WriteLine("Please input ID greater than 0.");
                        Search_Role_UserById();
                        return;
                    }

                    foreach (User_Role_Management UserRole in UserRoleList)
                    {
                        if (this.Id == UserRole.Id)
                        {
                            Console.WriteLine("------------------------------------------ User Role Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}", "Id", "UserId", "RoleId", "CreateAt", "CreateBy");
                            Console.WriteLine(header);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}",
                                UserRole.Id, UserRole.UserId, UserRole.RoleId, UserRole.CreateAt, UserRole.CreateBy);

                            Console.WriteLine(row);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\nUser with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                Search_Role_UserById();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Manu_User_Role_Management();
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
                            Search_Role_UserById();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            Manu_User_Role_Management();
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
