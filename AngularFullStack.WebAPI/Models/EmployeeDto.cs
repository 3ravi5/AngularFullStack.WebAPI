﻿namespace AngularFullStack.WebAPI.Models
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public long Address { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }
}
