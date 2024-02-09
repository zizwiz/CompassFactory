
namespace CompassFactory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.rchtxtbx_output = new System.Windows.Forms.RichTextBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbobx_airport_info = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(801, 572);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(137, 47);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(12, 572);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(60, 47);
            this.btn_about.TabIndex = 1;
            this.btn_about.Text = "?";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // rchtxtbx_output
            // 
            this.rchtxtbx_output.Location = new System.Drawing.Point(12, 46);
            this.rchtxtbx_output.Name = "rchtxtbx_output";
            this.rchtxtbx_output.Size = new System.Drawing.Size(926, 520);
            this.rchtxtbx_output.TabIndex = 2;
            this.rchtxtbx_output.Text = "";
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(414, 572);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(137, 47);
            this.btn_go.TabIndex = 3;
            this.btn_go.Text = "Go";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Airport";
            // 
            // cmbobx_airport_info
            // 
            this.cmbobx_airport_info.FormattingEnabled = true;
            this.cmbobx_airport_info.Items.AddRange(new object[] {
            " Choose Airport Below",
            "AAC Middle Wallop",
            "Aberdeen Airport",
            "Aberporth Airport",
            "Aintree Heliport",
            "Alderney Airport",
            "Andrewsfield Aerodrome",
            "Anglesey Airport",
            "Anwick",
            "Ascot Racecourse Heliport",
            "Ashcroft",
            "Audley End Airfield",
            "Bagby Airfield",
            "Barra Airport",
            "Barrow/Walney Island Airport",
            "Beccles Airfield",
            "Bedford Aerodrome",
            "Belfast International Airport",
            "Bembridge Airport",
            "Benbecula Airport",
            "Beverley/Linley Hill Airfield",
            "Bicester Airfield",
            "Birmingham Airport",
            "Blackbushe Airport",
            "Blackpool Airport",
            "Bodmin Aerodrome",
            "Bourn Airfield",
            "Bournemouth Airport",
            "Breighton Aerodrome",
            "Brimpton",
            "Bristol Airport",
            "Brooklands",
            "Bruntingthorpe Aerodrome",
            "Caernarfon Airport",
            "Cambridge City Airport",
            "Campbeltown Airport ",
            "Cardiff Airport",
            "Cardiff Heliport",
            "Carlisle Lake District Airport",
            "Chalgrove Airfield",
            "Challock Airfield",
            "Cheltenham Racecourse Heliport",
            "Chester Hawarden Airport",
            "Chichester/Goodwood Airport",
            "City of Derry Airport",
            "Clacton Airport",
            "Colerne",
            "Coll Airport",
            "Colonsay Airport",
            "Compton Abbas Airfield",
            "Cotswold Airport",
            "Cottesmore",
            "Coventry Airport",
            "Cranfield Airport",
            "Crosland Moor Airfield",
            "Crowfield Airfield",
            "Culter Heliport",
            "Cumbernauld Airport",
            "Damyns Hall Aerodrome",
            "Deanland Lewes",
            "Deenethorpe",
            "Denham Aerodrome",
            "Derby Airfield",
            "Doncaster Sheffield Airport",
            "Dundee Airport",
            "Dunkeswell Aerodrome",
            "Dunsfold Aerodrome",
            "Duxford Aerodrome",
            "Eaglescott Airfield",
            "Earls Colne Airfield",
            "East Midlands Airport",
            "Eday Airport",
            "Edinburgh Airport",
            "Elmsett Airfield",
            "Elstree Aerodrome",
            "Elvington Airfield",
            "Enniskillen",
            "Enstone Airfield",
            "Exeter Airport",
            "Fair Isle Airport",
            "Fairoaks Airport",
            "Farnborough Airport",
            "Farthing Corner",
            "Fenland Airfield",
            "Fife Airport",
            "Filton",
            "Fishburn Airfield",
            "Fowlmere Airfield",
            "Full Sutton Airfield",
            "George Best Belfast City Airport",
            "Glasgow Airport",
            "Glasgow City Heliport",
            "Glasgow Prestwick Airport",
            "Gloucestershire Airport",
            "Goodwood Racecourse Heliport",
            "Great Yarmouth",
            "Guernsey Airport",
            "Haverfordwest Airport",
            "Headcorn Aerodrome",
            "Henstridge Airfield",
            "Holyhead Heliport",
            "Humberside Airport",
            "Hunsdon",
            "Inverness Airport",
            "Islay Airport",
            "Isle of Man Airport",
            "Isle of Skye",
            "Isle of Wight/Sandown Airport",
            "Jersey Airport",
            "Kinloss Barracks",
            "Kirkwall Airport",
            "Land\'s End Airport",
            "Langford Lodge",
            "Lasham Airfield",
            "Leconfield",
            "Lee on Solent",
            "Leeds Bradford Airport",
            "Leeds East Airport",
            "Leicester Airport",
            "Leuchars Station",
            "Little Gransden Airfield",
            "Liverpool John Lennon Airport",
            "Llanbedr Airport",
            "London Biggin Hill Airport",
            "London City Airport",
            "London Gatwick Airport",
            "London Heathrow Airport",
            "London Luton",
            "London Oxford Airport",
            "London Southend Airport",
            "London Stansted Airport",
            "London Westland Heliport",
            "Long Marston",
            "Longside",
            "Lydd Airport",
            "Main Hall Farm Airfield",
            "Manchester Airport",
            "Manchester Barton Aerodrome",
            "Manston Airport",
            "Marshland",
            "Maypole",
            "MoD Boscombe Down",
            "Netheravon Airfield",
            "Netherthorpe Airfield",
            "Newcastle International Airport",
            "Newmarket Heath",
            "Newquay Airport / RAF St Mawgan",
            "Newtownards Airport",
            "North Ronaldsay Airport",
            "North Weald Airfield",
            "Norwich Airport",
            "Nottingham Airport",
            "Oaksey Park Airfield",
            "Oban Airport",
            "Old Buckenham Airfield",
            "Old Sarum Airfield",
            "Papa Westray Airport",
            "Pembrey Airport",
            "Penzance Heliport",
            "Perranporth Airfield",
            "Perth Airport",
            "Peterborough Business Airport",
            "Peterborough Sibson",
            "Plymouth",
            "Popham Airfield",
            "Portland Heliport",
            "RAF Barkston Heath",
            "RAF Benson",
            "RAF Brize Norton",
            "RAF Coltishall",
            "RAF Coningsby",
            "RAF Cosford",
            "RAF Cranwell",
            "RAF Dishforth",
            "RAF Fairford",
            "RAF Halton",
            "RAF Henlow",
            "RAF Honington",
            "RAF Lakenheath",
            "RAF Leeming",
            "RAF Linton-on-Ouse",
            "RAF Lossiemouth",
            "RAF Lyneham",
            "RAF Marham",
            "RAF Mildenhall",
            "RAF Northolt",
            "RAF Odiham",
            "RAF Scampton",
            "RAF Shawbury",
            "RAF Ternhill",
            "RAF Topcliffe",
            "RAF Waddington",
            "RAF Wittering",
            "RAF Woodvale",
            "RAF Wyton",
            "Redhill Aerodrome",
            "Retford Gamston Airport",
            "RNAS Culdrose",
            "RNAS Yeovilton",
            "Rochester Airport",
            "Royal Marines Base Chivenor",
            "Sanday Airport",
            "Sandtoft Airfield",
            "Scatsta",
            "Seething Airfield",
            "Sherburn-in-Elmet Airfield",
            "Shipdham Airfield",
            "Shobdon Aerodrome",
            "Shoreham Airport",
            "Shotton Airfield/Peterlee Parachute Centre",
            "Shuttleworth Aerodrome",
            "Silverstone",
            "Skegness",
            "Sleap Airfield",
            "Southampton Airport",
            "St Athan",
            "St Mary\'s Airport",
            "Stapleford Aerodrome",
            "Stornoway Airport",
            "Stronsay Airport",
            "Strubby Airfield",
            "Sturgate Airfield",
            "Sumburgh Airport",
            "Swansea Airport",
            "Sywell Aerodrome",
            "Tatenhill Airfield",
            "Teesside International Airport",
            "Thruxton Aerodrome",
            "Thurrock",
            "Tilstock",
            "Tingwall Airport",
            "Tiree Airport",
            "Tresco Heliport",
            "Truro Aerodrome",
            "Turweston Aerodrome",
            "Unst Airport",
            "Upavon",
            "Warton Aerodrome",
            "Wattisham Airfield",
            "Wellesbourne Mountford Aerodrome",
            "Welshpool Airport",
            "West Freugh",
            "Westray Airport",
            "Whalsay Airstrip",
            "White Waltham Airfield",
            "Wick Airport",
            "Wickenby Aerodrome",
            "Wolverhampton Airport",
            "Wycombe Air Park",
            "Yeovil Aerodrome"});
            this.cmbobx_airport_info.Location = new System.Drawing.Point(620, 12);
            this.cmbobx_airport_info.Name = "cmbobx_airport_info";
            this.cmbobx_airport_info.Size = new System.Drawing.Size(318, 28);
            this.cmbobx_airport_info.Sorted = true;
            this.cmbobx_airport_info.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(202, 26);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 631);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbobx_airport_info);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.rchtxtbx_output);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.btn_exit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Compass Factory";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.RichTextBox rchtxtbx_output;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbobx_airport_info;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

