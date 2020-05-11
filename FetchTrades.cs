var systems = new[] {
	// SystemID, SystemName, SystemScaling
	// Run the forex systems first so we can scrape the trades to update the X-Rates table
	Tuple.Create(94987184,  "Just Forex Trades",  0.3),
	Tuple.Create(124998567, "abasacJAR 4X", 6.0 ),
	// PPRs pets systems
	Tuple.Create(120622361, "NQ Kingpin", 1.0 ),
	Tuple.Create(115023400, "Crude Oil Trader Z", 1.0),
	Tuple.Create(119232154, "PegasiCap", 1.0),
	// CDBs pet systems
	Tuple.Create(125935591, "Klarity", 3.0),
	//Tuple.Create(117442067, "Carma Managed Future",1.0), // Bad data in here causes Div0 Error
	Tuple.Create(125428941, "Clear Futures", 3.0),
	Tuple.Create(102081384, "OPN W888", 0.5),
	Tuple.Create(125587405, "Stock Star", 3.0),
};
var systemsIds = systems.Select(f=>(long)f.Item1);
var sideWord = new Dictionary <string,string> () {
	{"BTO","LONG"}, {"STO","SHORT"}
};
var XRates = new Dictionary<string,double>()
{
//CHF,JPY,AUD,NZD,USD,CAD,GBP,EUR,HUF,CNH,SEK,TRY,ZAR
	{"USD",1.0},
	{"AUD", 0.6138},
	{"CAD", 0.7118},
	{"CHF", 1.02},
	{"EUR", 1.108},
	{"GBP", 1.2372},
	{"JPY", 0.009288},
	{"NZD", 0.6028},
	{"HUF", 0.0031},
	{"SEK", 0.1005 },
	{"ZAR", 0.0556 },
	{"CNH", 0.1407 },
	{"TRY", 0.1535 },
	{"SGD", 0.7076 },
};
// Set starting date (YYYY,MM,DD)
var startDate = new DateTime(2015,01,01);
var startTime = DateTime.Now;
List<String> allCurrencies =  new List<String>();
List<String> errors =  new List<String>();
List<dynamic> tsig = new List<dynamic>();

foreach (var system in systems) {

	H2 = system.Item2;
	if(false) {
		// Look for the symbols a system trades
		TEXT="Symbols:" + system.Item2;
		TABLE = (from trade in C2TRADES
		         where trade.SystemId == system.Item1 && trade.EntryTime > startDate
		         select new { Symbol=trade.Symbol }).Distinct();
	}

	if (true) {

		var signals = C2SIGNALS.Where(sig => sig.SystemId == system.Item1 && sig.PostedWhen > startDate).OrderBy(sig=>sig.TradedWhen).ToList();
		var trades = C2TRADES.Where( trade => trade.SystemId == system.Item1 && trade.EntryTime > startDate )
		             .OrderByDescending(trade => trade.ExitTime).ToList();

		foreach ( var currency in signals.Select( s => s.Currency ).Distinct().ToList() ) {
			if ( !allCurrencies.Contains(currency) )
				allCurrencies.Add(currency);
		}

		foreach ( var trade in trades ) {
			if ( trade.Instrument.Equals("forex") ) {
				var baseCurrency = trade.Symbol.Substring(0,3);
				if ( !allCurrencies.Contains(baseCurrency) )
					allCurrencies.Add(baseCurrency);
			}
		}

		if (true) {
			var ourTrades=trades.Select( trade =>
			{
				decimal openQty=0,openSum=0,openPrice=0;
				decimal closeQty=0,closeSum=0,closePrice=0;
				decimal ddQty=0,dd = 0;

				// Search signals for this trade to establish open, close, and DD Qtys
				foreach ( var sig in signals.Where( sig => sig.TradeId == trade.Id )) {
				    if ( sig.Action.EndsWith("O") ) {
				        openSum += sig.Quant * sig.TradePrice;
				        openQty += sig.Quant;
				        openPrice = openSum / openQty;
					}else if ( sig.Action.EndsWith("C") ) {
				        closeSum += sig.Quant * sig.TradePrice;
				        closeQty += sig.Quant;
				        closePrice = closeSum / closeQty;
					}
				    if (sig.TradedWhen <= trade.MaxDrawdownTime) {
				        ddQty = openQty-closeQty;
					}
				}

				// If there is a price for MaxDrawdown then we compute the DD
				if ( true && trade.MaxDrawdown != 0 ) {
				    if ( trade.Instrument.Equals("forex") ) {
				        // If we are lookinhg at a USD trade that gives us a chance to update the x-rates table
				        if (trade.Symbol.Substring(0,3).Equals("USD")) {
				            XRates[trade.Symbol.Substring(3,3)] = 1/(double)closePrice;
						} else if ( trade.Symbol.Substring(3,3).Equals("USD") ) {
				            XRates[trade.Symbol.Substring(0,3)] = (double)closePrice;
						}
						// now we compute the DD
				        dd = Math.Abs(openPrice - trade.MaxDrawdown) * ddQty * 10000                                                                            // ()? data in JFT corrupt
				             / trade.MaxDrawdown                                                                           // quote 2 base
				             * (decimal)XRates[trade.Symbol.Substring(0,3)];                                                                           // base to USD
					}else{
						// DDs for non forex are simpler
				        dd = Math.Abs(openPrice - trade.MaxDrawdown) * ddQty * trade.PtValue
				             * (decimal)XRates[signals.First().Currency];
					}
				}

				return new {
				    //TradeId=trade.Id,
				    OpenTimeET=trade.EntryTime.ToString("yyyy-MM-dd HH:mm:ss"),
				    Side=sideWord[trade.Action],
				    QtyOpen=openQty,
				    Symbol=trade.Symbol,
				    Description=trade.Symbol,
				    AvgPriceOpen=Math.Round(openSum/openQty,4),
				    QtyClosed=closeQty,
				    ClosedTimeET=trade.ExitTime.ToString("yyyy-MM-dd HH:mm:ss"),
				    AvgPriceClosed=Math.Round(closeSum/closeQty,4),
				    DD_as_Pcnt=0,
				    DD_as_Dlr=Math.Round(-dd,0),
				    //Currency = openSigs.First().Currency,
				    //rate = Math.Round(XRates[openSigs.First().Currency],4),
				    //baseX = Math.Round(XRates[trade.Symbol.Substring(0,3)],4),
				    //PntVal=trade.PtValue,
				    DrawdownTimeET=trade.MaxDrawdownTime.ToString("yyyy-MM-dd HH:mm:ss"),
				    DD_Quant=ddQty,
				    DD_Worst_Price=Math.Round(trade.MaxDrawdown,4),
				    Trade_PL=Math.Round(trade.Result,2),
				};
			}).ToList();
			TABLE=ourTrades;
		}else{
			TABLE = trades;
			TABLE = signals;
		}
	}

	TEXT = String.Format("Query took {0}ms", (DateTime.Now - startTime).Milliseconds.ToString() );
	HR();
}

// if we have a problem with missing rates in the x-rates table we can turn on this debug
//TEXT = "All Currencies traded: " + String.Join(",",allCurrencies);
if (false) {
	foreach ( var cur in allCurrencies ) {
		if ( !XRates.ContainsKey( cur ) ) {
			TEXT = "Missing rate for " + cur;
		}
	}
}