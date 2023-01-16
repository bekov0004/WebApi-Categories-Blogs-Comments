using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategorieController
{
    private CategorieServices _categorieServices;

    public CategorieController()
    {
        _categorieServices = new CategorieServices();
    }

    [HttpGet("GetCategorie")]
    public List<CategorieDto> GetCategorie()
    {
        return _categorieServices.GetCategories();
    }
    
    [HttpGet("GetCategoriesById")]
    public List<CategorieDto> GetCategoriesById(int id)
    {
        return _categorieServices.GetCategoriesById(id);
    }
    
    [HttpPost("AddCategories")]
    public void AddQuote(CategorieDto categorieDto)
    {
        _categorieServices.AddCategories(categorieDto);
    }
    
    [HttpPut("UpdateCategories")]
    public void UpdateCategories(CategorieDto categorieDto)
    {
        _categorieServices.UpdateCategories(categorieDto);
    }
    [HttpDelete("DeleteCategories")]
    public void DeleteCategories(int id)
    {
        _categorieServices.DeleteCategories(id);
    }
}