using KHDate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MidTerm_PSO_System.Manu_POS_System;

namespace MidTerm_PSO_System
{
 //   -id
	//-CategoryName
	//-status
	//-CreateAt(date)
	//-CreateBy
	//-UpdateAt(Date)
	//-UpdateBy(Optional)

    internal class CategorManagerment
    {
        public int Id { get; set; }
		public string CategoryName { get; set; }
		public bool Status { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; } = DateTime.Now;
        public int UpdateBy { get; set; } = ByAdmin.ById;
		public int CreateBy { get; set; } = ByAdmin.ById;

        public bool anyUpdate=false;
		public static List<CategorManagerment> CategoryList = new List<CategorManagerment>();
		public CategorManagerment() { }

        public CategorManagerment(int id, string categoryName, bool status, DateTime createAt, int createBy, DateTime updateAt, int updateBy)
        {
            Id = id;
            CategoryName = categoryName;
            Status = status;
            CreateAt = createAt;
            UpdateAt = updateAt;
            UpdateBy = updateBy;
            CreateBy = createBy;
        }
        string UserAndAdmin;
        public void ManuCategory()
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
                Console.WriteLine("1.Add Category");
                Console.WriteLine("2.show Category");
                Console.WriteLine("3.Update Category");
                Console.WriteLine("4.Delete Category");
                Console.WriteLine("5.Search Category");
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

                            AddCategoryManagerment();
                            break;
                        case 2:
                            ShowCategoryManagerment();
                            break;
                        case 3:
                            UpdateCategory();
                            break;
                        case 4:
                            DeleteCategory();
                            break;
                        case 5:
                            Searchcategory();
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
        public void AddCategoryManagerment()
        {
            try
            {

                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update Category.!\n");
                    ManuCategory();
                    return;
                }
                Console.Write("input Count Add User:");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"-------------------input Information Category {i + 1}--------------------\n");
                    CategorManagerment category = new CategorManagerment();
                    start:
                    Console.Write("input Id:");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    if (CategoryList.Any(p => p.Id == inputId))
                    {
                        Console.WriteLine($"Id: {inputId} already exists. Please input a different Id:");
                        goto start;
                    }
                    else
                    {
                        category.Id = inputId;

                    }
                    Console.Write("input CategoryName:");
                    category.CategoryName = Console.ReadLine();

                    Console.Write("input Status:");
                    category.Status = Boolean.Parse(Console.ReadLine());

                    
                    CategoryList.Add(category);
                    Console.WriteLine("\n Category added successfully!\n");
                    category.CreateAt = DateTime.Now;
                    anyUpdate = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        string updateAtStr, updateByStr;
        public void ShowCategoryManagerment()
        {
            if (anyUpdate)
            {
                Console.WriteLine("------------------------------------------Categoty Management List (Update) ------------------------------------------");
                string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-25}{4,-15}{5,-25}{6,-15}", "Id", "CategoryName", "Status", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy");
                Console.WriteLine(header);

                foreach (CategorManagerment category in CategoryList)
                {

                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                    updateAtStr = (category.CategoryName == CategoryName) ? DateKH.UpdateGetKhmerDate(category.UpdateAt) : "-";
                    updateByStr = (category.CategoryName == CategoryName) ? category.UpdateBy.ToString() : "N/A";
                    //if(category.CategoryName == CategoryName)
                    //{
                    //    updateAtStr = KHDate.DateKH.UpdateGetKhmerDate(category.UpdateAt);
                    //    updateByStr = category.UpdateBy.ToString();
                    //}
                    //else
                    //{
                    //    updateAtStr = category.UpdateAt.ToString("-");
                    //    updateByStr = category.UpdateBy.ToString("N/A");
                    //}

                    string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-25}{4,-15}{5,-25}{6,-15}",
                        category.Id, category.CategoryName, category.Status, KHDate.DateKH.GetKhmerDate(category.CreateAt), category.CreateBy, updateAtStr, updateByStr);

                    Console.WriteLine(row);
                }

                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("------------------------------------------ Categoty Management List ------------------------------------------");
                string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}", "Id", "CategoryName", "Status", "CreateAt", "CreateBy");
                Console.WriteLine(header);

                foreach (CategorManagerment category in CategoryList)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}",
                        category.Id, category.CategoryName, category.Status,KHDate.DateKH.GetKhmerDate(category.CreateAt), category.CreateBy);

                    Console.WriteLine(row);
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------");

            }
        }
        public void UpdateCategory()
        {
            try
            {

                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update Update.!\n");
                    ManuCategory();
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
                    foreach (CategorManagerment category in CategoryList)
                    {
                        if (this.Id.Equals(category.Id))
                        {
                            Console.Write("input CategoryName:");
                            CategoryName = Console.ReadLine();
                            category.CategoryName = CategoryName;

                            Console.Write("input Status:");
                            Status = Boolean.Parse(Console.ReadLine());
                            category.Status = Status;
                            Console.WriteLine("\nYou updated successfully!");
                            found = true;
                            anyUpdate = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"\n Category with the given ID = {input} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to update again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                UpdateCategory();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuCategory();
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
                            UpdateCategory();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuCategory();
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
        public void DeleteCategory()
        {
            try
            {

                if (!UserCheck.chackUserOrAdmin)
                {
                    Console.WriteLine("You do not have permission to Update Delete.!\n");
                    ManuCategory();
                    return;
                }
                Console.WriteLine("-----------------------------------Delete Category-----------------------------");
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
                        DeleteCategory();
                        return;
                    }
                    foreach (CategorManagerment category in CategoryList)
                    {
                        if (category.Id == this.Id)
                        {
                            found = true;

                            if (this.Id == 1)
                            {
                                Console.WriteLine($"You can't delete the system UserName '{category.CategoryName}'!");

                                while (found)
                                {
                                    Console.Write("Do you want to try deleting again? (Y/N): ");
                                    string choice = Console.ReadLine();

                                    if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DeleteCategory();
                                        return;
                                    }
                                    else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        ManuCategory();
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
                                Console.Write($"Are you sure you want to delete user '{category.CategoryName}'? (Y/N): ");
                                string confirm = Console.ReadLine();

                                if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    CategoryList.Remove(category);
                                    Console.WriteLine("\nUser deleted successfully!");
                                    break;
                                }
                                else if (confirm.Equals("N", StringComparison.OrdinalIgnoreCase))
                                {
                                    ManuCategory();
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
                        Console.WriteLine($"\n Category with ID = {this.Id} not found.\n");

                        while (true)
                        {
                            Console.Write("Do you want to try deleting again? (Y/N): ");
                            string choice = Console.ReadLine();

                            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteCategory();
                                return;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuCategory();
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
                            DeleteCategory();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuCategory();
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
        public void Searchcategory()
        {
            try
            {
                Console.WriteLine("--------------------------Search Category--------------------------\n");
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
                        Searchcategory();
                        return;
                    }

                    foreach (CategorManagerment category in CategoryList)
                    {
                        if (this.Id == category.Id)
                        {
                            Console.WriteLine("------------------------------------------ Categoty Management List ------------------------------------------");
                            string header = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}", "Id", "CategoryName", "Status", "CreateAt", "CreateBy");
                            Console.WriteLine(header);

                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            string row = string.Format("{0,-10}{1,-15}{2,-10}{3,-15}{4,-15}",category.Id, category.CategoryName, category.Status,
                            KHDate.DateKH.GetKhmerDate(category.CreateAt), category.CreateBy);
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
                                Searchcategory();
                                break;
                            }
                            else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                            {
                                ManuCategory();
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
                            Searchcategory();
                            return;
                        }
                        else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            ManuCategory();
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
