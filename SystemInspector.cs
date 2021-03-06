// SET UP THE MODEL HERE ==============================================================================================//
var systems = new[] {
	// SystemID, SystemName, SystemScaling, System stops

	// Run the forex systems first so we can scrape the trades to update the X-Rates table
	Tuple.Create(94987184,  "Just Forex Trades",  1.0, new double[] {10.0,12.5,15.0,17.5,20.0,30.0}),
	Tuple.Create(124998567, "abasacJAR 4X", 1.0, new double[] {5.0,7.5,10.0,12.5, 15.0, 20, 25, 30}),
	//Tuple.Create(117863277,  "Forex Agressive risk",  1.0, new double[] {5.0,10.0,12.5,13.0,15.0,17.5,20.0,25.0}),
	Tuple.Create(122467834,  "Auto Wave Forex",  1.0, new double[] {5.0,6,7,8,9,10.0}),

	// PPRs pets systems
	//Tuple.Create(120622361, "NQ Kingpin", 1.0, new double[] {1.0,2.0,5.0,10.0,15.0} ),
	//Tuple.Create(115023400, "Crude Oil Trader Z", 1.0, new double[] {1.0,2.0,5.0,10.0,15.0} ),
	//Tuple.Create(119232154, "PegasiCap", 1.0, new double[] {1.0,2.0,5.0,10.0,15.0} ),

	// CDBs pet systems
	// Tuple.Create(125935591, "Klarity", 3.0, new double[] {5.0,10.0,15.0} ),
	////Tuple.Create(117442067, "Carma Managed Future",1.0, new double[] {5.0,10.0,15.0} ), // Bad data in here causes Div0 Error
	// Tuple.Create(125428941, "Clear Futures", 3.0, new double[] {5.0,10.0,15.0} ),
	////Tuple.Create(102081384, "OPN W888", 0.5, new double[] {5.0,10.0,15.0} ),
	// Tuple.Create(124998567, "abasacJAR 4X", 4.0, new double[] {5.0,10.0,15.0} ),
	Tuple.Create(125587405, "Stock Star", 3.0, new double[] {1,2,3,4,5.0,} ),
	//Tuple.Create(102081384, "OPN W888", 0.5, new double[] {5.0,10.0,15.0}),
	//Tuple.Create(125624499, "Dow M",2.0, new double[] {5.0,10.0,15.0}),
	//
	// // Forex systems
	// Tuple.Create(  121872737, "Aggressive Trend Scalper", 1.0 ),
	// Tuple.Create(  124998567, "abasacJAR 4X   ", 1.0 ),
	// Tuple.Create(  125277645, "FX Star", 1.0 ),
	// Tuple.Create(  122042540, "FX Reversals", 1.0 ),
	// Tuple.Create(  121808714, "PxV Forex", 1.0 ),
	// Tuple.Create(  122467834, "Auto Wave Forex", 1.0 ),
	// Tuple.Create(  123479706, "NEURAL STARK STRATEGY", 1.0 ),
	// Tuple.Create(  116569503, "FOREX SWING SYSTEM", 1.0 ),
	// Tuple.Create(  123805444, "Only A Boring FX", 1.0 ),
	// Tuple.Create(  123530483, "Trading FX complex", 1.0 ),
	//
	// // Futures strats from Top strats
	// Tuple.Create(   125587405, "stock star", 1.0 ),
	// Tuple.Create(   125982253, "GoldFutures", 1.0 ),
	// Tuple.Create(   125935591, "Klarity", 1.0 ),
	// Tuple.Create(   126043352, "Bond USA", 1.0 ),
	// Tuple.Create(   125624499, "dow m", 1.0 ),
	// Tuple.Create(   123071731, "MINI DOW 123071731 ", 1.0 ),
	// Tuple.Create(   121637339, "Stock dow", 1.0 ),
	// Tuple.Create(   125206069, "Marlin", 1.0 ),
	// Tuple.Create(   122397210, "Futrs only", 1.0 ),
	// Tuple.Create(   123458321, "ES DSXmes", 1.0 ),
	// Tuple.Create(   124332528, "ES Russell", 1.0 ),
	// Tuple.Create(   125284205, "Change a", 1.0 ),
	// Tuple.Create(   123472063, "C2Star dax and fgbl", 1.0 ),
	// Tuple.Create(   124283622, "YM AGRI", 1.0 ),
	// Tuple.Create(   123562056, "NASDAQ Mc", 1.0 ),
	// Tuple.Create(   125428941, "Clear Futures", 1.0 ),
	// Tuple.Create(   122681618, "lang", 1.0 ),
	// Tuple.Create(   122087689, "OPN Energy 8868", 1.0 ),
	// Tuple.Create(   125237603, "EliteSPX", 1.0 ),
	// Tuple.Create(   125876898, "Pool of traders", 1.0 ),
	// Tuple.Create(   123895279, "Commodity Gold", 1.0 ),
	// Tuple.Create(   122867565, "STOCK MARKET SWINGER", 1.0 ),
	// Tuple.Create(   124190857, "ES No Guts No Glory", 1.0 ),
	// Tuple.Create(   120622361, "NQ KingPin", 1.0 ),
	// Tuple.Create(   122174703, "AlgoSys YM - Andromalius", 1.0 ),
	// Tuple.Create(   114887103, "DRIVER Balanced", 1.0 ),
	// Tuple.Create(   123479706, "NEURAL STARK STRATEGY", 1.0 ),
	// Tuple.Create(   120687863, "ElitES SnP 500 ", 1.0 ),
	// Tuple.Create(   117442067, "Carma Managed Futures", 1.0 ),
	// Tuple.Create(   121285788, "Capstone Strategic", 1.0 ),
	// Tuple.Create(   125620901, "E MINI SP", 1.0 ),
	// Tuple.Create(   124696549, "4Timing Trend ML", 1.0 ),
	// Tuple.Create(   124877167, "Elliottwave System", 1.0 ),
	// Tuple.Create(   119232154, "PegasiCap", 1.0 ),
	// Tuple.Create(   123163369, "RedCrest Managed Vol", 1.0 ),
	//
	// // Stocks
	// Tuple.Create(	125587405	, "stock star", 1.0 ),
	// Tuple.Create(	121637339	, "Stock dow", 1.0 ),
	// Tuple.Create(	124727146	, "TQQQSQQQ", 1.0 ),
	// Tuple.Create(	126054331	, "CkNN Algo V", 1.0 ),
	// Tuple.Create(	125236007	, "Systematic Managed Alpha", 1.0 ),
	// Tuple.Create(	123007535	, "favour etf", 1.0 ),
	// Tuple.Create(	125876898	, "Pool of traders", 1.0 ),
	// Tuple.Create(	124343595	, "C2Star App SuperBands", 1.0 ),
	// Tuple.Create(	124994120	, "Obsidian ALPHA AI Master", 1.0 ),
	// Tuple.Create(	106901765	, "VIXTrader", 1.0 ),
	// Tuple.Create(	125620901	, "E MINI SP", 1.0 ),
	// Tuple.Create(	117580044	, "Volatility Balanced", 1.0 ),
	// Tuple.Create(	102427283	, "Smart Volatility Margin", 1.0 ),
	// Tuple.Create(	124696549	, "4Timing Trend ML", 1.0 ),
	// Tuple.Create(	106600099	, "VIXTrader Professional", 1.0 ),
	// Tuple.Create(	100707640	, "VXX Bias", 1.0 ),
	// Tuple.Create(	106187009	, "Dual QM18", 1.0 ),
	// Tuple.Create(	104952602	, "VIX Tactical Trader", 1.0 ),
	// Tuple.Create(	124270346	, "SPODD500", 1.0 ),
	// Tuple.Create(	126079605	, "Daily Scalp", 1.0 ),
	//
	// // Options
	// Tuple.Create(	125620901	, "E MINI SP", 1.0 ),
	// Tuple.Create(	117580044	, "Volatility Balanced", 1.0 ),
	// Tuple.Create(	102427283	, "Smart Volatility Margin", 1.0 ),

};
// GLOBAL VARIABLES ==============================================================================================//

