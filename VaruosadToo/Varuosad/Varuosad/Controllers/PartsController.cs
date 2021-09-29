using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Varuosad.DTO;

namespace Varuosad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Part> Get([FromQuery] QueryParams queryParams)
        {
            Console.WriteLine(queryParams.Page);
            List<Part> parts = new List<Part>();
            var pathGen = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location ); 
            var path = pathGen+ "\\LE.txt";


            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { "\t" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    var part = new Part();
                    part.SerialNumber = fields[0];
                    part.Name = fields[1];
                    part.price = Double.Parse(fields[8]);
                    parts.Add(part);

                }

            }
            var query = parts.AsQueryable();
            if (queryParams.Sort.ToLower() == "price")
            {
                query = query.OrderBy(part => part.price);
                query = query.Skip(60).Take(30);
                return query.ToList();
            }
            if (queryParams.Sort.ToLower() == "-price")
            {
                query = query.OrderByDescending(part => part.price);
                query = query.Skip(60).Take(30);
                return query.ToList();
            }
            if (queryParams.Sort.ToLower() == "name")
            {
                query = query.OrderByDescending(part => part.Name);
                query = query.Skip(60).Take(30);
                return query.ToList();
            }
            if (queryParams.Sort.ToLower() == "-name")
            {
                query = query.OrderByDescending(part => part.Name);
                query = query.Skip(60).Take(30);
                return query.ToList();
            }

            else
            {
                var CurrentPageContents = parts
                    .Skip(queryParams.PageSize * queryParams.Page - 1)
                    .Take(queryParams.PageSize);
                return CurrentPageContents;
            }


        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
            
        }
    }
}
