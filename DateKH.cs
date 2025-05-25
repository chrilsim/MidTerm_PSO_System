using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHDate
{
    
    public class DateKH
    {
       
        public  static string GetKhmerDate(DateTime CreateAt)
        {
            string[] khmerMonths = {
            "មករា", "កម្ភៈ", "មីនា", "មេសា", "ឧសភា", "មិថុនា",
            "កក្កដា", "សីហា", "កញ្ញា", "តុលា", "វិច្ឆិកា", "ធ្នូ"
            };

            return $"{CreateAt.Day:00} {khmerMonths[CreateAt.Month - 1]} {CreateAt.Year}";
        }

        public static string UpdateGetKhmerDate(DateTime UpdateAt)
        {
            DateTime date = DateTime.Now;
            string[] khmerMonths = {
                    "មករា", "កម្ភៈ", "មីនា", "មេសា", "ឧសភា", "មិថុនា",
                    "កក្កដា", "សីហា", "កញ្ញា", "តុលា", "វិច្ឆិកា", "ធ្នូ"
                    };
             return $"{date.Day:00} {khmerMonths[date.Month - 1]} {date.Year} ម៉ោង {date.Hour:00}:{date.Minute:00}";
        }
    }
}
