using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
    internal class User_Management
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        
        public int CreateBy { get; set; } = ByAdmin.ById;
        public int UpdateBy { get; set; } = ByAdmin.ById;
        public DateTime UpdateAt { get; set; }
        public bool anyUpdate = false;

        public static List<User_Management> UserList = new List<User_Management>()
        {
            new User_Management(1, "Admin", "123", true, "M", "Simchril@gmail.com", DateTime.Parse("2025-5-2"),1),
            new User_Management(2, "User", "1234", false, "M", "User@gmail.com", DateTime.Parse("2025-5-2"),1)

        };
        public User_Management()
        {

        }

        public User_Management(int Id, string UserName, string Password, bool Status, string Gender, string Email, DateTime CreateAt, int CreateBy)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Password = Password;
            this.Status = Status;
            this.Gender = Gender;
            this.Email = Email;
            this.CreateAt = CreateAt;
            this.CreateBy = CreateBy;
        }

        public User_Management(int Id, string UserName, string Password, bool Status, string Gender, string Email, DateTime CreateAt,int CreateBy, int UpdateBy, DateTime UpdateAt)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Password = Password;
            this.Status = Status;
            this.Gender = Gender;
            this.Email = Email;
            this.CreateAt = CreateAt;
            this.CreateBy = CreateBy;
            this.UpdateBy = UpdateBy;
            this.UpdateAt = UpdateAt;
        }
        string UserAndAdmin;
        public void Manu_UserManagement()
        {
           
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    UserAndAdmin = "User";

                }
                else
                {
                    UserAndAdmin = "Admin";
                }
                while (true)
                {
                    Console.WriteLine("---------------------Manu User Management----------------------");
                    Console.WriteLine("1.Add User");
                    Console.WriteLine("2.show User");
                    Console.WriteLine("3.Update User ");
                    Console.WriteLine("4.Delete User");
                    Console.WriteLine("5.Search User");
                    Console.WriteLine($"6.Back POS System {UserAndAdmin}");
                    Console.WriteLine("---------------------------------------------------------------\n");
                    int option;
                    int Case;
                    Console.Write("Pleas Select option :");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out Case))
                    {
                        option = Case;
                        switch (option)
                        {
                            case 1:

                                Add_User_Management();
                                break;
                            case 2:
                                ShowUserManagement();
                                break;
                            case 3:
                                UpdateUserById();
                                break;
                            case 4:
                                DeleteUserById();
                                break;
                            case 5:
                                SearchUserById();
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
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            

        }
        public void Add_User_Management()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Add User .!\n");
                    Manu_UserManagement();
                    return;
                }
                Console.Write("input Count Add User:");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    User_Management user = new User_Management();
                    Console.WriteLine($"-------------------input Information User {i + 1}--------------------\n");
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (UserList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        user.Id = inputId;

                    }
                    Console.Write("input Name:");
                    user.UserName = Console.ReadLine();
                    Console.Write("input Gender:");
                    user.Gender = Console.ReadLine();
                    Console.Write("input Password:");
                    user.Password = Console.ReadLine();
                    Console.Write("input Email:");
                    user.Email = Console.ReadLine();
                    Console.Write("Input Status (true/false):");
                    user.Status = Convert.ToBoolean(Console.ReadLine());
                    UserList.Add(user);
                    Console.WriteLine("\n✅ User added successfully!\n");

                    anyUpdate = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void UpdateUserById()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update User .!\n");
                    Manu_UserManagement();
                    return;
                }
                Console.WriteLine("-------------------------Update User---------------------- ");
                Console.Write("Please input ID of the user to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (User_Management user in UserList)
                    {
                        if (this.Id.Equals(user.Id))
                        {
                            Console.Write("Input Name: ");
                            UserName = Console.ReadLine();
                            user.UserName = UserName;

                            Console.Write("Input Gender: ");
                            Gender = Console.ReadLine();
                            user.Gender = Gender;

                            Console.Write("Input Password: ");
                            Password = Console.ReadLine();
                            user.Password = Password;

                            Console.Write("Input Email: ");
                            Email = Console.ReadLine();
                            user.Email =Email;

                            Console.WriteLine("\nYou updated successfully!");
                            found = true;
                            anyUpdate = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"\n'User with the given ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to update again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                UpdateUserById();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Manu_UserManagement();
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
                            UpdateUserById();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            Manu_UserManagement();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        string updateAtStr, updateByStr;
      

        public void ShowUserManagement()
        {


            if (anyUpdate)
            {
                Console.WriteLine("-------------------------------------------------------------UserManagement List------------------------------------------------------------");
                string DataLine = string.Format("{0,-10}{1,-10}{2,-10}{3,-10}{4,-20}{5,-10}{6,-25}{7,-20}{8,-25}{9,-20}",
                    "Id", "Name", "Gender", "Password", "Email", "Status", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy","UpdateAt","UpdateBy");
                Console.WriteLine(DataLine);


                foreach (User_Management user in UserList)
                {
                    DateTime date = DateTime.Now;
                    string[] khmerMonths = {
                    "មករា", "កម្ភៈ", "មីនា", "មេសា", "ឧសភា", "មិថុនា",
                    "កក្កដា", "សីហា", "កញ្ញា", "តុលា", "វិច្ឆិកា", "ធ្នូ"
                };
                    string khmerDate = $"{date.Day:00} {khmerMonths[date.Month - 1]} {date.Year}";

                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                    for(int i = 0; i < UserList.Count; i++)
                    {
                        if (user.UserName == UserName && user.Password == Password && user.Email == Email )
                        {
                            updateAtStr = khmerDate;
                            updateByStr = user.UpdateBy.ToString();


                        }
                        else
                        {
                            updateAtStr = user.UpdateBy.ToString("-");
                            updateByStr = user.UpdateAt.ToString("N/A");
                        }
                    }
                  

                    string result = string.Format("{0,-10}{1,-10}{2,-10}{3,-10}{4,-20}{5,-10}{6,-25}{7,-20}{8,-25}{9,-20}",
                    user.Id, user.UserName, user.Gender, user.Password, user.Email, user.Status, user.CreateAt, user.CreateBy, updateAtStr, updateByStr);
                    Console.WriteLine(result);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("----------------------------------------------UserManagement List--------------------------------------------------");
                string DataLine = string.Format("{0,-10}{1,-10}{2,-10}{3,-10}{4,-20}{5,-10}{6,-25}{7,-20}",
                    "Id", "Name", "Gender", "Password", "Email", "Status", "CreateAt", "CreateBy");
                Console.WriteLine(DataLine);
                foreach (User_Management user in UserList)
                {

                  
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                    string result = string.Format("{0,-10}{1,-10}{2,-10}{3,-10}{4,-20}{5,-10}{6,-25}{7,-20}",
                    user.Id, user.UserName, user.Gender, user.Password, user.Email, user.Status, user.CreateAt, user.CreateBy);
                    Console.WriteLine(result);
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            }

            
        }
        
        public void DeleteUserById()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Delete User .!\n");
                    Manu_UserManagement();
                    return;
                }
                Console.WriteLine("-------------------------Delete User---------------------- ");
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
                        DeleteUserById();
                        return;
                    }
                    foreach (User_Management user in UserList)
                    {

                        if (user.Id == this.Id)
                        {
                            found = true;
                            if (user.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{user.UserName}'!");

                                while (true)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteUserById();
                                        break;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        Manu_UserManagement();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                                    }
                                }
                                found = true;
                                break;
                            }
                            while (true)
                            {
                                Console.Write($"Are you sure you want to delete user '{user.UserName}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    UserList.Remove(user);
                                    Console.WriteLine("\nUser deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine("\nDelete operation canceled.");
                                    Manu_UserManagement();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid input: {confirm}. Please enter Y or N.");
                                }

                                found = true;
                            }
                            
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"\nUser with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteUserById();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Manu_UserManagement();
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
                    Console.WriteLine($"Invalid input!:{input} Please enter a valid number  Not string!.");
                    while (true)
                    {
                        Console.Write("Do you want to try Delete again? (Y/N): ");
                        string choice = Console.ReadLine();

                        if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            DeleteUserById();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            Manu_UserManagement();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }

                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public void SearchUserById()
        {
            try
            {
                Console.WriteLine("--------------------------Search User--------------------------\n");
                Console.Write("Please input ID of the user to Search: ");
                string input = Console.ReadLine();
                int userId;
                bool found = false;

                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;

                    foreach (User_Management user in UserList )
                    {

                        if (this.Id < 1)
                        {
                            Console.WriteLine("Please input ID greater than 0.");
                            SearchUserById();
                            return;
                        }
                        if (this.Id.Equals(user.Id))
                        {
                            Console.WriteLine("----------------------------------------------UserManagement List--------------------------------------------------");
                            string DataLine = string.Format("{0,-10}{1,-10}{2,-10}{3,-10}{4,-20}{5,-10}{6,-30}{7,-20}",
                                "Id", "Name", "Gender", "Password", "Email", "Status", "CreateAt", "CreateBy");
                            Console.WriteLine(DataLine);
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                            string result = string.Format("{0,-10}{1,-10}{2,-10}{3,-10}{4,-20}{5,-10}{6,-30}{7,-20}",
                                user.Id, user.UserName, user.Gender, user.Password, user.Email, user.Status, user.CreateAt, user.CreateBy);
                            Console.WriteLine(result);
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"\nUser with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchUserById();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                Manu_UserManagement();
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
                            SearchUserById();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            Manu_UserManagement();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {choice}. Please enter Y or N.");
                        }
                    }

                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
}

