using DhsarabiaTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DhsarabiaTask.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        bool Delete(Employee employee);
        List<Employee> GetEmployees();
        bool Insert(Employee employee);
        bool Update(Employee employee);
    }
}
