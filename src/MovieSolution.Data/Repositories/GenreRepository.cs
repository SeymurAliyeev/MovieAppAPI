using Microsoft.EntityFrameworkCore;
using MovieSolution.Core.Entities;
using MovieSolution.Core.Repositories;
using MovieSolution.Data.Context;
using System.Linq.Expressions;

namespace MovieSolution.Data.Repositories;

public class GenreRepository : IGenreRepositories
{
    private readonly AppDbContext _context;

    public GenreRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Delete(Genre Genre)
    {
        _context.Genres.Remove(Genre);
    }

    public async Task<List<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes)
    {
        var query = _context.Genres.AsQueryable();

        if(includes is not null)
        {
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
        }

        return expression is not null
            ? await query.Where(expression).ToListAsync()
            : await query.ToListAsync();
        
    }

    public async Task<Genre> GetAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes)
    {
        var query = _context.Genres.AsQueryable();

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return expression is not null
            ? await query.Where(expression).FirstOrDefaultAsync()
            : await query.FirstOrDefaultAsync();
    }

    public async Task<Genre> GetByIdAsync(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public async Task InsertAsync(Genre genre)
    {
        await _context.Genres.AddAsync(genre);
    }
}
