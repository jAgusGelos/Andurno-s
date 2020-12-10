namespace WindowsFormsApp1.Remitos
{
    partial class Frm_VerRemito
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.clienteBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Remito = new WindowsFormsApp1.Remitos.Datos_Remito();
            this.remitoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rp_rem = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Remito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remitoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detaleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clienteBindingSource1
            // 
            this.clienteBindingSource1.DataMember = "Cliente";
            this.clienteBindingSource1.DataSource = this.Datos_Remito;
            // 
            // Datos_Remito
            // 
            this.Datos_Remito.DataSetName = "Datos_Remito";
            this.Datos_Remito.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // remitoBindingSource
            // 
            this.remitoBindingSource.DataMember = "Remito";
            this.remitoBindingSource.DataSource = this.Datos_Remito;
            // 
            // detaleBindingSource
            // 
            this.detaleBindingSource.DataMember = "Detale";
            this.detaleBindingSource.DataSource = this.Datos_Remito;
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataMember = "Cliente";
            this.ClienteBindingSource.DataSource = this.Datos_Remito;
            // 
            // rp_rem
            // 
            this.rp_rem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            reportDataSource1.Name = "Cliente";
            reportDataSource1.Value = this.clienteBindingSource1;
            reportDataSource2.Name = "Remito";
            reportDataSource2.Value = this.remitoBindingSource;
            reportDataSource3.Name = "Detalle";
            reportDataSource3.Value = this.detaleBindingSource;
            this.rp_rem.LocalReport.DataSources.Add(reportDataSource1);
            this.rp_rem.LocalReport.DataSources.Add(reportDataSource2);
            this.rp_rem.LocalReport.DataSources.Add(reportDataSource3);
            this.rp_rem.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Remitos.Remito_reporte.rdlc";
            this.rp_rem.Location = new System.Drawing.Point(95, -3);
            this.rp_rem.Name = "rp_rem";
            this.rp_rem.ServerReport.BearerToken = null;
            this.rp_rem.Size = new System.Drawing.Size(988, 756);
            this.rp_rem.TabIndex = 0;
            // 
            // Frm_VerRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 751);
            this.Controls.Add(this.rp_rem);
            this.Name = "Frm_VerRemito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "N ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_VerRemito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Remito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remitoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detaleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rp_rem;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
        private Datos_Remito Datos_Remito;
        private System.Windows.Forms.BindingSource clienteBindingSource1;
        private System.Windows.Forms.BindingSource remitoBindingSource;
        private System.Windows.Forms.BindingSource detaleBindingSource;
    }
}