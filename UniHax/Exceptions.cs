
// Copyright (c) 2011 by Christopher Weber

// Permission is hereby granted, free of charge, to any person obtaining a copy  
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights  
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell  
// copies of the Software, and to permit persons to whom the Software is  
// furnished to do so, subject to the following conditions: 

// The above copyright notice and this permission notice shall be included in     
// all copies or substantial portions of the Software. 

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR  
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,  
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE  
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER  
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
// SOFTWARE. 

// Authors: 
// Christopher Weber (chris@lookout.net)

using System;


namespace UniHax
{
    public class BestFitMappingException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime TimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public BestFitMappingException()
        {
        }


        public override string Message
        {
            get
            {
                return String.Format("Bestfit mapping error:{0}", messageDetails);
                return base.Message;
            }
        }
    }
}
