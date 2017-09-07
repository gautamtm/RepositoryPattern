using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DbContextTransactionWrapper
    {
        private readonly DbContextTransaction _tx;

        public DbContextTransactionWrapper(DbContextTransaction tx)
        {
            _tx = tx;
        }

        public void Commit()
        {
            _tx.Commit();
        }

        public void Rollback()
        {
            _tx.Rollback();
        }

        public void Dispose()
        {
            _tx.Dispose();
        }
    }

}
