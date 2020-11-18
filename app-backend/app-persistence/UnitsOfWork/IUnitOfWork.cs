using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.UnitsOfWork
{
    public interface IUnitOfWork
    {
        DbContext Open();
        void SaveChanges();
    }
}
