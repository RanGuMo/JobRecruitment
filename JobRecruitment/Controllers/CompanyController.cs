using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JobRecruitment.Entities;
using JobRecruitment.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace JobRecruitment.Controllers
{
    [EnableCors("any")]
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public JobRecruitmentContext Context { get; }
        public CompanyController(JobRecruitmentContext context)
        {
            Context = context;
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Companys> Get()
        {
            return new CompanysViewModel(Context).GetCompanys();
        }
        // GET: api/Company/5
        [HttpGet("{id}")]
        public Companys Get(int id)
        {
            CompanysViewModel companysViewModel = new CompanysViewModel(Context);
            return companysViewModel.GetCompanyById(id);
        }

    }
}
