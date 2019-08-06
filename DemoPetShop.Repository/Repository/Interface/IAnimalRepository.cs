using DemoPetShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPetShop.Repository.Repository.Interface
{
    public interface IAnimalRepository
    {
        List<Animal> FindAll( );
        Animal GetById( string p_Id );
        void Insert( Animal obj );
    }
}
