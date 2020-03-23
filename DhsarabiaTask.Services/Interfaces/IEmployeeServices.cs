using DhsarabiaTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DhsarabiaTask.Services.Interfaces
{
    public interface IEmployeeServices
    {
        bool Delete(Employee employee);
        List<Employee> GetEmployees();
        int Insert(Employee employee);
        bool Update(Employee employee);
    }
}