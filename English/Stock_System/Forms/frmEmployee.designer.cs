namespace Stock_System.Forms
{
    partial class frmEmployee
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
            this.btnRest = new Telerik.WinControls.UI.RadButton();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btnSearchProduct = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNIDNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtCurrentAddress = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTINNo = new System.Windows.Forms.TextBox();
            this.txtMobile1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGurantorPerson = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JoiningDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Photo = new System.Windows.Forms.DataGridViewImageColumn();
            this.EmpPhoto = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBrows = new Telerik.WinControls.UI.RadButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpPhoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrows)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRest
            // 
            this.btnRest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRest.ForeColor = System.Drawing.Color.White;
            this.btnRest.Location = new System.Drawing.Point(466, 368);
            this.btnRest.Name = "btnRest";
            // 
            // 
            // 
            this.btnRest.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnRest.Size = new System.Drawing.Size(132, 62);
            this.btnRest.TabIndex = 187;
            this.btnRest.Text = "Rest";
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRest.GetChildAt(0))).Text = "Rest";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnRest.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnRest.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnRest.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnRest.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(168, 175);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(436, 39);
            this.cmbGender.TabIndex = 3;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(905, 236);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 20);
            this.label34.TabIndex = 191;
            this.label34.Text = "Position";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.Location = new System.Drawing.Point(318, 368);
            this.btnSearchProduct.Name = "btnSearchProduct";
            // 
            // 
            // 
            this.btnSearchProduct.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.Size = new System.Drawing.Size(132, 62);
            this.btnSearchProduct.TabIndex = 186;
            this.btnSearchProduct.Text = "Search";
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearchProduct.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearchProduct.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearchProduct.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearchProduct.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearchProduct.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(170, 368);
            this.btnSave.Name = "btnSave";
            // 
            // 
            // 
            this.btnSave.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(132, 62);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).ClipDrawing = false;
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(168, 43);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(436, 38);
            this.txtFullName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 188;
            this.label7.Text = "Full Name";
            // 
            // txtFatherName
            // 
            this.txtFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(168, 87);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(436, 38);
            this.txtFatherName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 193;
            this.label1.Text = "Father Name";
            // 
            // txtNIDNo
            // 
            this.txtNIDNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIDNo.Location = new System.Drawing.Point(168, 131);
            this.txtNIDNo.Name = "txtNIDNo";
            this.txtNIDNo.Size = new System.Drawing.Size(436, 38);
            this.txtNIDNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 195;
            this.label2.Text = "Tazkira ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 197;
            this.label3.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 199;
            this.label4.Text = "Date of Birth";
            // 
            // dtDob
            // 
            this.dtDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDob.Location = new System.Drawing.Point(168, 220);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(436, 38);
            this.dtDob.TabIndex = 4;
            // 
            // txtPosition
            // 
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(1067, 227);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(436, 38);
            this.txtPosition.TabIndex = 11;
            // 
            // txtCurrentAddress
            // 
            this.txtCurrentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentAddress.Location = new System.Drawing.Point(168, 264);
            this.txtCurrentAddress.Multiline = true;
            this.txtCurrentAddress.Name = "txtCurrentAddress";
            this.txtCurrentAddress.Size = new System.Drawing.Size(436, 54);
            this.txtCurrentAddress.TabIndex = 5;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.Location = new System.Drawing.Point(41, 285);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(68, 20);
            this.Address.TabIndex = 202;
            this.Address.Text = "Address";
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalary.Location = new System.Drawing.Point(1067, 319);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(436, 38);
            this.txtSalary.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(905, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 205;
            this.label5.Text = "Salary";
            // 
            // dtJoiningDate
            // 
            this.dtJoiningDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtJoiningDate.Location = new System.Drawing.Point(1067, 273);
            this.dtJoiningDate.Name = "dtJoiningDate";
            this.dtJoiningDate.Size = new System.Drawing.Size(436, 38);
            this.dtJoiningDate.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(907, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 206;
            this.label6.Text = "Joining Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(905, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 209;
            this.label8.Text = "TIN#";
            // 
            // txtTINNo
            // 
            this.txtTINNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTINNo.Location = new System.Drawing.Point(1067, 181);
            this.txtTINNo.Name = "txtTINNo";
            this.txtTINNo.Size = new System.Drawing.Size(436, 38);
            this.txtTINNo.TabIndex = 10;
            // 
            // txtMobile1
            // 
            this.txtMobile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile1.Location = new System.Drawing.Point(168, 324);
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Size = new System.Drawing.Size(436, 38);
            this.txtMobile1.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 211;
            this.label9.Text = "Mobile Number";
            // 
            // txtMobile2
            // 
            this.txtMobile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile2.Location = new System.Drawing.Point(1067, 43);
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(436, 38);
            this.txtMobile2.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(905, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 20);
            this.label12.TabIndex = 213;
            this.label12.Text = "Mobile Number 2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1651, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 20);
            this.label19.TabIndex = 214;
            this.label19.Text = "Employee Photo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(7, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(218, 25);
            this.label13.TabIndex = 216;
            this.label13.Text = "Employee Entry Form";
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(1067, 89);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(436, 38);
            this.txtEmail.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(905, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 218;
            this.label10.Text = "e-Mail";
            // 
            // txtGurantorPerson
            // 
            this.txtGurantorPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGurantorPerson.Location = new System.Drawing.Point(1067, 135);
            this.txtGurantorPerson.Name = "txtGurantorPerson";
            this.txtGurantorPerson.Size = new System.Drawing.Size(436, 38);
            this.txtGurantorPerson.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(905, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 220;
            this.label11.Text = "Gurantor Person";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.FullName,
            this.FatherName,
            this.Gender,
            this.DateOfBirth,
            this.cAddress,
            this.Mobile1,
            this.Position,
            this.JoiningDate,
            this.Salary,
            this.Photo});
            this.dataGridView1.Location = new System.Drawing.Point(9, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1890, 398);
            this.dataGridView1.TabIndex = 222;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Width = 130;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 250;
            // 
            // FatherName
            // 
            this.FatherName.DataPropertyName = "FatherName";
            this.FatherName.HeaderText = "Father Name";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            this.FatherName.Width = 250;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "Date Of Birth";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.Width = 130;
            // 
            // cAddress
            // 
            this.cAddress.DataPropertyName = "Address";
            this.cAddress.HeaderText = "Address";
            this.cAddress.Name = "cAddress";
            this.cAddress.ReadOnly = true;
            this.cAddress.Width = 300;
            // 
            // Mobile1
            // 
            this.Mobile1.DataPropertyName = "Mobile1";
            this.Mobile1.HeaderText = "Mobile1";
            this.Mobile1.Name = "Mobile1";
            this.Mobile1.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Width = 200;
            // 
            // JoiningDate
            // 
            this.JoiningDate.DataPropertyName = "JoiningDate";
            this.JoiningDate.HeaderText = "Joining Date";
            this.JoiningDate.Name = "JoiningDate";
            this.JoiningDate.ReadOnly = true;
            this.JoiningDate.Width = 150;
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "Salary";
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            this.Salary.Width = 150;
            // 
            // Photo
            // 
            this.Photo.DataPropertyName = "Photo";
            this.Photo.FillWeight = 120F;
            this.Photo.HeaderText = "Photo";
            this.Photo.Name = "Photo";
            this.Photo.ReadOnly = true;
            this.Photo.Width = 120;
            // 
            // EmpPhoto
            // 
            this.EmpPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmpPhoto.Location = new System.Drawing.Point(1573, 55);
            this.EmpPhoto.Name = "EmpPhoto";
            this.EmpPhoto.Size = new System.Drawing.Size(308, 296);
            this.EmpPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EmpPhoto.TabIndex = 215;
            this.EmpPhoto.TabStop = false;
            this.EmpPhoto.Click += new System.EventHandler(this.EmpPhoto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnBrows);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtGurantorPerson);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnRest);
            this.groupBox1.Controls.Add(this.EmpPhoto);
            this.groupBox1.Controls.Add(this.btnSearchProduct);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbGender);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMobile2);
            this.groupBox1.Controls.Add(this.txtFatherName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMobile1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNIDNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTINNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtJoiningDate);
            this.groupBox1.Controls.Add(this.dtDob);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Address);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCurrentAddress);
            this.groupBox1.Controls.Add(this.txtSalary);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.txtPosition);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1905, 440);
            this.groupBox1.TabIndex = 217;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Information";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Resigned",
            "Terminated"});
            this.cmbStatus.Location = new System.Drawing.Point(1067, 364);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(436, 39);
            this.cmbStatus.TabIndex = 1615;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(907, 377);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 1616;
            this.label14.Text = "Status";
            // 
            // btnBrows
            // 
            this.btnBrows.BackColor = System.Drawing.Color.PaleGreen;
            this.btnBrows.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrows.Location = new System.Drawing.Point(1665, 357);
            this.btnBrows.Name = "btnBrows";
            // 
            // 
            // 
            this.btnBrows.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrows.Size = new System.Drawing.Size(145, 46);
            this.btnBrows.TabIndex = 1614;
            this.btnBrows.Text = "Brows Photo";
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnBrows.GetChildAt(0))).Text = "Brows Photo";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnBrows.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnBrows.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnBrows.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnBrows.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 584);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1905, 455);
            this.groupBox2.TabIndex = 223;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee List";
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpPhoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrows)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnRest;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label34;
        private Telerik.WinControls.UI.RadButton btnSearchProduct;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNIDNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtCurrentAddress;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtJoiningDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTINNo;
        private System.Windows.Forms.TextBox txtMobile1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMobile2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox EmpPhoto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGurantorPerson;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn JoiningDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewImageColumn Photo;
        private Telerik.WinControls.UI.RadButton btnBrows;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label14;
    }
}