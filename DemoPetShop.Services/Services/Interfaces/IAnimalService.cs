using DemoPetShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPetShop.Services.Services.Interfaces
{
    public interface IAnimalService
    {
        List<Animal> ListAll( );
        void Insert( Animal animal );

    }
}
