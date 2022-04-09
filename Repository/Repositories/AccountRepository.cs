﻿using DataBaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly IDbContextFactory<RestaurantDBContext> _factory;
        public int lastId { get; set; } // nie wiem do czego to jest potrzebne - zostawiam

        public AccountRepository(IDbContextFactory<RestaurantDBContext> factory)
        {
            this._factory = factory;
        }

        public async Task Delete(int id)
        {
            using(var context = _factory.CreateDbContext())
            {
                var Account = await context.Account.FirstOrDefaultAsync(b => b.IdAccount == id);
                if (Account != null)
                {
                    context.Remove(Account);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Account>> GetAll()
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.Account.ToListAsync();
            }
        }

        public async Task<Account> GetById(int id)
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.Account.FindAsync(id);
            }
        }

        public async Task<Account> Insert(Account entity)
        {
            using(var context = _factory.CreateDbContext())
            {
                await context.Account.AddAsync(entity);
                await context.SaveChangesAsync();
                lastId++;
                return entity;
            }
        }

    }
}