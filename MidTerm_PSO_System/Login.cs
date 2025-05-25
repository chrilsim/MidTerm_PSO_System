using System;
using System.Collections.Generic;

namespace MidTerm_PSO_System
{
    internal class Login
    {
        public int Id { get;  set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; } 
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; } 
        public int UpdateBy { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; } 
        public string Name { get; set; }
        public int RoleId { get; set; }
        public object UpdateAt { get; internal set; }

        public static List<Login> loginList = new List<Login>()
        {
            new Login(1, "Admin", "123", true, "M", "Simchril@gmail.com", DateTime.Parse("2025-5-2") ,1,DateTime.Now),
            new Login(2, "User", "1234", false, "M", "User@gmail.com", DateTime.Parse("2025-5-2"), 2, DateTime.Now)
        };

        public Login()
        {

        }

        public Login(int Id, string UserName, string Password, bool Status, string Gender, string Email, DateTime CreateAt ,int UpdateBy,DateTime UpdateAt)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Password = Password;
            this.Status = Status;
            this.Gender = Gender;
            this.Email = Email;
            this.CreateAt = CreateAt;
            this.UpdateBy = UpdateBy;
        }

        public void LoginManagement_Admin()
        {
        start:
            Console.WriteLine("---------------------Login Admin------------------");
            Console.Write("input Username:");
            this.UserName = Console.ReadLine();
            Console.Write("input Password:");
            this.Password = Console.ReadLine();

            bool check = false;

            foreach (Login login in loginList)
            {
                if (this.UserName.Equals(login.UserName) && this.Password.Equals(login.Password) && login.Status == true)
                {
                    check = true;
                    Console.WriteLine("Login successful!\n");

                    Manu_POS_System manu_POS_System = new Manu_POS_System();
                    manu_POS_System.Manu_POS_Admin();
                    break;
                }
            }

            if (!check)
            {
                Console.WriteLine("Username or Password is invalid!");
                goto start;
            }
        }

        public void LoginManagement_User()
        {
            try
            {

                start:
                Console.WriteLine("---------------------Login User------------------");
                Console.Write("input Username:");
                this.UserName = Console.ReadLine();
                Console.Write("input Password:");
                this.Password = Console.ReadLine();

                bool check = false;

                foreach (Login login in loginList)
                {
                    if (this.UserName.Equals(login.UserName) && this.Password.Equals(login.Password) && login.Status == false)
                    {
                        check = true;
                        Console.WriteLine("Login successful!\n");

                        Manu_POS_System manu_POS_System = new Manu_POS_System();
                        manu_POS_System.Manu_POS_User();
                        break;
                    }
                }

                if (!check)
                {
                    Console.WriteLine("Username or Password is invalid!\n");
                    goto start;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AdminOrUser()
        {
            try
            {
                while (true)
                {

                    Console.WriteLine("----------Select Admin or User--------");
                    Console.WriteLine("1.Admin");
                    Console.WriteLine("2.User");
                    Console.WriteLine("'-------------------------------------");
                    Console.Write("Please Select option:");
                    int Role = Convert.ToInt32(Console.ReadLine());

                    switch (Role)
                    {
                        case 1:
                            LoginManagement_Admin();
                            break;
                        case 2:
                            LoginManagement_User();
                            break;
                        default:
                            Console.WriteLine("Please input User or Admin again!");
                            break;

                    }

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            AdminOrUser();
            return;
        }
    }
}
