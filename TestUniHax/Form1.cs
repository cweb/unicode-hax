
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
using System.Windows.Forms;
using UniHax;

namespace TestUniMap
{
    public partial class FormUniMapTest : Form
    {
        
        private char input;
        private string charset;
        private string transform;
        private Mappings data = new Mappings();

        public FormUniMapTest()
        {
            InitializeComponent();

            // Setup the charset combobox
            List<String> charsets =  Data.GetAvailableBestfitCharsets();
            // Insert a blank line at the beginning
            charsets.Insert(0, "");
            comboBoxCharsets.DataSource = charsets;
            comboBoxCharsets.DisplayMember = "Charset";

            // Setup the transform combobox 
            List<String> transforms = Data.GetAvailableTransforms();
            transforms.Insert(0, "");
            comboBoxTransformations.DataSource = transforms;
            comboBoxTransformations.DisplayMember = "Transform";

            // Populate unichar properties
            string[] aProps = { Fuzzer.uBOM, Fuzzer.uMVS, Fuzzer.uReservedCodePoint, Fuzzer.uRLO, Fuzzer.uDEAD,  Fuzzer.uDAAD, Fuzzer.uPrivate, Fuzzer.uNotACharacter };
            string sProps = String.Join("\r\n", aProps);
            textBoxUnicharProps.Text = sProps;
        }

        public Mappings Data
        {
            get { return data; }
            set { data = value; }
        }

        public char Input
        {
            get { return input; }

            set 
            {
                try
                {
                    //input = Convert.ToChar(0x0d);
                    input = Convert.ToChar(value); 
                }
                catch (Exception)
                {
                    textBoxStatus.Text =
                        "Error:  Input was not in a correct format.  Only a single ASCII character is allowed.  The first character you entered will be used.";
                }
            }
        }
        public string Charset
        {
            get { return charset; }
            set { charset = value; }
        }

        public string Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {


            string sInput = textBoxInput.Text;
            textBoxStatus.Text = "";
            
            try
            {
                Input = Convert.ToChar(sInput);
            }
            catch (Exception)
            {
                textBoxStatus.Text = 
                    "Error:  Input was not in a correct format.  Only a single ASCII character is allowed.  The first character you entered will be used.";

            }
        }

        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonGetBestfit_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "";
            List<String> bestfits = new List<string>();
            bestfits = Data.GetBestfitMappings(Input);

            string output = String.Empty;

            foreach (string bestfit in bestfits)
            {
                UniChar uc = new UniChar();
                if (!String.IsNullOrEmpty(bestfit))
                {
                    output += uc.ConvertCodePointToString(bestfit) + "\r\n";
                }
            }

            textBoxOutput.Text = output;

            // Fill DataGrid
            List<BestFitMapping> lBestfits = new List<BestFitMapping>();
            dataGridViewBestFit.DataSource = null;
            Data.BuildBestfitTable(Input,ref lBestfits, Charset);
            dataGridViewBestFit.DataSource = lBestfits;


        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBestFit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormUniMapTest_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCharsets_SelectedIndexChanged(object sender, EventArgs e)
        {
            Charset = comboBoxCharsets.SelectedValue.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTransformations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transform = comboBoxTransformations.SelectedValue.ToString();
        }

        private void buttonGetUnicode_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "";
            List<String> transforms = new List<string>();
            transforms = Data.GetNormalizationMappings(Input);

            string output = String.Empty;

            foreach (string transform in transforms)
            {
                UniChar uc = new UniChar();
                if (!String.IsNullOrEmpty(transform))
                {
                    output += uc.ConvertCodePointToString(transform) + "\r\n";
                }
            }

            textBoxOutput.Text = output;

            // Fill DataGrid
            List<UnicodeMapping> lTransformations = new List<UnicodeMapping>();
            dataGridViewBestFit.DataSource = null;
            Data.BuildTransformationsTable(Input, ref lTransformations, Transform);
            dataGridViewBestFit.DataSource = lTransformations;
        }

        private void textBoxUnicharProps_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelInput_Click(object sender, EventArgs e)
        {

        }
    }
}
