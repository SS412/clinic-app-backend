using System;
using System.Collections.Generic;
using System.Text;
using app_persistence;
using Microsoft.EntityFrameworkCore;

namespace AppPersistence.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context = new Db();

    }
}
