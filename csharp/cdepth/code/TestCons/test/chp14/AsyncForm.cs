using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCons.test.chp14
{
    public partial class AsyncForm : Form
    {
        Label label;
        Button button;
        public AsyncForm()
        {
            label = new Label { Location = new Point(10, 20), Text = "Length" };
            button = new Button { Location = new Point(10, 50), Text = "Click me" };
            button.Click += DisplayWebSiteLength;
            AutoSize = true;
            Controls.Add(label);
            Controls.Add(button);

        }
        async void DisplayWebSiteLength(object sender, EventArgs e) {
            label.Text = "Fetching...";
            using (HttpClient client = new HttpClient()) {
                string text =await client.GetStringAsync("http://www.baidu.com");
                label.Text = text.Length.ToString();
            }
        }

      
    }
}
