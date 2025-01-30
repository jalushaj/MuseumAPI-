
using MuseumAPI.Data.Models;
using tryfour.Repositories;

namespace MuseumAPI.Data.Services
{
    public class ExhibitionService
    {
        private readonly ExhibitionRepository _repository;

        public ExhibitionService(ExhibitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExhibitionDTO>> GetAllAsync()
        {
            var exhibitions = await _repository.GetAllAsync();
            return exhibitions.Select(e => new ExhibitionDTO
            {
                Name = e.Name,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                VisitorType = e.VisitorType,
                EventType = e.EventType
            }).ToList();
        }

        public async Task<ExhibitionDTO> GetByIdAsync(int id)
        {
            var exhibition = await _repository.GetByIdAsync(id);
            if (exhibition == null) return null;

            return new ExhibitionDTO
            {
                Name = exhibition.Name,
                Description = exhibition.Description,
                StartDate = exhibition.StartDate,
                EndDate = exhibition.EndDate,
                VisitorType = exhibition.VisitorType,
                EventType = exhibition.EventType
            };
        }

        public async Task AddAsync(ExhibitionDTO exhibitionDTO)
        {
            var exhibition = new Exhibition
            {
                Name = exhibitionDTO.Name,
                Description = exhibitionDTO.Description,
                StartDate = exhibitionDTO.StartDate,
                EndDate = exhibitionDTO.EndDate,
                VisitorType = exhibitionDTO.VisitorType,
                EventType = exhibitionDTO.EventType
            };

            await _repository.AddAsync(exhibition);
        }

        public async Task UpdateAsync(int id, ExhibitionDTO exhibitionDTO)
        {
            var exhibition = await _repository.GetByIdAsync(id);
            if (exhibition == null) return;

            exhibition.Name = exhibitionDTO.Name;
            exhibition.Description = exhibitionDTO.Description;
            exhibition.StartDate = exhibitionDTO.StartDate;
            exhibition.EndDate = exhibitionDTO.EndDate;
            exhibition.VisitorType = exhibitionDTO.VisitorType;
            exhibition.EventType = exhibitionDTO.EventType;

            await _repository.UpdateAsync(exhibition);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
