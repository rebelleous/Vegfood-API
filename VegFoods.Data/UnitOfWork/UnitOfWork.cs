using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.UnitOfWork;
using VegFoods.Data.Repositories;

namespace VegFoods.Data.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private CategoryRepository _categoryRepository;
        private RecipeRepository _recipeRepository;
        private IngredientRepository _ıngredientRepository;
        private UserRepository _userRepository;
        private UserRoleRepository _userRoleRepository;
        private RoleRepository _roleRepository;
        private RecipeIngredientRepository _recipeIngredientRepository;


        public ICategoryRepository Categories => _categoryRepository = _categoryRepository 
            ?? new CategoryRepository(_context);

        public IRecipeRepository Recipes => _recipeRepository = _recipeRepository 
            ?? new RecipeRepository(_context);

        public IingredientRepository Ingredients => _ıngredientRepository = _ıngredientRepository 
            ?? new IngredientRepository(_context);

        public IRoleRepository Roles => _roleRepository = _roleRepository 
            ?? new RoleRepository(_context);

        public IUserRepository Users=> _userRepository = _userRepository 
            ?? new UserRepository(_context);

        public IUserRoleRepository UserRoles => _userRoleRepository = _userRoleRepository 
            ?? new UserRoleRepository(_context);

        public IRecipeIngredientRepository RecipeIngredient => _recipeIngredientRepository = _recipeIngredientRepository 
            ?? new RecipeIngredientRepository(_context);


        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
