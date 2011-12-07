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
using RestSharp;
using RestSharp.Contrib;

namespace Devnos.GoogAnalytics
{
	public class AnalyticsTrackerService
	{
		const string UTM_GIF = @"http://www.google-analytics.com/__utm.gif";
		
		private static RestClient Client {
			get { return new RestClient(UTM_GIF); }
		}
		
		Func<TrackerRequest, TrackerResult> TrackerRequestAction;
		
		public AnalyticsTrackerService()
		{
			 TrackerRequestAction = Send;
		}
		
		public TrackerResult Send(TrackerRequest trackerRequest)
		{
			if(trackerRequest == null && trackerRequest == default(TrackerRequest)) {
				throw new ArgumentException("Invalid TrackerRequest parameter provided. Deez Nuts. Boom.");
			}
			
			var result = new TrackerResult();
			
			var request = new RestRequest("");
			BuildTrackerRequest(ref request, trackerRequest);
			
			var response = Client.Execute(request);
			
			result.StatusCode = response.StatusCode;
			result.ErrorMessage = result.ErrorMessage;
			
			return result;
		}
		
		public void SendAsync(TrackerRequest request, Action<TrackerResult> callback = null)
		{
			TrackerRequestAction.BeginInvoke(request, (ar) => {
				var result = TrackerRequestAction.EndInvoke(ar);
				
				if(callback != null) {
					callback(result);
				}
			
			}, null);
		}
		
		private void BuildTrackerRequest(ref RestRequest req, TrackerRequest tracker)
		{
			req.AddParameter("utmn", tracker.Id);
			req.AddParameter("utmhid", tracker.Hid);
			req.AddParameter("utmcs", tracker.LanguageEncoding);
			req.AddParameter("utmwv", tracker.TrackingCodeVersion);
			
			if(!string.IsNullOrWhiteSpace(tracker.Account)) {
				req.AddParameter("utmac", tracker.Account ?? "-");
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.PageTitle)) {
				req.AddParameter("utmdt", HttpUtility.UrlEncode(tracker.PageTitle));
			}
			
			if(tracker.TrackerEvent != null && tracker.TrackerEvent != default(TrackerEvent)) {
				var encoded = EncodeTrackerEvent(tracker.TrackerEvent);
				req.AddParameter("utme", encoded);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.HostName)) {
				req.AddParameter("utmhn", HttpUtility.UrlEncode(tracker.HostName));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.SKUProductCode)) {
				req.AddParameter("utmipc", tracker.SKUProductCode);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.ProductName)) {
				req.AddParameter("utmipn", HttpUtility.UrlEncode(tracker.SKUProductCode));
			}
			
			if(tracker.UnitPrice != default(double) && tracker.UnitPrice >= 0) {
				req.AddParameter("utmipr", tracker.UnitPrice);
			}
			
			if(tracker.Quantity != default(int) && tracker.Quantity > 0) {
				req.AddParameter("utmiqt", tracker.Quantity);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.Variations)) {
				req.AddParameter("utmiva", HttpUtility.UrlEncode(tracker.Variations));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.PageRequest)) {
				req.AddParameter("utmp", tracker.PageRequest);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.PageReferral)) {
				req.AddParameter("utmr", tracker.PageReferral);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.ScreenDepth)) {
				req.AddParameter("utmsc", tracker.ScreenDepth);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.ScreenResolution)) {
				req.AddParameter("utmsr", tracker.ScreenResolution);
			}
			
			if(tracker.RequestType != null) {
				req.AddParameter("utmt", (string)tracker.RequestType);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.BillingCity)) {
				req.AddParameter("utmci", HttpUtility.UrlEncode(tracker.BillingCity));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.BillingCountry)) {
				req.AddParameter("utmco", HttpUtility.UrlEncode(tracker.BillingCity));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.BillingRegion)) {
				req.AddParameter("utmrg", HttpUtility.UrlEncode(tracker.BillingRegion));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.OrderId)) {
				req.AddParameter("utmid", HttpUtility.UrlEncode(tracker.OrderId));
			}
			
			if(tracker.ShippingCost != default(double) && tracker.ShippingCost >= 0) {
				req.AddParameter("utmsp", tracker.ShippingCost);
			}
			
			if(tracker.TotalCost != default(double) && tracker.TotalCost >= 0) {
				req.AddParameter("utmtto", tracker.TotalCost);
			}
			
			if(tracker.Tax != default(double) && tracker.Tax >= 0) {
				req.AddParameter("utmttx", tracker.Tax);
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.Affiliation)) {
				req.AddParameter("utmst", HttpUtility.UrlEncode(tracker.Affiliation));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.Language)) {
				req.AddParameter("utmul", HttpUtility.UrlEncode(tracker.Language));
			}
			
			if(!string.IsNullOrWhiteSpace(tracker.IPAddress)) {
				req.AddParameter("utmip", HttpUtility.UrlEncode(tracker.IPAddress));
			}
		}
		
		private static string EncodeTrackerEvent(TrackerEvent evt)
		{
			var formatted = string.Format("5({0}*{1}*{2})({3})", evt.Object, evt.Action, evt.Label, evt.Value);
			return HttpUtility.UrlEncode(formatted);
		}
		
		
		
	}
}
