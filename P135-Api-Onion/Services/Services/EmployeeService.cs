using AutoMapper;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Services.DTOs.Employee;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo,IMapper mapper,AppDbContext context)
        {
            _employeeRepo = employeeRepo; 
            _mapper = mapper;
        }

        public async Task CreateAsync(EmployeeCreateDto employee) => await _employeeRepo.CreateAsync(_mapper.Map<Employee>(employee));
      
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync() => _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeRepo.FindAllAsync());

        public async Task<EmployeeDto> GetByIdAsync(int? id) => _mapper.Map<EmployeeDto>(await _employeeRepo.GetByIdAsync(id));

        public async Task DeleteAsync(int? id) => await _employeeRepo.DeleteAsync(await _employeeRepo.GetByIdAsync(id));

        public async Task UpdateAsync(int? id, EmployeeUpdateDto employee)
        {
            if(id is null) throw new ArgumentNullException();

            var existEmployee = await _employeeRepo.GetByIdAsync(id) ?? throw new NullReferenceException(); //eyer varsa bu id-de data onu ver yoxdusa null-exception qaytar

            _mapper.Map(employee, existEmployee);  //bize gelen Dto-nu map ele modelmize

            await _employeeRepo.UpdateAsync(existEmployee); //ve gonder update
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _employeeRepo.SoftDeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> SearchAsync(string? searchText)
        {
            if(string.IsNullOrEmpty(searchText))
             return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeRepo.FindAllAsync());  //searchText gelmirse butun datalari versin
           return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeRepo.FindAllAsync(m => m.FullName.Contains(searchText))); //gelirse searchtext ona uyqun olanlari versin
        }
      
    }
}
