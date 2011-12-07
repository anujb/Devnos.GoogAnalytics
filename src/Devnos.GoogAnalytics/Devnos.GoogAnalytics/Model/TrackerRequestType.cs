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
	public class TrackerRequestType
	{
		private readonly string _type;
		
		private TrackerRequestType(string type)
		{
			_type = type;	
		}
		
		public override string ToString()
		{
			return _type;
		}
		
		public static implicit operator string(TrackerRequestType type)
		{
			return type.ToString();
			
		}
		
		public static readonly TrackerRequestType Page = new TrackerRequestType("page");
		public static readonly TrackerRequestType Event = new TrackerRequestType("event");
		public static readonly TrackerRequestType Transaction = new TrackerRequestType("transaction");
		public static readonly TrackerRequestType Item = new TrackerRequestType("item");
		public static readonly TrackerRequestType Custom = new TrackerRequestType("custom variable");
	}
}

