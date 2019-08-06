using DemoPetShop.Domain.Entity;
using DemoPetShop.Repository.AnimalRepository;
using DemoPetShop.Repository.Repository.Interface;
using DemoPetShop.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPetShop.Services.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository m_AnimalRepository;
        public AnimalService( IAnimalRepository p_AnimalRepository )
        {
            m_AnimalRepository = p_AnimalRepository;

        }
        public void Insert( Animal animal )
        {
            throw new NotImplementedException( );
        }

        public List<Animal> ListAll( )
        {
            return m_AnimalRepository.FindAll( );
        }
    }
}
