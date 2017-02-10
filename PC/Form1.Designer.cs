namespace TEF_Photo_Transfer
{
    partial class formMain
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
      this.label1 = new System.Windows.Forms.Label();
      this.listCameraFolder = new System.Windows.Forms.ListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.textCameraFolder = new System.Windows.Forms.TextBox();
      this.textLocalFolder = new System.Windows.Forms.TextBox();
      this.textRemoteFolder = new System.Windows.Forms.TextBox();
      this.textPartNumber = new System.Windows.Forms.TextBox();
      this.textIndex = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.labelLocalCount = new System.Windows.Forms.Label();
      this.labelRemoteCount = new System.Windows.Forms.Label();
      this.buttonProcess = new System.Windows.Forms.Button();
      this.buttonExit = new System.Windows.Forms.Button();
      this.buttonClear = new System.Windows.Forms.Button();
      this.timerUpdateListbox = new System.Windows.Forms.Timer(this.components);
      this.buttonClear1 = new System.Windows.Forms.Button();
      this.buttonClear4 = new System.Windows.Forms.Button();
      this.buttonClear2 = new System.Windows.Forms.Button();
      this.buttonClear3 = new System.Windows.Forms.Button();
      this.buttonCustomClear = new System.Windows.Forms.Button();
      this.textCustomClear = new System.Windows.Forms.TextBox();
      this.checkBoxNetwork = new System.Windows.Forms.CheckBox();
      this.buttonHTML = new System.Windows.Forms.Button();
      this.timerUpdateFilecount = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(96, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Camera Pic Folder:";
      // 
      // listCameraFolder
      // 
      this.listCameraFolder.FormattingEnabled = true;
      this.listCameraFolder.Location = new System.Drawing.Point(11, 92);
      this.listCameraFolder.Name = "listCameraFolder";
      this.listCameraFolder.Size = new System.Drawing.Size(189, 225);
      this.listCameraFolder.TabIndex = 1;
      this.listCameraFolder.SelectedIndexChanged += new System.EventHandler(this.listCameraFolder_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 36);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(125, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Local Pic Archive Folder:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 59);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(136, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Remote Pic Archive Folder:";
      // 
      // textCameraFolder
      // 
      this.textCameraFolder.Location = new System.Drawing.Point(140, 12);
      this.textCameraFolder.Name = "textCameraFolder";
      this.textCameraFolder.Size = new System.Drawing.Size(418, 20);
      this.textCameraFolder.TabIndex = 4;
      // 
      // textLocalFolder
      // 
      this.textLocalFolder.Location = new System.Drawing.Point(140, 33);
      this.textLocalFolder.Name = "textLocalFolder";
      this.textLocalFolder.Size = new System.Drawing.Size(418, 20);
      this.textLocalFolder.TabIndex = 5;
      // 
      // textRemoteFolder
      // 
      this.textRemoteFolder.Location = new System.Drawing.Point(140, 56);
      this.textRemoteFolder.Name = "textRemoteFolder";
      this.textRemoteFolder.Size = new System.Drawing.Size(418, 20);
      this.textRemoteFolder.TabIndex = 6;
      // 
      // textPartNumber
      // 
      this.textPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textPartNumber.Location = new System.Drawing.Point(207, 151);
      this.textPartNumber.Name = "textPartNumber";
      this.textPartNumber.Size = new System.Drawing.Size(353, 62);
      this.textPartNumber.TabIndex = 7;
      this.textPartNumber.Text = "XXXX.YYY.ZZZ";
      this.textPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // textIndex
      // 
      this.textIndex.Location = new System.Drawing.Point(427, 224);
      this.textIndex.Name = "textIndex";
      this.textIndex.Size = new System.Drawing.Size(37, 20);
      this.textIndex.TabIndex = 8;
      this.textIndex.Text = "1";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(287, 227);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(134, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Starting Index (default = 1):";
      // 
      // labelLocalCount
      // 
      this.labelLocalCount.AutoSize = true;
      this.labelLocalCount.Location = new System.Drawing.Point(564, 36);
      this.labelLocalCount.Name = "labelLocalCount";
      this.labelLocalCount.Size = new System.Drawing.Size(43, 13);
      this.labelLocalCount.TabIndex = 11;
      this.labelLocalCount.Text = "000000";
      // 
      // labelRemoteCount
      // 
      this.labelRemoteCount.AutoSize = true;
      this.labelRemoteCount.Location = new System.Drawing.Point(564, 59);
      this.labelRemoteCount.Name = "labelRemoteCount";
      this.labelRemoteCount.Size = new System.Drawing.Size(43, 13);
      this.labelRemoteCount.TabIndex = 12;
      this.labelRemoteCount.Text = "000000";
      // 
      // buttonProcess
      // 
      this.buttonProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonProcess.Location = new System.Drawing.Point(206, 250);
      this.buttonProcess.Name = "buttonProcess";
      this.buttonProcess.Size = new System.Drawing.Size(353, 67);
      this.buttonProcess.TabIndex = 13;
      this.buttonProcess.Text = "Process Camera Pics";
      this.buttonProcess.UseVisualStyleBackColor = true;
      this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
      // 
      // buttonExit
      // 
      this.buttonExit.Location = new System.Drawing.Point(519, 323);
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.Size = new System.Drawing.Size(88, 33);
      this.buttonExit.TabIndex = 14;
      this.buttonExit.Text = "Exit";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
      // 
      // buttonClear
      // 
      this.buttonClear.Location = new System.Drawing.Point(207, 93);
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.Size = new System.Drawing.Size(75, 23);
      this.buttonClear.TabIndex = 15;
      this.buttonClear.Text = "Clear";
      this.buttonClear.UseVisualStyleBackColor = true;
      this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
      // 
      // timerUpdateListbox
      // 
      this.timerUpdateListbox.Interval = 2000;
      this.timerUpdateListbox.Tick += new System.EventHandler(this.timerUpdateListbox_Tick);
      // 
      // buttonClear1
      // 
      this.buttonClear1.Location = new System.Drawing.Point(207, 122);
      this.buttonClear1.Name = "buttonClear1";
      this.buttonClear1.Size = new System.Drawing.Size(75, 23);
      this.buttonClear1.TabIndex = 16;
      this.buttonClear1.Text = "6002.";
      this.buttonClear1.UseVisualStyleBackColor = true;
      this.buttonClear1.Click += new System.EventHandler(this.buttonClear1_Click);
      // 
      // buttonClear4
      // 
      this.buttonClear4.Location = new System.Drawing.Point(369, 93);
      this.buttonClear4.Name = "buttonClear4";
      this.buttonClear4.Size = new System.Drawing.Size(75, 23);
      this.buttonClear4.TabIndex = 17;
      this.buttonClear4.Text = "F03C.";
      this.buttonClear4.UseVisualStyleBackColor = true;
      this.buttonClear4.Click += new System.EventHandler(this.buttonClear4_Click);
      // 
      // buttonClear2
      // 
      this.buttonClear2.Location = new System.Drawing.Point(288, 93);
      this.buttonClear2.Name = "buttonClear2";
      this.buttonClear2.Size = new System.Drawing.Size(75, 23);
      this.buttonClear2.TabIndex = 18;
      this.buttonClear2.Text = "F00H.";
      this.buttonClear2.UseVisualStyleBackColor = true;
      this.buttonClear2.Click += new System.EventHandler(this.buttonClear2_Click);
      // 
      // buttonClear3
      // 
      this.buttonClear3.Location = new System.Drawing.Point(288, 122);
      this.buttonClear3.Name = "buttonClear3";
      this.buttonClear3.Size = new System.Drawing.Size(75, 23);
      this.buttonClear3.TabIndex = 19;
      this.buttonClear3.Text = "F02F.";
      this.buttonClear3.UseVisualStyleBackColor = true;
      this.buttonClear3.Click += new System.EventHandler(this.buttonClear3_Click);
      // 
      // buttonCustomClear
      // 
      this.buttonCustomClear.Location = new System.Drawing.Point(369, 122);
      this.buttonCustomClear.Name = "buttonCustomClear";
      this.buttonCustomClear.Size = new System.Drawing.Size(75, 23);
      this.buttonCustomClear.TabIndex = 20;
      this.buttonCustomClear.Text = "Custom";
      this.buttonCustomClear.UseVisualStyleBackColor = true;
      this.buttonCustomClear.Click += new System.EventHandler(this.buttonCustomClear_Click);
      // 
      // textCustomClear
      // 
      this.textCustomClear.Location = new System.Drawing.Point(450, 122);
      this.textCustomClear.Name = "textCustomClear";
      this.textCustomClear.Size = new System.Drawing.Size(108, 20);
      this.textCustomClear.TabIndex = 21;
      // 
      // checkBoxNetwork
      // 
      this.checkBoxNetwork.AutoSize = true;
      this.checkBoxNetwork.Location = new System.Drawing.Point(466, 92);
      this.checkBoxNetwork.Name = "checkBoxNetwork";
      this.checkBoxNetwork.Size = new System.Drawing.Size(147, 17);
      this.checkBoxNetwork.TabIndex = 22;
      this.checkBoxNetwork.Text = "Enable Network Activities";
      this.checkBoxNetwork.UseVisualStyleBackColor = true;
      this.checkBoxNetwork.CheckedChanged += new System.EventHandler(this.checkBoxNetwork_CheckedChanged);
      // 
      // buttonHTML
      // 
      this.buttonHTML.Location = new System.Drawing.Point(207, 323);
      this.buttonHTML.Name = "buttonHTML";
      this.buttonHTML.Size = new System.Drawing.Size(116, 33);
      this.buttonHTML.TabIndex = 23;
      this.buttonHTML.Text = "Generate HTML";
      this.buttonHTML.UseVisualStyleBackColor = true;
      this.buttonHTML.Click += new System.EventHandler(this.buttonHTML_Click);
      // 
      // timerUpdateFilecount
      // 
      this.timerUpdateFilecount.Interval = 2000;
      this.timerUpdateFilecount.Tick += new System.EventHandler(this.timerUpdateFilecount_Tick);
      // 
      // formMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(619, 364);
      this.Controls.Add(this.buttonHTML);
      this.Controls.Add(this.checkBoxNetwork);
      this.Controls.Add(this.textCustomClear);
      this.Controls.Add(this.buttonCustomClear);
      this.Controls.Add(this.buttonClear3);
      this.Controls.Add(this.buttonClear2);
      this.Controls.Add(this.buttonClear4);
      this.Controls.Add(this.buttonClear1);
      this.Controls.Add(this.buttonClear);
      this.Controls.Add(this.buttonExit);
      this.Controls.Add(this.buttonProcess);
      this.Controls.Add(this.labelRemoteCount);
      this.Controls.Add(this.labelLocalCount);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.textIndex);
      this.Controls.Add(this.textPartNumber);
      this.Controls.Add(this.textRemoteFolder);
      this.Controls.Add(this.textLocalFolder);
      this.Controls.Add(this.textCameraFolder);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.listCameraFolder);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "formMain";
      this.Text = "TEF Photo Transfer App v0.16";
      this.Load += new System.EventHandler(this.formMain_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listCameraFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCameraFolder;
        private System.Windows.Forms.TextBox textLocalFolder;
        private System.Windows.Forms.TextBox textRemoteFolder;
        private System.Windows.Forms.TextBox textPartNumber;
        private System.Windows.Forms.TextBox textIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLocalCount;
        private System.Windows.Forms.Label labelRemoteCount;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timerUpdateListbox;
        private System.Windows.Forms.Button buttonClear1;
        private System.Windows.Forms.Button buttonClear4;
        private System.Windows.Forms.Button buttonClear2;
        private System.Windows.Forms.Button buttonClear3;
        private System.Windows.Forms.Button buttonCustomClear;
        private System.Windows.Forms.TextBox textCustomClear;
        private System.Windows.Forms.CheckBox checkBoxNetwork;
        private System.Windows.Forms.Button buttonHTML;
        private System.Windows.Forms.Timer timerUpdateFilecount;
    }
}

