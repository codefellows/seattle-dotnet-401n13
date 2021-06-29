using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadingDemo.Models;
using UploadingDemo.Services;

namespace UploadingDemo.Controllers
{
  public class HomeController : Controller
  {

    IConfiguration Configuration;
    IAzureBlob BlobService;

    public HomeController(IConfiguration config, IAzureBlob blobService)
    {
      Configuration = config;
      BlobService = blobService;

    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(IFormFile file)
    {

      Document doc = await BlobService.Upload(file);

      // Upload the file
      return View(doc);
    }


  }
}
