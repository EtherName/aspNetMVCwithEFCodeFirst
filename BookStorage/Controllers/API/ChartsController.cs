using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStorage.Controllers.API
{
    public class ChartsController : ApiController
    {
        Repository reposit { get; set; } = RepositoryFactory.GetRepository();
        [HttpGet]
        public HttpResponseMessage Quantity(int id)
        {
            System.Threading.Thread.Sleep(1000);
            var book = reposit.GetAllBooks().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Person is missed");
            }
            var data = book.GoogleChartData;
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
