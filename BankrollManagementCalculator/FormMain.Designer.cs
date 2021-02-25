namespace BankrollManagementCalculator
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llWelcome = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAvailableGames = new System.Windows.Forms.DataGridView();
            this.clmStake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRakeIncluded = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmROI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmComplexGame = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.ckNoPlay = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckExpenses = new System.Windows.Forms.CheckBox();
            this.gbExpenses = new System.Windows.Forms.GroupBox();
            this.cbPayPeriod = new System.Windows.Forms.ComboBox();
            this.txtPayFreq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpenses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtNoGames = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPlayPeriod = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCompute = new System.Windows.Forms.Button();
            this.cbObjectiveKind = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbSimPeriodType = new System.Windows.Forms.ComboBox();
            this.txtSimPeriod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObjective = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblComputationTime = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbElapsedKind = new System.Windows.Forms.ComboBox();
            this.txtPeriodsElapsed = new System.Windows.Forms.TextBox();
            this.lblNextGame = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblFailureProb = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSuccessProb = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStartingBankroll = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuMainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGames)).BeginInit();
            this.gbExpenses.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMainMenu
            // 
            this.menuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuMainMenu.Name = "menuMainMenu";
            this.menuMainMenu.Size = new System.Drawing.Size(1054, 24);
            this.menuMainMenu.TabIndex = 0;
            this.menuMainMenu.Text = "menuMainMenu";
            this.menuMainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuMainMenu_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "&Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "&Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // llWelcome
            // 
            this.llWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.llWelcome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llWelcome.Location = new System.Drawing.Point(0, 24);
            this.llWelcome.Name = "llWelcome";
            this.llWelcome.Size = new System.Drawing.Size(1054, 63);
            this.llWelcome.TabIndex = 1;
            this.llWelcome.TabStop = true;
            this.llWelcome.Text = resources.GetString("llWelcome.Text");
            this.llWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llWelcome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llWelcome_LinkClicked_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAvailableGames);
            this.panel1.Location = new System.Drawing.Point(13, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 206);
            this.panel1.TabIndex = 2;
            // 
            // dgvAvailableGames
            // 
            this.dgvAvailableGames.AllowUserToOrderColumns = true;
            this.dgvAvailableGames.AllowUserToResizeRows = false;
            this.dgvAvailableGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStake,
            this.clmRake,
            this.clmRakeIncluded,
            this.clmROI,
            this.clmProbability,
            this.clmGameType,
            this.clmComplexGame});
            this.dgvAvailableGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailableGames.Location = new System.Drawing.Point(0, 0);
            this.dgvAvailableGames.Name = "dgvAvailableGames";
            this.dgvAvailableGames.Size = new System.Drawing.Size(655, 206);
            this.dgvAvailableGames.TabIndex = 0;
            this.dgvAvailableGames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableGames_CellContentClick);
            this.dgvAvailableGames.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableGames_CellLeave);
            this.dgvAvailableGames.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableGames_CellValidated);
            this.dgvAvailableGames.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAvailableGames_CellValidating);
            this.dgvAvailableGames.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvAvailableGames_NewRowNeeded);
            this.dgvAvailableGames.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvAvailableGames_NewRowNeeded);
            this.dgvAvailableGames.RowDirtyStateNeeded += new System.Windows.Forms.QuestionEventHandler(this.dgvAvailableGames_RowDirtyStateNeeded);
            this.dgvAvailableGames.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableGames_RowValidated);
            this.dgvAvailableGames.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAvailableGames_RowValidating);
            this.dgvAvailableGames.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvAvailableGames_NewRowNeeded);
            // 
            // clmStake
            // 
            this.clmStake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmStake.Frozen = true;
            this.clmStake.HeaderText = "Stake";
            this.clmStake.MaxInputLength = 10;
            this.clmStake.Name = "clmStake";
            this.clmStake.Width = 60;
            // 
            // clmRake
            // 
            this.clmRake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRake.Frozen = true;
            this.clmRake.HeaderText = "Rake";
            this.clmRake.MaxInputLength = 10;
            this.clmRake.Name = "clmRake";
            this.clmRake.Width = 58;
            // 
            // clmRakeIncluded
            // 
            this.clmRakeIncluded.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRakeIncluded.FalseValue = "false";
            this.clmRakeIncluded.Frozen = true;
            this.clmRakeIncluded.HeaderText = "Rake Included";
            this.clmRakeIncluded.Name = "clmRakeIncluded";
            this.clmRakeIncluded.TrueValue = "true";
            this.clmRakeIncluded.Width = 75;
            // 
            // clmROI
            // 
            this.clmROI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmROI.Frozen = true;
            this.clmROI.HeaderText = "ROI";
            this.clmROI.MaxInputLength = 7;
            this.clmROI.Name = "clmROI";
            this.clmROI.Width = 51;
            // 
            // clmProbability
            // 
            this.clmProbability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmProbability.Frozen = true;
            this.clmProbability.HeaderText = "Probability Win";
            this.clmProbability.MaxInputLength = 7;
            this.clmProbability.Name = "clmProbability";
            this.clmProbability.Width = 94;
            // 
            // clmGameType
            // 
            this.clmGameType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmGameType.Frozen = true;
            this.clmGameType.HeaderText = "Game Type";
            this.clmGameType.Name = "clmGameType";
            this.clmGameType.ReadOnly = true;
            this.clmGameType.Width = 80;
            // 
            // clmComplexGame
            // 
            this.clmComplexGame.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmComplexGame.FalseValue = "false";
            this.clmComplexGame.Frozen = true;
            this.clmComplexGame.HeaderText = "Complex Game";
            this.clmComplexGame.Name = "clmComplexGame";
            this.clmComplexGame.ReadOnly = true;
            this.clmComplexGame.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmComplexGame.TrueValue = "true";
            this.clmComplexGame.Width = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Available Games";
            // 
            // ckNoPlay
            // 
            this.ckNoPlay.AutoSize = true;
            this.ckNoPlay.Location = new System.Drawing.Point(474, 340);
            this.ckNoPlay.Name = "ckNoPlay";
            this.ckNoPlay.Size = new System.Drawing.Size(194, 17);
            this.ckNoPlay.TabIndex = 4;
            this.ckNoPlay.Text = "I can also not play at 0 cost, 0 profit";
            this.ckNoPlay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prices in full monetary units. ROI and Probability in %.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(683, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Expenses";
            // 
            // ckExpenses
            // 
            this.ckExpenses.AutoSize = true;
            this.ckExpenses.Location = new System.Drawing.Point(686, 130);
            this.ckExpenses.Name = "ckExpenses";
            this.ckExpenses.Size = new System.Drawing.Size(260, 17);
            this.ckExpenses.TabIndex = 7;
            this.ckExpenses.Text = "I have mandatory expenses paid from the bankroll";
            this.ckExpenses.UseVisualStyleBackColor = true;
            this.ckExpenses.CheckedChanged += new System.EventHandler(this.ckExpenses_CheckedChanged);
            // 
            // gbExpenses
            // 
            this.gbExpenses.Controls.Add(this.cbPayPeriod);
            this.gbExpenses.Controls.Add(this.txtPayFreq);
            this.gbExpenses.Controls.Add(this.label5);
            this.gbExpenses.Controls.Add(this.txtExpenses);
            this.gbExpenses.Controls.Add(this.label4);
            this.gbExpenses.Location = new System.Drawing.Point(686, 153);
            this.gbExpenses.Name = "gbExpenses";
            this.gbExpenses.Size = new System.Drawing.Size(258, 90);
            this.gbExpenses.TabIndex = 8;
            this.gbExpenses.TabStop = false;
            this.gbExpenses.Text = "Expenses";
            // 
            // cbPayPeriod
            // 
            this.cbPayPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPayPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPayPeriod.FormattingEnabled = true;
            this.cbPayPeriod.Items.AddRange(new object[] {
            "Games",
            "Days",
            "Weeks",
            "Months",
            "Years"});
            this.cbPayPeriod.Location = new System.Drawing.Point(109, 54);
            this.cbPayPeriod.Name = "cbPayPeriod";
            this.cbPayPeriod.Size = new System.Drawing.Size(121, 21);
            this.cbPayPeriod.TabIndex = 10;
            // 
            // txtPayFreq
            // 
            this.txtPayFreq.Location = new System.Drawing.Point(49, 56);
            this.txtPayFreq.Name = "txtPayFreq";
            this.txtPayFreq.Size = new System.Drawing.Size(53, 20);
            this.txtPayFreq.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Every:";
            // 
            // txtExpenses
            // 
            this.txtExpenses.Location = new System.Drawing.Point(82, 25);
            this.txtExpenses.Name = "txtExpenses";
            this.txtExpenses.Size = new System.Drawing.Size(91, 20);
            this.txtExpenses.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount paid:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(685, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Basic Player Profile";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(13, 340);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add Complex Game...";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(145, 340);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(126, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit Complex Game...";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // txtNoGames
            // 
            this.txtNoGames.Location = new System.Drawing.Point(879, 283);
            this.txtNoGames.Name = "txtNoGames";
            this.txtNoGames.Size = new System.Drawing.Size(54, 20);
            this.txtNoGames.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(690, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Maximum number of games playable: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(690, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "every single";
            // 
            // cbPlayPeriod
            // 
            this.cbPlayPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPlayPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPlayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayPeriod.FormattingEnabled = true;
            this.cbPlayPeriod.Items.AddRange(new object[] {
            "Game",
            "Day",
            "Week",
            "Month",
            "Year"});
            this.cbPlayPeriod.Location = new System.Drawing.Point(759, 306);
            this.cbPlayPeriod.Name = "cbPlayPeriod";
            this.cbPlayPeriod.Size = new System.Drawing.Size(121, 21);
            this.cbPlayPeriod.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCompute);
            this.groupBox1.Controls.Add(this.cbObjectiveKind);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbSimPeriodType);
            this.groupBox1.Controls.Add(this.txtSimPeriod);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtObjective);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(13, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 185);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation";
            // 
            // btnCompute
            // 
            this.btnCompute.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompute.Location = new System.Drawing.Point(6, 116);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(316, 69);
            this.btnCompute.TabIndex = 13;
            this.btnCompute.Text = "Compute... (this might take a while)";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // cbObjectiveKind
            // 
            this.cbObjectiveKind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbObjectiveKind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObjectiveKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObjectiveKind.FormattingEnabled = true;
            this.cbObjectiveKind.Items.AddRange(new object[] {
            "Lorenestian",
            "Vecinian"});
            this.cbObjectiveKind.Location = new System.Drawing.Point(104, 88);
            this.cbObjectiveKind.Name = "cbObjectiveKind";
            this.cbObjectiveKind.Size = new System.Drawing.Size(154, 21);
            this.cbObjectiveKind.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Type of objective:";
            // 
            // cbSimPeriodType
            // 
            this.cbSimPeriodType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSimPeriodType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSimPeriodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSimPeriodType.FormattingEnabled = true;
            this.cbSimPeriodType.Items.AddRange(new object[] {
            "Games",
            "Days",
            "Weeks",
            "Months",
            "Years"});
            this.cbSimPeriodType.Location = new System.Drawing.Point(137, 55);
            this.cbSimPeriodType.Name = "cbSimPeriodType";
            this.cbSimPeriodType.Size = new System.Drawing.Size(121, 21);
            this.cbSimPeriodType.TabIndex = 10;
            // 
            // txtSimPeriod
            // 
            this.txtSimPeriod.Location = new System.Drawing.Point(93, 56);
            this.txtSimPeriod.Name = "txtSimPeriod";
            this.txtSimPeriod.Size = new System.Drawing.Size(38, 20);
            this.txtSimPeriod.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Simulation period:";
            // 
            // txtObjective
            // 
            this.txtObjective.Location = new System.Drawing.Point(163, 22);
            this.txtObjective.Name = "txtObjective";
            this.txtObjective.Size = new System.Drawing.Size(91, 20);
            this.txtObjective.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Objective bankroll after period:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BankrollManagementCalculator.Properties.Resources._671px_Two_red_dice_01_svg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(347, 392);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 185);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblComputationTime);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbElapsedKind);
            this.groupBox2.Controls.Add(this.txtPeriodsElapsed);
            this.groupBox2.Controls.Add(this.lblNextGame);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblFailureProb);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblSuccessProb);
            this.groupBox2.Controls.Add(this.btnGo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtStartingBankroll);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(634, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 197);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // lblComputationTime
            // 
            this.lblComputationTime.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputationTime.Location = new System.Drawing.Point(244, 131);
            this.lblComputationTime.Name = "lblComputationTime";
            this.lblComputationTime.Size = new System.Drawing.Size(158, 66);
            this.lblComputationTime.TabIndex = 20;
            this.lblComputationTime.Text = "------------";
            this.lblComputationTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(246, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Last computation took:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(174, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "elapsed.";
            // 
            // cbElapsedKind
            // 
            this.cbElapsedKind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbElapsedKind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbElapsedKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElapsedKind.FormattingEnabled = true;
            this.cbElapsedKind.Items.AddRange(new object[] {
            "Games",
            "Days",
            "Weeks",
            "Months",
            "Years"});
            this.cbElapsedKind.Location = new System.Drawing.Point(85, 48);
            this.cbElapsedKind.Name = "cbElapsedKind";
            this.cbElapsedKind.Size = new System.Drawing.Size(83, 21);
            this.cbElapsedKind.TabIndex = 17;
            // 
            // txtPeriodsElapsed
            // 
            this.txtPeriodsElapsed.Location = new System.Drawing.Point(9, 51);
            this.txtPeriodsElapsed.Name = "txtPeriodsElapsed";
            this.txtPeriodsElapsed.Size = new System.Drawing.Size(70, 20);
            this.txtPeriodsElapsed.TabIndex = 16;
            // 
            // lblNextGame
            // 
            this.lblNextGame.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextGame.Location = new System.Drawing.Point(244, 38);
            this.lblNextGame.Name = "lblNextGame";
            this.lblNextGame.Size = new System.Drawing.Size(158, 66);
            this.lblNextGame.TabIndex = 14;
            this.lblNextGame.Text = "------------";
            this.lblNextGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNextGame.Click += new System.EventHandler(this.lblNextGame_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(246, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Your next game should be:";
            // 
            // lblFailureProb
            // 
            this.lblFailureProb.AutoSize = true;
            this.lblFailureProb.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailureProb.ForeColor = System.Drawing.Color.Red;
            this.lblFailureProb.Location = new System.Drawing.Point(121, 147);
            this.lblFailureProb.Name = "lblFailureProb";
            this.lblFailureProb.Size = new System.Drawing.Size(125, 29);
            this.lblFailureProb.TabIndex = 12;
            this.lblFailureProb.Text = "100.00%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Probability of failure: ";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // lblSuccessProb
            // 
            this.lblSuccessProb.AutoSize = true;
            this.lblSuccessProb.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessProb.ForeColor = System.Drawing.Color.Green;
            this.lblSuccessProb.Location = new System.Drawing.Point(120, 94);
            this.lblSuccessProb.Name = "lblSuccessProb";
            this.lblSuccessProb.Size = new System.Drawing.Size(57, 29);
            this.lblSuccessProb.TabIndex = 10;
            this.lblSuccessProb.Text = "0%";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(174, 20);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(42, 23);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Probability of success: ";
            // 
            // txtStartingBankroll
            // 
            this.txtStartingBankroll.Location = new System.Drawing.Point(98, 22);
            this.txtStartingBankroll.Name = "txtStartingBankroll";
            this.txtStartingBankroll.Size = new System.Drawing.Size(70, 20);
            this.txtStartingBankroll.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Starting bankroll:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 601);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbPlayPeriod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNoGames);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gbExpenses);
            this.Controls.Add(this.ckExpenses);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckNoPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.llWelcome);
            this.Controls.Add(this.menuMainMenu);
            this.MainMenuStrip = this.menuMainMenu;
            this.Name = "FormMain";
            this.Text = "Poker Bankroll Management Calculator - by Mircea Digulescu";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuMainMenu.ResumeLayout(false);
            this.menuMainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableGames)).EndInit();
            this.gbExpenses.ResumeLayout(false);
            this.gbExpenses.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.LinkLabel llWelcome;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAvailableGames;
        private System.Windows.Forms.CheckBox ckNoPlay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckExpenses;
        private System.Windows.Forms.GroupBox gbExpenses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExpenses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPayFreq;
        private System.Windows.Forms.ComboBox cbPayPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtNoGames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbPlayPeriod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSimPeriodType;
        private System.Windows.Forms.TextBox txtSimPeriod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObjective;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbObjectiveKind;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStartingBankroll;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFailureProb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSuccessProb;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNextGame;
        private System.Windows.Forms.TextBox txtPeriodsElapsed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbElapsedKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStake;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRake;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmRakeIncluded;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmROI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGameType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmComplexGame;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblComputationTime;
        private System.Windows.Forms.Label label15;
    }
}

