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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UniHax.Properties;

namespace UniHax
{
    /// <summary>
    /// The Mappings class gives access to bestfit and Unicode normalization character mappings. 
    /// </summary>
    public class Mappings
    {

        #region fields

        // This stores the entire Bestfit XML as an in memory database
        private XDocument xDocBestfit;
        // This stores the entire Bestfit XML as an in memory database
        private XDocument xDocUnicode;
        
        #endregion

        #region Ctor(s)
        public Mappings()
        {
            Init();
        }
        #endregion


        #region properties
        public XDocument XDocBestfit
        {
            get { return xDocBestfit; }
            set { xDocBestfit = value; }
        }

        public XDocument XDocUnicode
        {
            get { return xDocUnicode; }
            set { xDocUnicode = value; }
        }

        #endregion

        private void Init()
        {
            // The bestfit.xml file embedded as a resource
            var sBestfitXml = Resources.bestfit;
            // The unicode.xml file embedded as a resource
            var sUnicodeXml = Resources.unicode;
            
            // Build the in-memory databases
            XDocBestfit = XDocument.Parse(sBestfitXml);
            XDocUnicode = XDocument.Parse(sUnicodeXml);


        }

        /// <summary>
        /// Get a unique list of the charsets from the bestfit database.
        /// </summary>
        /// <returns></returns>
        public List<String> GetAvailableBestfitCharsets()
        {
            List<String> charsets = new List<string>();
            IEnumerable<string> query;

            try
            {
                query = (from mapping in XDocBestfit.Descendants("Mapping")
                             select (string)mapping.Element("Charset").Value).Distinct();
            }
            catch (Exception)
            {
                throw;
            }


            try
            {
                foreach (var charset in query.Distinct())
                {
                    charsets.Add(charset);
                }
            }
            catch (Exception)
            {
                // fine just return an empty list
                charsets.Add("");
                throw;
            }

            return charsets;
        }

        /// <summary>
        /// Build a data table for all of an ASCII character's bestfit mappings.
        /// </summary>
        /// <param name="cAscii">The ASCII character to query on.</param>
        /// <param name="lBestFit">Reference to a List you want to populate with data.</param>
        /// <param name="sCharset">An optional charset to filter results by.
        /// </param>
        public void BuildBestfitTable(char cAscii, 
            ref List<BestFitMapping> lBestFit,
            string sCharset = "")
        {
            UniChar uc = new UniChar();
            uc.CodePoint = uc.GetCodePoint(cAscii);
            IEnumerable<XElement> query;

            if (String.IsNullOrEmpty(sCharset))
            {
                query = from mapping in XDocBestfit.Descendants("Mapping")
                        where (string)mapping.Element("Ascii") == uc.CodePoint
                        select mapping; 
            }
            else
            {
                query = (from mapping in XDocBestfit.Descendants("Mapping")
                            where (string)mapping.Element("Ascii") == uc.CodePoint &&
                                  (string)mapping.Element("Charset") == sCharset
                            select mapping);
            }

            var count = query.Count();
            foreach (var item in query.Distinct())
            {
                BestFitMapping bf = new BestFitMapping();
                UniChar uc2 = new UniChar();
                bf.Ascii = item.Element("Ascii").Value;
                bf.Unicode = item.Element("Unicode").Value;
                bf.Character = uc2.ConvertCodePointToString(bf.Unicode);
                bf.Charset = item.Element("Charset").Value;
                bf.Name = item.Element("Name").Value;
                lBestFit.Add(bf);
            }
        }

        /// <summary>
        /// Build a data table for all of an ASCII character's bestfit mappings.
        /// </summary>
        /// <param name="cAscii">The ASCII character to query on.</param>
        /// <param name="lTransformations">Reference to a List you want to populate with data.</param>
        /// <param name="sTransform">An optional charset to filter results by.</param>
        public void BuildTransformationsTable(char cAscii,
            ref List<UnicodeMapping> lTransformations,
            string sTransform = "")
        {
            UniChar uc = new UniChar();
            uc.CodePoint = uc.GetCodePoint(cAscii);
            IEnumerable<XElement> query;

            if (String.IsNullOrEmpty(sTransform))
            {
                query = from mapping in xDocUnicode.Descendants("Mapping")
                        where (string)mapping.Element("Ascii") == uc.CodePoint
                        select mapping;
            }
            else
            {
                query = (from mapping in XDocUnicode.Descendants("Mapping")
                         where (string)mapping.Element("Ascii") == uc.CodePoint &&
                               (string)mapping.Element("Transform") == sTransform
                         select mapping);
            }

            var count = query.Count();
            foreach (var item in query.Distinct())
            {
                UnicodeMapping um = new UnicodeMapping();
                UniChar uc2 = new UniChar();
                um.Ascii = item.Element("Ascii").Value;
                um.Unicode = item.Element("Unicode").Value;
                um.Character = uc2.ConvertCodePointToString(um.Unicode);
                um.Transform= item.Element("Transform").Value;
                um.Name = item.Element("Name").Value;
                lTransformations.Add(um);
            }
        }

