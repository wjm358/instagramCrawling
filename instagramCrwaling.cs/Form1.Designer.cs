namespace instagramCrwaling.cs
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.fileNameTextbox = new System.Windows.Forms.TextBox();
            this.fileOpenButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addMacroButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.inputUrlTextbox = new System.Windows.Forms.RichTextBox();
            this.urlClearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sleepEndTextBox = new System.Windows.Forms.TextBox();
            this.sleepStartTextBox = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.yAbsLocTextBox = new System.Windows.Forms.TextBox();
            this.xAbsLocTextBox = new System.Windows.Forms.TextBox();
            this.mouseDetectStopButton = new System.Windows.Forms.Button();
            this.mouseDetectStartButton = new System.Windows.Forms.Button();
            this.mouseEventComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.xAbsLocLabel = new System.Windows.Forms.Label();
            this.yAbsLocLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.replyFileNameTextBox = new System.Windows.Forms.TextBox();
            this.replyFileOpenButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.macroListClearButton = new System.Windows.Forms.Button();
            this.macroListTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.processStopButton = new System.Windows.Forms.Button();
            this.processStartButton = new System.Windows.Forms.Button();
            this.reportTextBox = new System.Windows.Forms.TextBox();
            this.currentMacroLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.browserXSizeTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.browserYSizeTextbox = new System.Windows.Forms.TextBox();
            this.browserSizeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(9, 172);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(474, 476);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "아이디";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "비밀번호";
            this.Column2.Name = "Column2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.fileNameTextbox);
            this.groupBox1.Controls.Add(this.fileOpenButton);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(19, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(491, 657);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "아이디목록";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(9, 150);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(430, 18);
            this.label18.TabIndex = 4;
            this.label18.Text = "텍스트파일 저장할 때 인코딩을 유니코드로 할 것";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(7, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(272, 72);
            this.label12.TabIndex = 3;
            this.label12.Text = "메모장 형식\r\nex )\r\nID1(공백)PASSWORD1(다음줄)\r\nID2(공백)PASSWORD2(다음줄)";
            // 
            // fileNameTextbox
            // 
            this.fileNameTextbox.Font = new System.Drawing.Font("Gulim", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileNameTextbox.Location = new System.Drawing.Point(156, 28);
            this.fileNameTextbox.Name = "fileNameTextbox";
            this.fileNameTextbox.Size = new System.Drawing.Size(325, 33);
            this.fileNameTextbox.TabIndex = 2;
            // 
            // fileOpenButton
            // 
            this.fileOpenButton.Location = new System.Drawing.Point(9, 28);
            this.fileOpenButton.Name = "fileOpenButton";
            this.fileOpenButton.Size = new System.Drawing.Size(141, 34);
            this.fileOpenButton.TabIndex = 1;
            this.fileOpenButton.Text = "파일 열기";
            this.fileOpenButton.UseVisualStyleBackColor = true;
            this.fileOpenButton.Click += new System.EventHandler(this.fileOpenButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.CausesValidation = false;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.addMacroButton);
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(521, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1189, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매크로 입력";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1023, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addMacroButton
            // 
            this.addMacroButton.Location = new System.Drawing.Point(1027, 68);
            this.addMacroButton.Name = "addMacroButton";
            this.addMacroButton.Size = new System.Drawing.Size(157, 100);
            this.addMacroButton.TabIndex = 0;
            this.addMacroButton.Text = "▶작업 목록 추가";
            this.addMacroButton.UseVisualStyleBackColor = true;
            this.addMacroButton.Click += new System.EventHandler(this.addMacroButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Location = new System.Drawing.Point(16, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(999, 165);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(991, 133);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "접속방식";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(553, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(127, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Mobile 버전";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(67, 51);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "PC 버전";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.inputUrlTextbox);
            this.tabPage2.Controls.Add(this.urlClearButton);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(991, 133);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "URL접속 또는 이동";
            // 
            // inputUrlTextbox
            // 
            this.inputUrlTextbox.Location = new System.Drawing.Point(104, 8);
            this.inputUrlTextbox.Name = "inputUrlTextbox";
            this.inputUrlTextbox.Size = new System.Drawing.Size(763, 110);
            this.inputUrlTextbox.TabIndex = 3;
            this.inputUrlTextbox.Text = "https://m.naver.com";
            // 
            // urlClearButton
            // 
            this.urlClearButton.Location = new System.Drawing.Point(874, 14);
            this.urlClearButton.Name = "urlClearButton";
            this.urlClearButton.Size = new System.Drawing.Size(107, 38);
            this.urlClearButton.TabIndex = 2;
            this.urlClearButton.Text = "초기화";
            this.urlClearButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "URL 입력 :";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(991, 133);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "검색기록삭제";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(991, 133);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "로그인";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(991, 133);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "로그인 버튼 클릭";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage7.Controls.Add(this.label7);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.sleepEndTextBox);
            this.tabPage7.Controls.Add(this.sleepStartTextBox);
            this.tabPage7.Location = new System.Drawing.Point(4, 28);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(991, 133);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "체류시간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "초(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "~";
            // 
            // sleepEndTextBox
            // 
            this.sleepEndTextBox.Location = new System.Drawing.Point(159, 44);
            this.sleepEndTextBox.Name = "sleepEndTextBox";
            this.sleepEndTextBox.Size = new System.Drawing.Size(100, 28);
            this.sleepEndTextBox.TabIndex = 1;
            this.sleepEndTextBox.Text = "10";
            // 
            // sleepStartTextBox
            // 
            this.sleepStartTextBox.Location = new System.Drawing.Point(26, 44);
            this.sleepStartTextBox.Name = "sleepStartTextBox";
            this.sleepStartTextBox.Size = new System.Drawing.Size(100, 28);
            this.sleepStartTextBox.TabIndex = 0;
            this.sleepStartTextBox.Text = "3";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage8.Controls.Add(this.yAbsLocTextBox);
            this.tabPage8.Controls.Add(this.xAbsLocTextBox);
            this.tabPage8.Controls.Add(this.mouseDetectStopButton);
            this.tabPage8.Controls.Add(this.mouseDetectStartButton);
            this.tabPage8.Controls.Add(this.mouseEventComboBox);
            this.tabPage8.Controls.Add(this.label13);
            this.tabPage8.Controls.Add(this.xAbsLocLabel);
            this.tabPage8.Controls.Add(this.yAbsLocLabel);
            this.tabPage8.Controls.Add(this.label10);
            this.tabPage8.Controls.Add(this.label9);
            this.tabPage8.Controls.Add(this.label8);
            this.tabPage8.Location = new System.Drawing.Point(4, 28);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(991, 133);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "마우스 이벤트";
            // 
            // yAbsLocTextBox
            // 
            this.yAbsLocTextBox.Location = new System.Drawing.Point(519, 64);
            this.yAbsLocTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.yAbsLocTextBox.Name = "yAbsLocTextBox";
            this.yAbsLocTextBox.Size = new System.Drawing.Size(71, 28);
            this.yAbsLocTextBox.TabIndex = 10;
            // 
            // xAbsLocTextBox
            // 
            this.xAbsLocTextBox.Location = new System.Drawing.Point(519, 20);
            this.xAbsLocTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.xAbsLocTextBox.Name = "xAbsLocTextBox";
            this.xAbsLocTextBox.Size = new System.Drawing.Size(70, 28);
            this.xAbsLocTextBox.TabIndex = 9;
            // 
            // mouseDetectStopButton
            // 
            this.mouseDetectStopButton.Location = new System.Drawing.Point(284, 78);
            this.mouseDetectStopButton.Margin = new System.Windows.Forms.Padding(4);
            this.mouseDetectStopButton.Name = "mouseDetectStopButton";
            this.mouseDetectStopButton.Size = new System.Drawing.Size(139, 34);
            this.mouseDetectStopButton.TabIndex = 8;
            this.mouseDetectStopButton.Text = "좌표감지종료";
            this.mouseDetectStopButton.UseVisualStyleBackColor = true;
            this.mouseDetectStopButton.Click += new System.EventHandler(this.mouseDetectStop);
            // 
            // mouseDetectStartButton
            // 
            this.mouseDetectStartButton.Location = new System.Drawing.Point(136, 78);
            this.mouseDetectStartButton.Margin = new System.Windows.Forms.Padding(4);
            this.mouseDetectStartButton.Name = "mouseDetectStartButton";
            this.mouseDetectStartButton.Size = new System.Drawing.Size(139, 34);
            this.mouseDetectStartButton.TabIndex = 7;
            this.mouseDetectStartButton.Text = "좌표감지시작";
            this.mouseDetectStartButton.UseVisualStyleBackColor = true;
            this.mouseDetectStartButton.Click += new System.EventHandler(this.mouseDetectStart);
            // 
            // mouseEventComboBox
            // 
            this.mouseEventComboBox.FormattingEnabled = true;
            this.mouseEventComboBox.Items.AddRange(new object[] {
            "왼쪽버튼 클릭",
            "왼쪽버튼 더블클릭",
            "오른쪽버튼 클릭",
            "오른쪽버튼 더블클릭"});
            this.mouseEventComboBox.Location = new System.Drawing.Point(136, 39);
            this.mouseEventComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.mouseEventComboBox.Name = "mouseEventComboBox";
            this.mouseEventComboBox.Size = new System.Drawing.Size(285, 26);
            this.mouseEventComboBox.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(647, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 18);
            this.label13.TabIndex = 5;
            this.label13.Text = "실시간 좌표";
            // 
            // xAbsLocLabel
            // 
            this.xAbsLocLabel.AutoSize = true;
            this.xAbsLocLabel.Location = new System.Drawing.Point(647, 51);
            this.xAbsLocLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xAbsLocLabel.Name = "xAbsLocLabel";
            this.xAbsLocLabel.Size = new System.Drawing.Size(64, 18);
            this.xAbsLocLabel.TabIndex = 4;
            this.xAbsLocLabel.Text = "X좌표=";
            // 
            // yAbsLocLabel
            // 
            this.yAbsLocLabel.AutoSize = true;
            this.yAbsLocLabel.Location = new System.Drawing.Point(647, 78);
            this.yAbsLocLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yAbsLocLabel.Name = "yAbsLocLabel";
            this.yAbsLocLabel.Size = new System.Drawing.Size(64, 18);
            this.yAbsLocLabel.TabIndex = 3;
            this.yAbsLocLabel.Text = "Y좌표=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(443, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "X좌표=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(443, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Y좌표=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "이벤트 선택 :";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage6.Location = new System.Drawing.Point(4, 28);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(991, 133);
            this.tabPage6.TabIndex = 8;
            this.tabPage6.Text = "좋아요";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage9.Location = new System.Drawing.Point(4, 28);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(991, 133);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Text = "팔로우";
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage10.Controls.Add(this.label6);
            this.tabPage10.Controls.Add(this.replyFileNameTextBox);
            this.tabPage10.Controls.Add(this.replyFileOpenButton);
            this.tabPage10.Location = new System.Drawing.Point(4, 28);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(991, 133);
            this.tabPage10.TabIndex = 10;
            this.tabPage10.Text = "댓글달기";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(509, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(404, 108);
            this.label6.TabIndex = 2;
            this.label6.Text = "메모장 형식\r\nex )\r\n댓글1(다음줄)\r\n댓글2(다음줄)\r\n\r\n텍스트파일 저장할 때 인코딩 유니코드로 설정";
            // 
            // replyFileNameTextBox
            // 
            this.replyFileNameTextBox.Location = new System.Drawing.Point(113, 51);
            this.replyFileNameTextBox.Name = "replyFileNameTextBox";
            this.replyFileNameTextBox.Size = new System.Drawing.Size(390, 28);
            this.replyFileNameTextBox.TabIndex = 1;
            // 
            // replyFileOpenButton
            // 
            this.replyFileOpenButton.Location = new System.Drawing.Point(3, 48);
            this.replyFileOpenButton.Name = "replyFileOpenButton";
            this.replyFileOpenButton.Size = new System.Drawing.Size(104, 31);
            this.replyFileOpenButton.TabIndex = 0;
            this.replyFileOpenButton.Text = "파일 열기";
            this.replyFileOpenButton.UseVisualStyleBackColor = true;
            this.replyFileOpenButton.Click += new System.EventHandler(this.replyFileOpenButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.macroListClearButton);
            this.groupBox3.Controls.Add(this.macroListTextBox);
            this.groupBox3.Location = new System.Drawing.Point(521, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1189, 190);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "작업 목록";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(1021, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 18);
            this.label11.TabIndex = 3;
            this.label11.Text = "총 명령어 개수 : \r\n";
            // 
            // macroListClearButton
            // 
            this.macroListClearButton.Location = new System.Drawing.Point(1027, 105);
            this.macroListClearButton.Name = "macroListClearButton";
            this.macroListClearButton.Size = new System.Drawing.Size(157, 33);
            this.macroListClearButton.TabIndex = 1;
            this.macroListClearButton.Text = "작업 초기화";
            this.macroListClearButton.UseVisualStyleBackColor = true;
            this.macroListClearButton.Click += new System.EventHandler(this.macroListClearButton_Click);
            // 
            // macroListTextBox
            // 
            this.macroListTextBox.Location = new System.Drawing.Point(16, 27);
            this.macroListTextBox.Multiline = true;
            this.macroListTextBox.Name = "macroListTextBox";
            this.macroListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.macroListTextBox.Size = new System.Drawing.Size(998, 151);
            this.macroListTextBox.TabIndex = 0;
            this.macroListTextBox.Text = resources.GetString("macroListTextBox.Text");
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox4.Controls.Add(this.processStopButton);
            this.groupBox4.Controls.Add(this.processStartButton);
            this.groupBox4.Controls.Add(this.reportTextBox);
            this.groupBox4.Location = new System.Drawing.Point(521, 436);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1189, 190);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "보고서(Report)";
            // 
            // processStopButton
            // 
            this.processStopButton.Location = new System.Drawing.Point(1026, 108);
            this.processStopButton.Name = "processStopButton";
            this.processStopButton.Size = new System.Drawing.Size(156, 30);
            this.processStopButton.TabIndex = 2;
            this.processStopButton.Text = "작업중단";
            this.processStopButton.UseVisualStyleBackColor = true;
            this.processStopButton.Click += new System.EventHandler(this.processStopButton_Click);
            // 
            // processStartButton
            // 
            this.processStartButton.Location = new System.Drawing.Point(1026, 70);
            this.processStartButton.Name = "processStartButton";
            this.processStartButton.Size = new System.Drawing.Size(157, 32);
            this.processStartButton.TabIndex = 1;
            this.processStartButton.Text = "작업시작";
            this.processStartButton.UseVisualStyleBackColor = true;
            this.processStartButton.Click += new System.EventHandler(this.processStartButton_Click);
            // 
            // reportTextBox
            // 
            this.reportTextBox.BackColor = System.Drawing.Color.Black;
            this.reportTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.reportTextBox.Location = new System.Drawing.Point(13, 27);
            this.reportTextBox.Multiline = true;
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportTextBox.Size = new System.Drawing.Size(1000, 156);
            this.reportTextBox.TabIndex = 0;
            // 
            // currentMacroLabel
            // 
            this.currentMacroLabel.AutoSize = true;
            this.currentMacroLabel.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentMacroLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.currentMacroLabel.Location = new System.Drawing.Point(519, 648);
            this.currentMacroLabel.Name = "currentMacroLabel";
            this.currentMacroLabel.Size = new System.Drawing.Size(150, 18);
            this.currentMacroLabel.TabIndex = 5;
            this.currentMacroLabel.Text = "현재 진행 명령 :";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(521, 688);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1190, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "브라우저 크기 설정 :";
            // 
            // browserXSizeTextbox
            // 
            this.browserXSizeTextbox.Location = new System.Drawing.Point(896, 14);
            this.browserXSizeTextbox.Name = "browserXSizeTextbox";
            this.browserXSizeTextbox.Size = new System.Drawing.Size(64, 28);
            this.browserXSizeTextbox.TabIndex = 7;
            this.browserXSizeTextbox.Text = "800";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(967, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "X";
            // 
            // browserYSizeTextbox
            // 
            this.browserYSizeTextbox.Location = new System.Drawing.Point(991, 14);
            this.browserYSizeTextbox.Name = "browserYSizeTextbox";
            this.browserYSizeTextbox.Size = new System.Drawing.Size(64, 28);
            this.browserYSizeTextbox.TabIndex = 10;
            this.browserYSizeTextbox.Text = "600";
            // 
            // browserSizeButton
            // 
            this.browserSizeButton.Location = new System.Drawing.Point(1063, 12);
            this.browserSizeButton.Name = "browserSizeButton";
            this.browserSizeButton.Size = new System.Drawing.Size(83, 33);
            this.browserSizeButton.TabIndex = 11;
            this.browserSizeButton.Text = "적용";
            this.browserSizeButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1297, 630);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(427, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "작업시작전에 꼭 파일 등록해놓고 실행할 것\r\n\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1153, 12);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 28);
            this.textBox1.TabIndex = 12;
            this.textBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1802, 757);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.browserYSizeTextbox);
            this.Controls.Add(this.browserSizeButton);
            this.Controls.Add(this.browserXSizeTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.currentMacroLabel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "인스타그램 크롤링";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addMacroButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox inputUrlTextbox;
        private System.Windows.Forms.Button urlClearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sleepEndTextBox;
        private System.Windows.Forms.TextBox sleepStartTextBox;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox yAbsLocTextBox;
        private System.Windows.Forms.TextBox xAbsLocTextBox;
        private System.Windows.Forms.Button mouseDetectStopButton;
        private System.Windows.Forms.Button mouseDetectStartButton;
        private System.Windows.Forms.ComboBox mouseEventComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label xAbsLocLabel;
        private System.Windows.Forms.Label yAbsLocLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button macroListClearButton;
        private System.Windows.Forms.TextBox macroListTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button processStopButton;
        private System.Windows.Forms.Button processStartButton;
        private System.Windows.Forms.TextBox reportTextBox;
        private System.Windows.Forms.Label currentMacroLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox fileNameTextbox;
        private System.Windows.Forms.Button fileOpenButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox browserXSizeTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox browserYSizeTextbox;
        private System.Windows.Forms.Button browserSizeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox replyFileNameTextBox;
        private System.Windows.Forms.Button replyFileOpenButton;
        private System.Windows.Forms.Label label6;
    }
}

