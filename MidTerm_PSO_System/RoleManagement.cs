using KHDate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
	//   -id
	//-Name
	//-Status
	//-CreateAt(date)
	//-CreateBy
	//-UpdateAt(Date)
	//-UpdateBy(Optional)

	internal class RoleManagement
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }
		public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; } = ByAdmin.ById;
		public DateTime UpdateAt { get; set; }
		public int UpdateBy { get; set; } = ByAdmin.ById;
        public bool anyUpdate = false;
        
        public static List<RoleManagement> RoleList = new List<RoleManagement>()
        {
        new RoleManagement(1, "Admin", true, DateTime.Parse("2025-5-2"), 1, DateTime.Parse("2025-5-2"), 1),
        new RoleManagement(2, "User", false, DateTime.Parse("2025-5-2"), 1, DateTime.Parse("2025-5-2"), 1)
        };

        public RoleManagement() { }
		public RoleManagement(int Id, string Name, bool Status, DateTime CreateAt, int CreateBy, DateTime UpdateAt, int UpdateBy)
        {
           this.Id = Id;
           this.Name = Name;
            this.Status = Status;
            this.CreateBy = CreateBy;
            this.CreateAt = CreateAt;
            this.UpdateAt = UpdateAt;
            this.UpdateBy = UpdateBy;
            this.UpdateAt = UpdateAt;
           
        }
        string UserAndAdmin;
        public void ManuRoleManagerment()
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
                Console.WriteLine("-----------------------Manu Role Managerment-------------------- ");
                Console.WriteLine("1.Add Role");
                Console.WriteLine("2.show Role");
                Console.WriteLine("3.Update Role");
                Console.WriteLine("4.Delete Role");
                Console.WriteLine("5.Search Role");
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

                            AddRoleManagerment();
                            break;
                        case 2:
                            ShowRoleManagerment();
                            break;
                        case 3:

                            UpdateRoleManagerment();
                            break;
                        case 4:
                           DeleteRoleManagerment();
                            break;
                        case 5:
                            SearchRoleManagerment();
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
		public void AddRoleManagerment()
		{
			try
			{
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Add Role.!\n");
                    ManuRoleManagerment();
                    return;
                }
                Console.Write("input Count Add User:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information User {i + 1}--------------------\n");
                    RoleManagement Role = new RoleManagement();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (RoleList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        Role.Id = inputId;

                    }

                    Console.Write("input Name:");
                    Role.Name = Console.ReadLine();

                    Console.Write("input Status:");
                    Role.Status = Boolean.Parse(Console.ReadLine());

                    RoleList.Add(Role);
                    Console.WriteLine("\n Role added successfully!\n");
                    Role.CreateAt = DateTime.Now;
                    anyUpdate = false;
                }
            }
			catch (Exception ex) { Console.WriteLine(ex.Message); }
		}
        public void UpdateRoleManagerment() 
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Add Update.!\n");
                    ManuRoleManagerment();
                    return;
                }
                Console.WriteLine("-------------------------Update Role ---------------------- ");
                Console.Write("Please input ID of the user to update: ");
                string input = Console.ReadLine();
                bool found = false;
                int userId;
                if (int.TryParse(input, out userId))
                {
                    this.Id = userId;
                    foreach (RoleManagement Role in RoleList)
                    {
                        if (this.Id.Equals(Role.Id))
                        {
                            Console.Write("Input Name: ");
                            Name = Console.ReadLine();
                            Role.Name = Name;

                            Console.Write("Input Status: ");
                            Status = bool.Parse(Console.ReadLine());
                            Role.Status = Status;


                            anyUpdate = true;
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
                                UpdateRoleManagerment();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuRoleManagerment();
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
                            UpdateRoleManagerment();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuRoleManagerment();
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
                Console.WriteLine(ex.Message);
            }
        }
        string updateAtStr, updateByStr;
        
        public void ShowRoleManagerment()
        {
            if (anyUpdate)
            {
                Console.WriteLine("------------------------------------------ Role Management List (Update) ------------------------------------------");
                string header = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}{5,-25}{6,-15}", "Id", "Name", "Status", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy");
                Console.WriteLine(header);

                foreach (RoleManagement Role in RoleList)
                {

                   

                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                    updateAtStr = (Role.Name == Name) ? DateKH.UpdateGetKhmerDate(Role.UpdateAt) : "-";
                    updateByStr = (Role.Name == Name) ? Role.UpdateBy.ToString(): "N/A";
     
                    string row = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}{5,-27}{6,-15}",
                        Role.Id, Role.Name, Role.Status, DateKH.GetKhmerDate(Role.CreateAt), Role.CreateBy, updateAtStr, updateByStr);

                    Console.WriteLine(row);
                }

                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("------------------------------------------ User Role Management List ------------------------------------------");
                string header = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}", "Id", "Name", "Satus", "CreateAt", "CreateBy");
                Console.WriteLine(header);

                foreach (RoleManagement Role in RoleList)
                {
                    
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    string row = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}",
                        Role.Id, Role.Name, Role.Status, DateKH.GetKhmerDate(Role.CreateAt), Role.CreateBy);

                    Console.WriteLine(row);
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------");

            }
        }
        public  void DeleteRoleManagerment()
        {
            try
            {
                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Delete Role.!\n");
                    ManuRoleManagerment();
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
                        DeleteRoleManagerment();
                        return;
                    }
                    foreach (RoleManagement Role in RoleList)
                    {
                        if (Role.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{Role.Name}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteRoleManagerment(); 
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuRoleManagerment();
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
                                Console.Write($"Are you sure you want to delete user '{Role.Name}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    RoleList.Remove(Role);
                                    Console.WriteLine("\nUser deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuRoleManagerment();
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
                                DeleteRoleManagerment();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuRoleManagerment() ;
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
                            DeleteRoleManagerment() ;
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuRoleManagerment();
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
        public void SearchRoleManagerment()
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
                        SearchRoleManagerment();
                        return;
                    }

                    foreach (RoleManagement Role in RoleList)
                    {
                        if (this.Id == Role.Id)
                        {
                            Console.WriteLine("------------------------------------------ User Role Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}", "Id", "Name", "Status", "CreateAt", "CreateBy");
                            Console.WriteLine(header);
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-10}{2,-10}{3,-30}{4,-20}",
                                Role.Id, Role.Name, Role.Status,KHDate.DateKH.GetKhmerDate(Role.CreateAt), Role.CreateBy);

                            Console.WriteLine(row);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            found = true;
                            break;
                        }

                    }
                    if (!found)
                    {
                        Console.WriteLine($"\n Role with ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try Search again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                SearchRoleManagerment();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuRoleManagerment();
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
                            SearchRoleManagerment();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuRoleManagerment();
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
