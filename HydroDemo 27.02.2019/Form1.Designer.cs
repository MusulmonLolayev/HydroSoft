using System.Windows.Forms;
namespace HydroDemo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnmainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnmainItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnmainItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnalysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAccountItemEDK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAccoutItemIZV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAccountItemXTS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAccountItemPDK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemHisobotPDKDolyax = new System.Windows.Forms.ToolStripMenuItem();
            this.пДКпоБассейнамРекВДоляхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemHisobotPDKBasyn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatisticItemCommon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnStatisticItemKorrelyatsion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHandbook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHandbookItemKompanenta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHandbookItemPost = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHandbookItemRiver = new System.Windows.Forms.ToolStripMenuItem();
            this.mnServis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnServesItemCopyDb = new System.Windows.Forms.ToolStripMenuItem();
            this.mnServisItemRestory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnServisItemRiver = new System.Windows.Forms.ToolStripMenuItem();
            this.mnServisItemPost = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuServesChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelpRefrences = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.chbKompanenta = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnKomponent = new System.Windows.Forms.Button();
            this.chbPost = new System.Windows.Forms.CheckBox();
            this.cbPost = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRiverList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvAnalysis = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRaqam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRiver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVaqt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPost_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSigm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOqimTezligi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDaryoSarfi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOqimSarfi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNamlik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTiniqlik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRangi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHarorat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSuzuvchi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmpH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTuyingan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQattiqlik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmXlorid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSulfat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGidroKarbanat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMineral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmXPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAzotAmonniy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAzotNitritniy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAzotNitratniy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAzotSumma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFosfat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmElektr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEh_MB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPumumiy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFeUmumiy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmZn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCr_VI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCr_III = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFenollar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSPAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSianidi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProponil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRogor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGeksaxloran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLindan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMetafos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmButifos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDalapon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKarbofos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчётПоКомпанентамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnmainFile,
            this.mnAnalysis,
            this.mnAccount,
            this.mnStatistic,
            this.mnHandbook,
            this.mnServis,
            this.mnHelp});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1181, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnmainFile
            // 
            this.mnmainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnmainItemImport,
            this.mnmainItemExport,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.mnmainFile.Name = "mnmainFile";
            this.mnmainFile.Size = new System.Drawing.Size(58, 23);
            this.mnmainFile.Text = "&Файл";
            // 
            // mnmainItemImport
            // 
            this.mnmainItemImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnmainItemImport.Name = "mnmainItemImport";
            this.mnmainItemImport.Size = new System.Drawing.Size(183, 24);
            this.mnmainItemImport.Text = "&Импорт с Excel";
            this.mnmainItemImport.Click += new System.EventHandler(this.mnmainItemImport_Click);
            // 
            // mnmainItemExport
            // 
            this.mnmainItemExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnmainItemExport.Name = "mnmainItemExport";
            this.mnmainItemExport.Size = new System.Drawing.Size(183, 24);
            this.mnmainItemExport.Text = "Экспорт к Excel";
            this.mnmainItemExport.Click += new System.EventHandler(this.mnmainItemExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.exitToolStripMenuItem.Text = "&Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mnAnalysis
            // 
            this.mnAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAnalysisItem});
            this.mnAnalysis.Name = "mnAnalysis";
            this.mnAnalysis.Size = new System.Drawing.Size(71, 23);
            this.mnAnalysis.Text = "&Анализ";
            this.mnAnalysis.Visible = false;
            // 
            // mnuAnalysisItem
            // 
            this.mnuAnalysisItem.Name = "mnuAnalysisItem";
            this.mnuAnalysisItem.Size = new System.Drawing.Size(128, 24);
            this.mnuAnalysisItem.Text = "&Анализ";
            this.mnuAnalysisItem.Click += new System.EventHandler(this.mnuAnalysisItem_Click);
            // 
            // mnAccount
            // 
            this.mnAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAccountItemEDK,
            this.mnAccoutItemIZV,
            this.mnAccountItemXTS,
            this.mnAccountItemPDK,
            this.mnItemHisobotPDKDolyax,
            this.пДКпоБассейнамРекВДоляхToolStripMenuItem,
            this.mnItemHisobotPDKBasyn,
            this.отчётПоКомпанентамиToolStripMenuItem});
            this.mnAccount.Name = "mnAccount";
            this.mnAccount.Size = new System.Drawing.Size(73, 23);
            this.mnAccount.Text = "&Отчеты";
            // 
            // mnAccountItemEDK
            // 
            this.mnAccountItemEDK.Name = "mnAccountItemEDK";
            this.mnAccountItemEDK.Size = new System.Drawing.Size(293, 24);
            this.mnAccountItemEDK.Text = "&ЕДК";
            this.mnAccountItemEDK.Click += new System.EventHandler(this.mnAccountItemEDK_Click);
            // 
            // mnAccoutItemIZV
            // 
            this.mnAccoutItemIZV.Name = "mnAccoutItemIZV";
            this.mnAccoutItemIZV.Size = new System.Drawing.Size(293, 24);
            this.mnAccoutItemIZV.Text = "&ИЗВ";
            this.mnAccoutItemIZV.Click += new System.EventHandler(this.mnAccoutItemIZV_Click);
            // 
            // mnAccountItemXTS
            // 
            this.mnAccountItemXTS.Name = "mnAccountItemXTS";
            this.mnAccountItemXTS.Size = new System.Drawing.Size(293, 24);
            this.mnAccountItemXTS.Text = "Химический состав воды";
            this.mnAccountItemXTS.Visible = false;
            // 
            // mnAccountItemPDK
            // 
            this.mnAccountItemPDK.Name = "mnAccountItemPDK";
            this.mnAccountItemPDK.Size = new System.Drawing.Size(293, 24);
            this.mnAccountItemPDK.Text = "ПДК";
            this.mnAccountItemPDK.Click += new System.EventHandler(this.mnAccountItemPDK_Click);
            // 
            // mnItemHisobotPDKDolyax
            // 
            this.mnItemHisobotPDKDolyax.Name = "mnItemHisobotPDKDolyax";
            this.mnItemHisobotPDKDolyax.Size = new System.Drawing.Size(293, 24);
            this.mnItemHisobotPDKDolyax.Text = "ПДК (в долях)";
            this.mnItemHisobotPDKDolyax.Click += new System.EventHandler(this.mnItemHisobotPDKDolyax_Click);
            // 
            // пДКпоБассейнамРекВДоляхToolStripMenuItem
            // 
            this.пДКпоБассейнамРекВДоляхToolStripMenuItem.Name = "пДКпоБассейнамРекВДоляхToolStripMenuItem";
            this.пДКпоБассейнамРекВДоляхToolStripMenuItem.Size = new System.Drawing.Size(293, 24);
            this.пДКпоБассейнамРекВДоляхToolStripMenuItem.Text = "ПДК(по бассейнам рек)";
            this.пДКпоБассейнамРекВДоляхToolStripMenuItem.Click += new System.EventHandler(this.пДКпоБассейнамРекВДоляхToolStripMenuItem_Click);
            // 
            // mnItemHisobotPDKBasyn
            // 
            this.mnItemHisobotPDKBasyn.Name = "mnItemHisobotPDKBasyn";
            this.mnItemHisobotPDKBasyn.Size = new System.Drawing.Size(293, 24);
            this.mnItemHisobotPDKBasyn.Text = "ПДК(по бассейнам рек в долях)";
            this.mnItemHisobotPDKBasyn.Click += new System.EventHandler(this.mnItemHisobotPDKBasyn_Click);
            // 
            // mnStatistic
            // 
            this.mnStatistic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnStatisticItemCommon,
            this.mnStatisticItemKorrelyatsion});
            this.mnStatistic.Name = "mnStatistic";
            this.mnStatistic.Size = new System.Drawing.Size(99, 23);
            this.mnStatistic.Text = "&Статистика";
            // 
            // mnStatisticItemCommon
            // 
            this.mnStatisticItemCommon.Name = "mnStatisticItemCommon";
            this.mnStatisticItemCommon.Size = new System.Drawing.Size(198, 24);
            this.mnStatisticItemCommon.Text = "&Общий";
            this.mnStatisticItemCommon.Click += new System.EventHandler(this.mnStatisticItemCommon_Click);
            // 
            // mnStatisticItemKorrelyatsion
            // 
            this.mnStatisticItemKorrelyatsion.Name = "mnStatisticItemKorrelyatsion";
            this.mnStatisticItemKorrelyatsion.Size = new System.Drawing.Size(198, 24);
            this.mnStatisticItemKorrelyatsion.Text = "&Корреляционный";
            this.mnStatisticItemKorrelyatsion.Click += new System.EventHandler(this.mnStatisticItemKorrelyatsion_Click);
            // 
            // mnHandbook
            // 
            this.mnHandbook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHandbookItemKompanenta,
            this.mnHandbookItemPost,
            this.mnHandbookItemRiver});
            this.mnHandbook.Name = "mnHandbook";
            this.mnHandbook.Size = new System.Drawing.Size(114, 23);
            this.mnHandbook.Text = "С&правочники";
            // 
            // mnHandbookItemKompanenta
            // 
            this.mnHandbookItemKompanenta.Name = "mnHandbookItemKompanenta";
            this.mnHandbookItemKompanenta.Size = new System.Drawing.Size(320, 24);
            this.mnHandbookItemKompanenta.Text = "Справочник загрязняющих веществ";
            this.mnHandbookItemKompanenta.Click += new System.EventHandler(this.mnHandbookItemKompanenta_Click);
            // 
            // mnHandbookItemPost
            // 
            this.mnHandbookItemPost.Name = "mnHandbookItemPost";
            this.mnHandbookItemPost.Size = new System.Drawing.Size(320, 24);
            this.mnHandbookItemPost.Text = "Справочник постов";
            this.mnHandbookItemPost.Click += new System.EventHandler(this.mnHandbookItemPost_Click);
            // 
            // mnHandbookItemRiver
            // 
            this.mnHandbookItemRiver.Name = "mnHandbookItemRiver";
            this.mnHandbookItemRiver.Size = new System.Drawing.Size(320, 24);
            this.mnHandbookItemRiver.Text = "Справочник водных объектов";
            this.mnHandbookItemRiver.Click += new System.EventHandler(this.mnHandbookItemRiver_Click);
            // 
            // mnServis
            // 
            this.mnServis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnServesItemCopyDb,
            this.mnServisItemRestory,
            this.mnServisItemRiver,
            this.mnServisItemPost,
            this.tmnuServesChangePassword});
            this.mnServis.Name = "mnServis";
            this.mnServis.Size = new System.Drawing.Size(71, 23);
            this.mnServis.Text = "С&ервис";
            this.mnServis.Visible = false;
            // 
            // mnServesItemCopyDb
            // 
            this.mnServesItemCopyDb.Name = "mnServesItemCopyDb";
            this.mnServesItemCopyDb.Size = new System.Drawing.Size(319, 24);
            this.mnServesItemCopyDb.Text = "Резервное копирование баз данных";
            this.mnServesItemCopyDb.Click += new System.EventHandler(this.mnServesItemCopyDb_Click);
            // 
            // mnServisItemRestory
            // 
            this.mnServisItemRestory.Name = "mnServisItemRestory";
            this.mnServisItemRestory.Size = new System.Drawing.Size(319, 24);
            this.mnServisItemRestory.Text = "Восстановление баз данных";
            this.mnServisItemRestory.Click += new System.EventHandler(this.mnServisItemRestory_Click);
            // 
            // mnServisItemRiver
            // 
            this.mnServisItemRiver.Name = "mnServisItemRiver";
            this.mnServisItemRiver.Size = new System.Drawing.Size(319, 24);
            this.mnServisItemRiver.Text = "Редактировать вод объекты";
            this.mnServisItemRiver.Click += new System.EventHandler(this.mnServisItemRiver_Click);
            // 
            // mnServisItemPost
            // 
            this.mnServisItemPost.Name = "mnServisItemPost";
            this.mnServisItemPost.Size = new System.Drawing.Size(319, 24);
            this.mnServisItemPost.Text = "Редактировать посты";
            this.mnServisItemPost.Click += new System.EventHandler(this.mnServisItemPost_Click);
            // 
            // tmnuServesChangePassword
            // 
            this.tmnuServesChangePassword.Name = "tmnuServesChangePassword";
            this.tmnuServesChangePassword.Size = new System.Drawing.Size(319, 24);
            this.tmnuServesChangePassword.Text = "Изменить пароль";
            this.tmnuServesChangePassword.Click += new System.EventHandler(this.tmnuServesChangePassword_Click);
            // 
            // mnHelp
            // 
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHelpRefrences});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(76, 23);
            this.mnHelp.Text = "По&мощь";
            // 
            // mnHelpRefrences
            // 
            this.mnHelpRefrences.Name = "mnHelpRefrences";
            this.mnHelpRefrences.Size = new System.Drawing.Size(159, 24);
            this.mnHelpRefrences.Text = "Инструкция";
            this.mnHelpRefrences.Click += new System.EventHandler(this.mnHelpRefrences_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.chbKompanenta);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.btnKomponent);
            this.gbSearch.Controls.Add(this.chbPost);
            this.gbSearch.Controls.Add(this.cbPost);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.cbRiverList);
            this.gbSearch.Controls.Add(this.label3);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.chbDate);
            this.gbSearch.Controls.Add(this.dtpTo);
            this.gbSearch.Controls.Add(this.dtpFrom);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(3, 30);
            this.gbSearch.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1181, 127);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск по опросы";
            // 
            // chbKompanenta
            // 
            this.chbKompanenta.AutoSize = true;
            this.chbKompanenta.Location = new System.Drawing.Point(679, 56);
            this.chbKompanenta.Name = "chbKompanenta";
            this.chbKompanenta.Size = new System.Drawing.Size(116, 23);
            this.chbKompanenta.TabIndex = 15;
            this.chbKompanenta.Text = "Компоненты";
            this.chbKompanenta.UseVisualStyleBackColor = true;
            this.chbKompanenta.CheckedChanged += new System.EventHandler(this.chbKompanenta_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1034, 84);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 30);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnKomponent
            // 
            this.btnKomponent.Location = new System.Drawing.Point(668, 21);
            this.btnKomponent.Name = "btnKomponent";
            this.btnKomponent.Size = new System.Drawing.Size(127, 30);
            this.btnKomponent.TabIndex = 13;
            this.btnKomponent.Text = "Компоненты";
            this.btnKomponent.UseVisualStyleBackColor = true;
            this.btnKomponent.Click += new System.EventHandler(this.btnKomponent_Click);
            // 
            // chbPost
            // 
            this.chbPost.AutoSize = true;
            this.chbPost.Location = new System.Drawing.Point(267, 92);
            this.chbPost.Name = "chbPost";
            this.chbPost.Size = new System.Drawing.Size(61, 23);
            this.chbPost.TabIndex = 12;
            this.chbPost.Text = "Пост";
            this.chbPost.UseVisualStyleBackColor = true;
            // 
            // cbPost
            // 
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(126, 63);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(201, 27);
            this.cbPost.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Пост";
            // 
            // cbRiverList
            // 
            this.cbRiverList.FormattingEnabled = true;
            this.cbRiverList.Location = new System.Drawing.Point(126, 25);
            this.cbRiverList.Name = "cbRiverList";
            this.cbRiverList.Size = new System.Drawing.Size(201, 27);
            this.cbRiverList.TabIndex = 9;
            this.cbRiverList.SelectedIndexChanged += new System.EventHandler(this.cbRiverList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Водный обьект";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "До";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "От";
            // 
            // chbDate
            // 
            this.chbDate.AutoSize = true;
            this.chbDate.Location = new System.Drawing.Point(567, 89);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(60, 23);
            this.chbDate.TabIndex = 5;
            this.chbDate.Text = "Дата";
            this.chbDate.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(427, 57);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 26);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(427, 25);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 26);
            this.dtpFrom.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(529, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Результат поиска";
            // 
            // dgvAnalysis
            // 
            this.dgvAnalysis.AllowUserToAddRows = false;
            this.dgvAnalysis.AllowUserToDeleteRows = false;
            this.dgvAnalysis.AllowUserToOrderColumns = true;
            this.dgvAnalysis.AllowUserToResizeColumns = false;
            this.dgvAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnalysis.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnalysis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmRaqam,
            this.clmRiver,
            this.clmPost,
            this.clmSana,
            this.clmVaqt,
            this.clmPost_Id,
            this.clmSigm,
            this.clmOqimTezligi,
            this.clmDaryoSarfi,
            this.clmOqimSarfi,
            this.clmNamlik,
            this.clmTiniqlik,
            this.clmRangi,
            this.clmHarorat,
            this.clmSuzuvchi,
            this.clmpH,
            this.clmO2,
            this.clmTuyingan,
            this.clmCO2,
            this.clmQattiqlik,
            this.clmXlorid,
            this.clmSulfat,
            this.clmGidroKarbanat,
            this.clmNa,
            this.clmK,
            this.clmCa,
            this.clmMg,
            this.clmMineral,
            this.clmXPK,
            this.clmBPK,
            this.clmAzotAmonniy,
            this.clmAzotNitritniy,
            this.clmAzotNitratniy,
            this.clmAzotSumma,
            this.clmFosfat,
            this.clmSi,
            this.clmElektr,
            this.clmEh_MB,
            this.clmPumumiy,
            this.clmFeUmumiy,
            this.clmCi,
            this.clmZn,
            this.clmNi,
            this.clmCr,
            this.clmCr_VI,
            this.clmCr_III,
            this.clmPb,
            this.clmHg,
            this.clmCd,
            this.clmMn,
            this.clmAs,
            this.clmFenollar,
            this.clmNeft,
            this.clmSPAB,
            this.clmF,
            this.clmSianidi,
            this.clmProponil,
            this.clmDDE,
            this.clmRogor,
            this.clmDDT,
            this.clmGeksaxloran,
            this.clmLindan,
            this.clmDDD,
            this.clmMetafos,
            this.clmButifos,
            this.clmDalapon,
            this.clmKarbofos,
            this.clmStatus});
            this.dgvAnalysis.Location = new System.Drawing.Point(3, 184);
            this.dgvAnalysis.Name = "dgvAnalysis";
            this.dgvAnalysis.RowHeadersVisible = false;
            this.dgvAnalysis.Size = new System.Drawing.Size(1181, 249);
            this.dgvAnalysis.TabIndex = 16;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.Visible = false;
            // 
            // clmRaqam
            // 
            this.clmRaqam.HeaderText = "№";
            this.clmRaqam.Name = "clmRaqam";
            this.clmRaqam.ReadOnly = true;
            this.clmRaqam.Width = 80;
            // 
            // clmRiver
            // 
            this.clmRiver.HeaderText = "Река";
            this.clmRiver.Name = "clmRiver";
            this.clmRiver.ReadOnly = true;
            this.clmRiver.Width = 150;
            // 
            // clmPost
            // 
            this.clmPost.HeaderText = "Пост";
            this.clmPost.Name = "clmPost";
            this.clmPost.ReadOnly = true;
            this.clmPost.Width = 150;
            // 
            // clmSana
            // 
            this.clmSana.HeaderText = "Дата";
            this.clmSana.Name = "clmSana";
            this.clmSana.ReadOnly = true;
            // 
            // clmVaqt
            // 
            this.clmVaqt.HeaderText = "Времья";
            this.clmVaqt.Name = "clmVaqt";
            this.clmVaqt.ReadOnly = true;
            // 
            // clmPost_Id
            // 
            this.clmPost_Id.HeaderText = "Post Id";
            this.clmPost_Id.Name = "clmPost_Id";
            this.clmPost_Id.ReadOnly = true;
            this.clmPost_Id.Visible = false;
            this.clmPost_Id.Width = 10;
            // 
            // clmSigm
            // 
            this.clmSigm.HeaderText = "К-во дней хранения(дни)";
            this.clmSigm.Name = "clmSigm";
            this.clmSigm.ReadOnly = true;
            this.clmSigm.Width = 120;
            // 
            // clmOqimTezligi
            // 
            this.clmOqimTezligi.HeaderText = "Скорость течения, м3/сек";
            this.clmOqimTezligi.Name = "clmOqimTezligi";
            this.clmOqimTezligi.ReadOnly = true;
            this.clmOqimTezligi.Width = 120;
            // 
            // clmDaryoSarfi
            // 
            this.clmDaryoSarfi.HeaderText = "Расход реки, м3/сек";
            this.clmDaryoSarfi.Name = "clmDaryoSarfi";
            this.clmDaryoSarfi.ReadOnly = true;
            // 
            // clmOqimSarfi
            // 
            this.clmOqimSarfi.HeaderText = "Расход сточных.вод, м3/сек";
            this.clmOqimSarfi.Name = "clmOqimSarfi";
            this.clmOqimSarfi.ReadOnly = true;
            this.clmOqimSarfi.Width = 120;
            // 
            // clmNamlik
            // 
            this.clmNamlik.HeaderText = "запах, балл";
            this.clmNamlik.Name = "clmNamlik";
            this.clmNamlik.ReadOnly = true;
            // 
            // clmTiniqlik
            // 
            this.clmTiniqlik.HeaderText = "Прозрачность, см";
            this.clmTiniqlik.Name = "clmTiniqlik";
            this.clmTiniqlik.ReadOnly = true;
            this.clmTiniqlik.Width = 120;
            // 
            // clmRangi
            // 
            this.clmRangi.HeaderText = "Цветность, град";
            this.clmRangi.Name = "clmRangi";
            this.clmRangi.ReadOnly = true;
            // 
            // clmHarorat
            // 
            this.clmHarorat.HeaderText = "Температура, оС";
            this.clmHarorat.Name = "clmHarorat";
            this.clmHarorat.ReadOnly = true;
            // 
            // clmSuzuvchi
            // 
            this.clmSuzuvchi.HeaderText = "Взвешенные вещества, мг/дм3";
            this.clmSuzuvchi.Name = "clmSuzuvchi";
            this.clmSuzuvchi.ReadOnly = true;
            this.clmSuzuvchi.Width = 120;
            // 
            // clmpH
            // 
            this.clmpH.HeaderText = "рН";
            this.clmpH.Name = "clmpH";
            this.clmpH.ReadOnly = true;
            // 
            // clmO2
            // 
            this.clmO2.HeaderText = "О2, мг/дм3";
            this.clmO2.Name = "clmO2";
            this.clmO2.ReadOnly = true;
            // 
            // clmTuyingan
            // 
            this.clmTuyingan.HeaderText = "Насыщение О2, мг/дм3";
            this.clmTuyingan.Name = "clmTuyingan";
            this.clmTuyingan.ReadOnly = true;
            // 
            // clmCO2
            // 
            this.clmCO2.HeaderText = "СО2, мг/дм3";
            this.clmCO2.Name = "clmCO2";
            this.clmCO2.ReadOnly = true;
            // 
            // clmQattiqlik
            // 
            this.clmQattiqlik.HeaderText = "Жесткость, мг-экв/дм3";
            this.clmQattiqlik.Name = "clmQattiqlik";
            this.clmQattiqlik.ReadOnly = true;
            // 
            // clmXlorid
            // 
            this.clmXlorid.HeaderText = "Хлориды, мг/дм3";
            this.clmXlorid.Name = "clmXlorid";
            this.clmXlorid.ReadOnly = true;
            // 
            // clmSulfat
            // 
            this.clmSulfat.HeaderText = "Сульфаты, мг/дм3";
            this.clmSulfat.Name = "clmSulfat";
            this.clmSulfat.ReadOnly = true;
            // 
            // clmGidroKarbanat
            // 
            this.clmGidroKarbanat.HeaderText = "Гидрокарбонаты, мг/дм3";
            this.clmGidroKarbanat.Name = "clmGidroKarbanat";
            this.clmGidroKarbanat.ReadOnly = true;
            this.clmGidroKarbanat.Width = 130;
            // 
            // clmNa
            // 
            this.clmNa.HeaderText = "Na, мг/дм3";
            this.clmNa.Name = "clmNa";
            this.clmNa.ReadOnly = true;
            // 
            // clmK
            // 
            this.clmK.HeaderText = "K, мг/дм3";
            this.clmK.Name = "clmK";
            this.clmK.ReadOnly = true;
            // 
            // clmCa
            // 
            this.clmCa.HeaderText = "Ca, мг/дм3";
            this.clmCa.Name = "clmCa";
            this.clmCa.ReadOnly = true;
            // 
            // clmMg
            // 
            this.clmMg.HeaderText = "Mg, мг/дм3";
            this.clmMg.Name = "clmMg";
            this.clmMg.ReadOnly = true;
            // 
            // clmMineral
            // 
            this.clmMineral.HeaderText = "Минерализация, мг/дм3";
            this.clmMineral.Name = "clmMineral";
            this.clmMineral.ReadOnly = true;
            this.clmMineral.Width = 120;
            // 
            // clmXPK
            // 
            this.clmXPK.HeaderText = "ХПК, мг/дм3";
            this.clmXPK.Name = "clmXPK";
            this.clmXPK.ReadOnly = true;
            // 
            // clmBPK
            // 
            this.clmBPK.HeaderText = "БПК5, мг/дм3";
            this.clmBPK.Name = "clmBPK";
            this.clmBPK.ReadOnly = true;
            // 
            // clmAzotAmonniy
            // 
            this.clmAzotAmonniy.HeaderText = "Азот аммонний, мг/дм3";
            this.clmAzotAmonniy.Name = "clmAzotAmonniy";
            this.clmAzotAmonniy.ReadOnly = true;
            this.clmAzotAmonniy.Width = 120;
            // 
            // clmAzotNitritniy
            // 
            this.clmAzotNitritniy.HeaderText = "Азот нитритный, мг/дм3";
            this.clmAzotNitritniy.Name = "clmAzotNitritniy";
            this.clmAzotNitritniy.ReadOnly = true;
            this.clmAzotNitritniy.Width = 120;
            // 
            // clmAzotNitratniy
            // 
            this.clmAzotNitratniy.HeaderText = "Азот нитратный, мг/дм3";
            this.clmAzotNitratniy.Name = "clmAzotNitratniy";
            this.clmAzotNitratniy.ReadOnly = true;
            // 
            // clmAzotSumma
            // 
            this.clmAzotSumma.HeaderText = "Сумма азота, мг/дм3";
            this.clmAzotSumma.Name = "clmAzotSumma";
            this.clmAzotSumma.ReadOnly = true;
            // 
            // clmFosfat
            // 
            this.clmFosfat.HeaderText = "Фосфат, мг/дм3";
            this.clmFosfat.Name = "clmFosfat";
            this.clmFosfat.ReadOnly = true;
            // 
            // clmSi
            // 
            this.clmSi.HeaderText = "Si, мг/дм3";
            this.clmSi.Name = "clmSi";
            this.clmSi.ReadOnly = true;
            // 
            // clmElektr
            // 
            this.clmElektr.HeaderText = "Электропроводность, мкСм/см";
            this.clmElektr.Name = "clmElektr";
            this.clmElektr.ReadOnly = true;
            this.clmElektr.Width = 160;
            // 
            // clmEh_MB
            // 
            this.clmEh_MB.HeaderText = "Eh, MB";
            this.clmEh_MB.Name = "clmEh_MB";
            this.clmEh_MB.ReadOnly = true;
            // 
            // clmPumumiy
            // 
            this.clmPumumiy.HeaderText = "P общий, мг/дм3";
            this.clmPumumiy.Name = "clmPumumiy";
            this.clmPumumiy.ReadOnly = true;
            // 
            // clmFeUmumiy
            // 
            this.clmFeUmumiy.HeaderText = "Fe общий, мг/дм3";
            this.clmFeUmumiy.Name = "clmFeUmumiy";
            this.clmFeUmumiy.ReadOnly = true;
            // 
            // clmCi
            // 
            this.clmCi.HeaderText = "Сu, мкг/дм3";
            this.clmCi.Name = "clmCi";
            this.clmCi.ReadOnly = true;
            // 
            // clmZn
            // 
            this.clmZn.HeaderText = "Zn, мкг/дм3";
            this.clmZn.Name = "clmZn";
            this.clmZn.ReadOnly = true;
            // 
            // clmNi
            // 
            this.clmNi.HeaderText = "Ni, мкг/дм3";
            this.clmNi.Name = "clmNi";
            this.clmNi.ReadOnly = true;
            // 
            // clmCr
            // 
            this.clmCr.HeaderText = "Cr, мкг/дм3";
            this.clmCr.Name = "clmCr";
            this.clmCr.ReadOnly = true;
            // 
            // clmCr_VI
            // 
            this.clmCr_VI.HeaderText = "Cr-VI, мкг/дм3";
            this.clmCr_VI.Name = "clmCr_VI";
            this.clmCr_VI.ReadOnly = true;
            // 
            // clmCr_III
            // 
            this.clmCr_III.HeaderText = "Cr-III, мкг/дм3";
            this.clmCr_III.Name = "clmCr_III";
            this.clmCr_III.ReadOnly = true;
            // 
            // clmPb
            // 
            this.clmPb.HeaderText = "Pb, мкг/дм3";
            this.clmPb.Name = "clmPb";
            this.clmPb.ReadOnly = true;
            // 
            // clmHg
            // 
            this.clmHg.HeaderText = "Hg, мкг/дм3";
            this.clmHg.Name = "clmHg";
            this.clmHg.ReadOnly = true;
            // 
            // clmCd
            // 
            this.clmCd.HeaderText = "Cd, мкг/дм3";
            this.clmCd.Name = "clmCd";
            this.clmCd.ReadOnly = true;
            // 
            // clmMn
            // 
            this.clmMn.HeaderText = "Mn, мкг/дм3";
            this.clmMn.Name = "clmMn";
            this.clmMn.ReadOnly = true;
            // 
            // clmAs
            // 
            this.clmAs.HeaderText = "As, мкг/дм3";
            this.clmAs.Name = "clmAs";
            this.clmAs.ReadOnly = true;
            // 
            // clmFenollar
            // 
            this.clmFenollar.HeaderText = "Фенолы, мг/дм3";
            this.clmFenollar.Name = "clmFenollar";
            this.clmFenollar.ReadOnly = true;
            // 
            // clmNeft
            // 
            this.clmNeft.HeaderText = "Нефтепродукты, мг/дм3";
            this.clmNeft.Name = "clmNeft";
            this.clmNeft.ReadOnly = true;
            this.clmNeft.Width = 120;
            // 
            // clmSPAB
            // 
            this.clmSPAB.HeaderText = "СПАВ, мг/дм3";
            this.clmSPAB.Name = "clmSPAB";
            this.clmSPAB.ReadOnly = true;
            // 
            // clmF
            // 
            this.clmF.HeaderText = "F, мг/дм3";
            this.clmF.Name = "clmF";
            this.clmF.ReadOnly = true;
            // 
            // clmSianidi
            // 
            this.clmSianidi.HeaderText = "Цианиды, мг/дм3";
            this.clmSianidi.Name = "clmSianidi";
            this.clmSianidi.ReadOnly = true;
            // 
            // clmProponil
            // 
            this.clmProponil.HeaderText = "Пропонил, мг/дм3";
            this.clmProponil.Name = "clmProponil";
            this.clmProponil.ReadOnly = true;
            // 
            // clmDDE
            // 
            this.clmDDE.HeaderText = "ДДЕ, мкг/дм3";
            this.clmDDE.Name = "clmDDE";
            this.clmDDE.ReadOnly = true;
            // 
            // clmRogor
            // 
            this.clmRogor.HeaderText = "Рогор, мкг/дм3";
            this.clmRogor.Name = "clmRogor";
            this.clmRogor.ReadOnly = true;
            // 
            // clmDDT
            // 
            this.clmDDT.HeaderText = "ДДТ, мкг/дм3";
            this.clmDDT.Name = "clmDDT";
            this.clmDDT.ReadOnly = true;
            // 
            // clmGeksaxloran
            // 
            this.clmGeksaxloran.HeaderText = "Гексахлоран (α-ГХЦГ), мкг/дм3";
            this.clmGeksaxloran.Name = "clmGeksaxloran";
            this.clmGeksaxloran.ReadOnly = true;
            this.clmGeksaxloran.Width = 120;
            // 
            // clmLindan
            // 
            this.clmLindan.HeaderText = "Линдан (γ-ГХЦГ), мкг/дм3";
            this.clmLindan.Name = "clmLindan";
            this.clmLindan.ReadOnly = true;
            this.clmLindan.Width = 120;
            // 
            // clmDDD
            // 
            this.clmDDD.HeaderText = "ДДД, мкг/дм3";
            this.clmDDD.Name = "clmDDD";
            this.clmDDD.ReadOnly = true;
            // 
            // clmMetafos
            // 
            this.clmMetafos.HeaderText = "Метафос, мкг/дм3";
            this.clmMetafos.Name = "clmMetafos";
            this.clmMetafos.ReadOnly = true;
            // 
            // clmButifos
            // 
            this.clmButifos.HeaderText = "Бутифос, мкг/дм3";
            this.clmButifos.Name = "clmButifos";
            this.clmButifos.ReadOnly = true;
            // 
            // clmDalapon
            // 
            this.clmDalapon.HeaderText = "Далапон, мкг/дм3";
            this.clmDalapon.Name = "clmDalapon";
            this.clmDalapon.ReadOnly = true;
            // 
            // clmKarbofos
            // 
            this.clmKarbofos.HeaderText = "Карбофос, мкг/дм3";
            this.clmKarbofos.Name = "clmKarbofos";
            this.clmKarbofos.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Visible = false;
            // 
            // отчётПоКомпанентамиToolStripMenuItem
            // 
            this.отчётПоКомпанентамиToolStripMenuItem.Name = "отчётПоКомпанентамиToolStripMenuItem";
            this.отчётПоКомпанентамиToolStripMenuItem.Size = new System.Drawing.Size(293, 24);
            this.отчётПоКомпанентамиToolStripMenuItem.Text = "Отчёт по компонентами ";
            this.отчётПоКомпанентамиToolStripMenuItem.Click += new System.EventHandler(this.отчётПоКомпанентамиToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1187, 439);
            this.Controls.Add(this.dgvAnalysis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Информационно-аналитическая система поверхностных вод";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnmainFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnAnalysis;
        private System.Windows.Forms.ToolStripMenuItem mnuAnalysisItem;
        private System.Windows.Forms.ToolStripMenuItem mnAccount;
        private System.Windows.Forms.ToolStripMenuItem mnAccountItemEDK;
        private System.Windows.Forms.ToolStripMenuItem mnAccoutItemIZV;
        private System.Windows.Forms.ToolStripMenuItem mnStatistic;
        private System.Windows.Forms.ToolStripMenuItem mnStatisticItemCommon;
        private System.Windows.Forms.ToolStripMenuItem mnStatisticItemKorrelyatsion;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnKomponent;
        private System.Windows.Forms.CheckBox chbPost;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRiverList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbDate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvAnalysis;
        private System.Windows.Forms.ToolStripMenuItem mnmainItemImport;
        private System.Windows.Forms.ToolStripMenuItem mnmainItemExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnAccountItemXTS;
        private System.Windows.Forms.ToolStripMenuItem mnAccountItemPDK;
        private System.Windows.Forms.ToolStripMenuItem mnHandbook;
        private System.Windows.Forms.ToolStripMenuItem mnHandbookItemKompanenta;
        private System.Windows.Forms.ToolStripMenuItem mnHandbookItemPost;
        private System.Windows.Forms.ToolStripMenuItem mnHandbookItemRiver;
        private System.Windows.Forms.ToolStripMenuItem mnServis;
        private System.Windows.Forms.ToolStripMenuItem mnServisItemRestory;
        private System.Windows.Forms.ToolStripMenuItem mnServisItemRiver;
        private System.Windows.Forms.ToolStripMenuItem mnServisItemPost;
        private System.Windows.Forms.ToolStripMenuItem mnHelp;
        private System.Windows.Forms.ToolStripMenuItem mnHelpRefrences;
        private System.Windows.Forms.CheckBox chbKompanenta;
        private DataGridViewTextBoxColumn clmId;
        private DataGridViewTextBoxColumn clmRaqam;
        private DataGridViewTextBoxColumn clmRiver;
        private DataGridViewTextBoxColumn clmPost;
        private DataGridViewTextBoxColumn clmSana;
        private DataGridViewTextBoxColumn clmVaqt;
        private DataGridViewTextBoxColumn clmPost_Id;
        private DataGridViewTextBoxColumn clmSigm;
        private DataGridViewTextBoxColumn clmOqimTezligi;
        private DataGridViewTextBoxColumn clmDaryoSarfi;
        private DataGridViewTextBoxColumn clmOqimSarfi;
        private DataGridViewTextBoxColumn clmNamlik;
        private DataGridViewTextBoxColumn clmTiniqlik;
        private DataGridViewTextBoxColumn clmRangi;
        private DataGridViewTextBoxColumn clmHarorat;
        private DataGridViewTextBoxColumn clmSuzuvchi;
        private DataGridViewTextBoxColumn clmpH;
        private DataGridViewTextBoxColumn clmO2;
        private DataGridViewTextBoxColumn clmTuyingan;
        private DataGridViewTextBoxColumn clmCO2;
        private DataGridViewTextBoxColumn clmQattiqlik;
        private DataGridViewTextBoxColumn clmXlorid;
        private DataGridViewTextBoxColumn clmSulfat;
        private DataGridViewTextBoxColumn clmGidroKarbanat;
        private DataGridViewTextBoxColumn clmNa;
        private DataGridViewTextBoxColumn clmK;
        private DataGridViewTextBoxColumn clmCa;
        private DataGridViewTextBoxColumn clmMg;
        private DataGridViewTextBoxColumn clmMineral;
        private DataGridViewTextBoxColumn clmXPK;
        private DataGridViewTextBoxColumn clmBPK;
        private DataGridViewTextBoxColumn clmAzotAmonniy;
        private DataGridViewTextBoxColumn clmAzotNitritniy;
        private DataGridViewTextBoxColumn clmAzotNitratniy;
        private DataGridViewTextBoxColumn clmAzotSumma;
        private DataGridViewTextBoxColumn clmFosfat;
        private DataGridViewTextBoxColumn clmSi;
        private DataGridViewTextBoxColumn clmElektr;
        private DataGridViewTextBoxColumn clmEh_MB;
        private DataGridViewTextBoxColumn clmPumumiy;
        private DataGridViewTextBoxColumn clmFeUmumiy;
        private DataGridViewTextBoxColumn clmCi;
        private DataGridViewTextBoxColumn clmZn;
        private DataGridViewTextBoxColumn clmNi;
        private DataGridViewTextBoxColumn clmCr;
        private DataGridViewTextBoxColumn clmCr_VI;
        private DataGridViewTextBoxColumn clmCr_III;
        private DataGridViewTextBoxColumn clmPb;
        private DataGridViewTextBoxColumn clmHg;
        private DataGridViewTextBoxColumn clmCd;
        private DataGridViewTextBoxColumn clmMn;
        private DataGridViewTextBoxColumn clmAs;
        private DataGridViewTextBoxColumn clmFenollar;
        private DataGridViewTextBoxColumn clmNeft;
        private DataGridViewTextBoxColumn clmSPAB;
        private DataGridViewTextBoxColumn clmF;
        private DataGridViewTextBoxColumn clmSianidi;
        private DataGridViewTextBoxColumn clmProponil;
        private DataGridViewTextBoxColumn clmDDE;
        private DataGridViewTextBoxColumn clmRogor;
        private DataGridViewTextBoxColumn clmDDT;
        private DataGridViewTextBoxColumn clmGeksaxloran;
        private DataGridViewTextBoxColumn clmLindan;
        private DataGridViewTextBoxColumn clmDDD;
        private DataGridViewTextBoxColumn clmMetafos;
        private DataGridViewTextBoxColumn clmButifos;
        private DataGridViewTextBoxColumn clmDalapon;
        private DataGridViewTextBoxColumn clmKarbofos;
        private DataGridViewTextBoxColumn clmStatus;
        private ToolStripMenuItem mnServesItemCopyDb;
        private ToolStripMenuItem tmnuServesChangePassword;
        private ToolStripMenuItem mnItemHisobotPDKDolyax;
        private ToolStripMenuItem mnItemHisobotPDKBasyn;
        private ToolStripMenuItem пДКпоБассейнамРекВДоляхToolStripMenuItem;
        private ToolStripMenuItem отчётПоКомпанентамиToolStripMenuItem;
    }
}

