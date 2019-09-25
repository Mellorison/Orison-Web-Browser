using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orison
{
    public partial class Form1 : Form
    {
        String Url = string.Empty;
        public Form1()
        {
            InitializeComponent();
            Url = "https://www.duckduckgo.com";
            MyBrowser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            toolStripButton3.Enabled = false;
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            MyBrowser();
        }

        private void MyBrowser()

        {
            if (toolStripComboBox1.Text != "")
                Url = toolStripComboBox1.Text;
            webBrowser1.Navigate(Url);
            webBrowser1.ProgressChanged +=
                new WebBrowserProgressChangedEventHandler(Webpage_ProgressChanged);
            webBrowser1.DocumentTitleChanged += new EventHandler(Webpage_DocumentTitleChanged);
            webBrowser1.StatusTextChanged += new EventHandler(Webpage_StatusTextChanged);
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(Webpage_Navigated);
            webBrowser1.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(Webpage_DocumentCompleted);
        }

        private void Webpage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.CanGoBack) toolStripButton1.Enabled = true;
            else toolStripButton1.Enabled = false;

            if (webBrowser1.CanGoForward) toolStripButton3.Enabled = true;
            else toolStripButton3.Enabled = false;
            toolStripStatusLabel1.Text = "Done";

        }

        private void Webpage_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle.ToString();
        }

        private void Webpage_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = webBrowser1.StatusText;
        }

        private void Webpage_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar1.Value = ((int)e.CurrentProgress < 0 ||
            (int)e.MaximumProgress < (int)e.CurrentProgress) ? (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void Webpage_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripComboBox1.Text = webBrowser1.Url.ToString();
        }


    }
}
