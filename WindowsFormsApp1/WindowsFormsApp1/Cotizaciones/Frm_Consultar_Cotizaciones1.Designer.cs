﻿namespace WindowsFormsApp1.Cotizaciones
{
    partial class Frm_Consultar_Cotizaciones1
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_clientes = new System.Windows.Forms.DataGridView();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cuit = new System.Windows.Forms.TextBox();
            this.chk_todos = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Razon_Social = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nro = new System.Windows.Forms.TextBox();
            this.btn_ver = new System.Windows.Forms.Button();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ch_fecha = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(353, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 54);
            this.label1.TabIndex = 7;
            this.label1.Text = "Consultar Cotizaciones";
            // 
            // dgv_clientes
            // 
            this.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clientes.Location = new System.Drawing.Point(479, 108);
            this.dgv_clientes.Name = "dgv_clientes";
            this.dgv_clientes.RowTemplate.Height = 24;
            this.dgv_clientes.Size = new System.Drawing.Size(663, 412);
            this.dgv_clientes.TabIndex = 8;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(25, 417);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(433, 46);
            this.btn_buscar.TabIndex = 4;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "C.U.I.T:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_cuit
            // 
            this.txt_cuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cuit.Location = new System.Drawing.Point(189, 108);
            this.txt_cuit.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cuit.Multiline = true;
            this.txt_cuit.Name = "txt_cuit";
            this.txt_cuit.Size = new System.Drawing.Size(269, 46);
            this.txt_cuit.TabIndex = 0;
            this.txt_cuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.solo_numeros);
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_todos.Location = new System.Drawing.Point(348, 341);
            this.chk_todos.Margin = new System.Windows.Forms.Padding(4);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(110, 33);
            this.chk_todos.TabIndex = 3;
            this.chk_todos.Text = "Todos";
            this.chk_todos.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Razon Social:";
            // 
            // txt_Razon_Social
            // 
            this.txt_Razon_Social.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Razon_Social.Location = new System.Drawing.Point(189, 162);
            this.txt_Razon_Social.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Razon_Social.Multiline = true;
            this.txt_Razon_Social.Name = "txt_Razon_Social";
            this.txt_Razon_Social.Size = new System.Drawing.Size(269, 46);
            this.txt_Razon_Social.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nro Cotización:";
            // 
            // txt_nro
            // 
            this.txt_nro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nro.Location = new System.Drawing.Point(189, 216);
            this.txt_nro.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nro.Multiline = true;
            this.txt_nro.Name = "txt_nro";
            this.txt_nro.Size = new System.Drawing.Size(269, 46);
            this.txt_nro.TabIndex = 2;
            this.txt_nro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.solo_numeros);
            // 
            // btn_ver
            // 
            this.btn_ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ver.Location = new System.Drawing.Point(25, 471);
            this.btn_ver.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(433, 46);
            this.btn_ver.TabIndex = 26;
            this.btn_ver.Text = "Ver";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(189, 278);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(200, 30);
            this.dtp_fecha.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 278);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fecha Desde:";
            // 
            // ch_fecha
            // 
            this.ch_fecha.AutoSize = true;
            this.ch_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_fecha.Location = new System.Drawing.Point(189, 341);
            this.ch_fecha.Margin = new System.Windows.Forms.Padding(4);
            this.ch_fecha.Name = "ch_fecha";
            this.ch_fecha.Size = new System.Drawing.Size(107, 33);
            this.ch_fecha.TabIndex = 29;
            this.ch_fecha.Text = "Fecha";
            this.ch_fecha.UseVisualStyleBackColor = true;
            // 
            // Frm_Consultar_Cotizaciones1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1184, 538);
            this.Controls.Add(this.ch_fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nro);
            this.Controls.Add(this.chk_todos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Razon_Social);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_cuit);
            this.Controls.Add(this.dgv_clientes);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Consultar_Cotizaciones1";
            this.Text = "Consultar Cotizaciones";
            this.Load += new System.EventHandler(this.Frm_Consultar_Cotizaciones1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_clientes;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cuit;
        private System.Windows.Forms.CheckBox chk_todos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Razon_Social;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nro;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ch_fecha;
    }
}