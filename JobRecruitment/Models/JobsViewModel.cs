using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobRecruitment.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JobRecruitment.Models
{
    public class JobsViewModel
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobPay { get; set; }
        public string Welfare { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        public int? CityId { get; set; }
        public string WorkArea { get; set; }
        public DateTime? PublishTime { get; set; }
        public string PositionInfo { get; set; }
        public int? CompanyId { get; set; }

        public Companys Company { get; set; }
        public Cities City { get; set; }
        private readonly JobRecruitmentContext _context;

        public JobsViewModel()
        {
        }
        public JobsViewModel(JobRecruitmentContext context)
        {
            this._context = context;
        }

        public List<JobsViewModel> GetAll()
        {
            var jobsJoin = from j in _context.Jobs
                           join cp in _context.Companys on j.CompanyId equals cp.Id
                           join ct in _context.Cities on j.CityId equals ct.Id
                           select new JobsViewModel
                           {
                               Id = j.Id,
                               JobName = j.JobName,
                               JobPay = j.JobPay,
                               Welfare = j.Welfare,
                               Education = j.Education,
                               WorkExperience = j.WorkExperience,
                               CityId = j.CityId,
                               WorkArea = j.WorkArea,
                               PublishTime = j.PublishTime,
                               PositionInfo = j.PositionInfo,
                               CompanyId = j.CompanyId,
                               Company = cp,
                               City = ct,
                           };
            return jobsJoin.ToList();
        }

        // public JobsViewModel Get(int id){

        // }
    }
}
