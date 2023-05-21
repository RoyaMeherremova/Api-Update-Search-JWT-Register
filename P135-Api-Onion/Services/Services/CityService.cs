using AutoMapper;
using Domain.Models;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Services.DTOs.City;
using Services.DTOs.Country;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CityService : ICityService
    {

        private readonly ICityRepository _cityRepo;

        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepo, IMapper mapper, AppDbContext context)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityCreateDto city) => await _cityRepo.CreateAsync(_mapper.Map<City>(city));


        public async Task DeleteAsync(int? id) => await _cityRepo.DeleteAsync(await _cityRepo.GetByIdAsync(id));

        public async Task<IEnumerable<CityDto>> GetAllAsync() => _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.FindAllAsync());

        public async Task<CityDto> GetByIdAsync(int? id) => _mapper.Map<CityDto>(await _cityRepo.GetByIdAsync(id));


        public async Task SoftDeleteAsync(int id)
        {
            await _cityRepo.SoftDeleteAsync(id);
        }

        public async Task UpdateAsync(int? id, CityUpdateDto city)
        {
            if (id is null) throw new ArgumentNullException();

            var existCity = await _cityRepo.GetByIdAsync(id) ?? throw new NullReferenceException(); //eyer varsa bu id-de data onu ver yoxdusa null-exception qaytar

            _mapper.Map(city, existCity);  //bize gelen Dto-nu map ele modelmize

            await _cityRepo.UpdateAsync(existCity); //ve gonder update
        }

        public async Task<IEnumerable<CityDto>> SearchAsync(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.FindAllAsync());  //searchText gelmirse butun datalari versin
            return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.FindAllAsync(m => m.Name.Contains(searchText))); //gelirse searchtext ona uyqun olanlari
        }
    }
}
