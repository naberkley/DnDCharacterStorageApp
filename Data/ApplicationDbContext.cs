﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnDCharacterStorageApp.Models;

namespace DnDCharacterStorageApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DnDCharacterStorageApp.Models.Character> Character { get; set; } = default!;
    }
}
