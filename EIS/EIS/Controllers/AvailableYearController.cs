using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EIS.Models;

namespace EIS.Controllers
{
    public class AvailableYearController : ApiController
    {
        // GET api/availableyear
        public IEnumerable<AvailableYear> Get()
        {
            eisEntities ctx = new eisEntities();
            var years = from year in ctx.AvailableYears1
                        select year;
            return years;
        }

        // GET api/availableyear/create/2012
        [System.Web.Http.AcceptVerbs("GET")]
        public ActionResponse Create(int year)
        {
            eisEntities ctx = new eisEntities();

            //Add available year
            var newAvailableYear = ctx.AvailableYears1.CreateObject();
            newAvailableYear.Year = year;
            newAvailableYear.CreatedDate = DateTime.Now;
            ctx.AvailableYears1.AddObject(newAvailableYear);

            //Warrant Fund Provider
            var warrantFundProviders = from provider in ctx.WarrantFundProviders select provider;
            foreach (var p in warrantFundProviders) {
                var providing = ctx.WarrantFundProvidings1.CreateObject();
                providing.Year = year;
                providing.WarrantFundProviderId = p.WarrantFundProviderId;
                providing.LastUpdated = DateTime.Now;
                ctx.WarrantFundProvidings1.AddObject(providing);
            }

            //RetirementFundUsage
            var retirementFundType = from type in ctx.RetirementFundTypes1 select type;
            foreach (var rft in retirementFundType) {
                var fundUsage = ctx.RetirementFundUsages1.CreateObject();
                fundUsage.Year = year;
                fundUsage.RetirementFundTypeId = rft.RetirementFundTypeId;
                fundUsage.LastUpdated = DateTime.Now;
                ctx.RetirementFundUsages1.AddObject(fundUsage);
            }

            //EmployeeRelatedBudgetUsage
            var empBudgetTypes = from type in ctx.EmployeeRelatedBudgetTypes1 select type;
            foreach (var type in empBudgetTypes) {
                var empBudgetUsage = ctx.EmployeeRelatedBudgetUsages1.CreateObject();
                empBudgetUsage.Year = year;
                empBudgetUsage.EmployeeRelatedBudgetTypeId = type.EmployeeRelatedBudgetTypeId;
                empBudgetUsage.LastUpdated = DateTime.Now;
                ctx.EmployeeRelatedBudgetUsages1.AddObject(empBudgetUsage);
            }

            //EstimatedRetirement
            var retirementType = from type in ctx.RetirementTypes1 select type;
            foreach (var type in retirementType) {
                var est = ctx.EstimatedRetirements1.CreateObject();
                est.Year = year;
                est.RetirementTypeId = type.RetirementTypeId;
                est.LastUpdated = DateTime.Now;
                ctx.EstimatedRetirements1.AddObject(est);
            }

            //NumberOfEmployee
            var empType = from type in ctx.EmployeeTypes1 select type;
            foreach (var type in empType) {
                var noEmp = ctx.NumberOfEmployees1.CreateObject();
                noEmp.Year = year;
                noEmp.EmployeeTypeId = type.EmployeeTypeId;
                noEmp.LastUpdated = DateTime.Now;
                ctx.NumberOfEmployees1.AddObject(noEmp);
            }

            //BudgetUsage
            var budgetType = from type in ctx.BudgetTypes1 select type;
            foreach (var type in budgetType) {
                var usage = ctx.BudgetUsages1.CreateObject();
                usage.Year = year;
                usage.BudgetTypeId = type.BudgetTypeId;
                usage.LastUpdated = DateTime.Now;
                ctx.BudgetUsages1.AddObject(usage);
            }

            //EstimatedFundmember
            var memberType = from type in ctx.FundMemberTypes select type;
            foreach (var type in memberType) {
                var est = ctx.EstimatedFundMembers1.CreateObject();
                est.Year = year;
                est.FundMemberTypeId = type.FundMemberTypeId;
                est.LastUpdated = DateTime.Now;
                ctx.EstimatedFundMembers1.AddObject(est);
            }

            //FirstCarStatus
            var firstCarStatusTypes = from type in ctx.FirstCarStatusTypes1 select type;
            foreach (var type in firstCarStatusTypes) {
                var status = ctx.FirstCarStatus.CreateObject();
                status.Year = year;
                status.StatusTypeId = type.FirstCarStatusTypeId;
                status.LastUpdated = DateTime.Now;
                ctx.FirstCarStatus.AddObject(status);
            }

            //BankLoadApproval
            var bankType = from type in ctx.BankTypes1 select type;
            foreach (var bank in bankType) {
                var approval = ctx.BankLoanApprovals1.CreateObject();
                approval.Year = year;
                approval.BankTypeId = bank.BankTypeId;
                approval.LastUpdated = DateTime.Now;
                ctx.BankLoanApprovals1.AddObject(approval);
            }

            try {
                ctx.SaveChanges();
                return new ActionResponse() {
                    Success=true
                };
            }
            catch (Exception ex) {
                return new ActionResponse() {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        // GET api/availableyear/delete/2012
        [System.Web.Http.AcceptVerbs("GET")]
        public ActionResponse Delete(int year) {
            eisEntities ctx = new eisEntities();
            ctx.ExecuteStoreCommand("DELETE FROM BankLoanApproval WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM BudgetUsage WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM EmployeeRelatedBudgetUsage WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM EstimatedFundMember WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM EstimatedRetirement WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM FirstCarStatus WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM NumberOfEmployee WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM RetirementFundUsage WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM WarrantFundProviding WHERE Year = {0}", year);
            ctx.ExecuteStoreCommand("DELETE FROM AvailableYears WHERE Year = {0}", year);
            return new ActionResponse() {
                Success = true
            };
        }
    }
}