// Get some colors to use
List<System.Drawing.Color> colors = new List<System.Drawing.Color>(new System.Drawing.Color[]
                                                                   {Color.Blue, Color.Brown, Color.Red, Color.Green, Color.Orange, Color.Purple,
                                                                    Color.Pink, Color.DarkGreen, Color.DarkBlue, Color.Olive,
                                                                    Color.DarkBlue, Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen,
                                                                    Color.DarkKhaki, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange, Color.DarkOrchid,
                                                                    Color.DarkRed, Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray,
                                                                    Color.DarkTurquoise, Color.DarkViolet} );
int colorIndex = 0;
var systemsIds = systems.Select(f=>(long)f.Item1);
var sideWord = new Dictionary <string,string> () {
	{"BTO","LONG"}, {"STO","SHORT"}
};

// A 'bootstrap' exchange rate tables updated April 2020, so long as we run some
// forex systems through the program first we can scrape the trades for more current
// x-rates and update our table as we go
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


bool debug = false;
// We will keep a list of all currencies seen in case we need it for debugging
List<String> allCurrencies =  new List<String>();
List<String> errors =  new List<String>();

// MAIN ==============================================================================================//
// Here we go.....
foreach (var system in systems) {
	var autoStops = system.Item4.Select(x=>(decimal)x);
	var startingCash = C2SYSTEMS.Where( sys => sys.SystemId == system.Item1 ).Select( sys => sys.StartingCash ).First();
	decimal runningEquity = startingCash;
	DateTime lastExitTime = new DateTime(0);
	DateTime exitTime = new DateTime(0);
	DateTime lastEntryTime = new DateTime(0);
	DateTime entryTime = new DateTime(0);
	colorIndex = 0;

	// We need to convert each query to a List so that we don't have open more than one database connection
	var signals = C2SIGNALS.Where(sig => sig.SystemId == system.Item1 && sig.PostedWhen > startDate).OrderBy(sig=>sig.TradedWhen).ToList();
	var trades = C2TRADES.Where( trade => trade.SystemId == system.Item1 && trade.EntryTime > startDate )
	             .OrderBy(trade => trade.ExitTime).ToList();

	// Sometimes when adding a a new forex system we encounter currencies we don't have in our x-rates table, this debug helps us identify them
	if (debug) {
		// We will record the currency for every trade for debugging in the case that we find a currency not in our XRates tables
		foreach ( var currency in signals.Select( s => s.Currency ).Distinct().ToList() ) {
			if ( !allCurrencies.Contains(currency) )
				allCurrencies.Add(currency);
		}
		// we also want 'base' currencies in our XRates table
		foreach ( var trade in trades ) {
			if ( trade.Instrument.Equals("forex") ) {
				var baseCurrency = trade.Symbol.Substring(0,3);
				if ( !allCurrencies.Contains(baseCurrency) )
					allCurrencies.Add(baseCurrency);
			}
		}
	}

	// Now we start to build our trades table  ------------------------------------------------------------ //
	if (true) {
		var ourTrades=trades.Select( trade =>
		{
			decimal openQty=0,openSum=0,openPrice=0;
			decimal closeQty=0,closeSum=0,closePrice=0;
			decimal ddQty=0,dd = 0;
			decimal lastEquity = runningEquity;
			runningEquity += trade.Result;

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
			if ( trade.MaxDrawdown != 0 ) {
			    if ( trade.Instrument.Equals("forex") ) {
			        // If we are lookinhg at a USD trade that gives us a chance to update the x-rates table
			        if (trade.Symbol.Substring(0,3).Equals("USD")) {
			            XRates[trade.Symbol.Substring(3,3)] = 1/(double)closePrice;
					} else if ( trade.Symbol.Substring(3,3).Equals("USD") ) {
			            XRates[trade.Symbol.Substring(0,3)] = (double)closePrice;
					}
			        // now we compute the DD
			        dd = Math.Abs(openPrice - trade.MaxDrawdown) * ddQty * 10000                                                                                // ()? data in JFT corrupt
			             / trade.MaxDrawdown                                                                               // quote 2 base
			             * (decimal)XRates[trade.Symbol.Substring(0,3)];                                                                               // base to USD
				}else{
			        // DDs for non forex DD are simpler
			        dd = Math.Abs(openPrice - trade.MaxDrawdown) * ddQty * trade.PtValue
			             * (decimal)XRates[signals.First().Currency];
				}
			}

			// Entry and Exit times are used as table keys  and therefore must be unique
			// sometime the database contains duplicate entry or exit times, when that
			// happens we will 'bump' them by 100ns
			{
			    exitTime = trade.ExitTime;
			    if ( exitTime == lastExitTime )
					exitTime += new TimeSpan(1); //100ns
			    lastExitTime = exitTime;
			    entryTime = trade.EntryTime;
			    if ( entryTime == lastEntryTime )
					entryTime += new TimeSpan(1); //100ns
			    lastEntryTime = entryTime;
			}
			// return the new table row
			return new {
			    //TradeId=trade.Id,
			    OpenTimeET=entryTime,//.ToString("yyyy-MM-dd HH:mm:ss"),
			    Side=sideWord[trade.Action],
			    QtyOpen=openQty,
			    Symbol=trade.Symbol,
			    Description=trade.Symbol,
			    AvgPriceOpen=Math.Round(openSum/openQty,4),
			    QtyClosed=closeQty,
			    ClosedTimeET=exitTime,//.ToString("yyyy-MM-dd HH:mm:ss"),
			    AvgPriceClosed=Math.Round(closeSum/closeQty,4),
			    DD_as_Pcnt=Math.Round(-dd/lastEquity*100,2),
			    DD_as_Dlr=Math.Round(-dd,0),
			    //Currency = openSigs.First().Currency,
			    //rate = Math.Round(XRates[openSigs.First().Currency],4),
			    //baseX = Math.Round(XRates[trade.Symbol.Substring(0,3)],4),
			    //PntVal=trade.PtValue,
			    DrawdownTimeET=trade.MaxDrawdownTime,//.ToString("yyyy-MM-dd HH:mm:ss"),
			    DD_Quant=ddQty,
			    DD_Worst_Price=Math.Round(trade.MaxDrawdown,4),
			    Trade_PL=Math.Round(trade.Result,2),
			    Equity=runningEquity,
			};
		}).ToList();
		// ------------------------------------------------------------------------------------- //

		// Create a deedle frame with trade ClosedTime as Keys
		var ourFrame = Frame.FromRowKeys(ourTrades.Select(t=>t.ClosedTimeET));
		// copy all the properties from ourTrades into ourFrame
		foreach (var p in ourTrades.First().GetType().GetProperties() ) {
			ourFrame.AddColumn(p.Name, ourTrades.Select(t=>p.GetValue(t)));
		}
		// Add an empty column
		ourFrame.AddColumn("_", Enumerable.Repeat("", ourTrades.Count()));


		if (true) {
			// Create chart objects
			ITimeSeriesChart systemChart = new TimeSeriesChart();
			systemChart.Name = system.Item2;

			ITimeSeriesChart scalingChart = new TimeSeriesChart();
			scalingChart.Name = system.Item2 + " Stops Scaling";

			var realisedEquity = new List<KeyValuePair<DateTime,decimal> >( ourTrades.OrderBy(t=>t.ClosedTimeET).Select(t=> { return new KeyValuePair<DateTime,decimal>(t.ClosedTimeET,t.Equity); }));
			var realtimeEquity = C2EQUITY.Where(sys=>sys.SystemId == system.Item1).Select(ep => new KeyValuePair<DateTime,decimal>(ep.DateTime,ep.Value) );

			systemChart.Add( new Series<DateTime,decimal>( realisedEquity ),
			                 "Realised Equity",
			                 colors[colorIndex++]);

			systemChart.Add( new Series<DateTime,decimal>( realtimeEquity ),
			                 "Realtime Equity",
			                 colors[colorIndex++]);

			// Now process the autoStops data series
			foreach ( var stop in autoStops ) {
				runningEquity = startingCash;
				decimal runningScaling = 1.0m;
				int stopsHit = 0;

				var stopTrades = ourTrades.Select( trade =>
				{
					decimal stopResult = 0;
					// No stop -> result is same as scaled trade result
					if ( -stop < trade.DD_as_Pcnt )  {
					    stopResult = Math.Round(trade.Trade_PL * runningScaling,2);
					    runningEquity = Math.Max(runningEquity+stopResult,0);
					}
					// Stop Hit -> result is the scaled fraction of the trade DD
					else{
					    stopResult = Math.Round( (-stop/trade.DD_as_Pcnt) * (trade.DD_as_Dlr * runningScaling), 0 );
					    runningEquity = Math.Max(runningEquity+stopResult,0);
					    runningScaling = Math.Max(Math.Round(runningEquity/trade.Equity,1),0);
					    stopsHit++;
					}
					// return the table row for this stop
					return new {
					    OpenTimeET = trade.OpenTimeET,
					    ClosedTimeET = trade.ClosedTimeET,
					    ModelDdPct = trade.DD_as_Pcnt,
					    StopPct = -stop,
					    ModelDdDlr = trade.DD_as_Dlr,
					    ModelPnL = trade.Trade_PL,
					    StopPnL = stopResult,
					    ModelEquity = trade.Equity,
					    StopEquity = runningEquity,
					    Scaling = runningScaling,
					    StopHits = stopsHit,
					};
				}).ToList(); //stopTrades

				// create the stops equity series for the chart
				var stopEquity = new List<KeyValuePair<DateTime,decimal> >( stopTrades.OrderBy(t=>t.ClosedTimeET).Select(t=> { return new KeyValuePair<DateTime,decimal>(t.ClosedTimeET,t.StopEquity); }));
				systemChart.Add( new Series<DateTime,decimal>( stopEquity ),
				                 String.Format("{0}% stop", stop),
				                 colors[colorIndex]);

				// create a series of 'scaling points' to show when the systems needs rescaling subsequent to a 'stop event'
				var scalingPoints = new List<KeyValuePair<DateTime,decimal> >( stopTrades.OrderBy(t=>t.ClosedTimeET).Select(t=> { return new KeyValuePair<DateTime,decimal>(t.ClosedTimeET,(decimal)t.Scaling); }));
				scalingChart.Add( new Series<DateTime,decimal>( scalingPoints ),
				                  String.Format("Scaling for {0}% stop", stop),
				                  colors[colorIndex++]);

				// Add the stops results to our frame. We can't put "." in the coumn titles so we use "_" which turns into " " in the final output
				ourFrame.AddColumn(
					String.Format("{0}%",stop).Replace(".","_"),
					new Series<DateTime,decimal>( stopTrades.Select(t=>{ return new KeyValuePair<DateTime,decimal>(t.ClosedTimeET,t.StopPnL); }))
					);
			} // autostops

			/*=== OUTPUT ======================================================================================================*/
			H2 = system.Item2;
			CHART=systemChart;
			HTML="<br/>";
			CHART=scalingChart;
			//TABLE=ourTrades.OrderByDescending(t=>t.ClosedTimeET);
			//TABLE=ourTrades.OrderBy(t=>t.ClosedTimeET);
			HTML="<br/>";
			// Oldest first
			//TABLE=FrameToTable(ourFrame);
			HTML="<br/>";
			// Newest first
			TABLE=FrameToTable(ourFrame.RealignRows(ourFrame.RowKeys.Reverse()));

			TEXT = String.Format("Query took {0}ms", (DateTime.Now - startTime).Milliseconds.ToString() );
			HR();
			/*=== OUTPUT ======================================================================================================*/
		}
	}else{
		TABLE = trades;
		TABLE = signals;
	}

	if(debug) {
		// Look for the symbols a system trades
		TEXT="Symbols:" + system.Item2;
		TABLE = (from trade in C2TRADES
		         where trade.SystemId == system.Item1 && trade.EntryTime > startDate
		         select new { Symbol=trade.Symbol }).Distinct();
	}
}

// if we have a problem with missing rates in the x-rates table we can turn on this debug
if (debug) {
	TEXT = "All Currencies traded: " + String.Join(",",allCurrencies);
	foreach ( var cur in allCurrencies ) {
		if ( !XRates.ContainsKey( cur ) ) {
			TEXT = "Missing rate for " + cur;
		}
	}
}
