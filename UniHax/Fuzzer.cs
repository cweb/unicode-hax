 
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
using System.IO;

namespace UniHax
{
    /// <summary>
    /// The Fuzzer has cases for some of the oddball manifestations of Unicode that can trip up software including:
    /// 
    /// - non-character, reserved, and private use area code points
    /// - special meaning characters such as the BOM and RLO
    /// - ill-formed byte sequences
    /// - a half-surrogate code point
    /// 
    /// 
    /// </summary>
    public class Fuzzer
    {

        /// <summary>
        /// The Byte Order Mark U+FEFF is a special character defining the byte order and endianess
        /// of text data.
        /// UTF-8 percent encoding is %EF%BB%BF
        /// </summary>
        public static readonly string uBOM = "\uFEFF";
        /// <summary>
        /// The Right to Left Override U+202E defines special meaning to re-order the 
        /// display of text for right-to-left reading.
        /// UTF-8 percent encoding is %E2%80%AE
        /// </summary>
        public static readonly string uRLO = "\u202E";
        /// <summary>
        /// Mongolian Vowel Separator U+180E is invisible and has the whitespace property.
        /// UTF-8 percent encoding is %E1%A0%8E
        /// </summary>
        public static readonly string uMVS = "\u180E";
        /// <summary>
        /// Word Joiner U+2060 is an invisible zero-width character.
        /// UTF-8 percent encoding is %E2%81%A0
        /// </summary>
        public static readonly string uWordJoiner = "\u2060";
        /// <summary>
        /// A reserved code point U+FEFE
        /// UTF-8 percent encoding is %ef%bb%bf
        /// </summary>
        public static readonly string uReservedCodePoint = "\uFEFE";
        /// <summary>
        /// The code point U+FFFF is guaranteed to not be a Unicode character at all
        /// UTF-8 percent encoding is %ef%bf%bf
        /// </summary>
        public static readonly string uNotACharacter = "\uFFFF";
        /// <summary>
        /// An unassigned code point U+0FED
        /// UTF-8 percent encoding is %e0%bf%ad
        /// </summary>
        public static readonly string uUnassigned = "\u0FED";
        /// <summary>
        ///  An illegal low half-surrogate U+DEAD
        /// UTF-8 percent encoding is %ed%ba%ad
        /// </summary>
        public static readonly string uDEAD = "\uDEAD";
        /// <summary>
        /// An illegal high half-surrogate U+DAAD
        /// UTF-8 percent encoding is %ed%aa%ad
        /// </summary>
        public static readonly string uDAAD = "\uDAAD";
        /// <summary>
        /// A Private Use Area code point U+F8FF which Apple happens to use for its logo.
        /// UTF-8 percent encoding is %EF%A3%BF
        /// </summary>
        public static readonly string uPrivate = "\uF8FF";
        /// <summary>
        /// U+FF0F FULLWIDTH SOLIDUS should normalize to / in a hostname
        /// UTF-8 percent encoding is %F0%9D%9F%96
        /// </summary>
        public static readonly string uFullwidthSolidus = "\uFF0F";
        /// <summary>
        /// Code point with a numerical mapping and value U+1D7D6 MATHEMATICAL BOLD DIGIT EIGHT
        /// UTF-8 percent encoding is 
        /// </summary>
        public static readonly string uBoldEight = char.ConvertFromUtf32(0x1D7D6);
        /// <summary>
        /// IDNA2003/2008 Deviant - U+00DF normalizes to "ss" during IDNA2003's mapping phase,
        /// different from its IDNA2008 mapping.
        /// See http://www.unicode.org/reports/tr46/
        /// UTF-8 percent encoding is %C3%9F
        /// </summary>
        public static readonly string uIdnaSs = "\u00DF";
        /// <summary>
        /// U+FDFD expands by 11x (UTF-8) and 18x (UTF-16) under NFKC/NFKC
        /// UTF-8 percent encoding is %EF%B7%BA
        /// </summary>
        public static readonly string uFDFA = "\uFDFA";
        /// <summary>
        /// U+0390 expands by 3x (UTF-8) under NFD
        /// UTF-8 percent encoding is %CE%90
        /// </summary>
        public static readonly string u0390 = "\u0390";
        /// <summary>
        /// U+1F82 expands by 4x (UTF-16) under NFD
        /// UTF-8 percent encoding is %E1%BE%82
        /// </summary>
        public static readonly string u1F82 = "\u1F82";
        /// <summary>
        /// U+FB2C expands by 3x (UTF-16) under NFC
        /// UTF-8 percent encoding is %EF%AC%AC
        /// </summary>
        public static readonly string uFB2C = "\uFB2C";
        /// <summary>
        /// U+1D160 expands by 3x (UTF-8) under NFC
        /// UTF-8 percent encoding is %F0%9D%85%A0
        /// </summary>
        public static readonly string u1D160 = char.ConvertFromUtf32(0x1D160);