        /// <summary>
        /// Send me an ASCII character and I'll return you a list of Unicode characters that
        /// best fit map to it.  Since you're not telling me a specific charset your're
        /// interested in, I'm going to send you data for all of them.
        /// </summary>
        /// <param name="cAscii">The ASCII character to query on.</param>
        /// <param name="sCharset">An option charset name to filter by, valid values include:
        /// APL-ISO-IR-68
        /// CP424
        /// IBMGRAPH
        /// US-ASCII-QUOTES
        /// windows-1250
        /// windows-1251
        /// windows-1252
        /// windows-1253
        /// windows-1254
        /// windows-1255
        /// windows-1256
        /// windows-1257
        /// windows-1258
        /// windows-874
        /// CP864
        /// CP037
        /// CP1026
        /// CP500
        /// CP875
        /// DINGBATS
        /// KEYBOARD
        /// SYMBOL
        /// symbol
        /// zdingbat
        /// JAPANESE
        /// GSM0338
        /// </param>
        /// <returns></returns>
        public List<String> GetBestfitMappings(char cAscii, string sCharset = "")
        {
            BestFitMapping bm = new BestFitMapping();
            // If an invald charset was entered then set it to the wildcard
            if (!bm.charsets.Contains(sCharset))
            {
                sCharset = "";
            }
            UniChar uc = new UniChar();
            uc.CodePoint = uc.GetCodePoint(cAscii);
            IEnumerable<string> query;

            // If a charset wasn't specified, filter by the ASCII character
            if (String.IsNullOrEmpty(sCharset))
            {
                
                query = (from mapping in XDocBestfit.Descendants("Mapping")
                                       where 
                                        (string)mapping.Element("Ascii") == uc.CodePoint
                                       select mapping.Element("Unicode").Value);
            }

            // else filter by the charset too
            else
            {

                query = (from mapping in XDocBestfit.Descendants("Mapping")
                                       where
                                           (string)mapping.Element("Ascii") == "0043" &&
                                           (string)mapping.Element("Charset") == sCharset
                                       select mapping.Element("Unicode").Value);
            }

            List<String> data = new List<string>();
            foreach (var item in query.Distinct())
            {
                data.Add(item);
            }
            return data;
        }


        /// <summary>
        /// Get a unique list of the charsets from the bestfit database.
        /// </summary>
        /// <returns></returns>
        public List<String> GetAvailableTransforms()
        {
            List<String> transforms = new List<string>();
            var query = (from mapping in XDocUnicode.Descendants("Mapping")
                         select (string)mapping.Element("Transform").Value).Distinct();

            foreach (var charset in query.Distinct())
            {
                transforms.Add(charset);
            }
            return transforms;
        }


        /// <summary>
        /// Get all normalization mappings for an ASCII character.  Optionally specify a specific transform
        /// as a filter.  
        /// </summary>
        /// <param name="cAscii">A single ASCII character.</param>
        /// <param name="sTransform">Valid transformations specified as:
        /// 
        /// Simple_Lowercase_Mapping
        /// Lowercase_Mapping
        /// Simple_Case_Folding
        /// cf
        /// Simple_Uppercase_Mapping
        /// Simple_Titlecase_Mapping
        /// Uppercase_Mapping
        /// Titlecase_Mapping
        /// Decomposition_Mapping
        /// FC_NFKC
        /// </param>
        /// <returns></returns>
        public List<String> GetNormalizationMappings(char cAscii, string sTransform = "")
        {
            UnicodeMapping um = new UnicodeMapping();

            // If something is passed in we don't know about then set transform to a wildcard
            if (!um.transformations.Contains(sTransform))
            {
                sTransform = "";
            }
            UniChar uc = new UniChar();
            uc.CodePoint = uc.GetCodePoint(cAscii);
            IEnumerable<string> query;

            // If a transformation wasn't specified, filter by the ASCII character
            if (String.IsNullOrEmpty(sTransform))
            {

                query = (from mapping in XDocUnicode.Descendants("Mapping")
                         where
                          (string)mapping.Element("Ascii") == uc.CodePoint
                         select mapping.Element("Unicode").Value);
            }

            // else filter by the transformation too
            else
            {

                query = (from mapping in XDocUnicode.Descendants("Mapping")
                         where
                             (string)mapping.Element("Ascii") == "0043" &&
                             (string)mapping.Element("Transform") == sTransform
                         select mapping.Element("Unicode").Value);
            }

            List<String> data = new List<string>();
            foreach (var item in query.Distinct())
            {
                data.Add(item);
            }
            return data;
        }
    }
}
