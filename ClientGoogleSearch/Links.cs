using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClientGoogleSearch
{
    public partial class Links : Form
    {
        public string Content { private set; get; }
        public RestClient client;
        public LinkLabel linkLabel;
        public Label label;
        public int X { get; private set; }
        public int Y { get; private set; }
        public Links()
        {
            InitializeComponent();
        }

        private void Links_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void setText(string text)
        {
            this.Content = text;
        }

        /*
         * Método que preenche o form com os titulos e links retornados pela classe RestClient.  
         */
        public void populateListBox()
        {
            this.client = new RestClient();
            this.Y = 40;
            this.X = 30;
            foreach (var value in client.getListOflinks(this.Content))
            {
                if (!string.IsNullOrWhiteSpace(value.Text)) {
                    if (!value.Href.Contains("blogger") && !value.Href.Contains("youtube"))
                    {
                        //Cria o primeiro título e constroi o elemento no form nas posiçãos X e Y.
                        label = new Label();
                        label.Location = new Point(this.X, this.Y);
                        label.AutoSize = true;
                        label.Text = value.Text;
                        this.Controls.Add(label);
                        this.Y += 15; //Incrementa para não sobescrever.

                        //Cria o primeiro link (LinkLabel) e constroi o elemento no form nas posiçãos X e Y.
                        LinkLabel.Link link = new LinkLabel.Link();
                        link.LinkData = value.Href;
                        linkLabel = new LinkLabel();
                        linkLabel.Location = new Point(this.X, this.Y);
                        linkLabel.AutoSize = true;
                        linkLabel.Links.Add(link);
                        linkLabel.Text = value.Href;
                        linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
                        this.Controls.Add(linkLabel);
                        this.Y += 25;
                    }
                }
            }
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }
    }
}
