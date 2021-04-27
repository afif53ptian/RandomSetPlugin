namespace ExamplePacketPlugin
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.btnRandomAll = new System.Windows.Forms.Button();
            this.tbAr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCo = new System.Windows.Forms.TextBox();
            this.tbWeapon = new System.Windows.Forms.TextBox();
            this.tbHe = new System.Windows.Forms.TextBox();
            this.tbBa = new System.Windows.Forms.TextBox();
            this.tbPe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbArLock = new System.Windows.Forms.CheckBox();
            this.cbCoLock = new System.Windows.Forms.CheckBox();
            this.cbWeapLock = new System.Windows.Forms.CheckBox();
            this.cbHeLock = new System.Windows.Forms.CheckBox();
            this.cbBaLock = new System.Windows.Forms.CheckBox();
            this.cbPeLock = new System.Windows.Forms.CheckBox();
            this.tbTextLogs = new System.Windows.Forms.TextBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbIndexLog = new System.Windows.Forms.Label();
            this.lbIndexLog2 = new System.Windows.Forms.Label();
            this.lbIndexLog3 = new System.Windows.Forms.Label();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.lbSetIndex = new System.Windows.Forms.Label();
            this.btnMoveToInv = new System.Windows.Forms.Button();
            this.lbInvStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(13, 12);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(59, 17);
            this.cbEnable.TabIndex = 0;
            this.cbEnable.Text = "Enable";
            this.cbEnable.UseVisualStyleBackColor = true;
            this.cbEnable.CheckedChanged += new System.EventHandler(this.cbEnable_CheckedChanged);
            // 
            // btnRandomAll
            // 
            this.btnRandomAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRandomAll.Location = new System.Drawing.Point(13, 357);
            this.btnRandomAll.Name = "btnRandomAll";
            this.btnRandomAll.Size = new System.Drawing.Size(134, 23);
            this.btnRandomAll.TabIndex = 1;
            this.btnRandomAll.Text = "Randomize";
            this.btnRandomAll.UseVisualStyleBackColor = true;
            this.btnRandomAll.Click += new System.EventHandler(this.btnRandomAll_Click);
            // 
            // tbAr
            // 
            this.tbAr.Location = new System.Drawing.Point(66, 40);
            this.tbAr.Name = "tbAr";
            this.tbAr.ReadOnly = true;
            this.tbAr.Size = new System.Drawing.Size(166, 20);
            this.tbAr.TabIndex = 2;
            this.tbAr.Text = "(Class Armor)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Class:";
            // 
            // tbCo
            // 
            this.tbCo.Location = new System.Drawing.Point(66, 67);
            this.tbCo.Name = "tbCo";
            this.tbCo.ReadOnly = true;
            this.tbCo.Size = new System.Drawing.Size(166, 20);
            this.tbCo.TabIndex = 4;
            this.tbCo.Text = "(Armor)";
            // 
            // tbWeapon
            // 
            this.tbWeapon.Location = new System.Drawing.Point(66, 94);
            this.tbWeapon.Name = "tbWeapon";
            this.tbWeapon.ReadOnly = true;
            this.tbWeapon.Size = new System.Drawing.Size(166, 20);
            this.tbWeapon.TabIndex = 5;
            this.tbWeapon.Text = "(Weapon)";
            // 
            // tbHe
            // 
            this.tbHe.Location = new System.Drawing.Point(66, 121);
            this.tbHe.Name = "tbHe";
            this.tbHe.ReadOnly = true;
            this.tbHe.Size = new System.Drawing.Size(166, 20);
            this.tbHe.TabIndex = 6;
            this.tbHe.Text = "(Helm)";
            // 
            // tbBa
            // 
            this.tbBa.Location = new System.Drawing.Point(66, 148);
            this.tbBa.Name = "tbBa";
            this.tbBa.ReadOnly = true;
            this.tbBa.Size = new System.Drawing.Size(166, 20);
            this.tbBa.TabIndex = 7;
            this.tbBa.Text = "(Cape)";
            // 
            // tbPe
            // 
            this.tbPe.Location = new System.Drawing.Point(66, 175);
            this.tbPe.Name = "tbPe";
            this.tbPe.ReadOnly = true;
            this.tbPe.Size = new System.Drawing.Size(166, 20);
            this.tbPe.TabIndex = 8;
            this.tbPe.Text = "(Pet)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Armor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Weapon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Helm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cape:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pet:";
            // 
            // cbArLock
            // 
            this.cbArLock.AutoSize = true;
            this.cbArLock.Location = new System.Drawing.Point(238, 42);
            this.cbArLock.Name = "cbArLock";
            this.cbArLock.Size = new System.Drawing.Size(50, 17);
            this.cbArLock.TabIndex = 14;
            this.cbArLock.Text = "Lock";
            this.cbArLock.UseVisualStyleBackColor = true;
            // 
            // cbCoLock
            // 
            this.cbCoLock.AutoSize = true;
            this.cbCoLock.Location = new System.Drawing.Point(238, 69);
            this.cbCoLock.Name = "cbCoLock";
            this.cbCoLock.Size = new System.Drawing.Size(50, 17);
            this.cbCoLock.TabIndex = 15;
            this.cbCoLock.Text = "Lock";
            this.cbCoLock.UseVisualStyleBackColor = true;
            // 
            // cbWeapLock
            // 
            this.cbWeapLock.AutoSize = true;
            this.cbWeapLock.Location = new System.Drawing.Point(238, 96);
            this.cbWeapLock.Name = "cbWeapLock";
            this.cbWeapLock.Size = new System.Drawing.Size(50, 17);
            this.cbWeapLock.TabIndex = 16;
            this.cbWeapLock.Text = "Lock";
            this.cbWeapLock.UseVisualStyleBackColor = true;
            // 
            // cbHeLock
            // 
            this.cbHeLock.AutoSize = true;
            this.cbHeLock.Location = new System.Drawing.Point(238, 123);
            this.cbHeLock.Name = "cbHeLock";
            this.cbHeLock.Size = new System.Drawing.Size(50, 17);
            this.cbHeLock.TabIndex = 17;
            this.cbHeLock.Text = "Lock";
            this.cbHeLock.UseVisualStyleBackColor = true;
            // 
            // cbBaLock
            // 
            this.cbBaLock.AutoSize = true;
            this.cbBaLock.Location = new System.Drawing.Point(238, 150);
            this.cbBaLock.Name = "cbBaLock";
            this.cbBaLock.Size = new System.Drawing.Size(50, 17);
            this.cbBaLock.TabIndex = 18;
            this.cbBaLock.Text = "Lock";
            this.cbBaLock.UseVisualStyleBackColor = true;
            // 
            // cbPeLock
            // 
            this.cbPeLock.AutoSize = true;
            this.cbPeLock.Location = new System.Drawing.Point(238, 177);
            this.cbPeLock.Name = "cbPeLock";
            this.cbPeLock.Size = new System.Drawing.Size(50, 17);
            this.cbPeLock.TabIndex = 19;
            this.cbPeLock.Text = "Lock";
            this.cbPeLock.UseVisualStyleBackColor = true;
            // 
            // tbTextLogs
            // 
            this.tbTextLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTextLogs.Location = new System.Drawing.Point(13, 201);
            this.tbTextLogs.Multiline = true;
            this.tbTextLogs.Name = "tbTextLogs";
            this.tbTextLogs.ReadOnly = true;
            this.tbTextLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTextLogs.Size = new System.Drawing.Size(275, 150);
            this.tbTextLogs.TabIndex = 20;
            this.tbTextLogs.Text = "Text Logs";
            this.tbTextLogs.TextChanged += new System.EventHandler(this.tbTextLogs_TextChanged);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearLogs.Location = new System.Drawing.Point(155, 357);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(134, 23);
            this.btnClearLogs.TabIndex = 21;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(213, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbIndexLog
            // 
            this.lbIndexLog.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbIndexLog.Location = new System.Drawing.Point(10, 419);
            this.lbIndexLog.Name = "lbIndexLog";
            this.lbIndexLog.Size = new System.Drawing.Size(279, 17);
            this.lbIndexLog.TabIndex = 23;
            this.lbIndexLog.Text = "(Listed: Inventory 0% + Bank 0% = 0 Items)";
            this.lbIndexLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIndexLog2
            // 
            this.lbIndexLog2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbIndexLog2.Location = new System.Drawing.Point(10, 436);
            this.lbIndexLog2.Name = "lbIndexLog2";
            this.lbIndexLog2.Size = new System.Drawing.Size(278, 17);
            this.lbIndexLog2.TabIndex = 24;
            this.lbIndexLog2.Text = "(Ar: 0, We: 0, He: 0, Ca: 0, Pe: 0)";
            this.lbIndexLog2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIndexLog3
            // 
            this.lbIndexLog3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbIndexLog3.Location = new System.Drawing.Point(10, 453);
            this.lbIndexLog3.Name = "lbIndexLog3";
            this.lbIndexLog3.Size = new System.Drawing.Size(279, 18);
            this.lbIndexLog3.TabIndex = 25;
            this.lbIndexLog3.Text = "You can generate 0 possible sets!";
            this.lbIndexLog3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackward
            // 
            this.btnBackward.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBackward.Location = new System.Drawing.Point(13, 387);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(48, 23);
            this.btnBackward.TabIndex = 26;
            this.btnBackward.Text = "<";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnForward.Location = new System.Drawing.Point(99, 387);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(48, 23);
            this.btnForward.TabIndex = 27;
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // lbSetIndex
            // 
            this.lbSetIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbSetIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetIndex.Location = new System.Drawing.Point(61, 387);
            this.lbSetIndex.Name = "lbSetIndex";
            this.lbSetIndex.Size = new System.Drawing.Size(36, 23);
            this.lbSetIndex.TabIndex = 28;
            this.lbSetIndex.Text = "(0)";
            this.lbSetIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMoveToInv
            // 
            this.btnMoveToInv.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMoveToInv.Location = new System.Drawing.Point(155, 387);
            this.btnMoveToInv.Name = "btnMoveToInv";
            this.btnMoveToInv.Size = new System.Drawing.Size(133, 23);
            this.btnMoveToInv.TabIndex = 29;
            this.btnMoveToInv.Text = "Move To Inv";
            this.btnMoveToInv.UseVisualStyleBackColor = true;
            this.btnMoveToInv.Click += new System.EventHandler(this.btnMoveToInv_Click);
            // 
            // lbInvStatus
            // 
            this.lbInvStatus.Location = new System.Drawing.Point(78, 13);
            this.lbInvStatus.Name = "lbInvStatus";
            this.lbInvStatus.Size = new System.Drawing.Size(129, 16);
            this.lbInvStatus.TabIndex = 30;
            this.lbInvStatus.Text = "(Inventory: 0/0)";
            this.lbInvStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 480);
            this.Controls.Add(this.lbInvStatus);
            this.Controls.Add(this.btnMoveToInv);
            this.Controls.Add(this.lbSetIndex);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.lbIndexLog3);
            this.Controls.Add(this.lbIndexLog2);
            this.Controls.Add(this.lbIndexLog);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.tbTextLogs);
            this.Controls.Add(this.cbPeLock);
            this.Controls.Add(this.cbBaLock);
            this.Controls.Add(this.cbHeLock);
            this.Controls.Add(this.cbWeapLock);
            this.Controls.Add(this.cbCoLock);
            this.Controls.Add(this.cbArLock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPe);
            this.Controls.Add(this.tbBa);
            this.Controls.Add(this.tbHe);
            this.Controls.Add(this.tbWeapon);
            this.Controls.Add(this.tbCo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAr);
            this.Controls.Add(this.btnRandomAll);
            this.Controls.Add(this.cbEnable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Set Randomizer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.Button btnRandomAll;
        private System.Windows.Forms.TextBox tbAr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCo;
        private System.Windows.Forms.TextBox tbWeapon;
        private System.Windows.Forms.TextBox tbHe;
        private System.Windows.Forms.TextBox tbBa;
        private System.Windows.Forms.TextBox tbPe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbArLock;
        private System.Windows.Forms.CheckBox cbCoLock;
        private System.Windows.Forms.CheckBox cbWeapLock;
        private System.Windows.Forms.CheckBox cbHeLock;
        private System.Windows.Forms.CheckBox cbBaLock;
        private System.Windows.Forms.CheckBox cbPeLock;
        private System.Windows.Forms.TextBox tbTextLogs;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbIndexLog;
        private System.Windows.Forms.Label lbIndexLog2;
        private System.Windows.Forms.Label lbIndexLog3;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Label lbSetIndex;
        private System.Windows.Forms.Button btnMoveToInv;
        private System.Windows.Forms.Label lbInvStatus;
    }
}