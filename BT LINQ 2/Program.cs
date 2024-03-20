using System;
using System.Collections.Generic;
using System.Linq;

namespace BT_LINQ_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new List<Department>
            {
                new Department(1, "Phong IT", "Phong cong nghe thong tin"),
                new Department(2, "Phong UX/UI", "Phong thiet ke giao dien nguoi dung"),
                new Department(3, "Phong AI", "Phong tri tue nhan tao"),
            };

            var positions = new List<Position>
            {
                new Position (1,"Dev","Lap trinh vien" ),
                new Position (2, "Designer", "Thiet ke" ),
                new Position (3, "Manager", "Quan ly" ),
            };

            var employees = new List<Employee>
            {
                new Employee(1, "Nguyen Van A", 25, 1, 1),
                new Employee(2, "Tran Thi B", 30, 2, 2),
                new Employee(3, "Le Van C", 35, 3, 3),
                new Employee(4, "Pham Thi D", 40, 1, 2),
                new Employee(5, "Nguyen Van E", 45, 2, 3),
                new Employee(6, "Tran Thi F", 50, 3, 1),
                new Employee(7, "Le Van G", 55, 1, 2),
                new Employee(8, "Pham Thi H", 60, 2, 3),
                new Employee(9, "Nguyen Van I", 65, 3, 1),
                new Employee(10, "Tran Thi K", 70, 1, 2),   
            };

            Console.WriteLine("Nhap tu khoa tim kiem:");
            var keyword = Console.ReadLine();

            Console.WriteLine("Nhap tuoi tu:");
            var minAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap tuoi đen:");
            var maxAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap vi tri cong viec:");
            var position = Console.ReadLine();

            Console.WriteLine("Nhap Phong ban:");
            var department = Console.ReadLine();

            var searchResults = employees
                .Join(positions, e => e.PositionId, p => p.Id, (e, p) => new
                {
                    EmployeeName = e.Name,
                    Age = e.Age,
                    Position = p.Name,
                    Department = departments.Single(d => d.Id == e.DepartmentId).Name
                })
                .Where(e => e.EmployeeName.Contains(keyword))
                .Where(e => e.Age >= minAge && e.Age <= maxAge)
                .Where(e => e.Position.Contains(position))
                .Where(e => e.Department.Contains(department))
                .ToList();     
            
            Console.WriteLine("Ket qua tim kiem:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"Ten nhan vien: {result.EmployeeName}");
                Console.WriteLine($"Tuoi: {result.Age}");
                Console.WriteLine($"Vi tri cong viec: {result.Position}");
                Console.WriteLine($"Phong ban: {result.Department}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}