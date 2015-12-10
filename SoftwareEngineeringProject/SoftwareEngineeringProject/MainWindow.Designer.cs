namespace SoftwareEngineeringProject
{
    partial class MainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelPlayer3 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.buttonPlayCard = new System.Windows.Forms.Button();
            this.buttonDrawCard = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBoxCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.labelPlayer3);
            this.splitContainer1.Panel1.Controls.Add(this.labelPlayer2);
            this.splitContainer1.Panel1.Controls.Add(this.labelPlayer1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxMap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxCard);
            this.splitContainer1.Panel2.Controls.Add(this.buttonPlayCard);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDrawCard);
            this.splitContainer1.Panel2.Controls.Add(this.buttonTest);
            this.splitContainer1.Panel2.Controls.Add(this.buttonMove);
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(870, 387);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelPlayer3
            // 
            this.labelPlayer3.AutoSize = true;
            this.labelPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer3.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer3.Location = new System.Drawing.Point(816, 1434);
            this.labelPlayer3.Name = "labelPlayer3";
            this.labelPlayer3.Size = new System.Drawing.Size(100, 33);
            this.labelPlayer3.TabIndex = 3;
            this.labelPlayer3.Text = "Player3";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer2.Location = new System.Drawing.Point(816, 1390);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(100, 33);
            this.labelPlayer2.TabIndex = 2;
            this.labelPlayer2.Text = "Player2";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer1.Location = new System.Drawing.Point(816, 1344);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(100, 33);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player1";
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Image = global::SoftwareEngineeringProject.Properties.Resources.CSULBMap3;
            this.pictureBoxMap.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(1670, 2000);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            // 
            // buttonPlayCard
            // 
            this.buttonPlayCard.Location = new System.Drawing.Point(3, 61);
            this.buttonPlayCard.Name = "buttonPlayCard";
            this.buttonPlayCard.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayCard.TabIndex = 4;
            this.buttonPlayCard.Text = "Play Card";
            this.buttonPlayCard.UseVisualStyleBackColor = true;
            this.buttonPlayCard.Click += new System.EventHandler(this.buttonPlayCard_Click);
            // 
            // buttonDrawCard
            // 
            this.buttonDrawCard.Location = new System.Drawing.Point(3, 3);
            this.buttonDrawCard.Name = "buttonDrawCard";
            this.buttonDrawCard.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawCard.TabIndex = 3;
            this.buttonDrawCard.Text = "Draw Card";
            this.buttonDrawCard.UseVisualStyleBackColor = true;
            this.buttonDrawCard.Click += new System.EventHandler(this.buttonDrawCard_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(422, 32);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(3, 32);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 1;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 90);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(129, 30);
            this.listBox1.TabIndex = 0;
            // 
            // pictureBoxCard
            // 
            this.pictureBoxCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBoxCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCard.Location = new System.Drawing.Point(160, 3);
            this.pictureBoxCard.Name = "pictureBoxCard";
            this.pictureBoxCard.Size = new System.Drawing.Size(109, 119);
            this.pictureBoxCard.TabIndex = 5;
            this.pictureBoxCard.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 387);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelPlayer3;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonPlayCard;
        private System.Windows.Forms.Button buttonDrawCard;
        private System.Windows.Forms.PictureBox pictureBoxCard;
    }
}