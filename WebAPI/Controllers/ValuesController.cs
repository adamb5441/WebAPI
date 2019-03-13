using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Enumeration;
using WebAPI.Models;


namespace WebAPI.Controllers
{

    [RoutePrefix("api/Test")]
    public class ValuesController : ApiController
    {
        APIdbContext db = new APIdbContext();

        /// <summary>
        /// Get household
        /// </summary>
        /// <remarks>
        /// Returns a list of household data.
        /// </remarks>
        /// <returns></returns>
        [Route("GetHouseholds")]
        public IEnumerable<Household>  GetHousehoulds()
        {
            return db.Households.ToList();
        }
        /// <summary>
        /// Get household.
        /// </summary>
        /// <remarks>
        /// Gets household data for the given primary key.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetHousehold")]
        public Task<Household> GetHousehold(int id)
        {
            return db.GetHousehold(id);
        }
        /// <summary>
        /// Add Budget.
        /// </summary>
        /// <remarks>
        /// Add a budget to the given household.
        /// </remarks>
        /// <param name="hhid"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="tar"></param>
        /// <param name="cur"></param>
        /// <returns></returns>
        [Route("AddBudget")]
        public async Task<IHttpActionResult> AddBudget(int hhid, string name, string desc, decimal tar, decimal cur)
        {
            return Ok(await db.AddBudget(hhid, name, desc, tar, cur));
        }
        /// <summary>
        /// Get budgets.
        /// </summary>
        /// <remarks>
        /// Gets all budgets for a household.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<IEnumerable<Budget>> GetBudgets(int id)
        {
            return await db.GetHouseBudgets(id);
        }
        /// <summary>
        /// Get budget.
        /// </summary>
        /// <remarks>
        /// Gets budget data for the given primary key.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetBudget")]
        public async Task<Budget> GetBudget(int id)
        {
            return await db.GetHouseBudget(id);
        }
        /// <summary>
        /// Get budget items by budget id.
        /// </summary>
        /// <remarks>
        /// Gets budget items for a given budget.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetBudgetsItems")]
        public async Task<IEnumerable<BudgetItem>> GetBudgetsItems(int id)
        {
            return await db.GetBudgetItems(id);
        }
        /// <summary>
        /// Get Budget item.
        /// </summary>
        /// <remarks>
        /// Gets budget item data for the given primary key.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetBudgetsItem")]
        public async Task<BudgetItem> GetBudgetsItem(int id)
        {
            return await db.GetBudgetItem(id);
        }
        /// <summary>
        /// Add account.
        /// </summary>
        /// <remarks>
        /// Add account to the given household.
        /// </remarks>
        /// <param name="hhid"></param>
        /// <param name="name"></param>
        /// <param name="initial"></param>
        /// <param name="low"></param>
        /// <returns></returns>
        [Route("AddAccount")]
        public async Task<IHttpActionResult> AddAccount(int hhid, string name, decimal initial, decimal low)
        {
            return Ok(await db.AddAccount( hhid,  name,  initial,  low));
        }
        /// <summary>
        /// Get accounts.
        /// </summary>
        /// <remarks>
        /// Gets accounts for the given household.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAccounts")]
        public async Task<IEnumerable<Account>> GetAccounts(int id)
        {
            return await db.GetAccounts(id);
        }
        /// <summary>
        /// Get account by primary key.
        /// </summary>
        /// <remarks>
        /// Get account data for the given primary key.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAccount")]
        public async Task<Account> GetAccount(int id)
        {
            return await db.GetAccount(id);
        }
        /// <summary>
        /// Add transaction.
        /// </summary>
        /// <remarks>
        /// Add transaction for the given account.
        /// </remarks>
        /// <param name="acid"></param>
        /// <param name="biid"></param>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("AddTransaction")]
        public async Task<IHttpActionResult> AddTransaction(int acid, int biid, string userId, decimal amount, TransactionTypes type)
        {
            return Ok(await db.AddTransaction( acid, biid, userId, amount, type));
        }
        /// <summary>
        /// Get transaction by account id.
        /// </summary>
        /// <remarks>
        /// Gets transactions for the given account.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<IEnumerable<Transaction>> GetTransactions(int id)
        {
            return await db.GetTransactions(id);
        }
        /// <summary>
        /// Get transaction.
        /// </summary>
        /// <remarks> 
        /// Gets transaction data for the given primary key.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetTransaction")]
        public async Task<Transaction> GetTransaction(int id)
        {
            return await db.GetTransaction(id);
        }
        /// <summary>
        /// Get households json
        /// </summary>
        /// <remarks>
        /// Json formatted households .
        /// </remarks>
        /// <returns></returns>
        [Route("GetHouseholds/json")]
        public IHttpActionResult GetHouseholdsJson()
        {
            var json = JsonConvert.SerializeObject(db.Households.ToList());
            return Ok(json);
        }

    }
}
