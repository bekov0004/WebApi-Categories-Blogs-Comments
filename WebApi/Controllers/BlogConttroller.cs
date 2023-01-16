using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BlogConttroller
{
    private BlogServices _blogServices;

    public BlogConttroller()
    {
        _blogServices = new BlogServices();
    }

    [HttpGet("GetBlog")]
    public List<Blog> GetBlog()
    {
        return _blogServices.GetBlog();
    }
    
    [HttpGet("GetBlogsById")]
    public List<Blog> GetBlogsById(int id)
    {
        return _blogServices.GetBlogsById(id);
    }
    [HttpGet("GetBlogByCategoryId")]
    public List<Blog> GetBlogByCategoryId(int id)
    {
        return _blogServices.GetBlogByCategoryId(id);
    }
    
    [HttpPost("AddBlogs")]
    public void AddQuote(Blog blog)
    {
        _blogServices.AddBlogs(blog);
    }
    
    [HttpPut("UpdateBlog")]
    public void UpdateBlog(Blog blog)
    {
        _blogServices.UpdateBlog(blog);
    }
    [HttpDelete("DeleteCategories")]
    public void DeleteBlog(int id)
    {
        _blogServices.DeleteBlog(id);
    }
}