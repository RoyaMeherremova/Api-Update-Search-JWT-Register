using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository  //EmployeRepository Umumi Repositoriden miras alirqki tekrar CRUD-larin implementini yazmayaq 
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }    //ve Umumi Repository icinde constructoru argument teleb edir deye,bizde miras almisiq deye mecburi nese gonderik
    }
}

