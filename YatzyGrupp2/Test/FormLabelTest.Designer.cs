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
            this.lblRound = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EndGame
            // 
            this.EndGame.Font = new System.Drawing.Font("Times New Roman", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndGame.Location = new System.Drawing.Point(532, 579);
            this.EndGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EndGame.Name = "EndGame";
            this.EndGame.Size = new System.Drawing.Size(138, 29);
            this.EndGame.TabIndex = 1;
            this.EndGame.Text = "Spara spel";
            this.EndGame.UseVisualStyleBackColor = true;
            this.EndGame.Click += new System.EventHandler(this.EndGame_Click);
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.BackColor = System.Drawing.Color.Transparent;
            this.lblSpelare.Font = new System.Drawing.Font("Times New Roman", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(601, 31);
            this.lblSpelare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(213, 51);
            this.lblSpelare.TabIndex = 2;
            this.lblSpelare.Text = "Nu spelar: ";
            // 
            // ThrowDices
            // 
            this.ThrowDices.BackColor = System.Drawing.Color.White;
            this.ThrowDices.Font = new System.Drawing.Font("Times New Roman", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThrowDices.Location = new System.Drawing.Point(793, 471);
            this.ThrowDices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ThrowDices.Name = "ThrowDices";
            this.ThrowDices.Size = new System.Drawing.Size(140, 29);
            this.ThrowDices.TabIndex = 3;
            this.ThrowDices.Text = "Kasta Tärningar";
            this.ThrowDices.UseVisualStyleBackColor = false;
            this.ThrowDices.Click += new System.EventHandler(this.ThrowDices_Click);
            // 
            // Dice1
            // 
            this.Dice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice1.Location = new System.Drawing.Point(793, 522);
            this.Dice1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dice1.Name = "Dice1";
            this.Dice1.Size = new System.Drawing.Size(58, 58);
            this.Dice1.TabIndex = 4;
            this.Dice1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice1_MouseDown);
            // 
            // Dice2
            // 
            this.Dice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice2.Location = new System.Drawing.Point(855, 522);
            this.Dice2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dice2.Name = "Dice2";
            this.Dice2.Size = new System.Drawing.Size(58, 58);
            this.Dice2.TabIndex = 5;
            this.Dice2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice2_MouseDown);
            // 
            // Dice3
            // 
            this.Dice3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice3.Location = new System.Drawing.Point(917, 522);
            this.Dice3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dice3.Name = "Dice3";
            this.Dice3.Size = new System.Drawing.Size(58, 58);
            this.Dice3.TabIndex = 6;
            this.Dice3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice3_MouseDown);
            // 
            // Dice4
            // 
            this.Dice4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice4.Location = new System.Drawing.Point(979, 522);
            this.Dice4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dice4.Name = "Dice4";
            this.Dice4.Size = new System.Drawing.Size(58, 58);
            this.Dice4.TabIndex = 7;
            this.Dice4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice4_MouseDown);
            // 
            // Dice5
            // 
            this.Dice5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dice5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.Dice5.Location = new System.Drawing.Point(1041, 522);
            this.Dice5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dice5.Name = "Dice5";
            this.Dice5.Size = new System.Drawing.Size(58, 58);
            this.Dice5.TabIndex = 8;
            this.Dice5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Dice5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dice5_MouseDown);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label7.Location = new System.Drawing.Point(9, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(518, 75);
            this.label7.TabIndex = 9;
            this.label7.Text = "YATZY Klubben";
            // 
            // btnNextPlayer
            // 
            this.btnNextPlayer.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPlayer.Location = new System.Drawing.Point(959, 471);
            this.btnNextPlayer.Name = "btnNextPlayer";
            this.btnNextPlayer.Size = new System.Drawing.Size(140, 30);
            this.btnNextPlayer.TabIndex = 10;
            this.btnNextPlayer.Text = "Nästa spelare";
            this.btnNextPlayer.UseVisualStyleBackColor = true;
            this.btnNextPlayer.Click += new System.EventHandler(this.BtnNextPlayer_Click);
            // 
            // lblThrows
            // 
            this.lblThrows.AutoSize = true;
            this.lblThrows.Location = new System.Drawing.Point(607, 137);
            this.lblThrows.Name = "lblThrows";
            this.lblThrows.Size = new System.Drawing.Size(0, 13);
            this.lblThrows.TabIndex = 11;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblRound.Location = new System.Drawing.Point(606, 97);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(141, 20);
            this.lblRound.TabIndex = 12;
            this.lblRound.Text = "Du ska satsa på: ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(775, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Regler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(988, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 29);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Avsluta Spel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormLabelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1113, 614);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblRound);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLabelTest";
            this.Text = "FormLabelTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLabelTest_FormClosing);
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
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
    }
}