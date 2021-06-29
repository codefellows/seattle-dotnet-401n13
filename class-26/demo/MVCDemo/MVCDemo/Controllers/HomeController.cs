using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
  public class HomeController : Controller
  {

    // MODEL BINDING:
    // what happens if we put ?name=John in the browser?
    // This is using the query string
    // In our MVC framework, we call this "Model Binding"

    public string Index(string name)
    {
      return $"Hello, {name}";
    }

    public IActionResult People()
    {
      List<Person> people = new List<Person>()
      {
        new Person() { Name="John", Advice="Eat"},
        new Person() { Name="Cathy", Advice="Walk"},
        new Person() { Name="Allie", Advice="Study"},
        new Person() { Name="Zach", Advice="Work"},
      };

      return View(people);
    }

    public IActionResult Person(string name, string advice)
    {
      Person person = new Person()
      {
        Name = name,
        Advice = advice
      };
      return View(person);
    }

    // Show the add user form
    public IActionResult Add()
    {
      return View();
    }


    public IActionResult Article()
    {
      Blog blog = new Blog()
      {
        Title = "The World According To John",
        Description = "Wisdom from the bald one..."
      };

      Post post = new Post()
      {
        Title = "Broccoli should be banned",
        Author = "John Cokos",
        Article = "It's gross, just get rid of it.",
        PostTime = new DateTime(2021, 2, 8)
      };

      BlogPostVm blogpost = new BlogPostVm()
      {
        Blog = blog,
        Post = post
      };

      return View(blogpost);

    }

  }
}
