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
    /// <summary>
    /// A 32-bit representation of a Unicode character.  Treats all characters as
    /// a 32 bit value.  Gives access to a character's code point as a string.
    /// [!] Only handles the Basic Mulitlingual Plane (BMP).  Code points > U+FFFF
    /// will throw exceptions.
    /// [!] Does NOT support surrogate pairs.
    /// </summary>
    public struct UniChar
    {
        public string CodePoint;
        public string Character;


        //public UniChar(string codePoint)
        //{
        //    CodePoint = codePoint;
        //    Character = ConvertCodePointToString(CodePoint);
        //}

        //public UniChar(char character)
        //{
        //    this.Character = character;
        //    this.CodePoint = "0000";
        //    this.CodePoint = GetCodePoint(Character);
        //}

        public string GetCodePoint(char c)
        {
            int i;
            try
            {
                i = Convert.ToInt32(c); // 0x00 to 0x10ffff
            }
            catch (Exception)
            {
                // return the replacement chacter U+FFFD
                i = 0x0000FFFD;
                throw;
            }
            string codepoint = String.Format("{0:X4}", i);
            return codepoint;
        }

        public string ConvertCharacterToString(char character)
        {
            int i;

            try
            {
                i = Convert.ToInt32(CodePoint.Trim(), 16); // 0x00 to 0x10ffff
            }
            catch (FormatException e)
            {
                i = 0;
            }
            catch(Exception)
            {
                throw;
            }

            string x = Char.ConvertFromUtf32(i);
            string characters = x;

            return characters;
        }


        public string ConvertCharacterToCodePoint(char character)
        {
            int i = Convert.ToInt32(CodePoint.Trim(), 16); // 0x00 to 0x10ffff
            string x = string.Format("{0:X4}", i);

            return x;
        }

        public string ConvertCodePointToString(string codepoint)
        {
            int i;
            try
            {
                i = Convert.ToInt32(codepoint.Trim(), 16); // 0x00 to 0x10ffff
            }
            catch (FormatException e)
            {
                i = 0;
            }
            catch(ArgumentOutOfRangeException e)
            {
                i = 0;
            }
            return Char.ConvertFromUtf32(i);
        }
    }
}
