﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : class, new();

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

        string Alias { get; }

        // increasing performance on bulk operations
        bool ProxyCreationEnabled { get; set; }
        bool LazyLoadingEnabled { get; set; }
        bool AutoDetectChangesEnabled { get; set; }
        bool ValidateOnSaveEnabled { get; set; }
        bool HasChanges { get; }


        /// <summary>
        /// Gets or sets a value indicating whether entities returned from queries
        /// or created from stored procedures
        /// should automatically be attached to the <c>DbContext</c>.
        /// </summary>
        /// <remarks>
        /// Set this to <c>true</c> only during long running processes (like export)
        /// </remarks>
        bool ForceNoTracking { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether database write operations
        /// originating from repositories should be committed immediately.
        /// </summary>
        bool AutoCommitEnabled { get; set; }

        /// <summary>
        /// Determines whether the given entity is already attached to the current object context
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">The entity instance to attach</param>
        /// <returns><c>true</c> when the entity is attched already, <c>false</c> otherwise</returns>
        bool IsAttached<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Attaches an entity to the context or returns an already attached entity (if it was already attached)
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Attached entity</returns>
        TEntity Attach<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Detaches an entity from the current object context if it's attached
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">The entity instance to detach</param>
        void DetachEntity<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Detaches all entities of type <c>TEntity</c> from the current object context
        /// </summary>
        /// <param name="unchangedEntitiesOnly">When <c>true</c>, only entities in unchanged state get detached.</param>
        /// <returns>The count of detached entities</returns>
        int DetachEntities<TEntity>(bool unchangedEntitiesOnly = true) where TEntity : class;

        /// <summary>
        /// Change the state of an entity object
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">The entity instance</param>
        /// <param name="newState">The new state</param>
        void ChangeState<TEntity>(TEntity entity, System.Data.Entity.EntityState newState) where TEntity : class;

        /// <summary>
        /// Reloads the entity from the database overwriting any property values with values from the database. 
        /// The entity will be in the Unchanged state after calling this method. 
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">The entity instance</param>
        void ReloadEntity<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Begins a transaction on the underlying connection using the specified isolation level 
        /// </summary>
        /// <param name="isolationLevel">The database isolation level with which the underlying transaction will be created</param>
        /// <returns>A transaction object wrapping access to the underlying store's transaction object</returns>
        DbContextTransactionWrapper BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);

        /// <summary>
        /// Enables the user to pass in a database transaction created outside of the Database object if you want the Entity Framework to execute commands within that external transaction. Alternatively, pass in null to clear the framework's knowledge of that transaction.
        /// </summary>
        /// <param name="transaction">the external transaction</param>
        void UseTransaction(DbTransaction transaction);

    }
}