        /// <summary>
        /// Gets the requested byte representation of the current Unicode character codepoint
        /// </summary>
        /// <param name="encoding">The encoding you want a byte representation in.  Specify utf-8, utf-16le, or utf16-be</param>
        /// <param name="character">A single character sent as a string.</param>
        /// <returns>Returns a byte array</returns>
        public byte[] GetCharacterBytes(string encoding, string character)
        {
            System.Text.Encoding enc;
            if (encoding == "utf-16le")
            {
                enc = new System.Text.UnicodeEncoding();
            }
            else if (encoding == "utf-16be")
            {
                enc = new System.Text.UnicodeEncoding(true, false);
            }
            else
            {
                enc = new System.Text.UTF8Encoding();
            }

            return enc.GetBytes(character);

        }

        /// <summary>
        /// Malforms the bytes by removing the last byte from whichever encoding you specify.
        /// </summary>
        /// <param name="encoding">The encoding you want a byte representation in.  Specify utf-8, utf-16le, or utf16-be</param>
        /// <param name="character">A single character sent as a string.</param>
        /// <returns></returns>
        public byte[] GetCharacterBytesMalformed(string encoding, string character)
        {
            System.Text.Encoding enc;
            
            if (encoding == "utf-16le")
            {
                enc = new System.Text.UnicodeEncoding();
            }
            else if (encoding == "utf-16be")
            {
                enc = new System.Text.UnicodeEncoding(true, false);
            }
            else
            {
                enc = new System.Text.UTF8Encoding();
            }


            byte[] characterBytes = enc.GetBytes(character);  // now we have a byte array
            byte[] shorter;

            // Check that there's more than one byte before malforming it by removing the last byte.
            // Otherwise we'd end up with no bytes in the array.  This can make test cases pretty useless.
            if (enc.GetByteCount(character) > 1)
            {
                shorter = new byte[characterBytes.Length - 1];
                Array.Copy(characterBytes, shorter, shorter.Length);
            }

            // just return the one byte array rather than removing the one byte
            else
            {
                shorter = new byte[characterBytes.Length];
                Array.Copy(characterBytes, shorter, shorter.Length);
            }
            return shorter;

        }

        public string GetBom()
        {
            return Fuzzer.uBOM;
        }

        /// <summary>
        /// Return a UTF32 byte encoding for an illegal code point value U+1FFFFF.  
        /// Note that Unicode 6.0 supports only up to U+10FFFF.
        /// UTF-8 percent encoding for something out of range is %F4%8F%BF%BE
        /// </summary>
        /// <returns>A raw byte array because .NET will not allow illegal code points in the System.String class.</returns>
        public byte[] OutOfRangeCodePointAsUtf32BE()
        {
            byte[] bytes = {0x00, 0x1F, 0xFF, 0xFF};
            return bytes;
        }
    }
}
