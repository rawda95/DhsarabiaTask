using DhsarabiaTask.Data.Models;
using DhsarabiaTask.Repositories.Interfaces;
using DhsarabiaTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DhsarabiaTask.Services.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public bool Delete(Employee employee)
        {
            return this.employeeRepository.Delete(employee);
        }
        public List<Employee> GetEmployees()
        {
            return this.employeeRepository.GetEmployees();
        }
        public bool Insert(Employee employee)
        {
            return this.employeeRepository.Insert(employee);
        }
        public bool Update(Employee employee)
        {
            return this.employeeRepository.Update(employee);
        }
    }
}

