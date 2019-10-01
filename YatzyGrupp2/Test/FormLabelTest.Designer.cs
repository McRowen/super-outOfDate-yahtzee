﻿namespace YatzyGrupp2.Test
{
    partial class FormLabelTest
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
            this.EndGame = new System.Windows.Forms.Button();
            this.lblSpelare = new System.Windows.Forms.Label();
            this.ThrowDices = new System.Windows.Forms.Button();
            this.Dice1 = new System.Windows.Forms.Label();
            this.Dice2 = new System.Windows.Forms.Label();
            this.Dice3 = new System.Windows.Forms.Label();
            this.Dice4 = new System.Windows.Forms.Label();
            this.Dice5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNextPlayer = new System.Windows.Forms.Button();
            this.lblThrows = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EndGame
            // 
            this.EndGame.Font = new System.Drawing.Font("Times New Roman", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndGame.Location = new System.Drawing.Point(1064, 1114);
            this.EndGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EndGame.Name = "EndGame";
            this.EndGame.Size = new System.Drawing.Size(276, 56);
            this.EndGame.TabIndex = 1;
            this.EndGame.Text = "Avsluta Spel";
            this.EndGame.UseVisualStyleBackColor = true;
            this.EndGame.Click += new System.EventHandler(this.EndGame_Click);
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.BackColor = System.Drawing.Color.Transparent;
            this.lblSpelare.Font = new System.Drawing.Font("Times New Roman", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(1194, 214);
            this.lblSpelare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(427, 100);
            this.lblSpelare.TabIndex = 2;
            this.lblSpelare.Text = "Nu spelar: ";
            // 
            // ThrowDices
            // 
            this.ThrowDices.BackColor = System.Drawing.Color.White;
            this.ThrowDices.Font = new System.Drawing.Font("Times New Roman", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThrowDices.Location = new System.Drawing.Point(1546, 523);
            this.ThrowDices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ThrowDices.Name = "ThrowDices";
            this.ThrowDices.Size = new System.Drawing.Size(280, 56);
            this.ThrowDices.TabIndex = 3;
            this.ThrowDices.Text = "Kasta Tärningar";
            this.ThrowDices.UseVisualStyleBackColor = false;
            this.ThrowDices.Click += new System.EventHandler(this.ThrowDices_Click);
            // 
            // Dice1
            // 
            this.Dice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice1.Location = new System.Drawing.Point(1212, 372);
            this.Dice1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dice1.Name = "Dice1";
            this.Dice1.Size = new System.Drawing.Size(114, 110);
            this.Dice1.TabIndex = 4;
            this.Dice1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice1.Click += new System.EventHandler(this.Dice1_Click);
            this.Dice1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice1_MouseDown);
            // 
            // Dice2
            // 
            this.Dice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice2.Location = new System.Drawing.Point(1336, 372);
            this.Dice2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dice2.Name = "Dice2";
            this.Dice2.Size = new System.Drawing.Size(114, 110);
            this.Dice2.TabIndex = 5;
            this.Dice2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice2_MouseDown);
            // 
            // Dice3
            // 
            this.Dice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice3.Location = new System.Drawing.Point(1462, 372);
            this.Dice3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dice3.Name = "Dice3";
            this.Dice3.Size = new System.Drawing.Size(114, 110);
            this.Dice3.TabIndex = 6;
            this.Dice3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice3_MouseDown);
            // 
            // Dice4
            // 
            this.Dice4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice4.Location = new System.Drawing.Point(1586, 372);
            this.Dice4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dice4.Name = "Dice4";
            this.Dice4.Size = new System.Drawing.Size(114, 110);
            this.Dice4.TabIndex = 7;
            this.Dice4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice4_MouseDown);
            // 
            // Dice5
            // 
            this.Dice5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice5.Location = new System.Drawing.Point(1710, 372);
            this.Dice5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Dice5.Name = "Dice5";
            this.Dice5.Size = new System.Drawing.Size(114, 110);
            this.Dice5.TabIndex = 8;
            this.Dice5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice5_MouseDown);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label7.Location = new System.Drawing.Point(18, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1035, 144);
            this.label7.TabIndex = 9;
            this.label7.Text = "YATZY Klubben";
            // 
            // btnNextPlayer
            // 
            this.btnNextPlayer.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPlayer.Location = new System.Drawing.Point(1546, 641);
            this.btnNextPlayer.Margin = new System.Windows.Forms.Padding(6);
            this.btnNextPlayer.Name = "btnNextPlayer";
            this.btnNextPlayer.Size = new System.Drawing.Size(280, 58);
            this.btnNextPlayer.TabIndex = 10;
            this.btnNextPlayer.Text = "Nästa spelare";
            this.btnNextPlayer.UseVisualStyleBackColor = true;
            this.btnNextPlayer.Click += new System.EventHandler(this.BtnNextPlayer_Click);
            // 
            // lblThrows
            // 
            this.lblThrows.AutoSize = true;
            this.lblThrows.Location = new System.Drawing.Point(1912, 372);
            this.lblThrows.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblThrows.Name = "lblThrows";
            this.lblThrows.Size = new System.Drawing.Size(0, 25);
            this.lblThrows.TabIndex = 11;
            // 
            // FormLabelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2226, 1191);
            this.Controls.Add(this.lblThrows);
            this.Controls.Add(this.btnNextPlayer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Dice5);
            this.Controls.Add(this.Dice4);
            this.Controls.Add(this.Dice3);
            this.Controls.Add(this.Dice2);
            this.Controls.Add(this.Dice1);
            this.Controls.Add(this.ThrowDices);
            this.Controls.Add(this.lblSpelare);
            this.Controls.Add(this.EndGame);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormLabelTest";
            this.Text = "FormLabelTest";
            this.Load += new System.EventHandler(this.FormLabelTest_Load);
            this.MouseEnter += new System.EventHandler(this.label_Enter);
            this.MouseLeave += new System.EventHandler(this.label_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EndGame;
        private System.Windows.Forms.Label lblSpelare;
        private System.Windows.Forms.Button ThrowDices;
        private System.Windows.Forms.Label Dice1;
        private System.Windows.Forms.Label Dice2;
        private System.Windows.Forms.Label Dice3;
        private System.Windows.Forms.Label Dice4;
        private System.Windows.Forms.Label Dice5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNextPlayer;
        private System.Windows.Forms.Label lblThrows;
    }
}