using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Util;
using WebAPI.Enumeration;

namespace WebAPI.Models
{
    public class APIdbContext : DbContext
    {
        public APIdbContext()
            : base("Connection")
        {

        }

        public static APIdbContext Create()
        {
            return new APIdbContext();
        }
        public async   Task<Household> GetHousehold(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHousehold @id",
                new SqlParameter( "id", hhId )).FirstOrDefaultAsync();
        }
        public async Task<List<Budget>> GetHouseBudgets(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @id",
                new SqlParameter("id", hhId)).ToListAsync();
        }
        public async Task<Budget> GetHouseBudget(int Id)
        {
            return await Database.SqlQuery<Budget>("GetBudget @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        public async Task<List<BudgetItem>> GetBudgetItems(int bId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @id",
                new SqlParameter("id", bId)).ToListAsync();
        }
        public async Task<BudgetItem> GetBudgetItem(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItem @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        public async Task<List<Account>> GetAccounts(int hhId)
        {
            return await Database.SqlQuery<Account>("GetAccounts @id",
                new SqlParameter("id", hhId)).ToListAsync();
        }
        public async Task<Account> GetAccount(int Id)
        {
            return await Database.SqlQuery<Account>("GetAccount @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        public async Task<int> AddAccount(int hhid, string name, decimal initial, decimal low)
        {
            decimal current = initial;
            return await Database.ExecuteSqlCommandAsync("AddAccount @HouseholdId, @Name, @Initial, @Current, @Low",
                new SqlParameter("HouseholdId", hhid),
                new SqlParameter("Name", name),
                new SqlParameter("Initial", initial),
                new SqlParameter("Current", current),
                new SqlParameter("Low", low));
        }
        public async Task<int> AddBudget(int hhid, string name, string desc, decimal tar, decimal cur)
        { 
            return await Database.ExecuteSqlCommandAsync("AddBudget @HouseholdId, @Name, @Description, @target, @Current",
                new SqlParameter("HouseholdId", hhid),
                new SqlParameter("Name", name),
                new SqlParameter("Description", desc),
                new SqlParameter("target", tar),
                new SqlParameter("Current", cur));
        }
        public async Task<int> AddTransaction(int acid, int biid, string userId, decimal amount, TransactionTypes type )
        {
            bool isrec = false;
            decimal rec = 0.0m;

            return await Database.ExecuteSqlCommandAsync("AddTransaction @AccountId, @BudgetItemId, @EnteredBy, @Amount, @Type, @IsRec, @Rec",
                new SqlParameter("AccountId", acid),
                new SqlParameter("BudgetItemId", biid),
                new SqlParameter("EnteredBy", userId),
                new SqlParameter("Amount", amount),
                new SqlParameter("Type", type),
                new SqlParameter("@IsRec", isrec),
                new SqlParameter("@Rec", rec)
                );
        }
        public async Task<List<Transaction>> GetTransactions(int acId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @id",
                new SqlParameter("id", acId)).ToListAsync();
        }
        public async Task<Transaction> GetTransaction(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransaction @id",
                new SqlParameter("id", Id)).FirstOrDefaultAsync();
        }
        public DbSet<Household> Households { get; set; }


    }
}