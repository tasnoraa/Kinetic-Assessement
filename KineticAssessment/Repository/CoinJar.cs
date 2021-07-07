using Dapper;
using KineticAssessment.Interface;
using KineticAssessment.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KineticAssessment.Repository
{
    public class CoinJar: ICoinJar
    {
        private readonly IConfiguration Configuration;
        public CoinJar(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void AddCoin(ICoin coin)
        {
             
            try
            {
                if (coin != null && GetVolume() + coin.Volume <= 42)
                {
                    using (var connection = new SqlConnection(Configuration["CoinConnection"]))
                    {
                        string sqlCustomerInsert = "INSERT INTO Coin Values (@Amount, @Volume);";

                        connection.Execute(sqlCustomerInsert, new { Amount = coin.Amount, Volume = coin.Volume });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal GetTotalAmount()
        {
            decimal total = 0;

            try
            {
                using (var connection = new SqlConnection(Configuration["CoinConnection"]))
                {
                    string getCoins = "SELECT * FROM Coin;";

                    var coins = connection.Query<Coin>(getCoins).ToList();                   

                    foreach (var coin in coins)
                    {
                        total += coin.Amount;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return total;
        }
        public void Reset()
        {
            try
            {
                using (var connection = new SqlConnection(Configuration["CoinConnection"]))
                {
                    string getCoins = "DELETE Coin;";

                    connection.Query<Coin>(getCoins);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetVolume()
        {
            decimal totalVolume = 0;

            try
            {
                using (var connection = new SqlConnection(Configuration["CoinConnection"]))
                {
                    string getCoins = "SELECT * FROM Coin;";

                    var coins = connection.Query<Coin>(getCoins).ToList();

                    foreach (var coin in coins)
                    {
                        totalVolume += coin.Volume;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalVolume;
        }
    }
}
