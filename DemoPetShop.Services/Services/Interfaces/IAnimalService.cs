using DemoPetShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPetShop.Services.Services.Interfaces
{
    public interface IAnimalService
    {
        List<Animal> ListAll( );
        Animal GetById( string p_Id);
        void Insert( Animal p_Animal );
        void Delete( string id );

    }
}
