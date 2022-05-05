using SpotCheck.Models;
using SpotCheck.Repositories;

namespace SpotCheck.Services
{
    public class SpotsService
    {
        private readonly SpotsRepository _spotsRepo;

        public SpotsService(SpotsRepository spotsRepo)
        {
            _spotsRepo = spotsRepo;
        }

        internal Spot Create(Spot data)
        {
            return _spotsRepo.Create(data);
        }
    }
}