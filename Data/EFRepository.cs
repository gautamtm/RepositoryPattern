using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Extension;

namespace Data
{
    public partial class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        private bool _isEntityTracked;

        public EFRepository(IDbContext context)
        {
            context.AutoCommitEnabled = true;
            this._context = context;
        }
 
        #region interface members
 
        public virtual IQueryable<T> Table
        {
            get
            {
                if (_context.ForceNoTracking)
                {
                    return this.Entities.AsNoTracking();
                }
                return this.Entities;
            }
        }
 
        public virtual IQueryable<T> TableUntracked
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }
 
        public virtual ICollection<T> Local
        {
            get
            {
                return this.Entities.Local;
            }
        }
 
        public virtual T Create()
        {
            return this.Entities.Create();
        }
 
        public virtual T GetById(object id)
        {
            _isEntityTracked = true;
            return this.Entities.Find(id);
        }
 
        public virtual T Attach(T entity)
        {
            return this.Entities.Attach(entity);
        }
 
        public bool IsAttached(T entity)
        {
            ObjectStateEntry entry;
            var adapter = (IObjectContextAdapter)_context;
 
            if (adapter.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
            {
                return entry.State != EntityState.Detached;
            }
 
            return false;
        }
 
        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
 
            this.Entities.Add(entity);
 
            if (this.AutoCommitEnabledInternal)
                _context.SaveChanges();
        }
 
        public virtual void InsertRange(IEnumerable<T> entities, int batchSize = 100)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
 
                if (entities.Any())
                {
                    if (batchSize <= 0)
                    {
                        // insert all in one step
                        entities.Each(x => this.Entities.Add(x));
                        if (this.AutoCommitEnabledInternal)
                            _context.SaveChanges();
                    }
                    else
                    {
                        int i = 1;
                        bool saved = false;
                        foreach (var entity in entities)
                        {
                            this.Entities.Add(entity);
                            saved = false;
                            if (i % batchSize == 0)
                            {
                                if (this.AutoCommitEnabledInternal)
                                    _context.SaveChanges();
                                i = 0;
                                saved = true;
                            }
                            i++;
                        }
 
                        if (!saved)
                        {
                            if (this.AutoCommitEnabledInternal)
                                _context.SaveChanges();
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }
 
        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
 
            SetEntityStateToModifiedIfApplicable(entity);
 
            if (this.AutoCommitEnabledInternal)
            {
                _context.SaveChanges();
            }
        }
 
        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");
 
            entities.Each(entity =>
            {
                //_entities.AddOrUpdate(entity);
                _entities.Attach(entity);
                //SetEntityStateToModifiedIfApplicable(entity);
            });
 
            if (this.AutoCommitEnabledInternal)
            {
                _context.SaveChanges();
            }
        }
 
        private void SetEntityStateToModifiedIfApplicable(T entity)
        {
            var entry = InternalContext.Entry(entity);
            if (entry.State < System.Data.Entity.EntityState.Added || (this.AutoCommitEnabledInternal && !InternalContext.Configuration.AutoDetectChangesEnabled))
            {
                entry.State = System.Data.Entity.EntityState.Modified;
            }
        }
 
        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
 
            if (InternalContext.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                this.Entities.Attach(entity);
            }
 
            this.Entities.Remove(entity);
 
            if (this.AutoCommitEnabledInternal)
                _context.SaveChanges();
        }
 
        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");
 
            entities.Each(entity =>
            {
                //_entities.Remove(entity);
                this.Entities.Attach(entity);
                ((DbContext)_context).Entry(entity).State = EntityState.Deleted;
            });
 
            //this.Entities.RemoveRange(entities);
 
            if (this.AutoCommitEnabledInternal)
                _context.SaveChanges();
        }
 
        public virtual bool IsModified(T entity)
        {
            var ctx = InternalContext;
            var entry = ctx.Entry(entity);
 
            if (entry != null)
            {
                var modified = entry.State == System.Data.Entity.EntityState.Modified;
                return modified;
            }
 
            return false;
        }
 
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
 
 
        public virtual IDbContext Context
        {
            get { return _context; }
        }
 
        public bool? AutoCommitEnabled { get; set; }
 
        private bool AutoCommitEnabledInternal
        {
            get
            {
                return this.AutoCommitEnabled ?? _context.AutoCommitEnabled;
            }
        }
 
        #endregion
 
        #region Helpers
 
        protected internal TestDbContext InternalContext
        {
            get { return _context as TestDbContext; }
        }
 
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities as DbSet<T>;
            }
        }
 
        #endregion

    }
}
