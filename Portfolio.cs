namespace StockPortfolio
{
    /// <summary>
    /// This class represents a "stock portfolio", which is
    /// just a set of stocks owned by an individual.
    /// </summary>
    public class Portfolio
    {
        #region Instance fields
        /// <summary>
        /// A stock portofolio is currently limited
        /// to consist of three stocks.
        /// </summary>
        private Stock _stock1;
        private Stock _stock2;
        private Stock _stock3;
        #endregion

        #region Constructor
        /// <summary>
        /// The caller decides which stocks 
        /// to put into the portfolio
        /// </summary>
        public Portfolio(Stock stock1, Stock stock2, Stock stock3)
        {
            _stock1 = stock1;
            _stock2 = stock2;
            _stock3 = stock3;
        }
        #endregion

        #region Properties
        /// <summary>
        /// This property should return the total earnings percentage
        /// for the entire portfolio. This percentage is defined as the
        /// ratio between the net earnings for the stock (which may be
        /// a negative number), divded by the initial price for the stocks.
        /// 
        /// Example: The initial price for the stocks in the portfolio 
        /// was 150.000 kr. The current price for the stocks in the portfolio
        /// is now 180.000 kr., so a total of 30.000 kr. has been earned.
        /// The percentage is then 30.000 / 150.000 = 20 %.
        /// </summary>
        public double TotalEarningsPercentage
        {
            get
            {
                // Implement the property as described above...
                //return (_stock1.CurrentPrice - _stock1.InitialPrice) / _stock1.InitialPrice; 
                double InitialPrice1 = _stock1.InitialPrice * _stock1.Amount;
                double InitialPrice2 = _stock2.InitialPrice * _stock2.Amount;
                double InitialPrice3 = _stock3.InitialPrice * _stock3.Amount;
                double TotalValueInitial = (InitialPrice1 + InitialPrice2 + InitialPrice3);
                
                double CurrentPrice1 = _stock1.CurrentPrice * _stock1.Amount; 
                double CurrentPrice2 = _stock2.CurrentPrice * _stock2.Amount;
                double CurrentPrice3 = _stock3.CurrentPrice * _stock3.Amount;
                double TotalValueCurrent = (CurrentPrice1 + CurrentPrice2 + CurrentPrice3);
/*
                double Earnings1 = CurrentPrice1 / InitialPrice1;
                double Earnings2 = CurrentPrice2 / InitialPrice2;
                double Earnings3 = CurrentPrice3 / InitialPrice3;
                double TotalEarnings = Earnings1 + Earnings2 + Earnings3;

                double EarningsPercentage1 = Earnings1 / InitialPrice1;
                double EarningsPercentage2 = Earnings2 / InitialPrice2;
                double EarningsPercentage3 = Earnings3 / InitialPrice3;
                double TotalEarningsInPercentage = EarningsPercentage1 + EarningsPercentage2 + EarningsPercentage3;
                
*/
                double Earnings = TotalValueCurrent-TotalValueInitial;
                return (Earnings*100)/TotalValueInitial;

            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Given the percentages provided as parameters, 
        /// this method should update the prices for the
        /// stocks in the portfolio
        /// </summary>
        /// <param name="percent1">Percentage change in price for stock #1</param>
        /// <param name="percent2">Percentage change in price for stock #2</param>
        /// <param name="percent3">Percentage change in price for stock #3</param>
        public void UpdateCurrentPrices(double percent1, double percent2, double percent3)
        {
            // Implement the method as described above...
            _stock1.CurrentPrice = CalculateNewPrice(_stock1.CurrentPrice, percent1);
            _stock2.CurrentPrice = CalculateNewPrice(_stock2.CurrentPrice, percent2);
            _stock3.CurrentPrice = CalculateNewPrice(_stock3.CurrentPrice, percent3);
        }

        /// <summary>
        /// Helper method. Given a current price and a 
        /// percentage change, caluclate the new price.
        /// </summary>
        private double CalculateNewPrice(double currentPrice, double percentageChange)
        {
            return (currentPrice * (100.0 + percentageChange)) / 100.0;
        }
        #endregion
    }
}