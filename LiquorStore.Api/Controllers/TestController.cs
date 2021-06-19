using LiquorStore.DataAccess;
using LiquorStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiquorStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IActionResult Get([FromServices] LiquorStoreContext context)
        {
            var types = new List<LiquorType>
            {
                new LiquorType
                {
                    Name = "Whisky"
                },
                new LiquorType
                {
                    Name = "Vodka"
                },
                new LiquorType
                {
                    Name = "Rum"
                },
                new LiquorType
                {
                    Name = "Gin"
                }
            };

            var brands = new List<Brand>
            {
                new Brand
                {
                    Name = "Jack Daniel's"
                },
                new Brand
                {
                    Name = "Jameson"
                },
                new Brand
                {
                    Name = "Captain Morgan"
                },
                new Brand
                {
                    Name = "Bacardi"
                },
                new Brand
                {
                    Name = "Johnnie Walker"
                }
            };

            var sizes = new List<Size>
            {
                new Size
                {
                    Name = "0.5 l"
                },
                new Size
                {
                    Name = "0.7 l"
                },
                new Size
                {
                    Name = "0.75 l"
                },
                new Size
                {
                    Name = "1 l"
                }
            };

            var liquors = new List<Liquor>
            {
                new Liquor
                {
                    Name = "Black Label 12 Year Old",
                    Price = 45,
                    Description = "Johnnie Walker Black Label is the worlds No 1 Scotch whisky.",
                    Brand = brands.First(b => b.Name == "Johnnie Walker"),
                    Type = types.First(t => t.Name == "Whisky")
                },
                new Liquor
                {
                    Name = "151 (Puerto Rico)",
                    Price = 27,
                    Description = "Bacardi 151 (Puerto Rico) text description.",
                    Brand = brands.First(b => b.Name == "Bacardi"),
                    Type = types.First(t => t.Name == "Rum")
                },
                new Liquor
                {
                    Name = "Spiced",
                    Price = 19,
                    Description = "Captain Morgan Original Spiced Gold is a favourite worldwide.",
                    Brand = brands.First(b => b.Name == "Captain Morgan"),
                    Type = types.First(t => t.Name == "Rum")
                },
                new Liquor
                {
                    Name = "Old No. 7",
                    Price = 24,
                    Description = "Mellowed for smoothness drop by drop through sugar maple charcoal. Matured for character in our own handcrafted barrels",
                    Brand = brands.First(b => b.Name == "Jack Daniel's"),
                    Type = types.First(t => t.Name == "Whisky")
                }
            };


            var liquorSizes = new List<LiquorSizes>
            {
                new LiquorSizes
                {
                    Size = sizes.First(),
                    Liquor = liquors.First()
                },
                new LiquorSizes
                {
                    Size = sizes.First(s => s.Name == "1 l"),
                    Liquor = liquors.First()
                },
                new LiquorSizes
                {
                    Size = sizes.First(s => s.Name == "1 l"),
                    Liquor = liquors.First(s => s.Name == "151 (Puerto Rico)")
                },
                new LiquorSizes
                {
                    Size = sizes.First(s => s.Name == "1 l"),
                    Liquor = liquors.First(l => l.Name == "Spiced")
                },
                new LiquorSizes
                {
                    Size = sizes.First(s => s.Name == "1 l"),
                    Liquor = liquors.First(l => l.Name == "Old No. 7")
                }
            };

            context.LiquorTypes.AddRange(types);
            context.Brands.AddRange(brands);
            context.Sizes.AddRange(sizes);
            context.Liquors.AddRange(liquors);
            context.LiquorSizes.AddRange(liquorSizes);

            context.SaveChanges();

            return Ok();
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
