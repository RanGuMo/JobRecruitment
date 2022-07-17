using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobRecruitment.Entities;
using JobRecruitment.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobRecruitment.Controllers
{
    [EnableCors("any")]
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobRecruitmentContext _context;

        public JobController(JobRecruitmentContext context)
        {
            this._context = context;
        }


        // GET: api/Job/5
        [HttpGet]
        public Dictionary<string, object> Get(int id)
        {
            Dictionary<string, object> dicRes = new();
           
            JobsViewModel jobsViewModel  = new(_context);
            CompanysViewModel CompanyViewModel  = new(_context);
            RequriementFiltersViewModel requriementFiltersViewModel  = new(_context);

            var jobsViews = jobsViewModel.GetAll();
            var companys = CompanyViewModel.GetCompanys();
            var requriements = requriementFiltersViewModel.GetRequriement();
          
            dicRes.Add("jobViews", jobsViews);
            dicRes.Add("companyViews", companys);
            dicRes.Add("requriementViews", requriements);
            return dicRes;
        }

        // POST: api/Job
        [HttpPost]
        public void Post()
        {
            //var jobs = Context.Set<Jobs>().FromSqlRaw("SELECT * FROM Jobs");

            // var job = Context.Jobs.Find("IT软件工程师", "6-8千/月");
            Jobs jobs = new Jobs
            {
                JobName = "aa",
                JobPay = "8万",
                Welfare = "",
                Education = "本科",
                WorkExperience = "",
                CityId = 1,
                WorkArea = "",
                PublishTime = DateTime.Now,
                PositionInfo = "",
                CompanyId = 1,
            };

            _context.Add(jobs);
            _context.SaveChanges();
        }

    }
}
