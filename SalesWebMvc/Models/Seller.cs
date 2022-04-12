using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Inválido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Caracteres informados não reconhecido como {0} valido")]
        [Display(Name = "Funcionário")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Inválido")]
        [EmailAddress(ErrorMessage = "Informe um {0} valido")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Inválido")]
        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Inválido")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} Salário deve ser entre {1} e {2}")]
        [Display(Name = "Base Salárial")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
       
        [Display(Name = "Departamento")]
        public Department Department { get; set; }

        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
