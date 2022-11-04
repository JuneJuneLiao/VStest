using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace WindowsFormsApp1011
{
    public partial class JsonPath : Form
    {
        public JsonPath (string pushJsonData)
        {
            InitializeComponent();
            JObject json = JObject.Parse(pushJsonData.ToString());
            inputTextBox.Text = json.ToString();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            JObject strToJson = JObject.Parse(inputTextBox.Text);
            var jsonPath = JsonConvert.SerializeObject(strToJson.SelectTokens(searchJsonTextBox.Text));
            outputTextBox.Text = jsonPath.ToString();
        }
    }
}
