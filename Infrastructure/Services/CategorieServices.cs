using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class CategorieServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=Blog_db;User Id=postgres;Password=2004;";

    public List<CategorieDto> GetCategories()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = "select * from Categories ";
            var result = connection.Query<CategorieDto>(sql);
            return result.ToList();
        }
    }
    
    public List<CategorieDto> GetCategoriesById(int id)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"select * from Categories where id = {id}";
            var result = connection.Query<CategorieDto>(sql);
            return result.ToList();
        }
    }
    
    public void AddCategories(CategorieDto categorieDto)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =
                $"insert into Categories(Id,Title) " +
                $"values " +
                $"({categorieDto.Id},'{categorieDto.Title}')";
            var add = connection.Execute(sql);
            if (add>0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");

        }
    }
    
    public void UpdateCategories(CategorieDto categorieDto)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =  
                $" update Categories "+
                $" set  Title = '{categorieDto.Title}'"+
                $" where id = {categorieDto.Id}";
            var update = connection.Execute(sql);
            if (update>0) System.Console.WriteLine("Updated");
            else System.Console.WriteLine("Not Updaated");

        }
    }
    
    public void DeleteCategories(int id)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"delete from Categories where id = {id} ";
            var delete = connection.Execute(sql);
            if (delete>0) System.Console.WriteLine("Deleted");
            else System.Console.WriteLine("Not Removed");
        }
    }

}