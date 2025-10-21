namespace Combattimento_tra_personaggi
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
            this.pnl_AttackingCardArea = new System.Windows.Forms.Panel();
            this.pnl_TargetCardArea = new System.Windows.Forms.Panel();
            this.btt_turn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_AttackingCardArea.SuspendLayout();
            this.pnl_TargetCardArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_AttackingCardArea
            // 
            this.pnl_AttackingCardArea.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_AttackingCardArea.Controls.Add(this.label2);
            this.pnl_AttackingCardArea.Location = new System.Drawing.Point(12, 12);
            this.pnl_AttackingCardArea.Name = "pnl_AttackingCardArea";
            this.pnl_AttackingCardArea.Size = new System.Drawing.Size(200, 300);
            this.pnl_AttackingCardArea.TabIndex = 1;
            // 
            // pnl_TargetCardArea
            // 
            this.pnl_TargetCardArea.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnl_TargetCardArea.Controls.Add(this.label1);
            this.pnl_TargetCardArea.Location = new System.Drawing.Point(218, 12);
            this.pnl_TargetCardArea.Name = "pnl_TargetCardArea";
            this.pnl_TargetCardArea.Size = new System.Drawing.Size(200, 300);
            this.pnl_TargetCardArea.TabIndex = 2;
            // 
            // btt_turn
            // 
            this.btt_turn.Location = new System.Drawing.Point(1350, 740);
            this.btt_turn.Name = "btt_turn";
            this.btt_turn.Size = new System.Drawing.Size(75, 23);
            this.btt_turn.TabIndex = 3;
            this.btt_turn.Text = "Act";
            this.btt_turn.UseVisualStyleBackColor = true;
            this.btt_turn.Click += new System.EventHandler(this.btt_turn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "TARGET";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "ATTACK";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1582, 851);
            this.Controls.Add(this.btt_turn);
            this.Controls.Add(this.pnl_AttackingCardArea);
            this.Controls.Add(this.pnl_TargetCardArea);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Lotta di carte tra personaggi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl_AttackingCardArea.ResumeLayout(false);
            this.pnl_AttackingCardArea.PerformLayout();
            this.pnl_TargetCardArea.ResumeLayout(false);
            this.pnl_TargetCardArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_AttackingCardArea;
        private System.Windows.Forms.Panel pnl_TargetCardArea;
        private System.Windows.Forms.Button btt_turn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

