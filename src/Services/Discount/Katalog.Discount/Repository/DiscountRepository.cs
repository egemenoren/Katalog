using Dapper;
using Katalog.Discount.Types;
using Npgsql;
using System.Data;

namespace Katalog.Discount.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<bool> Create(Entities.Discount discount)
        {
            var discounts = await _dbConnection.ExecuteAsync(
                "Insert into discount (UserId,Code,Rate,CertainValue,MinCartValue," +
                "MaxCartValue,MaxDiscount,DiscountType,StoreIds,CategoryIds,ProductIds," +
                "IsLimited,Amount,ValidityDate,StatusType,CreatedById) " +
                "VALUES " +
                "(@UserId,@Code,@Rate,@CertainValue,@MinCartValue,@MaxCartValue,@MaxDiscount," +
                "@DiscountType,@StoreIds,@CategoryIds,@ProductIds,@IsLimited,@Amount,@ValidityDate,@StatusType,@CreatedById)", discount);
            if (discounts > 0)
                return true;
            return false;
        }
        public async Task<bool> Update(Entities.Discount discount)
        {
            var result = await _dbConnection.ExecuteAsync(
                "Update discount set UserId = @userId,Code = @code,Rate = @rate,CertainValue = @certainValue," +
                "MinCartValue = @minCartValue,MaxCartValue = @maxCartValue,MaxDiscount = @maxDiscount," +
                "DiscountType = @discountType,StoreIds = @storeIds,CategoryIds = @categoryIds,ProductIds = @productIds," +
                "IsLimited = @isLimited,Amount = @amount,ValidityDate = @validityDate,StatusType = @statusType," +
                "CreatedById = @createdById where Id = @id",
                new
                {
                    id = discount.Id,
                    code = discount.Code,
                    rate = discount.Rate,
                    certainValue = discount.CertainValue,
                    minCartValue = discount.MinCartValue,
                    maxCartValue = discount.MaxCartValue,
                    maxDiscount = discount.MaxDiscount,
                    discountType = discount.DiscountType,
                    storeIds = discount.StoreIds,
                    categoryIds = discount.CategoryIds,
                    productIds = discount.ProductIds,
                    isLimited = discount.IsLimited,
                    amount = discount.Amount,
                    validityDate = discount.ValidityDate,
                    statusType = discount.StatusType,
                    createdById = discount.CreatedById
                });
            if(result > 0) 
                return true;
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _dbConnection.ExecuteAsync("delete from discount where Id = @id", new { id = id });
            if (result > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<Entities.Discount>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Entities.Discount>("Select * from discount");
            return discounts;
        }

        public async Task<Entities.Discount> GetById(int id)
        {
            var discount = await _dbConnection.QueryAsync<Entities.Discount>("Select * from discount where Id = @id", new { id = id });
            return discount.SingleOrDefault();
        }

    }
}
