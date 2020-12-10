namespace WindowsFormsApp1.Frm_reportes
{
    partial class Frm_NotaCotizacion
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
            this.notaCreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datos_Nota_Cotizacion = new WindowsFormsApp1.Datos_Reportes.Datos_Nota_Cotizacion();
            this.detalleNCBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.totalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rp_NC = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Detalle_NCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalleNCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.notaCreditoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos_Nota_Cotizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleNCBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detalle_NCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleNCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // notaCreditoBindingSource
            // 
            this.notaCreditoBindingSource.DataMember = "NotaCredito";
            this.notaCreditoBindingSource.DataSource = this.datos_Nota_Cotizacion;
            // 
            // datos_Nota_Cotizacion
            // 
            this.datos_Nota_Cotizacion.DataSetName = "Datos_Nota_Cotizacion";
            this.datos_Nota_Cotizacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // detalleNCBindingSource1
            // 
            this.detalleNCBindingSource1.DataMember = "Detalle_NC";
            this.detalleNCBindingSource1.DataSource = this.datos_Nota_Cotizacion;
            // 
            // totalBindingSource
            // 
            this.totalBindingSource.DataMember = "Total";
            this.totalBindingSource.DataSource = this.datos_Nota_Cotizacion;
            // 
            // rp_NC
            // 
            this.rp_NC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rp_NC.AutoSize = true;
            reportDataSource1.Name = "Datos_NC";
            reportDataSource1.Value = this.notaCreditoBindingSource;
            reportDataSource2.Name = "Datos_detalle";
            reportDataSource2.Value = this.detalleNCBindingSource1;
            reportDataSource3.Name = "Datos_total";
            reportDataSource3.Value = this.totalBindingSource;
            this.rp_NC.LocalReport.DataSources.Add(reportDataSource1);
            this.rp_NC.LocalReport.DataSources.Add(reportDataSource2);
            this.rp_NC.LocalReport.DataSources.Add(reportDataSource3);
            this.rp_NC.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Cotizaciones.nota_Cotizacion.rdlc";
            this.rp_NC.Location = new System.Drawing.Point(77, -4);
            this.rp_NC.Name = "rp_NC";
            this.rp_NC.ServerReport.BearerToken = null;
            this.rp_NC.Size = new System.Drawing.Size(1005, 750);
            this.rp_NC.TabIndex = 0;
            // 
            // Detalle_NCBindingSource
            // 
            this.Detalle_NCBindingSource.DataMember = "Detalle_NC";
            this.Detalle_NCBindingSource.DataSource = this.datos_Nota_Cotizacion;
            // 
            // detalleNCBindingSource
            // 
            this.detalleNCBindingSource.DataMember = "Detalle_NC";
            this.detalleNCBindingSource.DataSource = this.datos_Nota_Cotizacion;
            // 
            // Frm_NotaCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 736);
            this.Controls.Add(this.rp_NC);
            this.Name = "Frm_NotaCotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota Cotización";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_NotaCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notaCreditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos_Nota_Cotizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleNCBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detalle_NCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleNCBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rp_NC;
        private System.Windows.Forms.BindingSource notaCreditoBindingSource;
        private Datos_Reportes.Datos_Nota_Cotizacion datos_Nota_Cotizacion;
        private System.Windows.Forms.BindingSource detalleNCBindingSource;
        private System.Windows.Forms.BindingSource totalBindingSource;
        private System.Windows.Forms.BindingSource Detalle_NCBindingSource;
        private System.Windows.Forms.BindingSource detalleNCBindingSource1;
    }
}