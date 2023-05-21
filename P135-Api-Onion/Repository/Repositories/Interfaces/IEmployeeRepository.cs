using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee> //Umumi IRepository interfacden basqa IEmployeRepository yaradirqki ozne mexsus methodlarida istifade ede bilek,yani IRepoda olan CRUD-lardan basqa
    {


    }
}
