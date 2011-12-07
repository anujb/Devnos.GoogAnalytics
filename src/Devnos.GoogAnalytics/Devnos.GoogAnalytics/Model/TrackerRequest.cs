// 
//  Copyright 2011  abhatia
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;

namespace Devnos.GoogAnalytics
{
	public class TrackerRequest
	{
		static Random _Random;
		
		public TrackerRequest()
		{
			_Random =new Random(093098);
		}
		
		// utmn
		public int Id { 
			get {
				return _Random.Next(100000, Int32.MaxValue);
			}
		}
		// utmhid
		public int Hid { 
			get {
				return _Random.Next(100000, Int32.MaxValue);
			}
		}
		
		// utmac
		public string Account { get; set; }
		
		// utmcs
		private string _languageEncoding;
		public string LanguageEncoding { 
			get { return string.IsNullOrWhiteSpace(_languageEncoding) ? "UTF-8" : _languageEncoding; }
			set {_languageEncoding = value; }
		}
		
		// utmdt
		public string PageTitle { get; set; }
		
		// utme
		public TrackerEvent TrackerEvent { get; set; }
		
		// utmhn
		// TODO: NEED TO URL ENCODE
		public string HostName { get; set; }
		
		
		// utmipc
		public string SKUProductCode { get; set; }
		
		// utmipn
		// TODO: NEED TO URL ENCODE
		public string ProductName { get; set; }
		
		// utmipr
		public double UnitPrice { get; set; }
		
		// utmiqt
		public int Quantity { get; set; }
		
		// utmiva
		// TODO: NEED TO URL ENCODE
		public string Variations { get; set ;}
		
		// utmp
		public string PageRequest { get; set; }
		
		// utmr
		public string PageReferral { get; set; }
		
		// utmsc
		public string ScreenDepth { get; set; }
		
		// utmsr
		public string ScreenResolution { get; set; }
		
		// utmt
		public TrackerRequestType RequestType { get; set; }
		
		// utmci
		// TODO: NEED TO URL ENCODE
		public string BillingCity { get; set; }
		
		// utmco
		// TODO: NEED TO URL ENCODE
		public string BillingCountry { get; set; }
		
		// utmrg
		// TODO: NEED TO URL ENCODE
		public string BillingRegion { get; set; }
		
		// utmid
		// TODO: NEED TO URL ENCODE
		public string OrderId { get; set; }
		
		// utmsp
		public double ShippingCost { get; set; }
		
		// utmtto
		public double TotalCost { get; set; }
		
		// utmttx
		public double Tax { get; set; }
		
		// utmst
		// TODO: NEED TO URL ENCODE
		public string Affiliation { get; set; }
		
		// utmul
		// TODO: NEED TO URL ENCODE
		public string Language { get; set; }
		
		// utmwv
		public int TrackingCodeVersion { get { return 1; } }
		
		// utmip
		public string IPAddress { get; set; }
		
	}
}

