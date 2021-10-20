using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePaymentAPI.KaniniModel;

namespace OnlinePaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlinePaymentController : Controller
    {
        public static stationaryContext db = new stationaryContext();
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await db.PaymentDetails.ToListAsync());
        }




        [HttpPost]
        public async Task<IActionResult> OnlinePay(PaymentDetail b)
        {
            db.PaymentDetails.Add(b);
            await db.SaveChangesAsync();
            return Ok();

        }

    }
}
