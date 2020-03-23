using DhsarabiaTask.Data.Models;
using DhsarabiaTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DhsarabiaTask.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly DbContext context;
        public EmployeeRepository(DbContext context)
        {
            this.context = context;


        }



        public int Insert(Employee employee)
        {
            context.Set<Employee>().Add(employee);
            try
            {
                context.SaveChanges();
                return employee.Id;
            }
            catch
            {
                return 0;
            }

        }

        public bool Update(Employee employee)
        {
            try
            {
                Employee OldEmployee = context.Set<Employee>().Where(e => e.Id == employee.Id).FirstOrDefault();

                OldEmployee.FirstName = employee.FirstName;


                context.Entry<Employee>(OldEmployee).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(Employee employee)
        {
            try
            {

                context.Set<Employee>().Remove(employee);
                context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }



        public List<Employee> GetEmployees()
        {
            var employees = context.Set<Employee>().ToList();

            return employees;

        }

    }
}
