using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PWAPhotos.Data;
using PWAPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWAPhotos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        
        private readonly ILogger<ImagesController> _logger;
        private readonly DBContext  _cntx;

        public ImagesController(ILogger<ImagesController> logger, DBContext cntx)
        {
            _cntx = cntx;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<ImageDTO>> Get()
        {
            var images = await _cntx.Images.ToListAsync();
            return images;
        }


        [HttpPost]
        public async Task<IActionResult> Post(ImageDTO image)
        {
            try
            {
                await _cntx.Images.AddAsync(image);
                await _cntx.SaveChangesAsync();
            }
            catch (Exception e )
            {
                throw;
            }
           
            return Ok(image);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var image = await _cntx.Images.FindAsync(Id);
            _cntx.Images.Remove(image);
            await _cntx.SaveChangesAsync();
            return Ok("Id");
        }
    }
}
