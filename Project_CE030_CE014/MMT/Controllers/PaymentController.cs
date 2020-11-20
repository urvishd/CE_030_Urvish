using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMT.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;

namespace MMT.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly PackageDbContext _context;
        
        public string SessionAmt1 = "_Amt1";
        public string SessionOtp1 = "_OTP1";
        public string Sessioncard1 = "_card1";
        public string Sessionpkgid1 = "_pkgid1";

        public PaymentController(PackageDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Dopayment(string username, int persons, string startdate, string email, string city, string payments)
        {
            ViewBag.amt = TempData["amount1"];
            int total = persons * (int)TempData["amount1"];
            HttpContext.Session.SetInt32(SessionAmt1, total);
            string total1 = total.ToString(); 
            
           var transaction = new  Booking { PackageName= (string)TempData["packagename"],NumberofPersons=persons,JourneyDate=startdate,email=email,city=city,PaymentMethod=payments,Amount=total1,status="Failed"};
           _context.Add(transaction);
            await _context.SaveChangesAsync();

            ViewBag.total = total;
           
            /*ViewBag.name = username;
            ViewBag.method = payments;
            ViewBag.person = persons;*/
            if (payments=="card")
            {
                return View("Dopayment");
            }

            return View("Netbanking");
        }

        public async Task<IActionResult> Cardpayment(string cardno,int mm,int yy,int cvv)
        {
            var card = await _context.Cards
               .FirstOrDefaultAsync(m => m.CardNumber ==cardno);
            HttpContext.Session.SetString(Sessioncard1, cardno);
            var booking = _context.Bookings
                .OrderByDescending(a => a.BookingID)
                .First();
            var mailid = card.mailid;
            ViewBag.mail = mailid;
            ViewBag.paymentStatus = "fail";
            ViewBag.pkgid = (int)TempData["packageid"];
            HttpContext.Session.SetInt32(Sessionpkgid1, (int)TempData["packageid"]);
            if (card==null)
            {
                ViewBag.message1 = "Payment failed due to wrong card number!";
            }
            else
            {
                
                if(card.month!=mm || (card.year!=yy || card.CVV!=cvv))
                {
                    ViewBag.message1 = "Payment failed due to wrong card Details!";
                }
                else if(card.balance< HttpContext.Session.GetInt32(SessionAmt1))
                {
                    ViewBag.message1 = "Payment failed due to insufficient balance!";
                }
                else
                {
                    var random = new Random();
                    int OTP = random.Next(100001, 999999);
                    HttpContext.Session.SetInt32(SessionOtp1, OTP);
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("Verify@MMT.com"));
                    email.To.Add(MailboxAddress.Parse(mailid));
                    email.Subject = "OTP for your Debit Card Payment";
                    email.Body = new TextPart(TextFormat.Plain) { Text = "Your OTP Via Debit card Payment on MMT is "+OTP };

                    using var smtp = new SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("freerechargepaymentsltd@gmail.com", "urvishdevani@");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                    return View("OTP");

                    /*card.balance = (int)(card.balance - HttpContext.Session.GetInt32(SessionAmt1));
                    booking.status = "Booked";
                    _context.Update(booking);
                    _context.Update(card);

                    await _context.SaveChangesAsync();
                    ViewBag.paymentStatus = "success";
                    ViewBag.message1 = "woohoo! Your payment is successfull. Enjoy your Trip :)";*/
                }
            }
            return View();
        }

        public async Task<IActionResult> OTPPayment(string otp1)
        {
            if(otp1 == (HttpContext.Session.GetInt32(SessionOtp1)).ToString())
            {
                var card = await _context.Cards
             .FirstOrDefaultAsync(m => m.CardNumber == HttpContext.Session.GetString(Sessioncard1));
                var booking = _context.Bookings
                   .OrderByDescending(a => a.BookingID)
                   .First();
                card.balance = (int)(card.balance - HttpContext.Session.GetInt32(SessionAmt1));
                booking.status = "Booked";
                _context.Update(booking);
                _context.Update(card);
                ViewBag.tid = booking.BookingID;

                await _context.SaveChangesAsync();
                ViewBag.paymentStatus = "success";
                ViewBag.message1 = "woohoo! Your payment is successfull. Enjoy your Trip :)";
                return View("Cardpayment");
            }
            else
            {
                ViewBag.pkgid = HttpContext.Session.GetInt32(Sessionpkgid1);
                ViewBag.paymentStatus = "fail";
                ViewBag.message1 = "Payment failed due to Wrong OTP! Please Try again";
                return View("Cardpayment");
            }
           

        }


        public async Task<IActionResult> Netbankingpayment(string bank, string uname,string passwd)
        {
            var bankuser = await _context.Netbankings
              .FirstOrDefaultAsync(m => m.Username == uname);
            ViewBag.paymentStatus = "fail";
            var booking = _context.Bookings
                .OrderByDescending(a => a.BookingID)
                .First();
            ViewBag.pkgid = (int)TempData["packageid"];
            if (bankuser == null)
            {
                ViewBag.message1 = "Payment failed because Invalid Username!";
            }
            else
            {
                if (bankuser.Password != passwd || bankuser.Bank!=bank)
                {
                    ViewBag.message1 = "Payment failed due to Invalid password or Bank!";
                }
                else if (bankuser.balance < HttpContext.Session.GetInt32(SessionAmt1))
                {
                    ViewBag.message1 = "Payment failed due to insufficient balance!";
                }
                else
                {
                    bankuser.balance = (int)(bankuser.balance - HttpContext.Session.GetInt32(SessionAmt1));
                    booking.status = "Booked";
                    ViewBag.tid = booking.BookingID;
                    _context.Update(booking);
                    _context.Update(bankuser);
                    await _context.SaveChangesAsync();
                    ViewBag.paymentStatus = "success";
                    ViewBag.message1 = "woohoo! Your payment is successfull. Enjoy your Trip :)";
                }
            }


            return View("Cardpayment");
        }
        [AllowAnonymous]
        public  IActionResult ContactUs()
        {

            return View("ContactUs");
        }
    }
}
