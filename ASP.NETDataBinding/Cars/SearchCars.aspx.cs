using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cars
{
    public partial class SearchCars : System.Web.UI.Page
    {
        // I know. I know. Magic strings!
        // If you have better idea than visible(except dynamic creating elements) would like to hear it.

        static ICollection<Producer> producers;
        static ICollection<string> extras = new List<string> { "Radio", "Insurance", "GPS", "Police Radio Scanner", "Nitrous Oxide System" };
        static ICollection<string> engines = new List<string> { "V8", "V6 Twin Turbo", "V10" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            producers = new List<Producer>();

            Producer porsche = new Producer("Porsche");
            porsche.Models = new List<string>()
            {
                "911 Turbo S",
                "911 Carrera S",
                "980 Carrera GT",
                "918 Spyder",
                "911 GT3 RS 4.0"
            };
            producers.Add(porsche);

            Producer ford = new Producer("Ford");
            ford.Models = new List<string>()
            {
                "Mustang",
                "GT",
                "Focus"
            };
            producers.Add(ford);

            Producer nissan = new Producer("Nissan");
            nissan.Models = new List<string>()
            {
                "Skyline GTR r34",
                "Skyline GTR r35",
                "240sx",

            };
            producers.Add(nissan);

            Producer toyota = new Producer("Toyota");
            toyota.Models = new List<string>()
            {
                "Supra 2jz",
                "Celica",
                "Corolla"
            };
            producers.Add(toyota);

            this.DropDownProducers.DataSource = producers;
            this.DropDownProducers.DataBind();
        }

        protected void DropDownProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producerName = ((DropDownList)sender).SelectedValue;
            if (producerName != "--select producer--")
            {
                Producer producer = producers.Where(x => x.Name == producerName).First();
                this.DropDownModels.Items.Clear();
                this.DropDownModels.Items.Add(new ListItem("--select model--"));
                this.DropDownModels.DataSource = producer.Models;
                this.DropDownModels.Visible = true;
            }
            else
            {
                this.DropDownModels.Items.Clear();
                this.DropDownModels.Visible = false;
                this.CheckBoxListExtras.Visible = false;
                this.CheckBoxListExtras.Items.Clear();
                this.RadioButtonGroupEngines.Visible = false;
                this.RadioButtonGroupEngines.Items.Clear();
            }
            this.DropDownModels.DataBind();
        }

        protected void DropDownModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string model = ((DropDownList)sender).SelectedValue;
            if (model != "--select model--")
            {
                this.ButtonSubmit.Visible = true;
                this.RadioButtonGroupEngines.Items.Clear();
                this.CheckBoxListExtras.Items.Clear();
                this.CheckBoxListExtras.Visible = true;
                this.CheckBoxListExtras.DataSource = extras;
                this.RadioButtonGroupEngines.Visible = true;
                this.RadioButtonGroupEngines.DataSource = engines;
            }
            else
            {
                this.ButtonSubmit.Visible = false;
                this.CheckBoxListExtras.Visible = false;
                this.CheckBoxListExtras.Items.Clear();
                this.RadioButtonGroupEngines.Visible = false;
                this.RadioButtonGroupEngines.Items.Clear();
            }

            this.CheckBoxListExtras.DataBind();
            this.RadioButtonGroupEngines.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();
            foreach (ListItem item in this.CheckBoxListExtras.Items)
            {
                if (item.Selected)
                {
                    selected.Add(item.Value);
                }
            }
            this.LiteralResult.Text = $"Producer: {this.DropDownProducers.SelectedValue}; ";
            this.LiteralResult.Text += $"Model: {this.DropDownModels.SelectedValue}; ";
            this.LiteralResult.Text += $"Engine: {this.RadioButtonGroupEngines.SelectedValue}; ";
            this.LiteralResult.Text += $"Extras: {string.Join(", ", selected)}";
        }
    }
}