
namespace AzureFacePOC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnImageSelect = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.txtWebCamImage = new System.Windows.Forms.TextBox();
            this.btnBrowseCamImage = new System.Windows.Forms.Button();
            this.btnAddFace = new System.Windows.Forms.Button();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblFaceAddProcess = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPersonId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompareResult = new System.Windows.Forms.TextBox();
            this.lblResultProcess = new System.Windows.Forms.Label();
            this.personList = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFaceCustomData = new System.Windows.Forms.TextBox();
            this.btnTrainPersonGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.personList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(258, 481);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(194, 34);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.Text = "Get Customer";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnImageSelect
            // 
            this.btnImageSelect.Location = new System.Drawing.Point(1144, 26);
            this.btnImageSelect.Name = "btnImageSelect";
            this.btnImageSelect.Size = new System.Drawing.Size(161, 34);
            this.btnImageSelect.TabIndex = 1;
            this.btnImageSelect.Text = "Browse";
            this.btnImageSelect.UseVisualStyleBackColor = true;
            this.btnImageSelect.Click += new System.EventHandler(this.btnImageSelect_Click);
            // 
            // txtImage
            // 
            this.txtImage.Enabled = false;
            this.txtImage.Location = new System.Drawing.Point(258, 26);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(880, 31);
            this.txtImage.TabIndex = 2;
            this.txtImage.Text = "Selfie Image...";
            // 
            // txtWebCamImage
            // 
            this.txtWebCamImage.Enabled = false;
            this.txtWebCamImage.Location = new System.Drawing.Point(258, 420);
            this.txtWebCamImage.Name = "txtWebCamImage";
            this.txtWebCamImage.Size = new System.Drawing.Size(854, 31);
            this.txtWebCamImage.TabIndex = 4;
            this.txtWebCamImage.Text = "Webcam Captured Image";
            // 
            // btnBrowseCamImage
            // 
            this.btnBrowseCamImage.Location = new System.Drawing.Point(1118, 419);
            this.btnBrowseCamImage.Name = "btnBrowseCamImage";
            this.btnBrowseCamImage.Size = new System.Drawing.Size(136, 34);
            this.btnBrowseCamImage.TabIndex = 3;
            this.btnBrowseCamImage.Text = "Browse";
            this.btnBrowseCamImage.UseVisualStyleBackColor = true;
            this.btnBrowseCamImage.Click += new System.EventHandler(this.btnBrowseCamImage_Click);
            // 
            // btnAddFace
            // 
            this.btnAddFace.Location = new System.Drawing.Point(258, 170);
            this.btnAddFace.Name = "btnAddFace";
            this.btnAddFace.Size = new System.Drawing.Size(162, 34);
            this.btnAddFace.TabIndex = 6;
            this.btnAddFace.Text = "Register Face";
            this.btnAddFace.UseVisualStyleBackColor = true;
            this.btnAddFace.Click += new System.EventHandler(this.btnAddFace_Click);
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(763, 78);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(220, 31);
            this.txtCustomerId.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Customer Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Webcam Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Selfie Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(258, 78);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(383, 31);
            this.txtCustomerName.TabIndex = 12;
            // 
            // lblFaceAddProcess
            // 
            this.lblFaceAddProcess.AutoSize = true;
            this.lblFaceAddProcess.Location = new System.Drawing.Point(440, 175);
            this.lblFaceAddProcess.Name = "lblFaceAddProcess";
            this.lblFaceAddProcess.Size = new System.Drawing.Size(110, 25);
            this.lblFaceAddProcess.TabIndex = 13;
            this.lblFaceAddProcess.Text = "Adding Face";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Person Id";
            // 
            // txtPersonId
            // 
            this.txtPersonId.Location = new System.Drawing.Point(258, 126);
            this.txtPersonId.Name = "txtPersonId";
            this.txtPersonId.Size = new System.Drawing.Size(383, 31);
            this.txtPersonId.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(647, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(302, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "(Add Multiple Face For Same Person)";
            // 
            // txtCompareResult
            // 
            this.txtCompareResult.Location = new System.Drawing.Point(258, 531);
            this.txtCompareResult.Multiline = true;
            this.txtCompareResult.Name = "txtCompareResult";
            this.txtCompareResult.ReadOnly = true;
            this.txtCompareResult.Size = new System.Drawing.Size(854, 142);
            this.txtCompareResult.TabIndex = 17;
            // 
            // lblResultProcess
            // 
            this.lblResultProcess.AutoSize = true;
            this.lblResultProcess.Location = new System.Drawing.Point(458, 486);
            this.lblResultProcess.Name = "lblResultProcess";
            this.lblResultProcess.Size = new System.Drawing.Size(109, 25);
            this.lblResultProcess.TabIndex = 18;
            this.lblResultProcess.Text = "Processing...";
            // 
            // personList
            // 
            this.personList.AllowUserToAddRows = false;
            this.personList.AllowUserToDeleteRows = false;
            this.personList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personList.Location = new System.Drawing.Point(258, 211);
            this.personList.Name = "personList";
            this.personList.ReadOnly = true;
            this.personList.RowHeadersWidth = 62;
            this.personList.RowTemplate.Height = 33;
            this.personList.Size = new System.Drawing.Size(1129, 172);
            this.personList.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1011, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Face Data";
            // 
            // txtFaceCustomData
            // 
            this.txtFaceCustomData.Location = new System.Drawing.Point(1105, 78);
            this.txtFaceCustomData.Name = "txtFaceCustomData";
            this.txtFaceCustomData.Size = new System.Drawing.Size(220, 31);
            this.txtFaceCustomData.TabIndex = 20;
            // 
            // btnTrainPersonGroup
            // 
            this.btnTrainPersonGroup.Location = new System.Drawing.Point(1178, 170);
            this.btnTrainPersonGroup.Name = "btnTrainPersonGroup";
            this.btnTrainPersonGroup.Size = new System.Drawing.Size(198, 34);
            this.btnTrainPersonGroup.TabIndex = 22;
            this.btnTrainPersonGroup.Text = "Train Person Group";
            this.btnTrainPersonGroup.UseVisualStyleBackColor = true;
            this.btnTrainPersonGroup.Click += new System.EventHandler(this.btnTrainPersonGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1707, 698);
            this.Controls.Add(this.btnTrainPersonGroup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFaceCustomData);
            this.Controls.Add(this.personList);
            this.Controls.Add(this.lblResultProcess);
            this.Controls.Add(this.txtCompareResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPersonId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFaceAddProcess);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnAddFace);
            this.Controls.Add(this.txtWebCamImage);
            this.Controls.Add(this.btnBrowseCamImage);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.btnImageSelect);
            this.Controls.Add(this.btnCompare);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.personList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnImageSelect;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.TextBox txtWebCamImage;
        private System.Windows.Forms.Button btnBrowseCamImage;
        private System.Windows.Forms.Button btnAddFace;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblFaceAddProcess;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPersonId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompareResult;
        private System.Windows.Forms.Label lblResultProcess;
        private System.Windows.Forms.DataGridView personList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFaceCustomData;
        private System.Windows.Forms.Button btnTrainPersonGroup;
    }
}

