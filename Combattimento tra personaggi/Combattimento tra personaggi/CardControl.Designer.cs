namespace Combattimento_tra_personaggi
{
    partial class CardControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_front = new System.Windows.Forms.Panel();
            this.btt_attack = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_infocard = new System.Windows.Forms.Label();
            this.pnl_front.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_front
            // 
            this.pnl_front.AutoSize = true;
            this.pnl_front.BackColor = System.Drawing.Color.GhostWhite;
            this.pnl_front.Controls.Add(this.btt_attack);
            this.pnl_front.Controls.Add(this.lbl_Title);
            this.pnl_front.Controls.Add(this.lbl_infocard);
            this.pnl_front.Location = new System.Drawing.Point(3, 3);
            this.pnl_front.Name = "pnl_front";
            this.pnl_front.Size = new System.Drawing.Size(144, 217);
            this.pnl_front.TabIndex = 0;
            // 
            // btt_attack
            // 
            this.btt_attack.Location = new System.Drawing.Point(33, 191);
            this.btt_attack.Name = "btt_attack";
            this.btt_attack.Size = new System.Drawing.Size(75, 23);
            this.btt_attack.TabIndex = 2;
            this.btt_attack.Text = "Attack";
            this.btt_attack.UseVisualStyleBackColor = true;
            this.btt_attack.Click += new System.EventHandler(this.btt_attack_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Location = new System.Drawing.Point(3, 10);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(138, 33);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Title";
            this.lbl_Title.Click += new System.EventHandler(this.lbl_Title_Click);
            // 
            // lbl_infocard
            // 
            this.lbl_infocard.Location = new System.Drawing.Point(3, 53);
            this.lbl_infocard.Name = "lbl_infocard";
            this.lbl_infocard.Size = new System.Drawing.Size(138, 135);
            this.lbl_infocard.TabIndex = 0;
            this.lbl_infocard.Text = "Infocard";
            // 
            // CardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkViolet;
            this.Controls.Add(this.pnl_front);
            this.Name = "CardControl";
            this.Size = new System.Drawing.Size(150, 220);
            this.Load += new System.EventHandler(this.CardControl_Load);
            this.pnl_front.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_front;
        private System.Windows.Forms.Label lbl_infocard;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btt_attack;
    }
}
